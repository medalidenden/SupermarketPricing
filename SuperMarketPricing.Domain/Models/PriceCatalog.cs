using System;
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

            var offer = PriceOffers.Where(o => o.Product.Name == name).FirstOrDefault();
            if (offer == null )
                throw new ArgumentNullException("Mandatory parameter", nameof(offer));

            switch (offer.Category)
            {
                case Category.FreeProduct:
                    return ComputePriceForFreeProductOffer(quantity, offer) ;

                case Category.SpecialPrice:
                    return ComputePriceForSpecialOfferProducts(quantity, offer);

                case Category.WeightedProducts:
                    return ComputePriceForWeightedProductsOffer(quantity, offer);

                default:
                    return PriceOffers.FirstOrDefault(normalOffer => normalOffer.Product.Name == name).Price;
            }
        }
        public decimal ComputePriceForSpecialOfferProducts(int quantity,PriceOffer specialProductOffer)  
        {
            return specialProductOffer == null ? 0 : specialProductOffer.ComputePriceForSpecialOffer(quantity); 
        }
        public decimal ComputePriceForFreeProductOffer(int quantity, PriceOffer freeProductOffer)
        {
            return freeProductOffer == null ? 0  : freeProductOffer.ComputePriceForFreeOffer(quantity); 
        }
        public decimal ComputePriceForWeightedProductsOffer(int quantity, PriceOffer weightedProductOffer)
        {
            return weightedProductOffer == null ? 0 : weightedProductOffer.ComputePriceForWeightedOffer(quantity); 
        }
    }
}