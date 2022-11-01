using SuperMarketPricing.Domain;
using SuperMarketPricing.Domain.Models;
using Xunit;

namespace SupermarketPricing.Test
{
    public class SupermarketPricingTest
    {
        private SuperMarketPricer _superMarketPricer;
        [Fact]
        public void ReturnZeroForEmptyCheckoutList()
        {
            //Arrange;
            Setup();
            //Act
            var result = _superMarketPricer.CalculateTotalAmount();

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnTotalAmountForSimplePricing()
        {
            //Arrange
            Setup();
            _superMarketPricer.AddToShoppingList(new Product("Soda",15M));
            _superMarketPricer.AddToShoppingList(new Product("Fromage", 20M));
            _superMarketPricer.AddToShoppingList(new Product("Portable", 30M));
            _superMarketPricer.AddToShoppingList(new Product("Pomme", 40M));

            //Act
            var result = _superMarketPricer.CalculateTotalAmount();

            //Assert
            Assert.Equal(105M, result);
        }

        void Setup()
        {
            _superMarketPricer = new SuperMarketPricer();
        }
    }
}
