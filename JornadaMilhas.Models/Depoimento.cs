using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Models
{
    public class Depoimento
    {
        private string _fotoPerfil = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_640.png";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Texto { get; set; }

        [Required]
        public string? FotoPerfil
        {
            get
            {
                return _fotoPerfil;
            }
            set
            {
                if (!string.IsNullOrEmpty(value)) _fotoPerfil = value;
            }
        }

    }
}
