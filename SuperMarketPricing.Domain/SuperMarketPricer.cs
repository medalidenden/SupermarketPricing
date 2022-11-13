using SuperMarketPricing.Domain.Models;
using System.Collections.Generic;

namespace SuperMarketPricing.Domain
{
    public class SuperMarketPricer
    {
        private Market _market { get; set; }
        private IList<Product> _productsList { get; set; } = new List<Product>();
        public SuperMarketPricer(Market market)
        {
            _market = market;
        }

        public decimal CalculateTotalAmount()
        {
            decimal totalPrice = 0;
            Dictionary<string, int> Cart = GetCart();
            foreach (var productKey in Cart.Keys)
            {
                totalPrice += _market.PriceCatalog.ComputePriceForProduct(productKey, Cart.GetValueOrDefault(productKey));
            }
            return totalPrice;
        }

        private Dictionary<string, int> GetCart()
        {
            Dictionary<string, int> Cart = new Dictionary<string, int>();
            foreach (var product in _productsList)
            {
                if (Cart.ContainsKey(product.Name))
                {
                    var currentCount = Cart.GetValueOrDefault(product.Name);
                    Cart[product.Name] = currentCount + 1;
                }
                else
                {
                    Cart.Add(product.Name, 1);
                }
            }

            return Cart;
        }

        public void AddToShoppingList(Product product)
        {
            _productsList.Add(product);
        }
    }
}
