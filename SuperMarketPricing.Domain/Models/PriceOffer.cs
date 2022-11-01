
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
    }
}
