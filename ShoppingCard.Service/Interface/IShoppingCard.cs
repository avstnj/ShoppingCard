using ShoppingCard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Interface
{
    public interface IShoppingCard
    {
        void AddItem(Product product);
        int GetCountDeliveries();
        int GetTotalProductCount();
        void ApplyCampingsDiscounts(List<Campaign> campaigns);
        void ApplyCoupon(Coupon coupon);
        decimal GetTotalAmount();
        void ApplyCampaignDiscount();
        decimal GetTotalDiscount();
        decimal ApplyCouponsDiscount();
        decimal GetCouponDiscount();
        ShowResult Print(decimal calculateDeliveryCost);
    }
}
