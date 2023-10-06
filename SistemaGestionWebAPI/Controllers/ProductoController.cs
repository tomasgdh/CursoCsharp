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
        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> Get()
        {
            return ProductoBusiness.ListarProductos();
        }

        [HttpGet("{id}")]
        public Producto GetProducto(int id)
        {
            return ProductoBusiness.ObtenerProducto(id);
        }
    }
}
