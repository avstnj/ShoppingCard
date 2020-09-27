using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCard.Interface;
using ShoppingCard.Models;
namespace ShoppingCard.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeliveryCost _deliveryCost;
        private readonly IShoppingCard _shoppingCard;
        public HomeController(IShoppingCard shoppingCar, IDeliveryCost deliveryCost)
        {
            _deliveryCost = deliveryCost;
            _shoppingCard = shoppingCar;
        }
        public IActionResult Index()
        {
            //Kategoriler tanımlanıyor...
            Category beverage = new Category("Beverage");
            Category electronic = new Category("Electronic");
            Category computer = new Category("Computer", electronic);

            //Ürünler Tanımlanıyor...
            Product apple = new Product(title: "Fanta", price: 5, category: beverage, amount: 10);
            Product orange = new Product(title: "Schweppes", price: 8, category: beverage, amount: 5);
            Product sportShoe = new Product(title: "Toshiba", price: 250, category: computer, amount: 2);

            //Ürünler Listesine ürünler ekleniyor...
            _shoppingCard.AddItem(apple);
            _shoppingCard.AddItem(orange);
            _shoppingCard.AddItem(sportShoe);

            //Kampanyalar tanımlanıyor ve Kampanya listesine ekleniyor...
            List<Campaign> listCampaign = new List<Campaign>();
            Campaign cmp1 = new Campaign(category: beverage, minAmount: 6, discountAmount: 10);
            Campaign cmp2 = new Campaign(category: computer, minAmount: 200, discountAmount: 20);
            listCampaign.Add(cmp1);
            listCampaign.Add(cmp2);
            _shoppingCard.ApplyCampingsDiscounts(listCampaign);

            //DeliveryCost için Model tanımlanıyor...
            DeliveryCostModel deliveryCostModel = new DeliveryCostModel()
            {
                CostDelivery = 4,
                CostProduct = 1,
                CountOfDeliveries = _shoppingCard.GetCountDeliveries(),
                CountOfProducts = _shoppingCard.GetTotalProductCount()
            };

            //Teslimat Hesaplanıyor...
            decimal calculateDeliveryCost = _deliveryCost.CalculateDeliveryCost(deliveryCostModel);

            //Kupon Tanımı yapılıyor...
            Coupon coupon = new Coupon(minAmount: 100, discountAmount: 23);
            _shoppingCard.ApplyCoupon(coupon);

            //Ürünlere, tanımlanan kampanyalar uygulanıyor.. 
            _shoppingCard.ApplyCampaignDiscount();

            //Toplam Tutara Kupon indirimi uygulanıyor ve Ürün bilgileri ekrana basılıyor...
            ShowResult showResult = _shoppingCard.Print(calculateDeliveryCost);
            return View(showResult);
        }
    }
}
