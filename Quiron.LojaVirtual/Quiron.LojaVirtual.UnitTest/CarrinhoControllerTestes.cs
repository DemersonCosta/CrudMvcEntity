using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Web.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemCarrinho()
        {

            Produto p1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste"
            };
            Produto p2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste3"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(p1, 3);

            carrinho.AdicionarItem(p2, 2);

            CarrinhoController controller = new CarrinhoController();

            //Action
            controller.Adicionar(carrinho, 2, " ");

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);

            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId, 1);

        }

        [TestMethod]
        public void Adiciono_Porduto_No_Carrinho_Volta_Para_A_Categoria()
        {
            //preparação (Arrange e o estímulo (Act), das verificações (Asserts)

            //Arrange
            Carrinho carrinho = new Carrinho();

            //A
            CarrinhoController controller = new CarrinhoController();

            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");

            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");

        }



    }
}
