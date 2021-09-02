using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.Domain
{
    public class ClienteDomain
    {
        public string agregarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                return "Por favor ingrese datos";
            }

            int maximoCarcteresParaNombre = 20;
            int minimoCaracteresParaNombre = 5;
            var nombreEsMuyLargo = cliente.nombreCliente.Count() > maximoCarcteresParaNombre;
            var nombreEsMuyCorto = cliente.nombreCliente.Count() < minimoCaracteresParaNombre;

            if (nombreEsMuyLargo)
            {
                return "El nombre contiene mas caracteres de lo permitido.";
            }

            if (nombreEsMuyCorto)
            {
                return "El nombre contiene menos caracteres de lo permitido.";
            }

            return null;
        }
    }
}
