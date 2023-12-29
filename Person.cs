using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressList
{
    public class Person
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }

        public Person(string email, string name, string surname, string phonenumber, Address address)
        {
            this.Email = email;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phonenumber;
            this.Address = address;
        }
    }
}
