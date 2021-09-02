using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentasTecnoSoft.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        public bool estado { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Estado> _estado)
            {
                _estado.HasKey(x => x.idEstado);
                _estado.Property(x => x.estado).HasColumnName("Estado").HasColumnType("bit");
            }
        }
    }
}
