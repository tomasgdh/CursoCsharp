using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await VentaBusiness.ListarVentasAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(int id)
        {
            try
            {
                var cliente = await VentaBusiness.ObtenerVentaAsync(id);
                if (cliente == null)
                {
                    return NotFound("Venta no encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete(Name = "DeleteVenta")]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            try
            {
                await VentaBusiness.EliminarVentaAsync(Id);
                return Ok("Se Eliminó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut(Name = "AltaVenta")]
        public async Task<IActionResult> Put([FromBody] Venta cliente)
        {
            try
            {
                await VentaBusiness.CrearVentaAsync(cliente);
                return Ok("Se Agregó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost(Name = "ModificarVenta")]
        public async Task<IActionResult> Post([FromBody] Venta cliente)
        {
            try
            {
                await VentaBusiness.ModificarVentaAsync(cliente);
                return Ok("Se Modificó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
