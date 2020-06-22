using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Cook
    {
        [Key, ForeignKey("Employee")]
        public int Id { get; set; }

        private Employee _employee;
        public Employee Employee 
        { get => _employee; 
          set
            {
                if(value != _employee)
                {
                    _employee = value;
                    value.Cook = this;
                }
            } 
        }

        public ICollection<Order> Orders { get; set; }
        

        public Cook() { }





        internal void RemoveOrder(Order order)
        {
            if (Orders.Contains(order))
            {
                Orders.Remove(order);
                order.Cook = null;
            }
        }

        internal void AddOrder(Order order)
        {
            if (!Orders.Contains(order))
            {
                Orders.Add(order);
                order.Cook = this;
            }
        }
    }
}
