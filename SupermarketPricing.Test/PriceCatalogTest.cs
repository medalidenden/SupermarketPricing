using SuperMarketPricing.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SupermarketPricing.Test
{
    public class PriceCatalogTest
    {
        private PriceCatalog _priceCatalog;

        [Theory]
        [InlineData(0, "Pomme", 55.5)]
        public void ReturnZeroForNoOffer(int quantity, string name, decimal expected)
        {
            //Arrange 
            Setup();

            //Act
            _priceCatalog.AddPriceOffer(new PriceOffer { Product = new Product(name, ProductUnit.Kilo), Price = 55.5M, Offer = "", Category = Category.NoOffer });
            var result = _priceCatalog.ComputePriceForProduct(name, quantity);

            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(2, "Fromage", 45)]
        public void ComputePriceForSpecialProduct(int quantity, string name, decimal expected)
        {
            //Arrange 
            Setup();

            //Act
            _priceCatalog.AddPriceOffer(new PriceOffer { Product = new Product(name, ProductUnit.Each), Price = 40.8M, Offer = "2 for 45", Category = Category.SpecialPrice });
            var result = _priceCatalog.ComputePriceForSpecialOfferProducts(name, quantity);

            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(5, "Banane", 30.3)]
        public void ComputePriceForFreeProduct(int quantity, string name, decimal expected)
        {
            //Arrange 
            Setup();

            //Act
            _priceCatalog.AddPriceOffer(new PriceOffer { Product = new Product(name, ProductUnit.Kilo), Price = 10.1M, Offer = "5 get 3", Category = Category.FreeProduct });
            var result = _priceCatalog.ComputePriceForFreeProductOffer(name, quantity);

            //Assert
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(2, "Lait", 20)]
        public void ComputePriceForWeightedProducts(int quantity, string name, decimal expected)
        {
            //Arrange 
            Setup();

            //Act
            _priceCatalog.AddPriceOffer(new PriceOffer { Product = new Product(name, ProductUnit.Liter), Price = 25.2M, Offer = "2 Liter for 20", Category = Category.WeightedProducts });
            var result = _priceCatalog.ComputePriceForWeightedProductsOffer(name, quantity);

            //Assert
            Assert.Equal(result, expected);
        }

        void Setup()
        {
            _priceCatalog = new PriceCatalog() { PriceOffers = new List<PriceOffer>() };
        }
    }
}