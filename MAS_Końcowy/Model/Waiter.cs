using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Waiter : Employee
    {
        public ICollection<Order> HandledOrders { get; set; }
        public Waiter() : base() { }

        public Waiter(
            String name, String lname, String phoneNum, Address address, 
            DateTime hireDate, String pesel, Decimal sal, DateTime? sanepidExpDate)
            : base(name, lname, phoneNum, address, hireDate, pesel, sal, sanepidExpDate) { }

        public void addOrder(Order newOrder)
        {
            //TODO
        }

    }
}
