using ejercicioRestAPI.Models;
using ejercicioRestAPI;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> GetUsuario(int id)
        {
            var usuarioARetornar = UsuariosData.Instancia.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuarioARetornar == null)
                return NotFound();
            return Ok(usuarioARetornar);
        }

    }
}
