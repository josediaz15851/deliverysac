using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAsignacionesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    RepartidorId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asignaciones_Usuarios_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_PedidoId",
                table: "Asignaciones",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaciones_RepartidorId",
                table: "Asignaciones",
                column: "RepartidorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaciones");

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 10, 7, 3, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 2, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 10, 7, 1, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2026, 10, 7, 3, 14, 13, 208, DateTimeKind.Utc).AddTicks(7466), new DateTime(2026, 10, 6, 22, 44, 13, 208, DateTimeKind.Utc).AddTicks(7466) });

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
    }
}
