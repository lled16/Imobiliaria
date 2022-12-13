using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Models
{
    public class ListaImoveisModel
    {
    
            [Key]
            public int CODIGO { get; set; }
            public string Nome { get; set; }
            public int QtdQuartos { get; set; }
            public int QtdBanheiros { get; set; }
            public int Vagas { get; set; }
            public double ValorLocacao { get; set; }
            public string Locado { get; set; }
            public string? NOME_LOCATARIO { get; set; }
            public string? CPF_LOCATARIO { get; set; }

            [MaxLength(8)]
            public string? Cep { get; set; }
            public string EnderecoCompleto { get; set; }

    }
}
