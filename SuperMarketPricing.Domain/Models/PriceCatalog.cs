using SuperMarketPricing.Domain.IServices;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing.Domain.Models
{
    public class PriceCatalog : IPriceCatalog
    {
        public IList<PriceOffer> priceOffers { get; set; }

        public decimal ComputePriceOfItemWithQuantity(string name, int quantity)
        {
            return computeSpecialOffer(name, quantity);
        }
        public decimal computeSpecialOffer(string name, int quantity)
        {
            var OffersSpecial = priceOffers.FirstOrDefault(offering => offering.product.getName() == name && offering.category == Category.SpecialPrice);
            if (OffersSpecial == null)
                return computeFreelOffer(name, quantity);
            else
            {
                return OffersSpecial.ComputeSpecialOffersPrice(quantity);
            }
        }
        public decimal computeFreelOffer(string name, int quantity)
        {
            var OffersSpecialFree = priceOffers.FirstOrDefault(offering => offering.product.getName() == name && offering.category == Category.FreeProducts);
            if (OffersSpecialFree == null)
                return priceOffers.FirstOrDefault(normalOffer => normalOffer.product.getName() == name).Price;
            else
            {
                return OffersSpecialFree.ComputeSpecialFreeOffersPrice(quantity);
            }
        }
    }
}
