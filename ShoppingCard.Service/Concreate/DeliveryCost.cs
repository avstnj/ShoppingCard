using ShoppingCard.Interface;
using ShoppingCard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard
{
    public class DeliveryCost : IDeliveryCost
    {
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
