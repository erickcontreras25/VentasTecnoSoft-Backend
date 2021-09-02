using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasTecnoSoft.AppServices;
using VentasTecnoSoft.Models;

namespace VentasTecnoSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly ProductoAppService _productoAppService;

        public ProductoController(DBContext _dbContext, ProductoAppService _productoService)
        {
            _db = _dbContext;
            _productoAppService = _productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> getProducto()
        {
            return await _db.Producto.OrderBy(y => y.nombreProducto).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> getProductoId(int id)
        {
            return await _db.Producto.FirstOrDefaultAsync(i => i.idProducto == id);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> postProducto(Producto producto)
        {
            var respuesta = await _productoAppService.AgregarProducto(producto);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idProducto}")]

        public async Task<ActionResult> putProducto(int idProducto, Producto producto)
        {

            if (idProducto == producto.idProducto)
            {
                _db.Entry(producto).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteProductos(int id)
        {
            var producto = await _db.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _db.Producto.Remove(producto);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}