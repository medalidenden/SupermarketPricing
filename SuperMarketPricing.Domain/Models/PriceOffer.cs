using System;

namespace SuperMarketPricing.Domain.Models
{
    public class PriceOffer
    {
        public string Offer { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }

        public decimal ComputePriceForSpecialOffer(int quantity)
        {
            var offerInTheDeal = Offer.Split();
            var newQuantity = int.Parse(offerInTheDeal[0]);
            var newPrice = int.Parse(offerInTheDeal[2]);

            return quantity == newQuantity ? newPrice : Price * quantity ;
        }
        public decimal ComputePriceForSpecialFreeOffer(int quantity)
        {
            var offerInTheDeal = Offer.Split();
            var specialQuantity = int.Parse(offerInTheDeal[0]);
            var newQuantity = int.Parse(offerInTheDeal[2]);
            decimal newPrice = newQuantity * Price;
            int usedOffer = quantity / specialQuantity;

            return quantity < specialQuantity ? Price * quantity :
                (usedOffer * newPrice) + (quantity % specialQuantity) * Price;
        }
        public decimal ComputePriceForWeightedOffer(int quantity)
        {
            var offerInTheDeal = Offer.Split();
            var newQuantity = int.Parse(offerInTheDeal[0]);
            Enum.TryParse(offerInTheDeal[1], out ProductUnit myUnit);
            var newPrice = int.Parse(offerInTheDeal[3]);
            int usedOffer = quantity / newQuantity;

            return myUnit != Product.Unit ? Price * quantity :
                (usedOffer * newPrice) + (quantity % newQuantity) * Price;
        }
    }
}
