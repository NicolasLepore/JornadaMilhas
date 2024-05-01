using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.API.Dtos.DepoimentoDtos
{
    public class ReadDepoimentoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Texto { get; set; }
        public string? FotoPerfil { get; set; }
    }
}
