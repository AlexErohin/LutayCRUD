using LutayCRUD.Common;
using LutayCRUD.Context;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserModel = LutayCRUD.Models.User;

namespace LutayCRUD.Services
{
    public class UserRegistrationService
    {
        private readonly UserDbContext context;

        public UserRegistrationService(UserDbContext context)
        {
            this.context = context;
        }

        public bool ValidateUser(UserModel model)
        {
            return model.FirstName != string.Empty &&
                model.LastName != string.Empty &&
                Regex.Match(model.PhoneNumber, @"^(\+[0-9]+)$").Success;
        }
        public async Task AddUser(UserModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Birthday = model.Birthday,
                PhoneNumber = model.PhoneNumber,
                FavoriteColors = (Color)model.FavoriteColors,
                FavoriteDrinks = (Drink)model.FavoriteDrinks
            };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
