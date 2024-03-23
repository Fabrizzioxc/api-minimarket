using app_minimarket.Data;
using app_minimarket.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_minimarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private IPedido _pedido;

        public PedidoController(IPedido pedido)
        {
            _pedido = pedido;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            return Ok(await _pedido.ListarPedidos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarPedido(int id)
        {
            return Ok(await _pedido.MostrarPedido(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPedido([FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _pedido.RegistrarPedido(pedido);
            return Created("Pedido registrado...", registro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPedido(int id, [FromBody] Pedido pedido)
        {
            if (pedido == null || id != pedido.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _pedido.ActualizarPedido(pedido);

            return Created("Pedido actualizado...", registro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPedido(int id)
        {
            var registro = await _pedido.EliminarPedido(id);

            return Created("Pedido eliminado...", registro);
        }
    }
}
