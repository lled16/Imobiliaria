using Imobiliaria.DataBase;
using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Controllers
{
    public class LocatarioController
    {
        [HttpPost("CadastraLocatario")]
        public string CadastroLocatario(CadastroLocatarioModel Locatario)
        {


            DataContext CadastroLocatario = new();


            CadastroLocatario.LOCATARIO.Add(Locatario);
            CadastroLocatario.SaveChanges();

            return "Cliente cadastrado com sucesso !";
        }



        [HttpGet("ListaClientes")]
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

        [HttpGet("ListaClientesPorCPF")]
        public List<CadastroLocatarioModel> ListaClientesPorCPF(long CPF)
        {
            DataContext context = new();

            List<CadastroLocatarioModel> Clientes = new List<CadastroLocatarioModel>();

            try
            {
                foreach (var cliente in context.LOCATARIO)
                {
                    if (long.Parse(cliente.CPF) == CPF)
                    {
                        Clientes.Add(cliente);
                    }

                }
                return Clientes;
            }
            catch
            {
                throw new ArgumentException("Não foi possível listar os clientes, contate o administrador.");
            }

        }


    }
}
