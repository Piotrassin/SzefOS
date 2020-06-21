using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Deliverer
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
                    value.Deliverer = this;
                }
            }
        }
        public String DrivingLicense { get; set; }
        public ICollection<Order> DeliveredOrders { get; set; }


        public Deliverer() { }

        public Deliverer(String drivingLicense)
        {
            DrivingLicense = drivingLicense;
        }

    }
}
