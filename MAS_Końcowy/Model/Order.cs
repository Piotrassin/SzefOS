using System;
using System.Collections.Generic;

namespace MAS_Końcowy.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal Price { get; set; }  //Wyliczable
        public int? TableNumber { get; set; }

        public Address DeliveryAddress { get; set; }
        public Cook Cook { get; set; }
        public Waiter Waiter { get; set; }
        public Deliverer Deliverer { get; set; }
        public ICollection<OrderContent> OrderContents { get; set; }

        public Order() { }

        public Order(DateTime orderDate, int? tableNumber, Address deliveryAddress)
        {
            OrderDate = orderDate;
            TableNumber = tableNumber;  //check XOR table / address, throw exception
            DeliveryAddress = deliveryAddress;
        }
    }
}
