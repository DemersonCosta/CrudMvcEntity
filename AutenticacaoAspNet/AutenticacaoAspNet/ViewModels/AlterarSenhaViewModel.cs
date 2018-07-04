using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutenticacaoAspNet.ViewModels
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "Informe sua senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        [MinLength(6, ErrorMessage = " A senha deve ter pelo menos 6 caracteres")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informe sua nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "nova senha")]
        [MinLength(6, ErrorMessage = " A nova senha deve ter pelo menos 6 caracteres")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme sua nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme senha")]
        [MinLength(6, ErrorMessage = " A senha e a confirmação não estão iguais")]
        public string ConfirmacaoSenha { get; set; }

    }
}