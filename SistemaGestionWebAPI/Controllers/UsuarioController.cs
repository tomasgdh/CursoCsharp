using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<Usuario> Get()
        {
            return UsuarioBusiness.ListarUsuarios();
        }

        [HttpGet("{id}")]
        public Usuario GetUsuario(int id)
        {
            return UsuarioBusiness.ObtenerUsuario(id);
        }
    }
}
