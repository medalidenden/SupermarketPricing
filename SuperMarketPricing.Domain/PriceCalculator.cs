using System;
using System.Collections.Generic;
using SuperMarketPricing.Domain.Interfaces;
using SuperMarketPricing.Domain.Models;

namespace SuperMarketPricing.Domain
{
    public class PriceCalculator : IPriceCalculator
    {
        private IPricingModel _pricecatalog;
        private Dictionary<Category, Func<IPricingModel>> _entityTypeMapper;

        public PriceCalculator()
        {
            _entityTypeMapper = new Dictionary<Category, Func<IPricingModel>> ();
            _entityTypeMapper.Add(Category.SpecialPrice, () => { return new BuyXforYPrice(); });
            _entityTypeMapper.Add(Category.FreeProduct, () => { return new BuyXgetYForFree(); });
            _entityTypeMapper.Add(Category.NoOffer, () => { return new ReturnDefaultPrice(); });
            _entityTypeMapper.Add(Category.WeightedProducts, () => { return new BuyXunitForYprice(); });
        }

        public void SetPriceStrategy(Category category)
        {
            this._pricecatalog = _entityTypeMapper[category]();
        }
        public decimal ComputePriceForProduct (int quantity, PriceOffer offer)
        {
            return _pricecatalog.ComputePriceForProduct(quantity, offer);
        }
    }
}
