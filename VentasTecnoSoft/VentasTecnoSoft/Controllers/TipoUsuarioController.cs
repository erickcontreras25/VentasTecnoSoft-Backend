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
    public class TipoUsuarioController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly UsuarioAppService _usuarioAppService;

        public TipoUsuarioController(DBContext _dbContext, UsuarioAppService _usuarioService)
        {
            _db = _dbContext;
            _usuarioAppService = _usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuario>>> getUsuario()
        {
            return await _db.TipoUsuario.OrderBy(y => y.nombreUsuario).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> getUsuarioId(int id)
        {
            return await _db.TipoUsuario.FirstOrDefaultAsync(i => i.idUsuario == id);
        }

        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> postUsuario(TipoUsuario usuario)
        {
            var respuesta = await _usuarioAppService.AgregarUsuario(usuario);
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
        public async Task<ActionResult> deleteUsuarios(int id)
        {
            var usuario = await _db.TipoUsuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _db.TipoUsuario.Remove(usuario);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}