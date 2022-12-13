using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.DTO
{
    public class CadastroImovelDTO
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
        public string? NOME_LOCATARIO { get; set; }
        public string? CPF_LOCATARIO { get; set; }

        [MaxLength(8)]
        [Required]
        public string? Cep { get; set; }
        public string EnderecoCompleto { get; set; }


    }
}
