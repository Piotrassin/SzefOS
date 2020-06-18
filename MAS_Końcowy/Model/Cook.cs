using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Cook : Employee
    {
        public ICollection<Order> CookedOrders { get; set; }

        public Cook() : base() { }

        public Cook(String name, String lname, String phoneNum, DateTime hireDate, String pesel, Decimal sal, DateTime? sanepidExpDate)
            : base(name, lname, phoneNum, hireDate, pesel, sal, sanepidExpDate) { }

    }
}
