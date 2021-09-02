using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Domain;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.AppServices
{
    public class PedidoProductoAppService
    {
        private readonly DBContext _db;
        private readonly PedidoProductoDomain _pedidoProductoDomain;

        public PedidoProductoAppService(DBContext db, PedidoProductoDomain pedidoProductoDomain)
        {
            _db = db;
            _pedidoProductoDomain = pedidoProductoDomain;
        }

        public async Task<string> AgregarPedidoProducto(PedidoProducto pedidoProducto, Producto c, Pedidos z)
        {
            var respuesta = _pedidoProductoDomain.agregarPedidoproducto(pedidoProducto, c, z);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _db.PedidoProducto.Add(pedidoProducto);
                await _db.SaveChangesAsync();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
