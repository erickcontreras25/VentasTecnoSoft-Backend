using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Domain;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.AppServices
{
    public class PedidoAppService
    {

        private readonly DBContext _db;
        private readonly PedidoDomain _pedidoDomain;

        public PedidoAppService(DBContext db, PedidoDomain pedidoDomain)
        {
            _db = db;
            _pedidoDomain = pedidoDomain;
        }

        public async Task<string> AgregarPedido(Pedidos pedidos)
        {
            var respuesta = _pedidoDomain.agregarPedido(pedidos);

            bool hayError = respuesta != null;

            if(hayError)
            {
                return respuesta;
            }

            try
            {

                _db.Pedidos.Add(pedidos);
                await _db.SaveChangesAsync();

                //foreach (var d in pedidos.pedidoProducto)
                //{
                //    _db.PedidoProducto.Add(d);
                //}
                //await _db.SaveChangesAsync();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
