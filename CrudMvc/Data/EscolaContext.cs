using Domain;
using System.Data.Entity;

namespace Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext() : base("Name=EscolaDb")
        {
            Database.SetInitializer<EscolaContext>(
                new CreateDatabaseIfNotExists<EscolaContext>());
            Database.Initialize(false);
        }

        public DbSet<Aluno> Alunos { get; set; }
        //public DbSet<Loja> Lojas { get; set; }
    }
}
