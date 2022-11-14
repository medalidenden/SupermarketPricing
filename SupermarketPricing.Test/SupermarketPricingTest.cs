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
            _superMarketPricer.AddToShoppingList(new Product("Soda", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Fromage", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Portable", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Pomme", ProductUnit.Kilo));

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
            _superMarketPricer.AddToShoppingList(new Product("Soda", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Soda", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Soda", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Fromage", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Fromage", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Portable", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Pomme", ProductUnit.Each));

            //Act
            var result = _superMarketPricer.CalculateTotalAmount();

            //Assert
            Assert.Equal(281.4M, result);
        }

        [Fact]
        public void ReturnTotalAmountForSpecialFreeProducts()
        {
            //Arrange
            Setup();
            _superMarketPricer.AddToShoppingList(new Product("Soda", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Fromage", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Portable", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Pomme", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Banane", ProductUnit.Kilo));
            _superMarketPricer.AddToShoppingList(new Product("Banane", ProductUnit.Kilo));
            _superMarketPricer.AddToShoppingList(new Product("Banane", ProductUnit.Kilo));
            _superMarketPricer.AddToShoppingList(new Product("Banane", ProductUnit.Kilo));
            _superMarketPricer.AddToShoppingList(new Product("Banane", ProductUnit.Kilo));
            _superMarketPricer.AddToShoppingList(new Product("Banane", ProductUnit.Kilo));

            //Act
            var result = _superMarketPricer.CalculateTotalAmount();

            //Assert
            Assert.Equal(217.8M, result);
        }

        [Fact]
        public void ReturnTotalAmountForWeightedProducts()
        {
            //Arrange
            Setup();
            _superMarketPricer.AddToShoppingList(new Product("Portable", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Pomme", ProductUnit.Each));
            _superMarketPricer.AddToShoppingList(new Product("Lait", ProductUnit.Liter));
            _superMarketPricer.AddToShoppingList(new Product("Lait", ProductUnit.Liter));
            _superMarketPricer.AddToShoppingList(new Product("Lait", ProductUnit.Liter));

            //Act
            var result = _superMarketPricer.CalculateTotalAmount();

            //Assert
            Assert.Equal(151.6M, result);
        }

        void Setup()
        {
            _market = new Market();
            _market.PriceCatalog = new PriceCatalog();
            _market.PriceCatalog.AddPriceOffer(new PriceOffer { Product = new Product("Soda", ProductUnit.Each), Price = 30.2M, Offer = "3 for 130", Category = Category.SpecialPrice });
            _market.PriceCatalog.AddPriceOffer(new PriceOffer { Product = new Product("Fromage", ProductUnit.Each), Price = 40.8M, Offer = "2 for 45", Category = Category.SpecialPrice });
            _market.PriceCatalog.AddPriceOffer(new PriceOffer { Product = new Product("Portable", ProductUnit.Each), Price = 50.9M, Offer = "", Category = Category.NoOffer });
            _market.PriceCatalog.AddPriceOffer(new PriceOffer { Product = new Product("Pomme", ProductUnit.Kilo), Price = 55.5M, Offer = "", Category = Category.NoOffer });
            _market.PriceCatalog.AddPriceOffer(new PriceOffer { Product = new Product("Banane", ProductUnit.Kilo), Price = 10.1M, Offer = "5 get 3", Category = Category.FreeProduct });
            _market.PriceCatalog.AddPriceOffer(new PriceOffer { Product = new Product("Lait", ProductUnit.Liter), Price = 25.2M, Offer = "2 Liter for 20", Category = Category.WeightedProducts });
            _superMarketPricer = new SuperMarketPricer(_market);
        }
    }
}
