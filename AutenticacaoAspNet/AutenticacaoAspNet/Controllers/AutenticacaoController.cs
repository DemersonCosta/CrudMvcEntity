﻿using AutenticacaoAspNet.Models;
using AutenticacaoAspNet.ViewModels;
using System.Security.Policy;
using System.Web.Mvc;
using AutenticacaoAspNet.Utils;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System;

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

            TempData["Mensagem"] = "Cadastro realizado com sucesso. Efetue login";

            return RedirectToAction("Index", "Painel");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == viewmodel.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewmodel);
            }

            if (usuario.Senha != Utils.Hash.GerarHash(viewmodel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha Incorreta");
                return View(viewmodel);
            }
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login),
                new Claim(ClaimTypes.Role, usuario.Tipo.ToString())
            },"ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno) || Url.IsLocalUrl(viewmodel.UrlRetorno))
                return Redirect(viewmodel.UrlRetorno);
            else
                return RedirectToAction("Index", "Painel");          
            
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}