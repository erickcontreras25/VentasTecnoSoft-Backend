using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<PedidoProducto> PedidoProducto { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            new Cliente.Map(mb.Entity<Cliente>());
            new Pedidos.Map(mb.Entity<Pedidos>());
            new Producto.Map(mb.Entity<Producto>());
            new TipoUsuario.Map(mb.Entity<TipoUsuario>());
            new PedidoProducto.Map(mb.Entity<PedidoProducto>());

            base.OnModelCreating(mb);
        }
    }
}
