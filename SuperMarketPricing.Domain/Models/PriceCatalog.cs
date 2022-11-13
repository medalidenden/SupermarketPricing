using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing.Domain.Models
{
    public class PriceCatalog
    {
        public IList<PriceOffer> PriceOffers { get; set; }

        public decimal ComputePriceForProduct(string name, int quantity)
        {
            return ComputePriceForSpecialOfferProducts(name, quantity);
        }
        public decimal ComputePriceForSpecialOfferProducts(string name, int quantity)
        {
            var specialProductOffer = PriceOffers.FirstOrDefault(offering => offering.Product.Name == name && offering.Category == Category.SpecialPrice);
            
            return specialProductOffer == null ?
                ComputePriceForFreelProductOffer(name, quantity) :
                specialProductOffer.ComputePriceForSpecialOffer(quantity); 
        }
        public decimal ComputePriceForFreelProductOffer(string name, int quantity)
        {
            var freeProductOffer = PriceOffers.FirstOrDefault(offering => offering.Product.Name == name && offering.Category == Category.FreeProduct);
            
            return freeProductOffer == null ?
                ComputePriceForWeightedProductsOffer(name, quantity)  :
                freeProductOffer.ComputePriceForSpecialFreeOffer(quantity); 
        }
        public decimal ComputePriceForWeightedProductsOffer(string name, int quantity)
        {
            var weightedProductOffer = PriceOffers.FirstOrDefault(offering => offering.Product.Name == name && offering.Category == Category.WeightedProducts);
            
            return weightedProductOffer == null ? 
                PriceOffers.FirstOrDefault(normalOffer => normalOffer.Product.Name == name).Price :
                weightedProductOffer.ComputePriceForWeightedOffer(quantity); 
        }
    }
}
