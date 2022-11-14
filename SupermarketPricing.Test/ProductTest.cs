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
            Assert.Throws<ArgumentNullException>(() => new Product("", ProductUnit.Cup));
        }
    }
}
