using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Migrations
{
    public partial class OrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "Name", "Password", "PersonType", "Surname" },
                values: new object[] { 1, "client@pizzeria", "Taras", "123456", 1, "Kulyavets" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "Name", "Password", "PersonType", "Surname" },
                values: new object[] { 1, "client@pizzeria", "Taras", "123456", 0, "Kulyavets" });
        }
    }
}
