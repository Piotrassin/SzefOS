using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime DateOfSigning { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int NumberOfDeliveries { get; set; }
        public String Description { get; set; }

        public Contract() { }

        public Contract(DateTime signDate, DateTime expirationDate, int numOfDeliveries, String description) {
            DateOfSigning = signDate;
            ExpirationDate = expirationDate;
            NumberOfDeliveries = numOfDeliveries;
            Description = description;
        }
    }
}
