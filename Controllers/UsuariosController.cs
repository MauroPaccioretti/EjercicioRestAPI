using ejercicioRestAPI.Models;
using ejercicioRestAPI;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ejercicioRestAPI.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDto>> GetUsuarios()
        {
            return Ok(UsuariosData.Instancia.Usuarios);
        }

        [HttpGet("{id}", Name = "GetUsuarios")]
        public ActionResult<UsuarioDto> GetUsuario(int id)
        {
            var usuarioARetornar = UsuariosData.Instancia.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuarioARetornar == null)
                return NotFound("El usuario no existe");
            return Ok(usuarioARetornar);
        }
        [HttpPost]
        public ActionResult<UsuarioDto> CrearUsuario(UsuarioParaCreacionDto user)
        {
            var listaUsuarios = UsuariosData.Instancia.Usuarios;
            var idMaximoUsuario = UsuariosData.Instancia.Usuarios.Max(x => x.Id);
            var nuevoUsuario = new UsuarioDto
            {
                Id = ++idMaximoUsuario,
                Name = user.Name,
            };
            listaUsuarios.Add(nuevoUsuario);
            return CreatedAtRoute(
                "GetUsuarios",
                new {
                    id = idMaximoUsuario
                },
                nuevoUsuario);
                
        }
        [HttpPut("{id}")]
        public ActionResult ActualizarUsuarios(int id, UsuarioParaUpdateDtocs user)
        {
            var usuario = UsuariosData.Instancia.Usuarios.FirstOrDefault(e => e.Id == id);

            if (usuario == null)
                return NotFound("El usuario no existe");
            usuario.Name = user.Name;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuarios(int id)
        {
            var listaUsuarios = UsuariosData.Instancia.Usuarios;
            var usuario = UsuariosData.Instancia.Usuarios.FirstOrDefault(e => e.Id == id);
            if (usuario is null)
                return NotFound("El usuario no existe");
            listaUsuarios.Remove(usuario);

            return NoContent();
        }

    }
}
