using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionBusiness
{
    public static class ClienteBusiness
    {
        public static async Task<List<Cliente>> ListarClientesAsync()
        {
            try
            {
                return await ClienteData.ListarClientesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Cliente> ObtenerClienteAsync(int id)
        {
            try
            {
                return await ClienteData.ObtenerClienteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task CrearClienteAsync(Cliente cliente)
        {
            try
            {
                await ClienteData.CrearClienteAsync(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task ModificarClienteAsync(Cliente cliente)
        {
            try
            {
                await ClienteData.ModificarClienteAsync(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task EliminarClienteAsync(int Id)
        {
            try
            {
                await ClienteData.EliminarClienteAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
