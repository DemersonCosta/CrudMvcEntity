using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspNet.ViewModels
{
    public class LoginViewModel
    {
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(50, ErrorMessage = "o login deve ter até 50 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o senha")]
        [MaxLength(6, ErrorMessage = "A senha ter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}