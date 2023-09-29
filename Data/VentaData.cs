using CursoCsharp.Context;
using CursoCsharp.Models;
using System.Data;


namespace CursoCsharp.Data
{
    public class VentaData
    {
        #region Ventas
        public static List<Venta> ListarVentas()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return dbContext.Ventas.OrderBy(x => x.Id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Venta ObtenerVenta(int id)
        {

            try
            {
                using var dbContext = new SistemaGestionContext();
                return dbContext.Ventas.Where(x => x.Id == id).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void CrearVentas(Venta venta)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                dbContext.Ventas.Add(venta);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarVentas(Venta venta)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                var ventaAModificar = dbContext.Ventas.Find(venta.Id);

                if (ventaAModificar != null)
                {
                    ventaAModificar.Comentarios = venta.Comentarios;
                    ventaAModificar.IdUsuario = venta.IdUsuario;
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void EliminarVentas(Venta venta)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                var ventaAEliminar = dbContext.Ventas.Find(venta.Id);

                if (ventaAEliminar != null)
                {
                    dbContext.Ventas.Remove(ventaAEliminar);
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
