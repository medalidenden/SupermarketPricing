using System;

namespace SuperMarketPricing.Domain.Models
{
    public class PriceOffer
    {
        public string Offer { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
