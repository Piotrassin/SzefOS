using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Address
    {
        public int Id { get; set; }
        public String StreetName { get; set; }
        public String BuildingNumber { get; set; }
        public String FlatNumber { get; set; }
        public String Postcode { get; set; }
        public String CityName { get; set; }

        public Person Person { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Address() { }
        public Address(String strName, String buildingNum, String flatNum, String postcode, String city)
        {
            StreetName = strName;
            BuildingNumber = buildingNum;
            FlatNumber = flatNum;
            Postcode = postcode;
            CityName = city;
        }

        public override string ToString()
        {
            return StreetName + ", " + BuildingNumber + ", " + FlatNumber + ", " + Postcode + ", " + CityName;
        }
    }
}
