using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing.Domain.Models
{
    public class Cart
    {
        private IList<Product> productsList { get; set; } = new List<Product>();
        public void AddToShoppingList(Product product)
        {
            var cartItem = productsList.SingleOrDefault(x => x.Name == product.Name);
            if (cartItem != null)
            {
                cartItem.AddItem();
            }
            else
            {
                productsList.Add(product);
            }
        }
        public Dictionary<string, int> GetListProductByName()
        {
            var products = productsList.GroupBy(y => y.Name).Select(x => x.First());
            Dictionary<string, int> cart = new Dictionary<string, int>();
            foreach (var product in products)
            {
                cart[product.Name] = product.Total;
            }

            return cart;
        }

    }
}
