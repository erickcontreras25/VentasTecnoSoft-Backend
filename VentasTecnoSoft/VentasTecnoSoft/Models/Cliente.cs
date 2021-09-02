using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentasTecnoSoft.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Cliente> _cliente)
            {
                _cliente.HasKey(x => x.idCliente);
                _cliente.Property(x => x.nombreCliente).HasColumnName("Nombre").HasMaxLength(20);
            }
        }
    }
}
