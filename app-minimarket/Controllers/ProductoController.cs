using app_minimarket.Data;
using app_minimarket.Model;
using Microsoft.AspNetCore.Mvc;

namespace app_minimarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {

        private IProducto _producto;

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }
        [HttpGet]
        public async Task<IActionResult> ListarProducto()
        {
            return Ok(await _producto.ListarProducto());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> MostrarProducto(String id)
        {
            return Ok(await _producto.MostrarProducto(id));
        }

        [HttpPost]

        public async Task<IActionResult> RegistrarProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _producto.RegistrarProducto(producto);
            return Created("Producto registrado...", registro);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registro = await _producto.ActualizarProducto(producto);

            return Created("Producto actualizado...", registro);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(String id)
        {
            var registro = await _producto.EliminarProducto(id);

            return Created("Producto eliminado...", registro);
        }
    }
}
