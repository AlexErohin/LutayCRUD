using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LutayCRUD.Migrations
{
    public partial class UserIdAutogen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0ddfc14b-938c-48a8-bf89-4c55f941760c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ae559bc2-dc4f-4378-83c5-3ea3129c81b7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Users",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Birthday", "FavoriteColors", "FavoriteDrinks", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("89f2c8aa-74c4-464e-a6a4-0daacf1aaf23"), new DateTime(2000, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 8, "Alex", "L", "+15556541122" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Birthday", "FavoriteColors", "FavoriteDrinks", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("5f9c92a6-e002-47e7-af01-7b9c6f41fe67"), new DateTime(1984, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 9, "Xander", "Tay", "+05551237845" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("5f9c92a6-e002-47e7-af01-7b9c6f41fe67"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("89f2c8aa-74c4-464e-a6a4-0daacf1aaf23"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Birthday", "FavoriteColors", "FavoriteDrinks", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("0ddfc14b-938c-48a8-bf89-4c55f941760c"), new DateTime(2000, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 8, "Alex", "L", "+15556541122" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Birthday", "FavoriteColors", "FavoriteDrinks", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("ae559bc2-dc4f-4378-83c5-3ea3129c81b7"), new DateTime(1984, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 9, "Xander", "Tay", "+05551237845" });
        }
    }
}
