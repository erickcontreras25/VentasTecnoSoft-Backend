using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Domain;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.AppServices
{
    public class UsuarioAppService
    {
        private readonly DBContext _db;
        private readonly UsuarioDomain _usuarioDomain;

        public UsuarioAppService(DBContext db, UsuarioDomain usuarioDomain)
        {
            _db = db;
            _usuarioDomain = usuarioDomain;
        }

        public async Task<string> AgregarUsuario(TipoUsuario usuario)
        {
            var respuesta = _usuarioDomain.agregarUsuario(usuario);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _db.TipoUsuario.Add(usuario);
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
