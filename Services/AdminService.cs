using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LutayCRUD.Context;
using LutayCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace LutayCRUD.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserDbContext context;
        
        private List<Admin> admins = new List<Admin>
        {
            new Admin { Login = "sa", Password = "1234" }
        };
        public AdminService(UserDbContext context)
        {
            this.context = context;
        }

        public async Task<Admin> Authenticate(string login, string password)
        {
            var admin = await Task.Run(() => admins.FirstOrDefault(x => x.Login == login && x.Password == password));
            if (admin == null)
            {
                return admin;
            }
            admin.Password = null;
            return admin;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}
