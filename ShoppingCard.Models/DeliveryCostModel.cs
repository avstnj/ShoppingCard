using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class DeliveryCostModel
    {
        public decimal CostDelivery { get; set; }
        public decimal CostProduct { get; set; }
        public int CountOfDeliveries { get; set; }
        public int CountOfProducts { get; set; }
    }
}
