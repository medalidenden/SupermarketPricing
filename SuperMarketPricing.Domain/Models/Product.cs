using SuperMarketPricing.Domain.Interfaces;
using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        public string Name { get; private set; }
        public int Total { get; private set; }
        public ProductUnit Unit { get; private set; }
        private IPriceCalculator pricecalculator;

        public Product(string _name, ProductUnit _unit)
        {
            if (string.IsNullOrEmpty(_name)) { throw new ArgumentNullException(nameof(_name)); }
            Name = _name;
            Unit = _unit;
            Total = 1;
        }
        public decimal GetPrice(int quantity, PriceOffer offer)
        {
            if (offer == null)
                throw new ArgumentNullException("Mandatory parameter", nameof(offer));

            pricecalculator = new PriceCalculator();
            pricecalculator.SetPriceStrategy(offer.Category);
            return pricecalculator.ComputePriceForProduct(quantity, offer);
        }

        public void AddItem()
        {
            Total++;
        }
    }
}
