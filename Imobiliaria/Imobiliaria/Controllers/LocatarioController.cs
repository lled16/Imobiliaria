using Imobiliaria.DataBase;
using Imobiliaria.Models;
using Imobiliaria.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Imobiliaria.Controllers
{
    public class LocatarioController
    {
        private LocatarioServices _locatarioServices = new();


        [HttpPost("CadastraLocatario")]
        public string CadastroLocatario(CadastroLocatarioModel Locatario)
        {
            string cadastrandoLocatario = _locatarioServices.CadastrandoLocatario(Locatario);
            return cadastrandoLocatario;

        }

        [HttpGet("ListaClientes")]
        public List<CadastroLocatarioModel> ListaClientes()
        {
            List<CadastroLocatarioModel> clientes = _locatarioServices.ListaClientes();

            return clientes;

        }

        [HttpGet("ListaClientesPorCPF")]
        public List<CadastroLocatarioModel> ListaClientesPorCPF(long CPF)
        {

            List<CadastroLocatarioModel> clientesPorCPF = _locatarioServices.ListaClientesPorCPF(CPF);
            return clientesPorCPF;
        }


    }
}
