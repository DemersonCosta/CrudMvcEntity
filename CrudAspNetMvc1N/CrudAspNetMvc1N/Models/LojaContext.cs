using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudAspNetMvc1N.Models
{
    public class LojaContext :DbContext
    {
        public LojaContext() : base("Loja")
        {
            Database.SetInitializer<LojaContext>(
               new CreateDatabaseIfNotExists<LojaContext>());
            Database.Initialize(false);

            //Mostrar no log a instrução
            //Database.Log = instrucao => System.Diagnostics.Debug.WriteLine(instrucao);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Consultor> Consultores { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
    }
}