using System.ComponentModel.DataAnnotations;

namespace ejercicioRestAPI.Models
{
    public class LoteParaUpdateDto
    {
        [Required(ErrorMessage = "Agregá un nombre para el Lote")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
