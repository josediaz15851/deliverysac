using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "ClienteId", "Descripcion", "Estado", "FechaActualizacion", "FechaCreacion", "Monto" },
                values: new object[,]
                {
                    { 1, 1, "2 cafés cortados + 1 medialunas", 0, new DateTime(2026, 10, 7, 3, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 10, 7, 3, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466), 450.00m },
                    { 2, 2, "Menú completo para 4 personas", 1, new DateTime(2026, 10, 7, 2, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 10, 7, 1, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466), 2500.00m },
                    { 3, 3, "Vitaminas y suplementos varios", 2, new DateTime(2026, 10, 7, 3, 14, 13, 208, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 10, 6, 22, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466), 1800.50m }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$OGdE5LDMkWkcsbeZ7V6ZDO9cBBKDPX7Yo05WFOJMdGJTm8xe8CH0q");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$j96xSkspGqEvuAH1KinjGeNXD9l2FLyjaxL2DNhtmAI6hpwcUxtsa");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$5UrPvFkTNgjQNz.kEHNkVOgOHXCFJn9zFyxeNKhqrnzpAu9jvMrXW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$.rDOskx9u5r7dvHJ2UKIi.8fM2xWKl60Uox051GYxM1oXHoX9QkoS");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$NpyoaqVRRgfNcf.odpjjdeOi0xQHoNw8JEHjkXLq.mDJxRQEg5kVa");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$gFaTaaSLXawG0icsBUNehe3S6evp.ERJUD9GreP9ZuQgBqYp1eRay");
        }
    }
}
