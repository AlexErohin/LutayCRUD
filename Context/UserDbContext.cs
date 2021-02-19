using System;
using LutayCRUD.Common;
using LutayCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace LutayCRUD.Context
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasKey(x => x.UserId);
            builder.Entity<User>()
                .Property(x => x.UserId)
                .HasDefaultValueSql("NEWID()");
            builder.Entity<User>().Property(x => x.FirstName).IsRequired();
            builder.Entity<User>().Property(x => x.LastName).IsRequired();
            builder.Entity<User>().Property(x => x.PhoneNumber).IsRequired();

            builder.Entity<User>()
                .Property(x => x.FavoriteColors)
                .HasConversion<int>();
            builder.Entity<User>()
                .Property(x => x.FavoriteDrinks)
                .HasConversion<int>();
            
            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Alex",
                    LastName = "L",
                    Birthday = new DateTime(2000, 2, 17),
                    PhoneNumber = "+15556541122",
                    FavoriteColors = Color.Red | Color.Yellow, 
                    FavoriteDrinks = Drink.Water
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Xander",
                    LastName = "Tay",
                    Birthday = new DateTime(1984, 12, 31),
                    PhoneNumber = "+05551237845",
                    FavoriteColors = 0,
                    FavoriteDrinks = Drink.Tea | Drink.Water
                });
        }
    }
}
