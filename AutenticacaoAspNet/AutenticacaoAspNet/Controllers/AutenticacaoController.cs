using AutenticacaoAspNet.Models;
using AutenticacaoAspNet.ViewModels;
using System.Security.Policy;
using System.Web.Mvc;
using AutenticacaoAspNet.Utils;
using System.Linq;

namespace AutenticacaoAspNet.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();

        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viemodel)
        {
            if (!ModelState.IsValid)
            { 
                return View(viemodel);
            }
            if (db.Usuarios.Count(u => u.Login == viemodel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login já está em uso");
                return View(viemodel);
            }
            Usuario novoUsuario = new Usuario
            {
                Nome = viemodel.Nome,
                Login = viemodel.Login,
                Senha = Utils.Hash.GerarHash(viemodel.Senha)
            };

            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login(string ReturnoUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnoUrl
            };

            return View(viewmodel);
        }
    }
}