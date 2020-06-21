using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    //TODO: Zmienić nazwę na zgodne z konwencją OrderDishes
    public class OrderContent
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public double Number { get; set; }

        public OrderContent() { }
        public OrderContent(Order order, Dish dish, double number)
        {
            if (number < 1)
            {
                throw new Exception("Given dish count: " + number + ", has to be greater than 0");
            }
            else if (order == null)
            {
                throw new Exception("Given order " + order + " cannot by null.");
            }
            else if (dish == null)
            {
                throw new Exception("Given order " + order + " cannot by null.");
            }
            else
            {
                Order = order;
                Dish = dish;
                Number = number;
                order.AddOrderDish(this);
                dish.AddOrderDish(this);
            }
        }
        public void Save(OrderContent oContent)
        {
            using (var context = new MASContext())
            {
                //context.Ord
                context.SaveChanges();
            }
        }

    }
}
