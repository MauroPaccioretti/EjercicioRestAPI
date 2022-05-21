using ejercicioRestAPI.Models;

namespace ejercicioRestAPI
{
    public class UsuariosData
    {
        public List<UsuarioDto> Usuarios { get; set; }
        public static UsuariosData Instancia { get; } = new UsuariosData();

        public UsuariosData()
        {
            Usuarios = new List<UsuarioDto>()
            {
                new UsuarioDto()
                {
                    Id = 1,
                    Name = "Esteban Quito",
                    Lotes = new List<LoteDto>()
                    {
                        new LoteDto()
                        {
                            Id = 1,
                            Name = "Lote 1",
                            Description = "Lote pequeño, contaminacion baja"
                        },
                        new LoteDto()
                        {
                            Id = 2,
                            Name = "Lote 2",
                            Description = "Lote mediano"
                        }
                    }
                },
                new UsuarioDto()
                {
                    Id = 2,
                    Name = "Aquiles Traigo",
                    Lotes = new List<LoteDto>()
                    {
                        new LoteDto()
                        {
                            Id = 3,
                            Name = "Lote 3",
                            Description = "Lote grande, contaminacion baja"
                        },
                        new LoteDto()
                        {
                            Id = 4,
                            Name = "Lote 4",
                            Description = "Lote grande, contaminacion Alta"
                        }
                    }
                },
                new UsuarioDto(){
                    Id = 3,
                    Name = "Mario Neta",
                    Lotes = new List<LoteDto>()
                    {
                        new LoteDto()
                        {
                            Id = 5,
                            Name = "Lote 5",
                            Description = "Lote mediano"
                        }
                    }
                }
            };
        }
    }
}
