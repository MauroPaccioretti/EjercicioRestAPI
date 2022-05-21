using System.ComponentModel.DataAnnotations;

namespace ejercicioRestAPI.Models
{
    public class LoteParaCreacionDto
    {
        [Required(ErrorMessage = "Agregá un nombre para el Lote")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
