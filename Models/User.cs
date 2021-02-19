using LutayCRUD.Common;
using System;

namespace LutayCRUD.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public Color FavoriteColors { get; set; }
        public Drink FavoriteDrinks { get; set; }
    }
}
