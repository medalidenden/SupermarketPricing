using SuperMarketPricing.Domain.IServices;
using SuperMarketPricing.Domain.Models;
using System.Collections.Generic;

namespace SuperMarketPricing.Domain
{
    public class SuperMarketPricer : ISuperMarketPricer
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
            Dictionary<string, int> itemDictionary = new Dictionary<string, int>();
            foreach (var product in this.shoppingList)
            {
                if (itemDictionary.ContainsKey(product.getName()))
                {
                    var currentCount = itemDictionary.GetValueOrDefault(product.getName());
                    itemDictionary[product.getName()] = currentCount + 1;
                }
                else
                {
                    itemDictionary.Add(product.getName(), 1);
                }
            }
            foreach (var key in itemDictionary.Keys)
            {
                totalPrice += market.PriceCatalog.ComputePriceOfItemWithQuantity(key, itemDictionary.GetValueOrDefault(key));
            }
            return totalPrice;
        }

        public void AddToShoppingList(Product product)
        {
            this.shoppingList.Add(product);
        }
    }
}
