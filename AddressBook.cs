using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.Security;
using System.Net.Http.Json;

namespace AddressList
{
    public class AddressBook
    {
        public List<Person> persons;
        public string name = "";
        public string lastName = "";
        public string email = "";
        public string phoneNumber = "";
        public Address address;

        public AddressBook()
        {
            persons = new List<Person>();
            address = new Address();
        }

        public void AddPerson()
        {
            Person newPerson = GetInputAddPerson();

            persons = ReadJson();

            bool personExists = false;

            //check if new person already exists in address list
            if(persons != null) 
            {
                personExists = FindPerson(newPerson.Email) != null;
            }
            if (personExists)
            {
                Console.WriteLine("This email is already registred in address book");
                Console.WriteLine("************************************************************************");
                Console.WriteLine("Please press enter to return to main many");
                Console.ReadLine();
            }
            else
            {
                persons.Add(newPerson);
                persons.OrderBy(p => p.Name).ToList();
            }
            if (persons.Count > 0)
            {
                WriteToJsonFile(persons);
            }
        }

        //Method to get input from user and return as Person object
        private Person GetInputAddPerson()
        {
            Console.WriteLine("Please type Firstname: ");
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty! Input your name once more");
                name = Console.ReadLine();
            }
            Console.WriteLine("Please type Lastname: ");
            lastName = Console.ReadLine();
            if (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Last name can't be empty! Input your last name once more");
                lastName = Console.ReadLine();
            }
            Console.WriteLine("Please type Email address: ");
            email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email can't be empty! Input your email once more");
                email = Console.ReadLine();
            }
            Console.WriteLine("Please type Phone Number: ");
            phoneNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("Phone number can't be empty! Input your phone once more");
                phoneNumber = Console.ReadLine();
            }
            Console.WriteLine("Please type Street: ");
            address.Street = Console.ReadLine();
            if (string.IsNullOrEmpty(address.Street))
            {
                Console.WriteLine("Address can't be empty! Input your street name once more");
                address.Street = Console.ReadLine();
            }
            Console.WriteLine("Please type Number: ");
            address.HouseNbr = Console.ReadLine();
            if (string.IsNullOrEmpty(address.HouseNbr))
            {
                Console.WriteLine("Number can't be empty! Input your house number once more");
                address.HouseNbr = Console.ReadLine();
            }
            Console.WriteLine("Please type Zip Code: ");
            address.ZipCode = Console.ReadLine();
            if (string.IsNullOrEmpty(address.ZipCode))
            {
                Console.WriteLine("Zip Code can't be empty! Input your zip once more");
                address.ZipCode = Console.ReadLine();
            }
            Console.WriteLine("Please type City: ");
            address.City = Console.ReadLine();
            if (string.IsNullOrEmpty(address.City))
            {
                Console.WriteLine("City can't be empty! Input your city name once more");
                address.City = Console.ReadLine();
            }
            return new Person(email, name, lastName, phoneNumber, address );
        }

        //method to read json file
        public List<Person> ReadJson()
        {
            List<Person> items;
            string path = "C:\\Users\\filip\\Projects\\AddressList\\jsonAddressBook.json";
            //string path = Directory.GetCurrentDirectory() + "/jsonAddressBook.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            return items;
        }

        //method to write to json file
        public bool WriteToJsonFile(List<Person> persons)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(persons);
                //string path = Directory.GetCurrentDirectory() + "/jsonAddressBook.json";
                string path = "C:\\Users\\filip\\Projects\\AddressList\\jsonAddressBook.json";
                File.WriteAllText(path, json);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        //list all users in address list
        internal void ListAddresBook()
        {
            persons = ReadJson();
            //sort list in alphabetical order by name 
            persons.Sort((x, y) => string.Compare(x.Name, y.Name));
            persons.ForEach(person =>
            {
                Console.WriteLine("************************************************************************");
                Console.WriteLine("*First name: " + person.Name + "\n*Last name: " + person.Surname + "\n*Email: " + person.Email + "\n*Address: " + person.Address.Street + " " + person.Address.HouseNbr + ", " + person.Address.ZipCode + " " + person.Address.City + " " + "\n*Phone number: " + person.PhoneNumber);
            });
            Console.WriteLine("************************************************************************");
            Console.WriteLine("Please press enter to return to main many");
            Console.ReadLine();
        }

        //remove person with from address list
        internal void RemovePerson()
        {
            if (persons.Count != 0)
            {
                Console.WriteLine("Please type Email address for person you want to remove: ");
                email = Console.ReadLine();
                persons = ReadJson();

                Person pers = FindPerson(email);
                if (pers != null)
                {
                    persons.Remove(pers);
                }

                else
                {
                    Console.WriteLine("This email is not registred in address book");
                    Console.WriteLine("************************************************************************");
                    Console.WriteLine("Please press enter to return to main many");
                    Console.ReadLine();
                }

                WriteToJsonFile(persons);
            }
            else
            {
                Console.WriteLine("Address Book is empty");
                Console.ReadLine();
            }
        }


        //find person in list by email
        public Person FindPerson(string email)
        {
            Person searchedPerson = persons.Find((p) => p.Email == email);
            return searchedPerson;
        }

        //show list with all persons in console
        public bool PrintPerson()
        {

            Console.WriteLine("Please type Email address for person you want to be listed: ");
            email = Console.ReadLine();
            persons = ReadJson();
            Person pers = FindPerson(email);
            if (pers != null)
            {
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*First name: " + pers.Name + "\n*Last name: " + pers.Surname + "\n*Email: " + pers.Email + "\n*Address: " + pers.Address.Street + " " + pers.Address.HouseNbr + ", " + pers.Address.ZipCode + " " + pers.Address.City + " " + "\n*Phone number: " + pers.PhoneNumber);
                Console.WriteLine("*******************************************************************************");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("This email is not registred in address book");
                Console.WriteLine("************************************************************************");
                Console.WriteLine("Please press enter to return to main many");
                Console.ReadLine();
                return false;
            }

        }
    }
}
