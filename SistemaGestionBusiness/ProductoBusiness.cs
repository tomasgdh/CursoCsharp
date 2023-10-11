using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionBusiness
{
    public class ProductoBusiness
    {
        #region Productos
        public static async Task<List<Producto>> ListarProductosAsync()
        {
            try
            {
                return await ProductoData.ListarProductosAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Producto> ObtenerProductoAsync(int id)
        {
            try
            {
                return await ProductoData.ObtenerProductoAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task CrearProductoAsync(Producto producto)
        {
            try
            {
                await ProductoData.CrearProductoAsync(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task ModificarProductoAsync(Producto producto)
        {
            try
            {
                await ProductoData.ModificarProductoAsync(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task EliminarProductoAsync(int Id)
        {
            try
            {
                await ProductoData.EliminarProductoAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
