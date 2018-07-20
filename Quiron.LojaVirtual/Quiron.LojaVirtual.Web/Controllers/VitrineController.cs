using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutoPorPagina = 8;


        // GET: Vitrine
        public ViewResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            ProdutoViewModel model = new ProdutoViewModel
            {

                 Produtos = _repositorio.Produtos
                .OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutoPorPagina)
                .Take(ProdutoPorPagina),

            Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutoPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()

                }
            };


            return View(model);
        }
    }
}