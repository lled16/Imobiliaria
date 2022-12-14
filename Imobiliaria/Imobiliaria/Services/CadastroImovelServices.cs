using Imobiliaria.Controllers;
using Imobiliaria.DataBase;
using Imobiliaria.DTO;
using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Imobiliaria.Services
{
    public class CadastroImovelServices
    {
        string strConnection = "server=DESKTOP-278IVMV;database=IMOBILIARIA;trusted_connection=true;Integrated Security=SSPI;TrustServerCertificate=True;";



        public string CadastroImovel(CadastroImovelModel Imovel)
        {

            string enderecoCompleto = "";

            try
            {
                List<CadastroImovelDTO> Imoveis = ListarImoveis();
                foreach (var imvl in Imoveis)
                {
                    if (imvl.CODIGO == Imovel.CODIGO)
                    {
                        return "Não foi possível cadastrar o imóvel, já existe outro com o mesmo código !";
                    }
                }
            }
            catch
            {
                throw new ArgumentException("Não foi possível verificar o código do imóvel, contate o administrador.");
            }


            try
            {
                ApiViaCepController apiViaCepController = new();
                enderecoCompleto = apiViaCepController.EnderecoPeloCep(Imovel.Cep);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Não foi possível buscar o endereço pelo CEP informado.");
            }

            CadastroImovelDTO imvlDTO = new();
            imvlDTO.Nome = Imovel.Nome;
            imvlDTO.QtdQuartos = Imovel.QtdQuartos;
            imvlDTO.QtdBanheiros = Imovel.QtdBanheiros;
            imvlDTO.Vagas = Imovel.Vagas;
            imvlDTO.ValorLocacao = Imovel.ValorLocacao;
            imvlDTO.CODIGO = Imovel.CODIGO;
            imvlDTO.Locado = Imovel.Locado;
            imvlDTO.CPF_LOCATARIO = "";
            imvlDTO.NOME_LOCATARIO = "";
            imvlDTO.EnderecoCompleto = enderecoCompleto;
            imvlDTO.Cep = Imovel.Cep;

            DataContext CadastroImovel = new();
            CadastroImovel.IMOVEIS.Add(imvlDTO);
            CadastroImovel.SaveChanges();


            return "Imóvel cadastrado com sucesso !";
        }





        public List<CadastroImovelDTO> ListarImoveis()
        {


            DataContext context = new();

            List<CadastroImovelDTO> Imoveis = new List<CadastroImovelDTO>();

            try
            {
                foreach (var imovel in context.IMOVEIS)
                {
                    Imoveis.Add(imovel);

                }
                return Imoveis;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Não foi possível listar os Imóveis, contate o administrador.");
            }
        }




        public string DeletaImovelPorID(int CODIGO)
        {
            List<CadastroImovelDTO> Imoveis = ListarImoveisPorCodigo(CODIGO);

            if (Imoveis[0].Locado == "NAO")
            {
                SqlConnection con = new SqlConnection(strConnection);
                con.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM IMOVEIS WHERE CODIGO =" + CODIGO, con);
                comando.ExecuteNonQuery();
                con.Close();

                return "Imóvel excluído com sucesso !";
            }
            else
            {
                return "Não é possível remover este imóvel pois o mesmo se encontra locado. !";
            }
        }





        public List<CadastroImovelDTO> ListarImoveisPorCodigo(int CODIGO)
        {

            DataContext context = new();

            List<CadastroImovelDTO> Imoveis = new List<CadastroImovelDTO>();

            try
            {
                foreach (var imovel in context.IMOVEIS)
                {
                    if (imovel.CODIGO == CODIGO)
                    {
                        Imoveis.Add(imovel);
                    }

                }
                return Imoveis;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Não foi possível listar os Imóveis, contate o administrador.");
            }
        }


        public string LocarImovel(string CPF, int CODIGO)
        {

            SqlConnection con = new SqlConnection(strConnection);
            Controllers.LocatarioController locatarioController = new();
            List<Models.CadastroLocatarioModel> Locatario = locatarioController.ListaClientesPorCPF(long.Parse(CPF));
            List<CadastroImovelDTO> Imoveis = ListarImoveisPorCodigo(CODIGO);

            if (Imoveis[0].Locado == "NAO"
                && string.IsNullOrEmpty(Imoveis[0].NOME_LOCATARIO)
                && string.IsNullOrEmpty(Imoveis[0].CPF_LOCATARIO))
            {


                con.Open();
                SqlCommand comando =
                new SqlCommand("UPDATE IMOVEIS SET LOCADO = 'SIM', " +
                               "CPF_LOCATARIO = @CPF_LOCATARIO, " +
                               "NOME_LOCATARIO = @NOME_LOCATARIO " +
                               "WHERE CODIGO = @CODIGO", con);

                comando.Parameters.Add(new SqlParameter("@CPF_LOCATARIO", Locatario[0].CPF));
                comando.Parameters.Add(new SqlParameter("@NOME_LOCATARIO", Locatario[0].Nome));
                comando.Parameters.Add(new SqlParameter("@CODIGO", CODIGO));

                comando.ExecuteNonQuery();
                con.Close();


                return "Imóvel locado com sucesso !";
            }
            else
            {
                return "Este imóvel já se encontra alugado.";
            }
        }


        public string RemoveLocacao(int CODIGO)
        {
            List<CadastroImovelDTO> Imoveis = ListarImoveisPorCodigo(CODIGO);


            if (Imoveis[0].Locado == "SIM")
            {
                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand comando =
                new SqlCommand("UPDATE IMOVEIS SET LOCADO = 'NAO', " +
                               "CPF_LOCATARIO = @CPF_LOCATARIO, " +
                               "NOME_LOCATARIO = @NOME_LOCATARIO " +
                               "WHERE CODIGO = @CODIGO", con);

                comando.Parameters.Add(new SqlParameter("@CPF_LOCATARIO", ""));
                comando.Parameters.Add(new SqlParameter("@NOME_LOCATARIO", ""));
                comando.Parameters.Add(new SqlParameter("@CODIGO", CODIGO));

                comando.ExecuteNonQuery();
                con.Close();


                return "Locação removida com sucesso !";
            }
            else
            {
                return "Este imóvel não se encontra locado.";
            }
        }
    }
}
