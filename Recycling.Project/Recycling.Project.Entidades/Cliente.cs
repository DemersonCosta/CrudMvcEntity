using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycling.Project.Entidades
{
    [Table("Clientes")]
    public class Cliente
    {        
        public long ID { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public Endereco Endereco { get; set; }


    }
}
