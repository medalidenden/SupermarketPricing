using SuperMarketPricing.Domain;
using SuperMarketPricing.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace SupermarketPricing.Test
{
    public class SupermarketPricingTest
    {
        private Market _market;
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
            _superMarketPricer.AddToShoppingList(new Product("Soda"));
            _superMarketPricer.AddToShoppingList(new Product("Fromage"));
            _superMarketPricer.AddToShoppingList(new Product("Portable"));
            _superMarketPricer.AddToShoppingList(new Product("Pomme"));

            //Act
            var result = _superMarketPricer.CalculateTotalAmount();

            //Assert
            Assert.Equal(177.4M, result);
        }

        [Fact]
        public void ReturnTotalAmountForSpecialOffers()
        {
            // Arrange
            Setup();
            _superMarketPricer.AddToShoppingList(new Product("Soda"));
            _superMarketPricer.AddToShoppingList(new Product("Soda"));
            _superMarketPricer.AddToShoppingList(new Product("Soda"));
            _superMarketPricer.AddToShoppingList(new Product("Fromage"));
            _superMarketPricer.AddToShoppingList(new Product("Fromage"));
            _superMarketPricer.AddToShoppingList(new Product("Portable"));
            _superMarketPricer.AddToShoppingList(new Product("Pomme"));

            //Act
            var result = _superMarketPricer.CalculateTotalAmount();

            //Assert
            Assert.Equal(281.4M, result);
        }

        void Setup()
        {
            _market = new Market
            {
                PriceCatalog = new PriceCatalog
                {
                    priceOffers = new List<PriceOffer>
                    {
                        new PriceOffer{product = new Product("Soda" ),Price = 30.2M,Offer = "3 for 130", category = Category.SpecialPrice},
                        new PriceOffer{product = new Product("Fromage"),Price = 40.8M, Offer = "2 for 45", category = Category.SpecialPrice },
                        new PriceOffer{product = new Product("Portable"),Price = 50.9M, Offer = "", category = Category.NoOffer },
                        new PriceOffer{product = new Product("Pomme"),Price = 55.5M,Offer = "", category = Category.NoOffer},
                    }
                }
            };
            _superMarketPricer = new SuperMarketPricer(_market);
        }
    }
}
