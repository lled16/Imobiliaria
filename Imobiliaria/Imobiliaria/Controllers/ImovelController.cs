using Imobiliaria.DataBase;
using Imobiliaria.DTO;
using Imobiliaria.Models;
using Imobiliaria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Imobiliaria.Controllers
{
    public class ImovelController
    {
        private CadastroImovelServices _imovelServices = new();

        [HttpPost("CadastraImovel")]
        public string CadastroImovel(CadastroImovelModel Imovel)
        {
            string cadastrandoImovel = _imovelServices.CadastroImovel(Imovel);

            return cadastrandoImovel;
        }

        [HttpDelete("DeletaImovel")]
        public string DeletaImovel(int CODIGO)
        {
            string retornoDeletar = _imovelServices.DeletaImovelPorID(CODIGO);

            return retornoDeletar;

           
        }

        [HttpGet("ListaImoveis")]
        public List<CadastroImovelDTO> ListaImoveis()
        {
            List<CadastroImovelDTO> imoveis = _imovelServices.ListarImoveis();

            return imoveis;

        }

        [HttpGet("ListaImoveisPorCodigo")]
        public List<CadastroImovelDTO> ListaImoveisPorCodigo(int CODIGO)
        {
            List<CadastroImovelDTO> imoveis = _imovelServices.ListarImoveisPorCodigo(CODIGO);
            return imoveis;
        }

        [HttpPut("LocarImovel")]
        public string LocarImovel(string CPF, int CODIGO)
        {
            string locandoImovel = _imovelServices.LocarImovel(CPF, CODIGO);

            return locandoImovel;

        }

        [HttpPut("RemoveLocacao")]
        public string RemoveLocacao(int CODIGO)
        {
            string removeLocacaoImovel = _imovelServices.RemoveLocacao(CODIGO);

            return removeLocacaoImovel;
        }
    }
}
