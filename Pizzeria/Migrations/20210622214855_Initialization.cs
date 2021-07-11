using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    PersonType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Pizza Caprichosa", 5.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 2, "Pizza Margarita", 6.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 3, "Pizza Two Cheese", 8.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 4, "Pizza California", 12.99 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 5, "Pizza Montanara", 5.4900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 6, "Pizza al Pesto", 6.4900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 7, "Pizza Francescana", 7.29 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 8, "Pizza Caprese", 10.99 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 9, "Pizza Marinara", 9.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 10, "Pizza Fattoria", 3.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 11, "Pizza Ortolana", 7.9900000000000002 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 12, "Pizza Contadina", 5.5899999999999999 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "Name", "Password", "PersonType", "Surname" },
                values: new object[] { 1, "client@pizzeria", "Taras", "123456", 1, "Kulyavets" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Email", "Name", "Password", "PersonType", "Surname" },
                values: new object[] { 2, "cook@pizzeria", "Sebastian", "123456", 2, "Kachniarz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
