using Imobiliaria.Models;
using Imobiliaria.DTO;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.DataBase
{
    public class DataContext : DbContext
    {
        public virtual DbSet<CadastroImovelDTO> IMOVEIS { get; set; }
        public virtual DbSet<CadastroLocatarioModel> LOCATARIO { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-278IVMV;database=IMOBILIARIA;trusted_connection=true;Integrated Security=SSPI;TrustServerCertificate=True;");


        }
    }
}
