using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Employee : Person
    {
        public DateTime HireDate { get; set; }
        public String PESEL { get; set; }
        public DateTime? SanepidBookExpirationDate { get; set; }
        public Decimal Salary { get; set; }
        public static Decimal MinimumSalary { get; set; } = 1400.0m;
        public static double MaximumSalaryModifier { get; set; } = 0.1;

        public Cook Cook { get; set; }
        public Waiter Waiter { get; set; }
        public Deliverer Deliverer { get; set; }
        public Manager Manager { get; set; }


        public Employee() : base() { }

        public Employee(
            String name, String lname, String phoneNum, Address address,  DateTime hireDate, 
            String pesel, Decimal sal, DateTime? sanepidExpDate) : base(name, lname, phoneNum, address)
        {
            HireDate = hireDate;
            PESEL = pesel;
            SanepidBookExpirationDate = sanepidExpDate;
            Salary = sal;
        }

        public void setSalary(Decimal raise)
        {
            //TODO
        }

        public void AssignToOrder(Order order)
        {
            //TODO
        }

        //public void setRole(Employee emp, ??)
    }
}
