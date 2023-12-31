﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await UsuarioBusiness.ListarUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            try
            {
                var usuario = await UsuarioBusiness.ObtenerUsuarioAsync(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("TraerNombre")]
        public async Task<IActionResult> GetNombreUsuario(int id)
        {
            try
            {
                string resultado = await UsuarioBusiness.ObtenerNombreUsuarioAsync(id);
                if (resultado == "El usuario no es correcto")
                {
                    return NotFound(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("DeleteUsuario")]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            try
            {
                await UsuarioBusiness.EliminarUsuarioAsync(Id);
                return Ok("Se Eliminó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("AltaUsuario")]
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            try
            {
                await UsuarioBusiness.CrearUsuarioAsync(usuario);
                return Ok("Se Agregó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ModificarUsuario")]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                await UsuarioBusiness.ModificarUsuarioAsync(usuario);
                return Ok("Se Modificó correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
