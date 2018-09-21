using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        public EfDbContext() : base("QuironDatabase")
        {
            //Database.SetInitializer<EfDbContext>(
            //  new CreateDatabaseIfNotExists<EfDbContext>());
            //Database.Initialize(false);

            //Mostrar no log a instrução
            //Database.Log = instrucao => System.Diagnostics.Debug.WriteLine(instrucao);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
        }

    }
}
