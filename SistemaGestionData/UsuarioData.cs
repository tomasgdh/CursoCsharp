using Microsoft.EntityFrameworkCore;
using SistemaGestionData.Context;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class UsuarioData
    {
        #region usuarios
        public static async Task<List<Usuario>> ListarUsuariosAsync()
        {
            try
            {
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Usuarios.OrderBy(x => x.Id).ToListAsync();
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
                using var dbContext = new SistemaGestionContext();
                return await dbContext.Usuarios.FindAsync(id);
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
                using var dbContext = new SistemaGestionContext();
                dbContext.Usuarios.Add(usuario);
                await dbContext.SaveChangesAsync();
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
                using var dbContext = new SistemaGestionContext();
                var usuarioAModificar = await dbContext.Usuarios.FindAsync(usuario.Id);

                if (usuarioAModificar != null)
                {
                    usuarioAModificar.Nombre = usuario.Nombre;
                    usuarioAModificar.Apellido = usuario.Apellido;
                    usuarioAModificar.NombreUsuario = usuario.NombreUsuario;
                    usuarioAModificar.Contraseña = usuario.Contraseña;
                    usuarioAModificar.Mail = usuario.Mail;
                    await dbContext.SaveChangesAsync();
                }
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
                using var dbContext = new SistemaGestionContext();
                var usuarioAEliminar = await dbContext.Usuarios.FindAsync(Id);

                if (usuarioAEliminar != null)
                {
                    dbContext.Usuarios.Remove(usuarioAEliminar);
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
