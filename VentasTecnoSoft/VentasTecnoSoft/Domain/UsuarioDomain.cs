using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.Domain
{
    public class UsuarioDomain
    {
        public string agregarUsuario(TipoUsuario usuario)
        {
            if (usuario == null)
            {
                return "Por favor ingrese datos";
            }

            int maximoCarcteresParaNombre = 20;
            int minimoCaracteresParaNombre = 5;
            var nombreEsMuyLargo = usuario.nombreUsuario.Count() > maximoCarcteresParaNombre;
            var nombreEsMuyCorto = usuario.nombreUsuario.Count() < minimoCaracteresParaNombre;

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
