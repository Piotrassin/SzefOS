using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Cook
    {
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

        public ICollection<Order> CookedOrders { get; set; }
        

        public Cook() { }

        internal void RemoveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        internal void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
