using ejercicioRestAPI.Models;
using ejercicioRestAPI;
using Microsoft.AspNetCore.Mvc;

namespace ejercicioRestAPI.Controllers
{
    [ApiController]
    [Route("api/usuarios/{idUsuario}/lotes")]
    public class LotesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<LoteDto>> GetLotes(int idUsuario) //get usuario??
        {
            var usuario = UsuariosData.Instancia.Usuarios.FirstOrDefault(x => x.Id == idUsuario);
            if (usuario == null) return NotFound("Usuario no encontrado");

            return Ok(usuario.Lotes);
        }

        [HttpGet("{idLote}", Name = "GetLote")]
        public ActionResult<LoteDto> GetLote(int idUsuario, int idLote)
        {
            var usuario = UsuariosData.Instancia.Usuarios.FirstOrDefault(x => x.Id == idUsuario);

            if (usuario == null)
                return NotFound();

            var lote = usuario.Lotes.FirstOrDefault(x => x.Id == idLote);

            if (lote == null)
                return NotFound("Lote no encontrado");

            return Ok(lote);
        }

        [HttpPost]
        public ActionResult<LoteDto> CrearLote(int idUsuario, LoteParaCreacionDto lote)
        {
            var usuario = UsuariosData.Instancia.Usuarios.FirstOrDefault(c => c.Id == idUsuario);
            if (usuario is null)
            {
                return NotFound("El usuario no existe");
            }

            var idMaximoPuntosDeInteres = UsuariosData.Instancia.Usuarios.SelectMany(c => c.Lotes).Max(p => p.Id);

            var nuevoLote = new LoteDto
            {
                Id = ++idMaximoPuntosDeInteres,
                Name = lote.Name,
                Description = lote.Description
            };

            usuario.Lotes.Add(nuevoLote);

            return CreatedAtRoute(
                "GetLote",
                new
                {
                    idUsuario,
                    idLote = nuevoLote.Id
                },
                nuevoLote);
        }

        [HttpPut("{idLote}")]
        public ActionResult ActualizarLote(int idUsuario, int idLote, LoteParaUpdateDto lote)
        {
            var usuario = UsuariosData.Instancia.Usuarios.FirstOrDefault(c => c.Id == idUsuario);

            if (usuario == null)
                return NotFound("El usuario no existe");

            var loteEnLaBase = usuario.Lotes.FirstOrDefault(p => p.Id == idLote);
            if (loteEnLaBase == null)
                return NotFound("El lote no existe");

            loteEnLaBase.Name = lote.Name;
            loteEnLaBase.Description = lote.Description;

            return NoContent();
        }

        [HttpDelete("{idLote}")]
        public ActionResult DeleteLote(int idUsuario, int idLote)
        {
            var usuario = UsuariosData.Instancia.Usuarios.FirstOrDefault(c => c.Id == idUsuario);
            if (usuario is null)
                return NotFound();

            var loteAEliminar = usuario.Lotes
                .FirstOrDefault(p => p.Id == idLote);
            if (loteAEliminar is null)
                return NotFound("El lote no existe");

            usuario.Lotes.Remove(loteAEliminar);

            return NoContent();
        }

    }
}
