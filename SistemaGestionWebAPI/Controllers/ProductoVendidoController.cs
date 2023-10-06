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
        [HttpGet(Name = "GetProductosVendidos")]
        public IEnumerable<ProductoVendido> Get()
        {
            return ProductoVendidoBusiness.ListarProductosVendidos();
        }

        [HttpGet("{id}")]
        public ProductoVendido GetProducto(int id)
        {
            return ProductoVendidoBusiness.ObtenerProductoVendido(id);
        }
    }
}
