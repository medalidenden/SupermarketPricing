using FluentAssertions;
using Moq;
using SuperMarketPricing.Domain.Models;
using System;
using Xunit;

namespace SupermarketPricing.Test
{
    public class ProductTest
    {
        [Fact]
        public void ThrowExceptionWhenNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(It.IsAny<string>(), It.IsAny<ProductUnit>()));
        }

        [Theory]
        [InlineData("test")] 
        public void ShouldCreateProduct(string name)
        {
            //Act 
            var result = new Product(name, It.IsAny<ProductUnit>());

            //Asser
            Assert.NotNull(result);
            result.Name.Should().NotBeNull();
        }
    }
}
