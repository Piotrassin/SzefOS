using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class IngredientsSupplier
        //: Person
    {
        [Key, ForeignKey("Person")]
        public int Id { get; set; }
        public String NIP { get; set; }
        public String CompanyName { get; set; }
        public bool HasRefrigeratedTrailers { get; set; }
        public ICollection<Contract> Contracts { get; set; }


        public IngredientsSupplier() { }

        public IngredientsSupplier(String nip, String compName, bool hasRefrigeratedTrailers)
        {
            NIP = nip;
            CompanyName = compName;
            HasRefrigeratedTrailers = hasRefrigeratedTrailers;
        }
    }
}
