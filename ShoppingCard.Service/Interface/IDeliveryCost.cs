using ShoppingCard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Interface
{
    public interface IDeliveryCost
    {
        decimal CalculateDeliveryCost(DeliveryCostModel model);
    }
}
