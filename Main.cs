using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressList
{
    internal class AddressListInit
    {
        private static AddressBook? book;

        static void Main(string[] args)
        {
            book = new AddressBook();
            ShowMeny();
        }

        private static void ShowMeny()
        {
            string command = "";
            while (command != "exit")
            {
                Console.Clear();
                // Display title as the C# console adressbok app.
                Console.WriteLine("***********************************");
                Console.WriteLine("Console Adressbok application in C#\r");
                Console.WriteLine("***********************************\n");

                // Ask the user to choose an option.
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add person");
                Console.WriteLine("\tb - Remove person");
                Console.WriteLine("\tc - Find person");
                Console.WriteLine("\td - List all persons");

                Console.WriteLine("Please enter your option: ");
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "a":
                        book.AddPerson();
                        break;
                    case "b":
                        book.RemovePerson();
                        break;
                    case "c":
                        book.PrintPerson();
                        break;
                    case "d":
                        book.ListAddresBook();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
