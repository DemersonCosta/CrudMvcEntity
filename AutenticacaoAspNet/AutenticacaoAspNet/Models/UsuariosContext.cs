using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutenticacaoAspNet.Models
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext() : base("Usuarios")
        {
            Database.SetInitializer<UsuariosContext>(
                new CreateDatabaseIfNotExists<UsuariosContext>());
            Database.Initialize(false);
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}