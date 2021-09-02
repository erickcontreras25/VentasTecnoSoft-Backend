using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.Domain
{
    public class PedidoDomain
    {
        private readonly DBContext _db;

        public string agregarPedido(Pedidos pedido)
        {

            if (pedido == null)
            {
                return "Por favor ingrese datos";
            }

            int existeCliente = pedido.clienteId;
            //
            DateTime horaPedido = pedido.horaConfirmacion;

            //if (c == null)
            //{
            //    return "Cliente no existe";
            //}

            if (existeCliente == 0)
            {
                return "Cliente debe existir";
            }

            if (horaPedido == null)
            {
                return "Debe colocar la fecha";
            }

            return null;
        }

    }
}
