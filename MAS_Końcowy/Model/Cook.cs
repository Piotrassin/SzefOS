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
