
using System;

namespace SuperMarketPricing.Domain.Models
{
    public class BuyXforYPrice : IPricingModel
    {
        public int minimumQuantity { get; set; }
        public decimal prixDeal { get; set; }
        public decimal ComputePriceForProduct(int quantity, PriceOffer priceOffer)
        {
            if (string.IsNullOrEmpty(priceOffer.Offer))
                throw new ArgumentNullException("Mandatory parameter", nameof(priceOffer));

            var offerInTheDeal = priceOffer.Offer.Split();
            minimumQuantity = int.Parse(offerInTheDeal[0]);
            prixDeal = int.Parse(offerInTheDeal[2]);

            return prixDeal;
        }
    }
}