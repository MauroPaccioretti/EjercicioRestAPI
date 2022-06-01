using System.ComponentModel.DataAnnotations;

namespace ejercicioRestAPI.Models
{
    public class UsuarioParaUpdateDtocs
    {
        [Required(ErrorMessage = "Agregá un nombre para el Usuario")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

    }
}
