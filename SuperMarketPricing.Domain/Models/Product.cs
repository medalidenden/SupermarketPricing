using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        public string Name { get; private set; }
        public int Total { get; private set; }
        public ProductUnit Unit { get; private set; }

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

            PriceCalculator pricecalculator = new PriceCalculator();
            switch (offer.Category)
            {
                case Category.FreeProduct:
                    pricecalculator.SetPriceStrategy(new BuyXgetYForFree());
                    return pricecalculator.ComputePriceForProduct(quantity, offer);

                case Category.SpecialPrice:
                    pricecalculator.SetPriceStrategy(new BuyXforYPrice());
                    return pricecalculator.ComputePriceForProduct(quantity, offer);

                case Category.WeightedProducts:
                    pricecalculator.SetPriceStrategy(new BuyXunitForYprice());
                    return pricecalculator.ComputePriceForProduct(quantity, offer);

                default:
                    pricecalculator.SetPriceStrategy(new ReturnDefaultPrice());
                    return pricecalculator.ComputePriceForProduct(quantity, offer);
            }
        }

        public void AddItem()
        {
            Total++;
        }
    }
}
