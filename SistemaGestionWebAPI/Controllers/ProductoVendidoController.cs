using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductoVendidos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await ProductoVendidoBusiness.ListarProductosVendidosAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoVendido(int id)
        {
            try
            {
                var cliente = await ProductoVendidoBusiness.ObtenerProductoVendidoAsync(id);
                if (cliente == null)
                {
                    return NotFound("ProductoVendido no encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteProductoVendido")]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            try
            {
                await ProductoVendidoBusiness.EliminarProductoVendidoAsync(Id);
                return Ok("Se Eliminó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut(Name = "AltaProductoVendido")]
        public async Task<IActionResult> Put([FromBody] ProductoVendido cliente)
        {
            try
            {
                await ProductoVendidoBusiness.CrearProductoVendidoAsync(cliente);
                return Ok("Se Agregó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost(Name = "ModificarProductoVendido")]
        public async Task<IActionResult> Post([FromBody] ProductoVendido cliente)
        {
            try
            {
                await ProductoVendidoBusiness.ModificarProductoVendidoAsync(cliente);
                return Ok("Se Modificó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
