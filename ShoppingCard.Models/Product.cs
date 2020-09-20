using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public Product(string title, decimal price, Category category, int amount)
        {
            Title = title;
            Price = price;
            Category = category;
            Amount = amount;
            TotalAmount = Price * Amount;
        }
    }
}
