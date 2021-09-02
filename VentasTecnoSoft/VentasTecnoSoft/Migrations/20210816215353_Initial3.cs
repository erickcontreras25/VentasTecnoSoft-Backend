using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasTecnoSoft.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProducto_Pedidos_pedidosidPedido",
                table: "PedidoProducto");

            migrationBuilder.DropIndex(
                name: "IX_PedidoProducto_pedidosidPedido",
                table: "PedidoProducto");

            migrationBuilder.DropColumn(
                name: "pedidosidPedido",
                table: "PedidoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProducto_PedidoId",
                table: "PedidoProducto",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProducto_Pedidos_PedidoId",
                table: "PedidoProducto",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "idPedido",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProducto_Pedidos_PedidoId",
                table: "PedidoProducto");

            migrationBuilder.DropIndex(
                name: "IX_PedidoProducto_PedidoId",
                table: "PedidoProducto");

            migrationBuilder.AddColumn<int>(
                name: "pedidosidPedido",
                table: "PedidoProducto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProducto_pedidosidPedido",
                table: "PedidoProducto",
                column: "pedidosidPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProducto_Pedidos_pedidosidPedido",
                table: "PedidoProducto",
                column: "pedidosidPedido",
                principalTable: "Pedidos",
                principalColumn: "idPedido",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
