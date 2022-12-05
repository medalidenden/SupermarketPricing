using SuperMarketPricing.Domain.Models;

namespace SuperMarketPricing.Domain.Interfaces
{
    public interface IPriceCalculator
    {
        void SetPriceStrategy(Category category);
        decimal ComputePriceForProduct(int quantity, PriceOffer offer);
    }
}
