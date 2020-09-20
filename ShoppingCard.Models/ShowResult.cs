using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class ShowResult
    {
        public List<Product> ProductsList { get; set; }
        public decimal GetTotalAmount { get; set; }
        public decimal ApplyCouponsDiscount { get; set; }
        public decimal GetTotalDiscount { get; set; }
        public decimal GetDeliveryCostCalculate { get; set; }
    }
}
