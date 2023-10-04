using SistemaGestionData;
using SistemaGestionEntities;


namespace SistemaGestionBusiness
{
    public class VentaBusiness
    {
        public static List<Venta> ListarVentas()
        {
            try
            {
                return  VentaData.ListarVentas();
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
                return VentaData.ObtenerVenta(id);
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
                VentaData.CrearVentas(venta);
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
                VentaData.ModificarVentas(venta);
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
                VentaData.EliminarVentas(venta);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
