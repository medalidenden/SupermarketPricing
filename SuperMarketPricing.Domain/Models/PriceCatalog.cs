using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing.Domain.Models
{
    public class PriceCatalog
    {
        public IList<PriceOffer> priceOffers { get; set; }

        public decimal ComputePriceOfItemWithQuantity(string name, int quantity)
        {
            return computeSpecialOffer(name, quantity);
        }
        public decimal computeSpecialOffer(string name, int quantity)
        {
            var OffersSpecial = priceOffers.FirstOrDefault(offering => offering.product.name == name && offering.category == Category.SpecialPrice);
            
            return OffersSpecial == null ? 
                computeFreelOffer(name, quantity) : 
                OffersSpecial.ComputeSpecialOffersPrice(quantity); 
        }
        public decimal computeFreelOffer(string name, int quantity)
        {
            var OffersSpecialFree = priceOffers.FirstOrDefault(offering => offering.product.name == name && offering.category == Category.FreeProducts);
            
            return OffersSpecialFree == null ? 
                computeWeightedOffer(name, quantity)  : 
                OffersSpecialFree.ComputeSpecialFreeOffersPrice(quantity); 
        }
        public decimal computeWeightedOffer(string name, int quantity)
        {
            var WeightedOffer = priceOffers.FirstOrDefault(offering => offering.product.name == name && offering.category == Category.weightedProductsOffer);
            
            return WeightedOffer == null ? 
                priceOffers.FirstOrDefault(normalOffer => normalOffer.product.name == name).Price : 
                WeightedOffer.ComputeWeightedOfferPrice(quantity); 
        }
    }
}
