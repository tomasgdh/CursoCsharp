using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBusiness;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("GetClientes")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await ClienteBusiness.ListarClientesAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            try
            {
                var cliente = await ClienteBusiness.ObtenerClienteAsync(id);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteCliente")]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            try
            {
                await ClienteBusiness.EliminarClienteAsync(Id);
                return Ok("Se Eliminó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("AltaCliente")]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            try
            {
                await ClienteBusiness.CrearClienteAsync(cliente);
                return Ok("Se Agregó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ModificarCliente")]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                await ClienteBusiness.ModificarClienteAsync(cliente);
                return Ok("Se Modificó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
