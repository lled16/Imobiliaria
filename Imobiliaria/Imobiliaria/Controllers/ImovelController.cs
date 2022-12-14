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
            string CadastrandoImovel = _imovelServices.CadastroImovel(Imovel);

            return CadastrandoImovel;
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
            List<CadastroImovelDTO> Imoveis = _imovelServices.ListarImoveis();

            return Imoveis;

        }

        [HttpGet("ListaImoveisPorCodigo")]
        public List<CadastroImovelDTO> ListaImoveisPorCodigo(int CODIGO)
        {
            List<CadastroImovelDTO> Imoveis = _imovelServices.ListarImoveisPorCodigo(CODIGO);
            return Imoveis;
        }

        [HttpPut("LocarImovel")]
        public string LocarImovel(string CPF, int CODIGO)
        {
            string LocandoImovel = _imovelServices.LocarImovel(CPF, CODIGO);

            return LocandoImovel;

        }

        [HttpPut("RemoveLocacao")]
        public string RemoveLocacao(int CODIGO)
        {
            string RemoveLocacaoImovel = _imovelServices.RemoveLocacao(CODIGO);

            return RemoveLocacaoImovel;
        }
    }
}
