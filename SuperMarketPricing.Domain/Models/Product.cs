using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        private IPricingModel pricecatalog { get; set; }
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

            switch (offer.Category)
            {
                case Category.FreeProduct:
                    pricecatalog = new BuyXgetYForFree();
                    return pricecatalog.ComputePriceForProduct(quantity, offer);

                case Category.SpecialPrice:
                    pricecatalog = new BuyXforYPrice();
                    return pricecatalog.ComputePriceForProduct(quantity, offer);

                case Category.WeightedProducts:
                    pricecatalog = new BuyXunitForYprice();
                    return pricecatalog.ComputePriceForProduct(quantity, offer);

                default:
                    pricecatalog = new ReturnDefaultPrice();
                    return pricecatalog.ComputePriceForProduct(quantity, offer);
            }
        }

        public void AddItem()
        {
            Total++;
        }
    }
}
