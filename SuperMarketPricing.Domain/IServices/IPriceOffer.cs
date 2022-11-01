
namespace SuperMarketPricing.Domain.IServices
{
    public interface IPriceOffer
    {
        decimal ComputeSpecialOffersPrice(int quantity);
    }
}
