using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class IngredientsSupplier : Person
    {
        public String NIP { get; set; }
        public String CompanyName { get; set; }
        public bool HasRefrigeratedTrailers { get; set; }
        public ICollection<Contract> Contracts { get; set; }


        public IngredientsSupplier() : base() { }

        public IngredientsSupplier(
            String name, String lname, String phoneNum, Address address, 
            String nip, String compName, bool hasRefrigeratedTrailers)
            : base(name, lname, phoneNum, address)
        {
            NIP = nip;
            CompanyName = compName;
            HasRefrigeratedTrailers = hasRefrigeratedTrailers;
        }
    }
}
