using CursoCsharp.Context;
using CursoCsharp.Models;
using System.Data;

namespace CursoCsharp.Data
{
    public class ClienteData
    {
        #region Clientes
        public static List<Cliente> ListarClientes()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return dbContext.Clientes.OrderBy(x => x.Id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Cliente ObtenerCliente(int id)
        {

            try
            {
                using var dbContext = new SistemaGestionContext();
                return dbContext.Clientes.Where(x => x.Id == id).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void CrearCliente(Cliente cliente)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                dbContext.Clientes.Add(cliente);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarCliente(Cliente cliente)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                var clienteAModificar = dbContext.Clientes.Find(cliente.Id);

                if (clienteAModificar != null)
                {
                    clienteAModificar.NombreApellido = cliente.NombreApellido;
                    clienteAModificar.Domicilio = cliente.Domicilio;
                    clienteAModificar.Telefono = cliente.Telefono;
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void EliminarCliente(Cliente cliente)
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                var clienteAEliminar = dbContext.Clientes.Find(cliente.Id);

                if (clienteAEliminar != null)
                {
                    dbContext.Clientes.Remove(clienteAEliminar);
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
