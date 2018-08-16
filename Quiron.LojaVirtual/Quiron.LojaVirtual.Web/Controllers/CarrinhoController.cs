using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;
        // GET: Carrinho
        public RedirectToRouteResult Adicionar( int produtoId, String returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }
            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            Carrinho carrinho = ObterCarrinho();          
           
            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possivel concluir o pedido, seu carrinho esta vazio");
            }
            if (ModelState.IsValid)
            {
                GmailEmailService gmail = new GmailEmailService();
                EmailMessage msg = new EmailMessage();
                msg.Body = gmail.CorpoEmail(carrinho, pedido);
                msg.IsHtml = true;
                msg.Subject = "Pedido Processado";
                msg.ToEmail = pedido.Email;
                gmail.SendEmailMessage(msg);
               
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else { return View(pedido); }
            
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}