
using System.Collections.Generic;

namespace SuperMarketPricing.Domain.Models
{
    public class Market
    {
        public IList<PriceOffer> PriceOffers { get; set; }

        public void AddPriceOffer(PriceOffer priceOffer)
        {
            PriceOffers.Add(priceOffer);
        }
    }
}
