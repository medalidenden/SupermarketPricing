using SuperMarketPricing.Domain.Models;

namespace SuperMarketPricing.Domain
{
    public class PriceCalculator
    {
        IPricingModel _pricecatalog;
        public void SetPriceStrategy(IPricingModel pricecatalog)
        {
            this._pricecatalog = pricecatalog;
        }
        public decimal ComputePriceForProduct (int quantity, PriceOffer offer)
        {
            return _pricecatalog.ComputePriceForProduct(quantity, offer);
        }
    }
}
