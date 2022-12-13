using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Models
{

    public class CadastroImovelModel
    {
        [Key]
        [Required]
        public int CODIGO { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int QtdQuartos { get; set; }
        [Required]
        public int QtdBanheiros { get; set; }
        [Required]
        public int Vagas { get; set; }
        [Required]
        public double ValorLocacao { get; set; }
        [Required]
        public string Locado { get; set; }

        [MaxLength(8)]
        [Required]
        public string? Cep
        {
            get; set;

        }
    }
}
