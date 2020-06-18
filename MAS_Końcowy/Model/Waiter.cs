using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Waiter : Employee
    {
        public Waiter() : base() { }

        public Waiter(String name, String lname, String phoneNum, DateTime hireDate, String pesel, Decimal sal, DateTime? sanepidExpDate)
            : base(name, lname, phoneNum, hireDate, pesel, sal, sanepidExpDate) { }

        public void addOrder(Order newOrder)
        {
            //TODO
        }

    }
}
