using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestionBusiness
{
    public class UsuarioBusiness
    {
        public static async Task<List<Usuario>> ListarUsuariosAsync()
        {
            try
            {
                return await UsuarioData.ListarUsuariosAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<Usuario> ObtenerUsuarioAsync(int id)
        {
            try
            {
                return await UsuarioData.ObtenerUsuarioAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> ObtenerNombreUsuarioAsync(int id)
        {
            try
            {
                Usuario usuario = await UsuarioData.ObtenerUsuarioAsync(id);
                if (usuario == null)
                {
                    return "El usuario no es correcto";
                }
                else {
                    return usuario.NombreUsuario;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<string> ObtenerUsuarioByNombreAsync(string nombreUsuario, string password)
        {
            try
            {
                Usuario usuario = await UsuarioData.ObtenerUsuarioByNombreAsync(nombreUsuario);
                if (usuario == null || usuario.Contraseña != password)
                {
                    return "El Usuario o password no son Correctos";
                }
                return "Se Inició sesión correctamente";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task CrearUsuarioAsync(Usuario usuario)
        {
            try
            {
                await UsuarioData.CrearUsuarioAsync(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task ModificarUsuarioAsync(Usuario usuario)
        {
            try
            {
                await UsuarioData.ModificarUsuarioAsync(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task EliminarUsuarioAsync(int Id)
        {
            try
            {
                await UsuarioData.EliminarUsuarioAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
