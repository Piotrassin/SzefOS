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
            Order = order;
            Dish = dish;
            Number = number;
        }

    }
}
