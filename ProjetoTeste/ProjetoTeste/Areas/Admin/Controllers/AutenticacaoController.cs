using ProjetoTeste.Areas.Admin.Models;
using ProjetoTeste.Models.Contexto;
using ProjetoTeste.Models.ViewModels;
using ProjetoTeste.Utils;
using System.Web.Mvc;

namespace ProjetoTeste.Areas.Admin.Controllers
{
    public class AutenticacaoController : Controller
    {
        private ContextoDb db = new ContextoDb();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            Usuario novousuario = new Usuario();

            novousuario.Nome = viewmodel.Nome;
            novousuario.Email = viewmodel.Email;
            novousuario.Login = viewmodel.Login;
            novousuario.Senha = Hash.GerarHash(viewmodel.Senha);
            novousuario.Endereco.Pais = viewmodel.Pais;
            novousuario.Endereco.Estado = viewmodel.Estado;
            novousuario.Endereco.Cidade = viewmodel.Cidade;
            novousuario.Endereco.Logradouro = viewmodel.Logradouro;
            novousuario.Endereco.Numero = viewmodel.Numero;
            novousuario.Endereco.Complemento = viewmodel.Complemento;
            novousuario.Endereco.Cep = viewmodel.Cep;

            db.Usuarios.Add(novousuario);
            db.SaveChanges();

            return RedirectToAction("Index","Painel");
        }
    }
}