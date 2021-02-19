using System.Collections.Generic;
using System.Threading.Tasks;
using LutayCRUD.Context;
using LutayCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace LutayCRUD.Services
{
    public class UserAdminService : IUserAdminService
    {
        private readonly UserDbContext context;

        public UserAdminService(UserDbContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }
    }
}
