using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Manager : Employee
    {
        public Manager() : base() { }

        public Manager(String name, String lname, String phoneNum, DateTime hireDate, String pesel, Decimal sal, DateTime? sanepidExpDate)
            : base(name, lname, phoneNum, hireDate, pesel, sal, sanepidExpDate) { }

    }
}
