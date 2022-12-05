using SuperMarketPricing.Domain.Interfaces;
using SuperMarketPricing.Domain.Models;
using System;

namespace SuperMarketPricing.Domain
{
    public class BuyXgetYForFree : IPricingModel
    {
        private int minimumQuantity { get; set; }
        private int freeItems { get; set; }
        public decimal ComputePriceForProduct(int quantity, PriceOffer priceOffer)
        {
            if (string.IsNullOrEmpty(priceOffer.Offer))
                throw new ArgumentNullException("Mandatory parameter", nameof(priceOffer));

            var offerInTheDeal = priceOffer.Offer.Split();
            minimumQuantity = int.Parse(offerInTheDeal[0]);
            freeItems = int.Parse(offerInTheDeal[2]);
            decimal newPrice = freeItems * priceOffer.Price;
            int usedOffer = quantity / minimumQuantity;

            return  (usedOffer * newPrice) + (quantity % minimumQuantity) * priceOffer.Price;
        }
    }
}