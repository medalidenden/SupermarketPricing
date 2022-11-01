using SuperMarketPricing.Domain.IServices;
using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product : IProduct
    {
        private string name { get; set; }
        private decimal price { get; set; }

        public Product(string name,decimal price)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name)); }
            this.name = name;
            this.price = price;
        }

        public string getName()
        {
            return name;
        }

        public decimal getPrice()
        {
            return price;
        }
    }
}
