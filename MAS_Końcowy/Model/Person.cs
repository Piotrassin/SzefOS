using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public abstract class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String PhoneNumber { get; set; }
        public Address Address { get; set; }

        protected Person() { }

        protected Person(String name, String lname, String phoneNum)
        {
            Name = name;
            Lastname = lname;
            PhoneNumber = phoneNum;
        }
    }
}
