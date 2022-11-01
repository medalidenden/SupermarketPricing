
namespace SuperMarketPricing.Domain.IServices
{
    public interface IPriceCatalog
    {
        decimal computeSpecialOffer(string name, int quantity);
        decimal ComputePriceOfItemWithQuantity(string name, int quantity);
    }
}
