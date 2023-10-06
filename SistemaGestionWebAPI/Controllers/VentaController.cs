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
        public IEnumerable<Venta> Get()
        {
            return VentaBusiness.ListarVentas();
        }

        [HttpGet("{id}")]
        public Venta GetVenta(int id)
        {
            return VentaBusiness.ObtenerVenta(id);
        }
    }
}
