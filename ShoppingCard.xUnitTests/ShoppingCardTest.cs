using ShoppingCard.Interface;
using ShoppingCard.Models;
using System;
using Xunit;

namespace ShoppingCard.xUnitTests
{
    public class ShoppingCardTest
    {
        private readonly IShoppingCard _shoppingCard;
        private readonly IDeliveryCost _deliveryCost;
        public ShoppingCardTest()
        {
            _shoppingCard = new ShoppingCard();
            _deliveryCost = new DeliveryCost();
        }
        [Fact]
        //Teslimat bilgisinin yazýldýðý metoda gönderilen (CostDelivery,CostProduct) parametre deðerlerinin
        //0(Sýfýr)'dan küçük ise hata fýtlatýlacaðý kontrolü yapýlýyor.
        public void CalculateDeliveryValueControl()
        {
            Category beverage = new Category("Beverage");
            Category electronic = new Category("Electronic");
            Category computer = new Category("Computer", electronic);

            Product apple = new Product("Fanta", 5, beverage, 10);
            Product orange = new Product("Schweppes", 8, beverage, 5);
            Product sportShoe = new Product("Toshiba", 250, computer, 2);

            _shoppingCard.AddItem(apple);
            _shoppingCard.AddItem(orange);
            _shoppingCard.AddItem(sportShoe);

            DeliveryCostModel deliveryCostModel = new DeliveryCostModel()
            {
                CostDelivery = -1,
                CostProduct = 3,
                CountOfDeliveries = _shoppingCard.GetCountDeliveries(),
                CountOfProducts = _shoppingCard.GetTotalProductCount()
            };

            Assert.Throws<ArgumentException>(() => _deliveryCost.CalculateDeliveryCost(deliveryCostModel));
        }
        [Fact]
        //Sipariþ toplamýnýn Doðruluðu test ediliyor..
        public void TotalAmountControl()
        {
            Category beverage = new Category("Beverage");
            Category electronic = new Category("Electronic");
            Category computer = new Category("Computer", electronic);

            Product apple = new Product("Fanta", 5, beverage, 10);
            Product orange = new Product("Schweppes", 8, beverage, 5);
            Product sportShoe = new Product("Toshiba", 250, computer, 2);

            _shoppingCard.AddItem(apple);
            _shoppingCard.AddItem(orange);
            _shoppingCard.AddItem(sportShoe);

            Assert.Equal(590, _shoppingCard.GetTotalAmount());
        }
        //Teslimat Tutarýnýn Doðruluðu Test ediliyor.. 
        [Fact]
        public void CalculateDeliveryCost()
        {
            Category beverage = new Category("Beverage");
            Category electronic = new Category("Electronic");
            Category computer = new Category("Computer", electronic);

            Product apple = new Product("Fanta", 5, beverage, 10);
            Product orange = new Product("Schweppes", 8, beverage, 5);
            Product sportShoe = new Product("Toshiba", 250, computer, 2);

            _shoppingCard.AddItem(apple);
            _shoppingCard.AddItem(orange);
            _shoppingCard.AddItem(sportShoe);

            DeliveryCostModel deliveryCostModel = new DeliveryCostModel()
            {
                CostDelivery = 2,
                CostProduct = 3,
                CountOfDeliveries = _shoppingCard.GetCountDeliveries(),
                CountOfProducts = _shoppingCard.GetTotalProductCount()
            };

            Assert.Equal(13,_deliveryCost.CalculateDeliveryCost(deliveryCostModel));
        }

        //Sipariþte bulunan ürün sayýsý kontrol ediliyor...
        [Fact]
        public void ProductCountControl()
        {
            Category beverage = new Category("Beverage");
            Category electronic = new Category("Electronic");
            Category computer = new Category("Computer", electronic);

            Product apple = new Product("Fanta", 5, beverage, 10);
            Product orange = new Product("Schweppes", 8, beverage, 5);
            Product sportShoe = new Product("Toshiba", 250, computer, 2);

            _shoppingCard.AddItem(apple);
            _shoppingCard.AddItem(orange);
            _shoppingCard.AddItem(sportShoe);

            Assert.Equal(3, _shoppingCard.GetTotalProductCount());
        }
    }
}
