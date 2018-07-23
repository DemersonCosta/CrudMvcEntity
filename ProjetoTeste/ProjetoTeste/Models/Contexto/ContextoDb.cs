using ProjetoTeste.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjetoTeste.Models.Contexto
{
    public class ContextoDb : DbContext
    {
        public ContextoDb() : base("StringBanco")
        {
            Database.SetInitializer<ContextoDb>(
                new CreateDatabaseIfNotExists<ContextoDb>());
            Database.Initialize(false);      

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


    }
}