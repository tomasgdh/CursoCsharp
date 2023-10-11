using Microsoft.EntityFrameworkCore;
using SistemaGestionData.Context;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ClienteData
    {
        #region Clientes
        public static async Task<List<Cliente>> ListarClientesAsync()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Clientes.OrderBy(x => x.Id).ToListAsync();
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
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Clientes.FindAsync(id);
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
                using var dbContext = new SistemaGestionContext();
                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
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
                using var dbContext = new SistemaGestionContext();
                var clienteAModificar = await dbContext.Clientes.FindAsync(cliente.Id);

                if (clienteAModificar != null)
                {
                    clienteAModificar.NombreApellido = cliente.NombreApellido;
                    clienteAModificar.Domicilio = cliente.Domicilio;
                    clienteAModificar.Telefono = cliente.Telefono;
                    await dbContext.SaveChangesAsync();
                }
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
                using var dbContext = new SistemaGestionContext();
                var clienteAEliminar = await dbContext.Clientes.FindAsync(Id);

                if (clienteAEliminar != null)
                {
                    dbContext.Clientes.Remove(clienteAEliminar);
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
