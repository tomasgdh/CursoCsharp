using SistemaGestionData.Context;
using SistemaGestionEntities;
using System.Data;

namespace SistemaGestionData
{
    public class ProductoData
    {
        #region Productos
        public static List<Producto> ListarProductos()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return dbContext.Productos.OrderBy(x => x.Id).ToList();
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
                using var dbContext = new SistemaGestionContext();
                return dbContext.Productos.Where(x => x.Id == id).First();
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
                using var dbContext = new SistemaGestionContext();
                dbContext.Productos.Add(producto);
                dbContext.SaveChanges();
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
                using var dbContext = new SistemaGestionContext();
                var productoAModificar = dbContext.Productos.Find(producto.Id);

                if (productoAModificar != null)
                {
                    productoAModificar.Descripcion = producto.Descripcion;
                    productoAModificar.Costo = producto.Costo;
                    productoAModificar.PrecioVenta = producto.PrecioVenta;
                    productoAModificar.Stock = producto.Stock;
                    productoAModificar.IdUsuario = producto.IdUsuario;
                    dbContext.SaveChanges();
                }

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
                using var dbContext = new SistemaGestionContext();
                var productoAEliminar = dbContext.Productos.Find(producto.Id);

                if (productoAEliminar != null)
                {
                    dbContext.Productos.Remove(productoAEliminar);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
