using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedCambiosEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAsignacion",
                value: new DateTime(2026, 10, 7, 2, 54, 22, 544, DateTimeKind.Utc).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAsignacion",
                value: new DateTime(2026, 10, 6, 22, 54, 22, 544, DateTimeKind.Utc).AddTicks(5114));

            migrationBuilder.InsertData(
                table: "CambiosEstado",
                columns: new[] { "Id", "EstadoAnterior", "EstadoNuevo", "Fecha", "PedidoId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(2026, 10, 7, 2, 54, 22, 544, DateTimeKind.Utc).AddTicks(5157), 2, 1 },
                    { 2, 0, 1, new DateTime(2026, 10, 6, 22, 54, 22, 544, DateTimeKind.Utc).AddTicks(5157), 3, 1 },
                    { 3, 1, 2, new DateTime(2026, 10, 7, 3, 24, 22, 544, DateTimeKind.Utc).AddTicks(5157), 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 54, 22, 544, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 10, 7, 3, 54, 22, 544, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 2, 54, 22, 544, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 10, 7, 1, 54, 22, 544, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 24, 22, 544, DateTimeKind.Utc).AddTicks(5066), new DateTime(2026, 10, 6, 22, 54, 22, 544, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Ynlh8jkdsOFfG1qBJmojZeLDQDMEe3svonSoCc0mCQXZG7hMxyHda");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$9lxJx32N5BMFyS2aiiu.Zeup5LwmGWJZpxe4sjTd0.MvJOBvGjcYa");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$AK6fS7EAL7PdDCi3O0LOqOIDSLXrNGqpMclpiYjQcG1w9luWHOh.O");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CambiosEstado",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CambiosEstado",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CambiosEstado",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAsignacion",
                value: new DateTime(2026, 10, 7, 2, 53, 49, 595, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAsignacion",
                value: new DateTime(2026, 10, 6, 22, 53, 49, 595, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 53, 49, 595, DateTimeKind.Utc).AddTicks(5483), new DateTime(2026, 10, 7, 3, 53, 49, 595, DateTimeKind.Utc).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 2, 53, 49, 595, DateTimeKind.Utc).AddTicks(5483), new DateTime(2026, 10, 7, 1, 53, 49, 595, DateTimeKind.Utc).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 23, 49, 595, DateTimeKind.Utc).AddTicks(5483), new DateTime(2026, 10, 6, 22, 53, 49, 595, DateTimeKind.Utc).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$DpyE/6WFeD514Fo/hQyNVe1beNTYpA6qBEE2aPziA9aoraNn5iVFq");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$az7ojWuBVxk8ESUg0HRKZuiDeU7QB/M7xBJCfIPirQP1wDbXZNEDm");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$AuO5ThfHItIn3DPpxQJaD.gGR.T8o.UiZr7VMWQUrH4qD9o9gUe/2");
        }
    }
}
