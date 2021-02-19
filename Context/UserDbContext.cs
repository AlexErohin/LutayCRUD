using System;
using System.Collections.Generic;
using System.Linq;
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

            builder.Entity<User>().Property(x => x.FirstName).IsRequired();
            builder.Entity<User>().Property(x => x.LastName).IsRequired();
            builder.Entity<User>().Property(x => x.PhoneNumber).IsRequired();

            builder.Entity<User>()
                .Property(x => x.FavoriteColors)
                .HasConversion<int>();
            builder.Entity<User>()
                .Property(x => x.FavoriteDrinks)
                .HasConversion<int>();

        }
    }
}
