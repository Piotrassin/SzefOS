using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Cook : Employee
    {
        public ICollection<Order> CookedOrders { get; set; }

        public Cook() : base() { }

        public Cook(
            String name, String lname, String phoneNum, Address address, 
            DateTime hireDate, String pesel, Decimal sal, DateTime? sanepidExpDate)
            : base(name, lname, phoneNum, address, hireDate, pesel, sal, sanepidExpDate) { }

    }
}
