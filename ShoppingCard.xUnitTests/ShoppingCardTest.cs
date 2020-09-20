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
        //Teslimat bilgisinin yaz�ld��� metoda g�nderilen (CostDelivery,CostProduct) parametre de�erlerinin
        //0(S�f�r)'dan k���k ise hata f�tlat�laca�� kontrol� yap�l�yor.
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
        //Sipari� toplam�n�n Do�rulu�u test ediliyor..
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
        //Teslimat Tutar�n�n Do�rulu�u Test ediliyor.. 
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

        //Sipari�te bulunan �r�n say�s� kontrol ediliyor...
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
