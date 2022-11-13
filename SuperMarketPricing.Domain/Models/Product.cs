using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        public string Name { get; set; }

        public ProductUnit Unit { get; set; }

        public Product(string name, ProductUnit unit)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name)); }
            Name = name;
            Unit = unit;
        }
    }
}
