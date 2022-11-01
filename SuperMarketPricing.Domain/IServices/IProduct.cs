using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricing.Domain.IServices
{
    public interface IProduct
    {
        string getName();
        decimal getPrice();
    }
}
