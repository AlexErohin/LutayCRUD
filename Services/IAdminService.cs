using LutayCRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LutayCRUD.Services
{
    public interface IAdminService
    {
        Task<Admin> Authenticate(string logn, string password);
        Task<List<User>> GetAllUsers();
    }
}
