using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Manager
    {
        [Key, ForeignKey("Employee")]
        public int Id { get; set; }

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
