using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.API.Dtos.DepoimentoDtos
{
    public class CreateDepoimentoDto
    {

        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Texto { get; set; }
        public string? FotoPerfil { get; set; } 
    }
}
