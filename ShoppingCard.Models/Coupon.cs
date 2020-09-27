using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class Coupon
    {
        public int MinAmount { get; private set; }//İndirim uygulanabilmesi için Sepette bulunması gereken minimum adet.
        public decimal DiscountAmount { get; private set; }//uygulanacak indirim miktarı
        public Coupon(int minAmount, decimal discountAmount)
        {
            MinAmount = minAmount;
            DiscountAmount = discountAmount;
        }
    }
}
