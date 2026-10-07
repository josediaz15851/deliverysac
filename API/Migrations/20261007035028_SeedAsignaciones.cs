using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedAsignaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Asignaciones",
                columns: new[] { "Id", "FechaAsignacion", "FechaEntrega", "PedidoId", "RepartidorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 7, 2, 50, 28, 476, DateTimeKind.Utc).AddTicks(4960), null, 2, 2 },
                    { 2, new DateTime(2026, 10, 6, 22, 50, 28, 476, DateTimeKind.Utc).AddTicks(4960), null, 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 50, 28, 476, DateTimeKind.Utc).AddTicks(4854), new DateTime(2026, 10, 7, 3, 50, 28, 476, DateTimeKind.Utc).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 2, 50, 28, 476, DateTimeKind.Utc).AddTicks(4854), new DateTime(2026, 10, 7, 1, 50, 28, 476, DateTimeKind.Utc).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 20, 28, 476, DateTimeKind.Utc).AddTicks(4854), new DateTime(2026, 10, 6, 22, 50, 28, 476, DateTimeKind.Utc).AddTicks(4854) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$jA1Wxwcyltt2RcFpMtuTnumqyrfP4NcqnwhQAbyxRFhRX9xTDPYWu");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$o7diHQsRnY47iwObSgchBeq6u7gTotEb87/VPLwlhcNi2jnubG3TW");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$YbkCbaJS0q.yKxcWXi5PK.GYUR5LGfSKNoZN4/1MzqrH0xx77b8v.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 49, 48, 651, DateTimeKind.Utc).AddTicks(5795), new DateTime(2026, 10, 7, 3, 49, 48, 651, DateTimeKind.Utc).AddTicks(5795) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 2, 49, 48, 651, DateTimeKind.Utc).AddTicks(5795), new DateTime(2026, 10, 7, 1, 49, 48, 651, DateTimeKind.Utc).AddTicks(5795) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 19, 48, 651, DateTimeKind.Utc).AddTicks(5795), new DateTime(2026, 10, 6, 22, 49, 48, 651, DateTimeKind.Utc).AddTicks(5795) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$Z/4othJUi7YlkZnPaCQ0le.G1hyaCizQG.pyQjf0.kMmh5zFciCB2");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$ypkHCBAXwt.Dn3kgTAggouFiPxrFmcgjjGiFLCBevKktP2TeJFpkK");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$5kUqLwz0s.hXtShf/nFh8.O5xHWMznRnwGPDLrvCPbHNXNzxDjani");
        }
    }
}
