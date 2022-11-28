using System;

namespace SuperMarketPricing.Domain.Models
{
    public class Product
    {
        public IPricingModel priceModel { get; set; }
        private string name { get; set; }
        private int total { get; set; }
        private ProductUnit unit { get; set; }

        public Product(string _name, ProductUnit _unit)
        {
            if (string.IsNullOrEmpty(_name)) { throw new ArgumentNullException(nameof(_name)); }
            name = _name;
            unit = _unit;
            total = 1;
        }
        public decimal GetPrice(int quantity, PriceOffer offer)
        {
            if (offer == null)
                throw new ArgumentNullException("Mandatory parameter", nameof(offer));
            IPricingModel pricecatalog;
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
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public ProductUnit Unit
        {
            get
            {
                return this.unit;
            }
        }

        public int Total
        {
            get
            {
                return this.total;
            }
        }

        public void AddItem()
        {
            this.total++;
        }
    }
}
