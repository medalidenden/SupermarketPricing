using SuperMarketPricing.Domain.Models;

namespace SuperMarketPricing.Domain.Interfaces
{
    public interface IPricingModel
    {   
        decimal ComputePriceForProduct(int quantity, PriceOffer offer);    
    }
}
