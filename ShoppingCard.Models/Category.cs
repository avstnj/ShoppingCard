using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard
{
    public class Category
    {
        public string Title { get; set; }
        public Category MainCategory { get; set; }
        public Category(string title)
        {
            Title = title;
        }
        public Category(string title, Category mainCategory)
        {
            Title = title;
            MainCategory = mainCategory;
        }
    }
}
