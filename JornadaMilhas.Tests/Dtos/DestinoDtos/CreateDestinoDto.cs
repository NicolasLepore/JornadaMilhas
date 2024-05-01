using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.API.Dtos.DestinoDtos
{
    public class CreateDestinoDto
    {
        [Required]
        [MaxLength(30)]
        public string? Nome { get; set; }

        [Required]
        public double? Preco { get; set; }

        public string? Foto { get; set; }
    }
}
