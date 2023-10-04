using SistemaGestionData;
using SistemaGestionData.Context;
using SistemaGestionEntities;


namespace SistemaGestionBusiness
{
    public static class ClienteBusiness
    {
        public static List<Cliente> ListarClientes()
        {
            try
            {
                return ClienteData.ListarClientes();
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
                return ClienteData.ObtenerCliente(id);
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
                ClienteData.CrearCliente(cliente);
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
                ClienteData.ModificarCliente(cliente);
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
                ClienteData.EliminarCliente(cliente);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }   
}
