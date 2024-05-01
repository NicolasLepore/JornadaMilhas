using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.API.Dtos.DestinoDtos
{
    public class ReadDestinoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public double? Preco { get; set; }
        public string? Foto { get; set; }
        
    }
}
