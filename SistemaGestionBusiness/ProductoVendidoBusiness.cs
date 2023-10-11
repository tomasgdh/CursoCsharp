using SistemaGestionEntities;
using SistemaGestionData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionBusiness
{
    public class ProductoVendidoBusiness
    {
        public static async Task<List<ProductoVendido>> ListarProductosVendidosAsync()
        {
            try
            {
                return await ProductoVendidoData.ListarProductosVendidosAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<ProductoVendido> ObtenerProductoVendidoAsync(int id)
        {
            try
            {
                return await ProductoVendidoData.ObtenerProductoVendidoAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task CrearProductoVendidoAsync(ProductoVendido productoVendido)
        {
            try
            {
                await ProductoVendidoData.CrearProductoVendidoAsync(productoVendido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task ModificarProductoVendidoAsync(ProductoVendido productoVendido)
        {
            try
            {
                await ProductoVendidoData.ModificarProductoVendidoAsync(productoVendido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task EliminarProductoVendidoAsync(int Id)
        {
            try
            {
                await ProductoVendidoData.EliminarProductoVendidoAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
