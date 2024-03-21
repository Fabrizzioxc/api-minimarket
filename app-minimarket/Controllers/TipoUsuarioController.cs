using app_minimarket.Data;
using app_minimarket.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace app_minimarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : Controller
    {
        private ITipoUsuario _tipoUsuario;

        public TipoUsuarioController(ITipoUsuario tipoUsuario)
        {
            _tipoUsuario = tipoUsuario;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTipoUsuario()
        {
            return Ok(await _tipoUsuario.ListarTipoUsuario());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarTipoUsuario(string id)
        {
            return Ok(await _tipoUsuario.MostrarTipoUsuario(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTipoUsuario([FromBody] TipoUsuario tipoUsuario)
        {
            if (tipoUsuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _tipoUsuario.RegistrarTipoUsuario(tipoUsuario);
            return Created("Tipo de usuario registrado...", registro);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarTipoUsuario([FromBody] TipoUsuario tipoUsuario)
        {
            if (tipoUsuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _tipoUsuario.ActualizarTipoUsuario(tipoUsuario);
            return Created("Tipo de usuario actualizado...", registro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipoUsuario(string id)
        {
            var registro = await _tipoUsuario.EliminarTipoUsuario(id);
            return Created("Tipo de usuario eliminado...", registro);
        }
    }
}
