using Microsoft.EntityFrameworkCore;
using SistemaGestionData.Context;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoData
    {
        #region Productos
        public static async Task<List<Producto>> ListarProductosAsync()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Productos.OrderBy(x => x.Id).ToListAsync();
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
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Productos.FindAsync(id);
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
                using var dbContext = new SistemaGestionContext();
                dbContext.Productos.Add(producto);
                await dbContext.SaveChangesAsync();
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
                using var dbContext = new SistemaGestionContext();
                var productoAModificar = await dbContext.Productos.FindAsync(producto.Id);

                if (productoAModificar != null)
                {
                    productoAModificar.Descripcion = producto.Descripcion;
                    productoAModificar.Costo = producto.Costo;
                    productoAModificar.PrecioVenta = producto.PrecioVenta;
                    productoAModificar.Stock = producto.Stock;
                    productoAModificar.IdUsuario = producto.IdUsuario;
                    await dbContext.SaveChangesAsync();
                }
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
                using var dbContext = new SistemaGestionContext();
                var productoAEliminar = await dbContext.Productos.FindAsync(Id);

                if (productoAEliminar != null)
                {
                    dbContext.Productos.Remove(productoAEliminar);
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
