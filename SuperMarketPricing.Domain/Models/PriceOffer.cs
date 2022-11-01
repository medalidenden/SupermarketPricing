using System;

namespace SuperMarketPricing.Domain.Models
{
    public class PriceOffer
    {
        public string Offer { get; set; }
        public decimal Price { get; set; }
        public Category category { get; set; }
        public Product product { get; set; }

        public decimal ComputeSpecialOffersPrice(int quantity)
        {
            var offerIntheDeal = Offer.Split();
            var NewQuantity = int.Parse(offerIntheDeal[0]);
            var NewPrice = int.Parse(offerIntheDeal[2]);
            if (quantity == NewQuantity)
            {
                return NewPrice;
            }
            else
            {
                return Price * quantity;
            }
        }
        public decimal ComputeSpecialFreeOffersPrice(int quantity)
        {
            var offerIntheDeal = Offer.Split();
            var SpecialQuantity = int.Parse(offerIntheDeal[0]);
            var NewQuantity = int.Parse(offerIntheDeal[2]);
            if (quantity >= SpecialQuantity)
            {
                decimal newPrice = NewQuantity * Price;
                int usedoffer = quantity / SpecialQuantity;

                return (usedoffer * newPrice) + (quantity % SpecialQuantity) * Price;
            }
            else
            {
                return Price * quantity;
            }
        }
        public decimal ComputeWeightedOfferPrice(int quantity)
        {
            var offerIntheDeal = Offer.Split();
            var NewQuantity = int.Parse(offerIntheDeal[0]);
            Enum.TryParse(offerIntheDeal[1], out ProductUnit myUnit);
            var NewPrice = int.Parse(offerIntheDeal[3]);
            if (myUnit == product.getUnit())
            {
                int UsedOffer = quantity / NewQuantity;

                return (UsedOffer * NewPrice) + (quantity % NewQuantity) * Price;
            }
            else
            {
                return Price * quantity;
            }
        }
    }
}
