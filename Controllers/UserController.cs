using System.Collections.Generic;
using System.Threading.Tasks;
using LutayCRUD.Models;
using LutayCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace LutayCRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        IUserRegistrationService registrationService;
        IUserAdminService adminService;

        public UserController(IUserRegistrationService registrationService,
            IUserAdminService adminService)
        {
            this.registrationService = registrationService;
            this.adminService = adminService;
        }

        [HttpGet()]
        public async Task<List<User>> GetAll()
        {
            return await adminService.GetAll();
        }

        [HttpGet("{user}")]
        public bool Validate(User user)
        {
            return registrationService.ValidateUser(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            if(!registrationService.ValidateUser(user))
            {
                return BadRequest();
            }
            await registrationService.AddUser(user);
            return Accepted();
        }
    }
}
