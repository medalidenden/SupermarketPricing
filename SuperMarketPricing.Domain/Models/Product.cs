using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        private string name { get; set; }

        public Product(string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name)); }
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

    }
}
