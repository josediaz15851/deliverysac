using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliverySac.API.Migrations
{
    /// <inheritdoc />
    public partial class AddClientesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$z6qMivzjwmP.NSgpYQl48uBKpXWXj77Iog5U6hcFr3uZZTCpMXy8O");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$J2ZUsyBB.1xmVXdaGo9AbORy9lfAuLmwxD0FjU37CldDjM4SPtxSq");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$umG3cOZqiAqo86ejSGETtuNDWy.J0SvjRlPPp2kAxhtDfAKaqpSSO");
        }
    }
}
