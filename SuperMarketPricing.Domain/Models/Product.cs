using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        public string name { get; set; }

        public ProductUnit unit { get; set; }

        public Product(string name, ProductUnit unit)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name)); }
            this.name = name;
            this.unit = unit;
        }
    }
}
