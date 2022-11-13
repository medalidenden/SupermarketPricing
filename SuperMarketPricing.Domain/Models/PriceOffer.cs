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

            return quantity == NewQuantity ? NewPrice : Price * quantity ;
        }
        public decimal ComputeSpecialFreeOffersPrice(int quantity)
        {
            var offerIntheDeal = Offer.Split();
            var SpecialQuantity = int.Parse(offerIntheDeal[0]);
            var NewQuantity = int.Parse(offerIntheDeal[2]);
            decimal newPrice = NewQuantity * Price;
            int usedoffer = quantity / SpecialQuantity;

            return quantity < SpecialQuantity ? Price * quantity :
                (usedoffer * newPrice) + (quantity % SpecialQuantity) * Price;
        }
        public decimal ComputeWeightedOfferPrice(int quantity)
        {
            var offerIntheDeal = Offer.Split();
            var NewQuantity = int.Parse(offerIntheDeal[0]);
            Enum.TryParse(offerIntheDeal[1], out ProductUnit myUnit);
            var NewPrice = int.Parse(offerIntheDeal[3]);
            int UsedOffer = quantity / NewQuantity;

            return myUnit != product.unit ? Price * quantity :
                (UsedOffer * NewPrice) + (quantity % NewQuantity) * Price;
        }
    }
}
