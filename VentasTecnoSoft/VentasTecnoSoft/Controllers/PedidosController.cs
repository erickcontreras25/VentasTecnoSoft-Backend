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
    public class PedidosController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly PedidoAppService _pedidoAppService;

        public PedidosController(DBContext _dbContext, PedidoAppService _pedidoService)
        {
            _db = _dbContext;
            _pedidoAppService = _pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidos>>> getPedidos()
        {
            return await _db.Pedidos.Include(x=>x.pedidoProducto).Include(z=>z.cliente).OrderBy(y => y.idPedido).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> getPedidosId(int id)
        {
            return await _db.Pedidos.Include(y=>y.cliente).Include(x=>x.pedidoProducto).FirstOrDefaultAsync(i => i.idPedido == id);
        }

        [HttpGet("xCliente")]
        public async Task<ActionResult<IEnumerable<Pedidos>>> getPedidosxCliente([FromQuery] decimal n1)
        {
            return await _db.Pedidos.Include(x => x.cliente).Include(z=>z.pedidoProducto).Where(y => y.clienteId == n1).ToArrayAsync();
        }

        [HttpGet("xFechaCreacion")]
        public async Task<ActionResult<IEnumerable<Pedidos>>> getPedidosxFechaCreacion([FromQuery] DateTime n1)
        {
            return await _db.Pedidos.Include(x => x.cliente).Include(z => z.pedidoProducto).Where(y => y.horaConfirmacion == n1).ToArrayAsync();
        }

        [HttpGet("xEstado")]
        public async Task<ActionResult<IEnumerable<Pedidos>>> getPedidosxEstado([FromQuery] bool n1)
        {
            return await _db.Pedidos.Where(y => y.aprobado == n1).ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> postPedidos(Pedidos pedidos)
        {
            //var c = await _db.TipoUsuario.FindAsync(pedidos.clienteId);
            var respuesta = await _pedidoAppService.AgregarPedido(pedidos);
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
        public async Task<ActionResult> deletePedidos(int id)
        {
            var pedidos = await _db.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }
            _db.Pedidos.Remove(pedidos);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}