using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasTecnoSoft.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "subTotal",
                table: "PedidoProducto",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subTotal",
                table: "PedidoProducto");
        }
    }
}
