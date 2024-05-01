using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Models
{
    public class Destino
    {
        private string _foto = "https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Nome { get; set; }

        [Required]
        public double? Preco { get; set; }

        [Required]
        public string? Foto
        {
            get
            {
                return _foto;
            }
            set
            {
                if(!string.IsNullOrEmpty(value)) _foto = value;
            }
        }
    }
}
