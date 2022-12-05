
using SuperMarketPricing.Domain.Models;
using Xunit;

namespace SupermarketPricing.Test
{
    public class CartTest
    {
        private Cart _cart;

        [Theory]
        [InlineData(1)]
        public void ReturnZeroForNoProduct(int expected)
        {
            //Arrange;
            _cart = new Cart();

            //act
            _cart.AddToShoppingList(new Product("produit", ProductUnit.Each));

            //Assert
            Assert.Equal(_cart.GetListProductByName().Count, expected);
        }
    }
}
