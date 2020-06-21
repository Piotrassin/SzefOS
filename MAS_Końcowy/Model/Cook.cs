using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Cook
    {
        public Employee Employee { get; set; }
        public ICollection<Order> CookedOrders { get; set; }

        public Cook() { Employee = new Employee(); }

        public Cook(
            String name, String lname, String phoneNum, Address address, 
            DateTime hireDate, String pesel, Decimal sal, DateTime? sanepidExpDate)
        {
            //Employee = new Employee(name, lname, phoneNum, address, hireDate, pesel, sal, sanepidExpDate);
        }

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
