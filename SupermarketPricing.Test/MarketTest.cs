using SuperMarketPricing.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace SupermarketPricing.Test
{
    public class MarketTest
    {
        private Market _market;

        [Theory]
        [InlineData(2)]
        public void ReturnZeroForNoProduct(int expected)
        {
            //Arrange;
            Setup();

            //act
            _market.AddPriceOffer(new PriceOffer { Product = new Product("Soda", ProductUnit.Each), Price = 30.2M, Offer = "3 for 130", Category = Category.SpecialPrice });
            _market.AddPriceOffer(new PriceOffer { Product = new Product("Portable", ProductUnit.Each), Price = 50.9M, Offer = "", Category = Category.NoOffer });

            //Assert
            Assert.Equal(_market.PriceOffers.Count, expected);
        }
        void Setup()
        {
            _market = new Market();
            _market.PriceOffers = new List<PriceOffer>();
        }
    }
}
