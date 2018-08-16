using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recycling.Project.Entidades
{
    [Table("Enderecos")]
    public class Endereco
    {
       
        public long ID{ get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Complemto { get; set; }

    }
}
