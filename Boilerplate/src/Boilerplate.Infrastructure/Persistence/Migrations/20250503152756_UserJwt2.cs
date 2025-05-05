using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boilerplate.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserJwt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d4d99b1-6e7b-4ef9-b404-75bc961bceb0"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("9d4d99b1-6e7b-4ef9-b404-75bc961bceb0"), "victor.eiras@gmail.com", "Victor Eiras", "123456", 0 });
        }
    }
}
