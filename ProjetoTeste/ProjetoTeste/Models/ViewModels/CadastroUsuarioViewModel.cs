using ProjetoTeste.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoTeste.Models.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu Email")]
        [MaxLength(100, ErrorMessage = "O e-mail deve ter até 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]       
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]        
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme senha")]
        [MinLength(6, ErrorMessage = "Confirme senha")]
        [Compare(nameof(Senha), ErrorMessage = "A senha e a confirmação não estão iguais")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Informe seu Pais")]
        [MaxLength(100)]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Informe seu Estado")]
        [MaxLength(100)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe sua Cidade")]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe seu Logradouro")]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe Numero da Casa")]
        [MaxLength(20)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe Complemento da Casa")]
        [MaxLength(100)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe seu Cep")]
        [MaxLength(15)]
        public string Cep { get; set; }


    }
}