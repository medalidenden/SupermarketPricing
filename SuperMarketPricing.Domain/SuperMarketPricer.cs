using SuperMarketPricing.Domain.Models;
using System.Collections.Generic;

namespace SuperMarketPricing.Domain
{
    public class SuperMarketPricer
    {
        private Market market { get; set; }
        private IList<Product> shoppingList { get; set; } = new List<Product>();
        public SuperMarketPricer(Market _market)
        {
            this.market = _market;
        }
        public decimal CalculateTotalAmount()
        {
            decimal totalPrice = 0;
            Dictionary<string, int> itemDictionary = GetCart();
            foreach (var key in itemDictionary.Keys)
            {
                totalPrice += market.PriceCatalog.ComputePriceOfItemWithQuantity(key, itemDictionary.GetValueOrDefault(key));
            }
            return totalPrice;
        }

        private Dictionary<string, int> GetCart()
        {
            Dictionary<string, int> itemDictionary = new Dictionary<string, int>();
            foreach (var product in this.shoppingList)
            {
                if (itemDictionary.ContainsKey(product.name))
                {
                    var currentCount = itemDictionary.GetValueOrDefault(product.name);
                    itemDictionary[product.name] = currentCount + 1;
                }
                else
                {
                    itemDictionary.Add(product.name, 1);
                }
            }

            return itemDictionary;
        }

        public void AddToShoppingList(Product product)
        {
            this.shoppingList.Add(product);
        }
    }
}
