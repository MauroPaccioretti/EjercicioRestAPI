namespace ejercicioRestAPI.Models
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<LoteDto> Lotes { get; set; } = new List<LoteDto>();

        public int CantidadLotes
        {
            get { return Lotes.Count; }
        }
    }
}
