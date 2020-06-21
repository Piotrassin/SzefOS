using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Manager
    {
        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                if (value != _employee)
                {
                    _employee = value;
                    value.Manager = this;
                }
            }
        }

        public Manager() { }

    }
}
