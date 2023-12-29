using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressList
{
    public class Address
    {
        public string Street { get; set; }
        public string HouseNbr { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public Address(string street, string houseNbr, string zipCode,
            string city) {
            this.Street = street;
            this.HouseNbr = houseNbr;
            this.ZipCode = zipCode;
            this.City = city;
        }

        public Address()
        {
        }
    }
}
