using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.Domain
{
    public class PedidoProductoDomain
    {
        public string agregarPedidoproducto(PedidoProducto pedidoProducto, Producto c, Pedidos z)
        {
            if (pedidoProducto == null)
            {
                return "Por favor ingrese datos";
            }

            int cantidadMayoraCero = pedidoProducto.cantidad;

            if (cantidadMayoraCero <= 0)
            {
                return "Cantidad no puede ser igual o menor a cero";
            }

            if (c == null)
            {
                return "Producto no existe";
            }
            if (c == null)
            {
                return "Pedido no existe";
            }


            return null;
        }
    }
}
