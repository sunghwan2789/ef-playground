using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Sqlite.Migrations
{
    public partial class AddWritePermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Name",
                keyValue: "root",
                column: "Permissions",
                value: "[0,1,2,3,4]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Name",
                keyValue: "root",
                column: "Permissions",
                value: "[0,1,2,3]");
        }
    }
}
