using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class Campaign
    {
        public Category Category { get; set; }
        public int MinAmount { get; private set; }
        public decimal DiscountAmount { get; private set; }

        public Campaign(Category category, int minAmount, decimal discountAmount)
        {
            Category = category;
            MinAmount = minAmount;
            DiscountAmount = discountAmount;
        }
    }
}
