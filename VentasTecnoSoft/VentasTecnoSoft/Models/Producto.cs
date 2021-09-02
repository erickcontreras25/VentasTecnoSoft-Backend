using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentasTecnoSoft.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int precio { get; set; }
        public List<PedidoProducto> pedidoProducto { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Producto> _producto)
            {
                _producto.HasKey(x => x.idProducto);
                _producto.Property(x => x.nombreProducto).HasColumnName("Nombre").HasMaxLength(20);
                _producto.Property(x => x.precio).HasColumnName("Precio").HasColumnType("int");
            }
        }
    }
}
