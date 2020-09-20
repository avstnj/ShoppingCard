using ShoppingCard.Interface;
using ShoppingCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCard
{
    public class ShoppingCard : IShoppingCard
    {
        internal Coupon Coupon { get; set; }
        internal List<Campaign> Campaigns { get; set; }
        internal List<Product> ProductsList { get; set; }
        internal ShowResult ShowResult { get; set; }

        public ShoppingCard()
        {
            Campaigns = new List<Campaign>();
            ProductsList = new List<Product>();
        }
        public void AddItem(Product product)
        {
            if (product != null)
            {
                if (ProductsList.Count > 0)
                {
                    bool control = true;
                    foreach (Product item in ProductsList)
                    {
                        if (item.Title == product.Title)
                        {
                            control = false;
                            item.Amount = item.Amount + product.Amount;
                        }
                    }
                    if (control)
                        ProductsList.Add(product);
                }
                else
                    ProductsList.Add(product);
            }
        }
        //Kampanyalar tanımlanıyor..
        public void ApplyCampingsDiscounts(List<Campaign> campaigns)
        {
            Campaigns = campaigns;
        }
        //Kupon Tanımlanıyor...
        public void ApplyCoupon(Coupon coupon)
        {
            Coupon = coupon;
        }
        //indirimsiz Toplam Ödeecek Tutar
        public decimal GetTotalAmount()
        {
            decimal result = 0;
            foreach (Product item in ProductsList)
                result += item.Amount * item.Price;

            return result;
        }
        //Sepete eklenen Toplam Ürün Sayısı
        public int GetTotalProductCount()
        {
            return ProductsList.Count;
        }
        //Sepete eklenen teslimat sayısı
        public int GetCountDeliveries()
        {
            return ProductsList.GroupBy(u => u.Category.Title).ToList().Count;
        }
        //Ürünler Kategorilerine göre Kampanya indirimleri uygulanıp, ürünlerin DiscountAmount özelliğine (product.DiscountAmount) indirim tutarı atanıyor...
        public void ApplyCampaignDiscount()
        {
            foreach (Campaign campaign in Campaigns)
            {
                foreach (Product product in ProductsList)
                    if (campaign.Category.Title == product.Category.Title && product.Amount > campaign.MinAmount)
                        product.DiscountAmount = product.Amount * campaign.DiscountAmount / 100;
            }
        }
        //Sepetteki ürünlere uygulanan Kampanya ve Kupon indirimleri toplamı bulunuyor. 
        public decimal GetTotalDiscount()
        {
            decimal result = 0;
            foreach (Product product in ProductsList)
                result += product.DiscountAmount;

            if (result > 0)
                result += GetCouponDiscount();

            return result;
        }
        //Sepetteki Toplam tutara, Kupon indirimi uygulandıktan sonraki toplam tutar bulunuyor..
        public decimal ApplyCouponsDiscount()
        {
            decimal result = GetTotalAmount();

            if (result > Coupon.MinAmount)
                result -= result * Coupon.DiscountAmount / 100;

            return result;
        }
        //Uygulanan Kupon Tutarı
        public decimal GetCouponDiscount()
        {
            decimal result = 0;
            decimal getTotalAmount = GetTotalAmount();

            if (getTotalAmount > Coupon.MinAmount)
                result = getTotalAmount * Coupon.DiscountAmount / 100;

            return result;
        }
        //aldığı Teslimat Tutarı(calculateDeliveryCost) parametesi ile birlikte Ürünler(ProductsList)
        //ekrana basılır...
        public ShowResult Print(decimal calculateDeliveryCost)
        {
            return ShowResult = new ShowResult()
            {
                ProductsList = ProductsList,
                GetTotalAmount = GetTotalAmount(),
                ApplyCouponsDiscount = ApplyCouponsDiscount(),
                GetTotalDiscount = GetTotalDiscount(),
                GetDeliveryCostCalculate = calculateDeliveryCost
            };
        }
    }
}
