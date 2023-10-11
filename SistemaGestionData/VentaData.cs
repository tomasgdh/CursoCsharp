using SistemaGestionEntities;
using SistemaGestionData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionData
{
    public class VentaData
    {
        #region Ventas
        public static async Task<List<Venta>> ListarVentasAsync()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Ventas.OrderBy(x => x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Venta> ObtenerVentaAsync(int id)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Ventas.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task CrearVentaAsync(Venta venta)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                dbContext.Ventas.Add(venta);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task ModificarVentaAsync(Venta venta)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                var ventaAModificar = await dbContext.Ventas.FindAsync(venta.Id);

                if (ventaAModificar != null)
                {
                    ventaAModificar.Comentarios = venta.Comentarios;
                    ventaAModificar.IdUsuario = venta.IdUsuario;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task EliminarVentaAsync(int Id)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                var ventaAEliminar = await dbContext.Ventas.FindAsync(Id);

                if (ventaAEliminar != null)
                {
                    dbContext.Ventas.Remove(ventaAEliminar);
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
