using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing.Domain.Models
{
    public class PriceCatalog
    {
        public IList<PriceOffer> PriceOffers = new List<PriceOffer>();
        public void AddPriceOffer(PriceOffer offer)
        {
            PriceOffers.Add(offer);
        }
        public decimal ComputePriceForProduct(string name, int quantity)
        {
            decimal amount = 0;
            amount = ComputePriceForSpecialOfferProducts(name, quantity);
            amount += ComputePriceForFreeProductOffer(name, quantity);
            amount += ComputePriceForWeightedProductsOffer(name, quantity);

            return amount == 0 ? PriceOffers.FirstOrDefault(normalOffer => normalOffer.Product.Name == name).Price : amount ;
        }
        public decimal ComputePriceForSpecialOfferProducts(string name, int quantity)  
        {
            var specialProductOffer = PriceOffers.FirstOrDefault(offering => offering.Product.Name == name && offering.Category == Category.SpecialPrice);           
            return specialProductOffer == null ? 0 : specialProductOffer.ComputePriceForSpecialOffer(quantity); 
        }
        public decimal ComputePriceForFreeProductOffer(string name, int quantity)
        {
            var freeProductOffer = PriceOffers.FirstOrDefault(offering => offering.Product.Name == name && offering.Category == Category.FreeProduct);         
            return freeProductOffer == null ? 0  : freeProductOffer.ComputePriceForFreeOffer(quantity); 
        }
        public decimal ComputePriceForWeightedProductsOffer(string name, int quantity)
        {
            var weightedProductOffer = PriceOffers.FirstOrDefault(offering => offering.Product.Name == name && offering.Category == Category.WeightedProducts);           
            return weightedProductOffer == null ? 0 : weightedProductOffer.ComputePriceForWeightedOffer(quantity); 
        }
    }
}