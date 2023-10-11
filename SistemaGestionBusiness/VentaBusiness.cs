using SistemaGestionEntities;
using SistemaGestionData.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public class VentaBusiness
    {
        public static async Task<List<Venta>> ListarVentasAsync()
        {
            try
            {
                return await VentaData.ListarVentasAsync();
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
                return await VentaData.ObtenerVentaAsync(id);
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
                await VentaData.CrearVentaAsync(venta);
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
                await VentaData.ModificarVentaAsync(venta);
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
                await VentaData.EliminarVentaAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
