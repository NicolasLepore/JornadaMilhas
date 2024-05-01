using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace JornadaMilhas.API.Dtos.DepoimentoDtos
{
    public class UpdateDepoimentoDto
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
