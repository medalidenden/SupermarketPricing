using SuperMarketPricing.Domain.Models;

namespace SuperMarketPricing.Domain
{
    public interface IPricingModel
    {   
        decimal ComputePriceForProduct(int quantity, PriceOffer offer);    
    }
}
