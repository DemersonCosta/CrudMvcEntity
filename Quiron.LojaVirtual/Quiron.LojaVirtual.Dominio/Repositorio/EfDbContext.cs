using Quiron.LojaVirtual.Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public EfDbContext()
        { 
            // Mostrar no log a instrução
            //Database.Log = instrucao => System.Diagnostics.Debug.WriteLine(instrucao);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
           
            
        }

    }
}
