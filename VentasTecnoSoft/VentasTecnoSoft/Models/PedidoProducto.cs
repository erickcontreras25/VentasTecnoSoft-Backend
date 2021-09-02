using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentasTecnoSoft.Models
{
    public class PedidoProducto
    {
        [Key]
        public int id { get; set; }
        public int pedidoId { get; set; }
        public virtual Pedidos pedido { get; set; }
        public int productoId { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public decimal subTotal { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<PedidoProducto> _pedidoProducto)
            {
                _pedidoProducto.HasKey(x => x.id);
                _pedidoProducto.Property(x => x.pedidoId).HasColumnName("PedidoId").HasColumnType("int");
                _pedidoProducto.HasOne(x => x.pedido);
                _pedidoProducto.Property(x => x.cantidad).HasColumnName("Cantidad").HasColumnType("int");
                _pedidoProducto.Property(x => x.subTotal).HasColumnName("subTotal").HasColumnType("real");
                _pedidoProducto.Property(x => x.productoId).HasColumnName("ProductoId").HasColumnType("int");
                _pedidoProducto.HasOne(x => x.producto);
                
            }
        }
    }
}
