using SuperMarketPricing.Domain.IServices;
using SuperMarketPricing.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing.Domain
{
    public class SuperMarketPricer : ISuperMarketPricer
    {
        private IList<Product> shoppingList { get; set; } = new List<Product>();
        public SuperMarketPricer()
        {
        }
        public decimal CalculateTotalAmount()
        {
            return this.shoppingList.Sum(p=>p.getPrice());
        }

        public void AddToShoppingList(Product product)
        {
            this.shoppingList.Add(product);
        }
    }
}
