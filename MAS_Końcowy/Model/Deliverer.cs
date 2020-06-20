using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Deliverer : Employee
    {
        public String DrivingLicense { get; set; }
        public ICollection<Order> DeliveredOrders { get; set; }

        public Deliverer() : base() { }

        public Deliverer(
            String name, String lname, String phoneNum, Address address, DateTime hireDate, 
            String pesel, Decimal sal, String drivingLicense, DateTime? sanepidExpDate)
            : base(name, lname, phoneNum, address, hireDate, pesel, sal, sanepidExpDate) 
        {
            DrivingLicense = drivingLicense;
        }

    }
}
