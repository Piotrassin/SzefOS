using System;
using System.Collections.Generic;
using System.Linq;

namespace MAS_Końcowy.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal Price { get; set; }  //Wyliczable
        public int? TableNumber { get; set; }

        public Address DeliveryAddress { get; set; }

        private Cook _cook;
        public Cook Cook
        {
            get => _cook;

            set
            {
                if (_cook != value)
                {
                    if (_cook != null) { _cook.RemoveOrder(this); }

                    _cook = value;

                    if (_cook != null) { _cook.AddOrder(this); }
                }
            }
        }
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

        public void AddOrderDish(OrderContent orderContent)
        {
            if (!OrderContents.Contains(orderContent))
            {
                OrderContents.Add(orderContent);
            }
        }

        //public void AddDish(Dish dish, int count)
        //{
        //    throw new NotImplementedException();
        //}

        public String GetContents()
        {
            using (var context = new MASContext())
            {

            }
            throw new NotImplementedException();
        }
    }
}
