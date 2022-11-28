using SuperMarketPricing.Domain;
using SuperMarketPricing.Domain.Models;
using System;
using Xunit;

namespace SupermarketPricing.Test
{
    public class PriceOfferTest
    {
        private IPricingModel _priceModel;
        private PriceOffer _priceOffer;

        [Theory]
        [InlineData(0, 0)]
        public void ReturnZeroForNoProduct(int quantity, decimal expected)
        {
            //Arrange;
            Setup(1);
            _priceModel = new ReturnDefaultPrice();

            //act
            var result = _priceModel.ComputePriceForProduct(quantity, _priceOffer);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2)]
        public void ThrowExceptionForNoOffer(int quantity)
        {
            //Arrange;
            Setup(5);
            _priceModel = new BuyXforYPrice();

            //Assert
            Assert.Throws<ArgumentNullException>(() => _priceModel.ComputePriceForProduct(quantity, _priceOffer));
        }

        [Theory]
        [InlineData(3, 130)]
        public void ReturnAmountForSpecialOffer(int quantity, decimal expected)
        {
            //Arrange;
            Setup(1);
            _priceModel = new BuyXforYPrice();

            //act
            var result = _priceModel.ComputePriceForProduct(quantity, _priceOffer);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 120)]
        public void ReturnAmountForFreeOffer(int quantity, decimal expected)
        {
            //Arrange;
            Setup(2);
            _priceModel = new BuyXgetYForFree();
            //act
            var result = _priceModel.ComputePriceForProduct(quantity, _priceOffer);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 20)]
        public void ReturnAmountForWeightedOffer(int quantity, decimal expected)
        {
            //Arrange;
            Setup(3);
            _priceModel = new BuyXunitForYprice();

            //act
            var result = _priceModel.ComputePriceForProduct(quantity, _priceOffer);

            //Assert
            Assert.Equal(expected, result);
        }

        void Setup(int option)
        {
            _priceOffer = new PriceOffer();
            switch (option)
            {
                case 1:
                    _priceOffer.Offer = "3 for 130";
                    _priceOffer.Price = 30M;
                    break;
                case 2:
                    _priceOffer.Offer = "5 get 3";
                    _priceOffer.Price = 40M;
                    break;
                case 3:
                    _priceOffer.Offer = "2 Liter for 20";
                    _priceOffer.Product = new Product("Lait", ProductUnit.Liter);
                    _priceOffer.Price = 40M;
                    break;
                default:
                    _priceOffer.Offer = "";
                    _priceOffer.Price = 20M;
                    break;

            }
        }
    }
}
