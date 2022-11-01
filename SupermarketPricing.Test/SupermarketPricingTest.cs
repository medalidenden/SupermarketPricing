using SuperMarketPricing.Domain;
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

        void Setup()
        {
            _superMarketPricer = new SuperMarketPricer();
        }
    }
}
