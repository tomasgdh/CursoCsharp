using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBusiness
{
    public class UsuarioBusiness
    {
        public static List<Usuario> ListarUsuarios()
        {
            try
            {
                return UsuarioData.ListarUsuarios();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Usuario ObtenerUsuario(int id)
        {

            try
            {
                return UsuarioData.ObtenerUsuario(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void CrearUsuario(Usuario usuario)
        {
            try
            {
                UsuarioData.CrearUsuario(usuario);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static void ModificarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioData.ModificarUsuario(usuario);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void EliminarUsuario(Usuario usuario)
        {
            try
            {
                UsuarioData.EliminarUsuario(usuario);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
