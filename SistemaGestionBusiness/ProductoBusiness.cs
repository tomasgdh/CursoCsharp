using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBusiness
{
    public class ProductoBusiness
    {
        #region Productos
        public static List<Producto> ListarProductos()
        {
            try
            {
                return ProductoData.ListarProductos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Producto ObtenerProducto(int id)
        {

            try
            {
                return ProductoData.ObtenerProducto(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void CrearProducto(Producto producto)
        {
            try
            {
                ProductoData.CrearProducto(producto);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarProducto(Producto producto)
        {
            try
            {
                ProductoData.ModificarProducto(producto);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void EliminarProducto(Producto producto)
        {
            try
            {
                ProductoData.EliminarProducto(producto);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
