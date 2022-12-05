using SuperMarketPricing.Domain.Interfaces;
using SuperMarketPricing.Domain.Models;
using System;

namespace SuperMarketPricing.Domain
{
    public class BuyXunitForYprice : IPricingModel
    {
        public decimal ComputePriceForProduct(int quantity, PriceOffer priceOffer)
        {
            if (string.IsNullOrEmpty(priceOffer.Offer))
                throw new ArgumentNullException("Mandatory parameter", nameof(priceOffer));

            var offerInTheDeal = priceOffer.Offer.Split();
            var newQuantity = int.Parse(offerInTheDeal[0]);
            var newPrice = int.Parse(offerInTheDeal[3]);
            int usedOffer = quantity / newQuantity;

            return  (usedOffer * newPrice) + (quantity % newQuantity) * priceOffer.Price;
        }
    }
}
