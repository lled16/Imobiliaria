using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Models
{
    public class CadastroLocatarioModel
    {
        [Key]
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public double Renda { get; set; }
    }
}
