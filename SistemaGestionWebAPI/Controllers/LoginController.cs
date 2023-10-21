using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost(Name = "InicioSesion")]
        public async Task<IActionResult> Post(string nombreUsuario, string password)
        {
            try
            {
                string resultado = await UsuarioBusiness.ObtenerUsuarioByNombreAsync(nombreUsuario,password);
                if (resultado == "El Usuario o password no son Correctos")
                {
                    return NotFound(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
