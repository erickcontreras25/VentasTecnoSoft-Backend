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
    public class PedidoProductoController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly PedidoProductoAppService _pedidoProductoAppService;

        public PedidoProductoController(DBContext _dbContext, PedidoProductoAppService _pedidoProductoService)
        {
            _db = _dbContext;
            _pedidoProductoAppService = _pedidoProductoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoProducto>>> getPedidoProducto()
        {
            return await _db.PedidoProducto.OrderBy(y => y.pedidoId).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoProducto>> getPedidoProductoId(int id)
        {
            return await _db.PedidoProducto.Where(x=>x.pedidoId==id).FirstOrDefaultAsync(i => i.productoId == id);
        }

        [HttpPost]
        public async Task<ActionResult<PedidoProducto>> postPedidoProducto(PedidoProducto pedidoProducto)
        {
            var c = await _db.Producto.FindAsync(pedidoProducto.productoId);
            var z = await _db.Pedidos.FindAsync(pedidoProducto.pedidoId);
            var respuesta = await _pedidoProductoAppService.AgregarPedidoProducto(pedidoProducto, c, z);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deletePedidoProducto(int id)
        {
            var pedidoProducto = await _db.PedidoProducto.FindAsync(id);
            if (pedidoProducto == null)
            {
                return NotFound();
            }
            _db.PedidoProducto.Remove(pedidoProducto);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}