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
                Usuario usuario = await UsuarioBusiness.ObtenerUsuarioByNombreAsync(nombreUsuario);
                if (usuario == null) {
                    return NotFound("El Usuario o password no son Correctos");
                }
                else {
                    if (usuario.Contraseña != password) {
                        return NotFound("El Usuario o password no son Correctos");
                    }
                }
                return Ok("Se Inicio sesion correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
