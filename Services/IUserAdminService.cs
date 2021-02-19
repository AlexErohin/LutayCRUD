using LutayCRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LutayCRUD.Services
{
    public interface IUserAdminService
    {
        Task<List<User>> GetAll();
    }
}
