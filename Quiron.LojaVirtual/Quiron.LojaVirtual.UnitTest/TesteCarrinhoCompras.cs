using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Web.Controllers;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {

        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            Produto p1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste",
                Preco = 300               
            };

            Produto p2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2",
                Preco = 200
            };
            Produto p3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste3",
                Preco = 100
            };

            //Arrange
            Carrinho carrinho = new Carrinho();            

            carrinho.AdicionarItem(p2, 1);
            carrinho.AdicionarItem(p1, 1);
            carrinho.AdicionarItem(p1, 2);
            carrinho.AdicionarItem(p1, 3);
            //carrinho.RemoverItem(p1);

            // var totalCarrinho =  carrinho.ObterValorTotal();

            //Act
            //ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();
            //Assert.AreEqual(itens.Length, 2);

            ItemCarrinho[] resultado = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2);

        } 
    }
}
