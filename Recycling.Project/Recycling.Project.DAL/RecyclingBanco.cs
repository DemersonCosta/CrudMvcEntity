using Recycling.Project.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Recycling.Project.DAL
{
    public class RecyclingBanco : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public RecyclingBanco()
        {
            DropCreateDatabaseIfModelChanges<RecyclingBanco> initializar =
            new DropCreateDatabaseIfModelChanges<RecyclingBanco>();
            Database.SetInitializer<RecyclingBanco>(initializar);

            //Mostrar no log a instrução
            //Database.Log = instrucao => System.Diagnostics.Debug.WriteLine(instrucao);
        }


    }
}
