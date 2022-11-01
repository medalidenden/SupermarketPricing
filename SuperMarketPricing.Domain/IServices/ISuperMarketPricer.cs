using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketPricing.Domain.IServices
{
    public interface ISuperMarketPricer
    {
        decimal CalculateTotalAmount();
    }
}
