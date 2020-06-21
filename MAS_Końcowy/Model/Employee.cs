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
        

        private Cook _cook;
        public Cook Cook
        {
            get => _cook;
            set
            {
                if (_waiter == null && _deliverer == null && _manager == null)
                {
                    if(value != _cook)
                    {
                        _cook = value;
                        value.Employee = this;
                    }
                }
                else
                {
                    throw new Exception("This employee already has a role");
                }
            }
        }
        
        private Waiter _waiter;
        public Waiter Waiter
        {
            get => _waiter;
            set
            {
                if (_cook == null && _deliverer == null && _manager == null)
                {
                    if (value != _waiter)
                    {
                        _waiter = value;
                        value.Employee = this;
                    }
                }
                else
                {
                    throw new Exception("This employee already has a role");
                }
            }
        }

        private Deliverer _deliverer;
        public Deliverer Deliverer
        {
            get => _deliverer;
            set
            {
                if (_waiter == null && _cook == null && _manager == null)
                {
                    if (value != _deliverer)
                    {
                        _deliverer = value;
                        value.Employee = this;
                    }
                }
                else
                {
                    throw new Exception("This employee already has a role");
                }
            }
        }

        private Manager _manager;
        public Manager Manager
        {
            get => _manager;
            set
            {
                if (_waiter == null && _deliverer == null && _cook == null)
                {
                    if (value != _manager)
                    {
                        _manager = value;
                        value.Employee = this;
                    }
                }
                else
                {
                    throw new Exception("This employee already has a role");
                }
            }
        }


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
