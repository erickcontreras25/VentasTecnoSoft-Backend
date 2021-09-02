using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasTecnoSoft.Domain;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.AppServices
{
    public class ProductoAppService
    {
        private readonly DBContext _db;
        private readonly ProductoDomain _productoDomain;

        public ProductoAppService(DBContext db, ProductoDomain productoDomain)
        {
            _db = db;
            _productoDomain = productoDomain;
        }

        public async Task<string> AgregarProducto(Producto producto)
        {
            var respuesta = _productoDomain.agregarProducto(producto);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _db.Producto.Add(producto);
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
