using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public abstract class Employee : Person
    {
        //public int PersonId { get; set; }
        public DateTime HireDate { get; set; }
        public String PESEL { get; set; }
        public DateTime? SanepidBookExpirationDate { get; set; }
        public Decimal Salary { get; set; }
        public static Decimal MinimumSalary { get; set; } = 1400.0m;
        public static double MaximumSalaryModifier { get; set; } = 0.1;

        protected Employee() : base() { }

        protected Employee(String name, String lname, String phoneNum, DateTime hireDate, String pesel, Decimal sal, DateTime? sanepidExpDate)
            : base(name, lname, phoneNum)
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
