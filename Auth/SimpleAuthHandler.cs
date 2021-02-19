using LutayCRUD.Models;
using LutayCRUD.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace LutayCRUD.Auth
{
    public class SimpleAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAdminService adminService;

        public SimpleAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAdminService adminService)
            : base(options, logger, encoder, clock)
        {
            this.adminService = adminService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            Admin admin = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var login = credentials[0];
                var password = credentials[1];
                admin = await adminService.Authenticate(login, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (admin == null)
                return AuthenticateResult.Fail("Invalid Login or Password");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, admin.Login),
                new Claim(ClaimTypes.Name, admin.Login),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
