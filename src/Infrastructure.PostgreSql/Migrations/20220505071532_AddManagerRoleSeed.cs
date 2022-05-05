using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.PostgreSql.Migrations
{
    public partial class AddManagerRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Name", "Permissions" },
                values: new object[] { "manager", new[] { 0, 1, 2, 3 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Name",
                keyValue: "manager");
        }
    }
}
