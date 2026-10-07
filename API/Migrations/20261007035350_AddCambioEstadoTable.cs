using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCambioEstadoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CambiosEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoAnterior = table.Column<int>(type: "int", nullable: false),
                    EstadoNuevo = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CambiosEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CambiosEstado_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CambiosEstado_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CambiosEstado_PedidoId",
                table: "CambiosEstado",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_CambiosEstado_UsuarioId",
                table: "CambiosEstado",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CambiosEstado");

            migrationBuilder.UpdateData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaAsignacion",
                value: new DateTime(2026, 10, 7, 2, 50, 28, 476, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Asignaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaAsignacion",
                value: new DateTime(2026, 10, 6, 22, 50, 28, 476, DateTimeKind.Utc).AddTicks(4960));

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
    }
}
