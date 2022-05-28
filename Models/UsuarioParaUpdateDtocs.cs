using System.ComponentModel.DataAnnotations;

namespace ejercicioRestAPI.Models
{
    public class UsuarioParaUpdateDtocs
    {
        [Required(ErrorMessage = "Agregá un nombre para el Usuario")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<LoteDto> Lotes { get; set; } = new List<LoteDto>();

        public int CantidadLotes
        {
            get { return Lotes.Count; }
        }
    }
}
