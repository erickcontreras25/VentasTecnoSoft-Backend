using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VentasTecnoSoft.Models
{
    public class TipoUsuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public bool tipoUsuario { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<TipoUsuario> _tipoUser)
            {
                _tipoUser.HasKey(x => x.idUsuario);
                _tipoUser.Property(x => x.nombreUsuario).HasMaxLength(20);
                _tipoUser.Property(x => x.tipoUsuario).HasColumnName("TipoUsuario").HasColumnType("bit");
            }
        }
    }
}
