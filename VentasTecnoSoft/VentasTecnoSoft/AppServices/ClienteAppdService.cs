using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Domain;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.AppServices
{
    public class ClienteAppdService
    {
        private readonly DBContext _db;
        private readonly ClienteDomain _clienteDomain;

        public ClienteAppdService(DBContext db, ClienteDomain clienteDomain)
        {
            _db = db;
            _clienteDomain = clienteDomain;
        }

        public async Task<string> AgregarCliente(Cliente cliente)
        {
            var respuesta = _clienteDomain.agregarCliente(cliente);

            bool hayError = respuesta != null;

            if(hayError)
            {
                return respuesta;
            }

            try
            {
                _db.Cliente.Add(cliente);
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
