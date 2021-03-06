﻿// <auto-generated />
using System;
using LutayCRUD.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LutayCRUD.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20210219040749_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LutayCRUD.Context.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Birthday");

                    b.Property<int>("FavoriteColors");

                    b.Property<int>("FavoriteDrinks");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = new Guid("0ddfc14b-938c-48a8-bf89-4c55f941760c"), Birthday = new DateTime(2000, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), FavoriteColors = 6, FavoriteDrinks = 8, FirstName = "Alex", LastName = "L", PhoneNumber = "+15556541122" },
                        new { UserId = new Guid("ae559bc2-dc4f-4378-83c5-3ea3129c81b7"), Birthday = new DateTime(1984, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), FavoriteColors = 0, FavoriteDrinks = 9, FirstName = "Xander", LastName = "Tay", PhoneNumber = "+05551237845" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
