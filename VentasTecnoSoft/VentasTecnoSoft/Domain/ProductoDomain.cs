using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.Domain
{
    public class ProductoDomain
    {
        public string agregarProducto(Producto producto)
        {
            if (producto == null)
            {
                return "Por favor ingrese datos";
            }

            int maximoCarcteresParaNombre = 20;
            int minimoCaracteresParaNombre = 5;
            var nombreEsMuyLargo = producto.nombreProducto.Count() > maximoCarcteresParaNombre;
            var nombreEsMuyCorto = producto.nombreProducto.Count() < minimoCaracteresParaNombre;

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
