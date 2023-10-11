using SistemaGestionEntities;
using SistemaGestionData.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionData
{
    public class ProductoVendidoData
    {
        #region ProductosVendidos
        public static async Task<List<ProductoVendido>> ListarProductosVendidosAsync()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return await dbContext.ProductosVendidos.OrderBy(x => x.Id).ToListAsync();
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
                using var dbContext = new SistemaGestionContext();
                return await dbContext.ProductosVendidos.Where(x => x.Id == id).FirstOrDefaultAsync();
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
                using var dbContext = new SistemaGestionContext();
                dbContext.ProductosVendidos.Add(productoVendido);
                await dbContext.SaveChangesAsync();
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
                using var dbContext = new SistemaGestionContext();
                var productoVendidoAModificar = await dbContext.ProductosVendidos.FindAsync(productoVendido.Id);

                if (productoVendidoAModificar != null)
                {
                    productoVendidoAModificar.IdProducto = productoVendido.IdProducto;
                    productoVendidoAModificar.Stock = productoVendido.Stock;
                    productoVendidoAModificar.Idventa = productoVendido.Idventa;
                    await dbContext.SaveChangesAsync();
                }
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
                using var dbContext = new SistemaGestionContext();
                var productoVendidoAEliminar = await dbContext.ProductosVendidos.FindAsync(Id);

                if (productoVendidoAEliminar != null)
                {
                    dbContext.ProductosVendidos.Remove(productoVendidoAEliminar);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
