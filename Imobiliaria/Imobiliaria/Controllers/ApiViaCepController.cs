using Imobiliaria.Models;
using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;

namespace Imobiliaria.Controllers
{
    public class ApiViaCepController
    {

        public string EnderecoPeloCep(string cep)
        {
            string enderecoCompleto = "";

            string urlApi = $"https://viacep.com.br/ws/{cep}/json";
            try
            {
                using (var cliente = new HttpClient())
                {
                    var request = cliente.GetStringAsync(urlApi);
                    request.Wait();

                    var response = JsonConvert.DeserializeObject<EnderecoViaCepModel>(request.Result);

                    enderecoCompleto = response.Logradouro + ", " +  
                                       response.Bairro+ ", " + 
                                       response.Localidade + "-" + 
                                       response.uf;

                    return enderecoCompleto;
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Não foi possível buscar o endereço pelo CEP informado.");
            }

        }
    }
}
