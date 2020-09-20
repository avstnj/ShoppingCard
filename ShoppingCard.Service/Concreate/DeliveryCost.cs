using ShoppingCard.Interface;
using ShoppingCard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard
{
    public class DeliveryCost : IDeliveryCost
    {
        //public decimal CostDelivery { get; private set; }
        //public decimal CostProduct { get; private set; }
        //public DeliveryCost(decimal costDelivery, decimal costProduct)
        //{
        //    CostDelivery = costDelivery;
        //    CostProduct = costProduct;
        //}

        //public decimal CalculateDeliveryCost(IShoppingCard card)
        //{
        //    if (card == null)
        //    {
        //        throw new ArgumentNullException($"{nameof(card)} is Null");
        //    }
        //    int countOfDeliveries = card.GetCountDeliveries();
        //    int countOfProducts = card.GetTotalProductCount();
        //    return (CostDelivery * countOfDeliveries) + (CostProduct * countOfProducts);
        //}
        public decimal CalculateDeliveryCost(DeliveryCostModel model)
        {
            try
            {
                if (model.CostDelivery < 0 || model.CostProduct < 0)
                {
                    throw new Exception("Değerler 0 dan küçük olamaz..");
                }
                return (model.CostDelivery * model.CountOfDeliveries) + (model.CostProduct * model.CountOfProducts);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
