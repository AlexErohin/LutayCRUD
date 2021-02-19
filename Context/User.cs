using System;

namespace LutayCRUD.Context
{
    public class User
    {
        [Flags]
        public enum Color
        {
            Blue = 1<<0,
            Yellow = 1<<1,
            Red = 1<<2,
        }
        [Flags]
        public enum Drink
        {
            Tea = 1<<0,
            Coffee = 1<<1,
            Juice = 1<<2,
            Water = 1<<3,
        }
        
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public Color FavoriteColors { get; set; }
        public Drink FavoriteDrinks { get; set; }
    }
}
