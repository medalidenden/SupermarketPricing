using SuperMarketPricing.Domain.Interfaces;
using SuperMarketPricing.Domain.Models;

namespace SuperMarketPricing.Domain
{
    public class ReturnDefaultPrice : IPricingModel
    {
        public decimal ComputePriceForProduct(int quantity, PriceOffer offer)
        {
            return offer.Price * quantity;
        }
    }
}