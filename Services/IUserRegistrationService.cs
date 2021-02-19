using LutayCRUD.Models;
using System.Threading.Tasks;

namespace LutayCRUD.Services
{
    public interface IUserRegistrationService
    {
        bool ValidateUser(User model);
        Task AddUser(User model);
    }
}
