using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoTeste.Areas.Admin.Models
{
    //Enable-Migrations
    //add-Migration
    // Update-database
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            this.Endereco = new Endereco();
        }      

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        public virtual Endereco Endereco { get; set; }

        //public TipoUsuario Tipo { get; set; } = TipoUsuario.Padrão;
    }
}