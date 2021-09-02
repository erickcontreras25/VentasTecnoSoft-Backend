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
    public class ClienteController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly ClienteAppdService _clienteAppSercice;

        public ClienteController(DBContext _dbContext, ClienteAppdService _clienteService)
        {
            _db = _dbContext;
            _clienteAppSercice = _clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> getCliente()
        {
            return await _db.Cliente.OrderBy(y => y.nombreCliente).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> getClienteId(int id)
        {
            return await _db.Cliente.FirstOrDefaultAsync(i => i.idCliente == id);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> postClientes(Cliente cliente)
        {
            var respuesta = await _clienteAppSercice.AgregarCliente(cliente);
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
        public async Task<ActionResult> deleteClientes(int id)
        {
            var cliente = await _db.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _db.Cliente.Remove(cliente);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}