using Imobiliaria.DataBase;
using Imobiliaria.Models;

namespace Imobiliaria.Services
{
    public class LocatarioServices
    {
        public string CadastrandoLocatario(CadastroLocatarioModel Locatario)
        {

            DataContext CadastroLocatario = new();


            CadastroLocatario.LOCATARIO.Add(Locatario);
            CadastroLocatario.SaveChanges();

            return "Cliente cadastrado com sucesso !";
        }

        public List<CadastroLocatarioModel> ListaClientes()
        {

            DataContext context = new();

            List<CadastroLocatarioModel> Clientes = new List<CadastroLocatarioModel>();

            try
            {
                foreach (var cliente in context.LOCATARIO)
                {
                    Clientes.Add(cliente);

                }
                return Clientes;
            }
            catch
            {
                throw new ArgumentException("Não foi possível listar os clientes, contate o administrador.");
            }
        }

        public List<CadastroLocatarioModel> ListaClientesPorCPF(long CPF)
        {

            DataContext context = new();

            List<CadastroLocatarioModel> ClientesPorCPF = new List<CadastroLocatarioModel>();

            try
            {
                foreach (var cliente in context.LOCATARIO)
                {
                    if (long.Parse(cliente.CPF) == CPF)
                    {
                        ClientesPorCPF.Add(cliente);
                    }

                }
                return ClientesPorCPF;
            }
            catch
            {
                throw new ArgumentException("Não foi possível listar os clientes, contate o administrador.");
            }
        }
    }
}
