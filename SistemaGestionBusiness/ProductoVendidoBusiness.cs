using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public class ProductoVendidoBusiness
    {
        public static List<ProductoVendido> ListarProductosVendidos()
        {
            try
            {
                return ProductoVendidoData.ListarProductosVendidos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static ProductoVendido ObtenerProductoVendido(int id)
        {

            try
            {
                return ProductoVendidoData.ObtenerProductoVendido(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                ProductoVendidoData.CrearProductoVendido(productoVendido);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                ProductoVendidoData.ModificarProductoVendido(productoVendido);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void EliminarProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                ProductoVendidoData.EliminarProductoVendido(productoVendido);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
