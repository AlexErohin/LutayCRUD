using LutayCRUD.Context;
using LutayCRUD.Models;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LutayCRUD.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserDbContext context;

        public UserRegistrationService(UserDbContext context)
        {
            this.context = context;
        }

        public bool ValidateUser(User model)
        {
            return model.FirstName != string.Empty &&
                model.LastName != string.Empty &&
                model.PhoneNumber != null &&
                Regex.Match(model.PhoneNumber, @"^(\+[0-9]+)$").Success;
        }
        public async Task AddUser(User model)
        {
            await context.Users.AddAsync(model);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
