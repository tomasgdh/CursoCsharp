using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("GetProductos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var productos = await ProductoBusiness.ListarProductosAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            try
            {
                var producto = await ProductoBusiness.ObtenerProductoAsync(id);
                if (producto == null)
                {
                    return NotFound("Producto no encontrado");
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteProducto")]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            try
            {
                await ProductoBusiness.EliminarProductoAsync(Id);
                return Ok("Se Eliminó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("AltaProducto")]
        public async Task<IActionResult> Put([FromBody] Producto producto)
        {
            try
            {
                await ProductoBusiness.CrearProductoAsync(producto);
                return Ok("Se Agregó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ModificarProducto")]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                await ProductoBusiness.ModificarProductoAsync(producto);
                return Ok("Se Modificó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
