using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.quiron.com.br";
        public int ServidorPorta = 587;
        public string Usuario = "Quiron";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"C:\Users\demerson.ferreira\Desktop\Projetos Entity\CrudMvcEntity\envioemail";
        public string De = "demerson_pt@hotmail.com";
        public string Para = "demenson6@gmail.com";
    }
}
