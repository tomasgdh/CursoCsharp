using SistemaGestionData.Context;
using SistemaGestionEntities;
using System.Data;

namespace SistemaGestionData
{
    public class UsuarioData
    {
        #region usuarios
        public static List<Usuario> ListarUsuarios()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return dbContext.Usuarios.OrderBy(x => x.Id).ToList();
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
                using var dbContext = new SistemaGestionContext();
                return dbContext.Usuarios.Where(x => x.Id == id).First();
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
                using var dbContext = new SistemaGestionContext();
                dbContext.Usuarios.Add(usuario);
                dbContext.SaveChanges();
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
                using var dbContext = new SistemaGestionContext();
                var usuarioAModificar = dbContext.Usuarios.Find(usuario.Id);

                if (usuarioAModificar != null)
                {
                    usuarioAModificar.Nombre = usuario.Nombre;
                    usuarioAModificar.Apellido = usuario.Apellido;
                    usuarioAModificar.NombreUsuario = usuario.NombreUsuario;
                    usuarioAModificar.Contraseña = usuario.Contraseña;
                    usuarioAModificar.Mail = usuario.Mail;
                    dbContext.SaveChanges();
                }

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
                using var dbContext = new SistemaGestionContext();
                var usuarioAEliminar = dbContext.Usuarios.Find(usuario.Id);

                if (usuarioAEliminar != null)
                {
                    dbContext.Usuarios.Remove(usuarioAEliminar);
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
