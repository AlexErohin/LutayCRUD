using LutayCRUD.Models;
using LutayCRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LutayCRUD.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        IAdminService adminService; 
        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Authenticate([FromBody]Admin model)
        {
            var admin = await adminService.Authenticate(model.Login, model.Password);

            if (admin == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(admin);
        }

        [HttpGet()]
        public async Task<List<User>> GetAllUsers()
        {
            return await adminService.GetAllUsers();
        }
    }
}
