using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Direccion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Calle 1 #100, Centro", "Café Central" },
                    { 2, "Avenida Principal 250, Zona Norte", "Restaurante El Buen Sabor" },
                    { 3, "Calle Secundaria 75, Barrio Sur", "Farmacia Salud Plus" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$XLD26bRbc2nvVHlfqvBRPOA7UElBZdAkd/L.MLLWvtEH2jW7W9x0S");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$18C7OK9FvrVP0OkP7Wmn1u8Jk5tYlSj3tj2ulxkkQktN151KcdFdi");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$WKbwVkdWc7O55FGbHWrWKOXLz1BQaNXGFqwBJmfOQJvwsK52FwFPK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$dgiNYXjWxkFpbuz4LgNG6eUBbKnXVj9RKrm7r/PjIgfuDm1ImPVEO");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$2dIHN0h.64ARsjnPcfAD2OPhJ/bLyLxBK74fneyRB/IfVsysy12Je");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$hINk/Os4BDBNuYgd13WC5O1uh1qJSx4XCex2X.7KzcC55OIlbK8w.");
        }
    }
}
