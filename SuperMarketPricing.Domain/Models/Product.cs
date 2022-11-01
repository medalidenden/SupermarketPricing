using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        private string name { get; set; }
        private ProductUnit unit;

        public Product(string name, ProductUnit unit)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name)); }
            this.name = name;
            this.unit = unit;
        }

        public string getName()
        {
            return name;
        }
        public ProductUnit getUnit()
        {
            return unit;
        }

    }
}
