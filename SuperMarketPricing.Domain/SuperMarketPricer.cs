using SuperMarketPricing.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing.Domain
{
    public class SuperMarketPricer
    {
        private Market market { get; set; }
        private Cart cart { get; set; }
        public SuperMarketPricer(Market _market,Cart _cart)
        {
            market = _market;
            cart = _cart;
        }

        public decimal CalculateTotalAmount()
        {
            decimal totalPrice = 0;
            Dictionary<string, int> listProducts = cart.GetCart();
            foreach (var productKey in listProducts)
            {
                var offer = market.PriceOffers.Where(c =>c.Product.Name == productKey.Key).FirstOrDefault();
                totalPrice += offer.Product.GetPrice(productKey.Value, offer); 
            }
            return totalPrice;
        }
    }
}
