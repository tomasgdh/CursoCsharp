using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBusiness;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet(Name = "GetClientes")]
        public IEnumerable<Cliente> Get() { 
            return ClienteBusiness.ListarClientes();
        }

        [HttpGet("{id}")]
        public Cliente GetCliente(int id)
        {
            return ClienteBusiness.ObtenerCliente(id);
        }
    }
}
