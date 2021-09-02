using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentasTecnoSoft.Models
{
    public class Pedidos
    {
        [Key]
        public int idPedido { get; set; }
        public DateTime horaConfirmacion { get; set; }
        public int clienteId { get; set; }
        public Cliente cliente { get; set; }
        public bool aprobado { get; set; }
        public virtual List<PedidoProducto> pedidoProducto { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Pedidos> _pedido)
            {
                _pedido.HasKey(x => x.idPedido);
                _pedido.Property(x => x.horaConfirmacion).HasColumnName("Hora Confirmacion").HasColumnType("Datetime");
                _pedido.Property(x => x.clienteId).HasColumnName("ClienteId").HasColumnType("int");
                _pedido.HasOne(x => x.cliente);
                _pedido.Property(x => x.aprobado).HasColumnName("Estado").HasColumnType("bit");
            }
        }
    }
}
