using System;

namespace LutayCRUD.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public int FavoriteColors { get; set; }
        public int FavoriteDrinks { get; set; }
    }
}
