using CursoCsharp.Context;
using CursoCsharp.Models;
using System.Data;

namespace CursoCsharp.Data
{
    public class ProductoVendidoData
    {
        #region ProductosVendidos
        public static List<ProductoVendido> ListarProductosVendidos()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return dbContext.ProductosVendidos.OrderBy(x => x.Id).ToList();
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
                using var dbContext = new SistemaGestionContext();
                return dbContext.ProductosVendidos.Where(x => x.Id == id).First();
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
                using var dbContext = new SistemaGestionContext();
                dbContext.ProductosVendidos.Add(productoVendido);
                dbContext.SaveChanges();
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
                using var dbContext = new SistemaGestionContext();
                var productoVendidoAModificar = dbContext.ProductosVendidos.Find(productoVendido.Id);

                if (productoVendidoAModificar != null)
                {
                    productoVendidoAModificar.IdProducto = productoVendido.IdProducto;
                    productoVendidoAModificar.Stock = productoVendido.Stock;
                    productoVendidoAModificar.Idventa = productoVendido.Idventa;
                    dbContext.SaveChanges();
                }

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
                using var dbContext = new SistemaGestionContext();
                var productoVendidoAEliminar = dbContext.ProductosVendidos.Find(productoVendido.Id);

                if (productoVendidoAEliminar != null)
                {
                    dbContext.ProductosVendidos.Remove(productoVendidoAEliminar);
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
