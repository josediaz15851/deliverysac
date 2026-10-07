using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "PasswordHash", "Rol" },
                values: new object[,]
                {
                    { 1, "admin@deliverysac.com", "$2a$11$z6qMivzjwmP.NSgpYQl48uBKpXWXj77Iog5U6hcFr3uZZTCpMXy8O", "Administrador" },
                    { 2, "repartidor@deliverysac.com", "$2a$11$J2ZUsyBB.1xmVXdaGo9AbORy9lfAuLmwxD0FjU37CldDjM4SPtxSq", "Repartidor" },
                    { 3, "supervisor@deliverysac.com", "$2a$11$umG3cOZqiAqo86ejSGETtuNDWy.J0SvjRlPPp2kAxhtDfAKaqpSSO", "Supervisor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
