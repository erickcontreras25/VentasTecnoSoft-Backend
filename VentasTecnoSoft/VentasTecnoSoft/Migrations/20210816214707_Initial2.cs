using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasTecnoSoft.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idPedidoProducto",
                table: "PedidoProducto",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "PedidoProducto",
                newName: "idPedidoProducto");
        }
    }
}
