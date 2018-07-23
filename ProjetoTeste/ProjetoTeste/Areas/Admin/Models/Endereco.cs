using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoTeste.Areas.Admin.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Pais { get; set; }

        [Required]
        [MaxLength(100)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(100)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(100)]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(15)]
        public string Cep { get; set; }
    }
}