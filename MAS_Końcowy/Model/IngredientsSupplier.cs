using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class IngredientsSupplier : Person
    {
        //public int PersonId { get; set; }
        public String NIP { get; set; }
        public String CompanyName { get; set; }
        public bool HasRefrigeratedTrailers { get; set; }
        public ICollection<Contract> Contracts { get; set; }


        public IngredientsSupplier() : base() { }

        public IngredientsSupplier(String name, String lname, String phoneNum, String nip, String compName, bool hasRefrigeratedTrailers)
            : base(name, lname, phoneNum)
        {
            NIP = nip;
            CompanyName = compName;
            HasRefrigeratedTrailers = hasRefrigeratedTrailers;
        }
    }
}
