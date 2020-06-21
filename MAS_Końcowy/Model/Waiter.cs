using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Waiter
    {
        [Key, ForeignKey("Employee")]
        public int Id { get; set; }

        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                if (value != _employee)
                {
                    _employee = value;
                    value.Waiter = this;
                }
            }
        }
        public ICollection<Order> HandledOrders { get; set; }


        public Waiter() { }

        public void addOrder(Order newOrder)
        {
            //TODO
        }

    }
}
