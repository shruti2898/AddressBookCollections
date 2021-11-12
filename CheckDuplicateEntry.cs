using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
    class CheckDuplicateEntry
    {
        List<Person> addressBook = new List<Person>();
        class Person
        {
            internal string name;
            internal long phone;
            internal string email;
            internal string address;
            internal string city;
            internal string state;
            internal int zip;
        }

        void addContact()
        {
            Person person = new Person();
            Console.WriteLine("\nPlease Enter Contact Details: \n");
            Console.Write("Name:  ");
            person.name = Console.ReadLine();
            person.name = CheckDuplicate(addressBook, person.name);
            Console.Write("Phone Number:  ");
            person.phone = long.Parse(Console.ReadLine());
            Console.Write("Email:  ");
            person.email = Console.ReadLine();
            Console.Write("Address:  ");
            person.address = Console.ReadLine();
            Console.Write("City:  ");
            person.city = Console.ReadLine();
            Console.Write("State:  ");
            person.state = Console.ReadLine();
            Console.Write("Zip:  ");
            person.zip =int.Parse(Console.ReadLine());

            addressBook.Add(person);
           
        }

        string CheckDuplicate(List<Person> addressBook,string name)
        {
            if (addressBook.Count != 0)
            {
                for (int i = 0; i < addressBook.Count; i++)
                {
                    String userName = addressBook[i].name;
                    do
                    {
                        if (name.Equals(userName))
                        {
                            Console.Write("\nPlease Enter Unique Name Again:   ");
                            name = Console.ReadLine();
                        }
                    } while (name.Equals(userName));
                }
            }
            return name;
        }


        void DisplayContactDetails(List<Person> addressBook)
        {   int count = 1;
            if (addressBook.Count == 0)
            {
                Console.WriteLine("AddressBook is empty.");
            }
            else
            {
                Console.WriteLine("\n\nContacts: ");
                foreach (var contact in addressBook)
                {
                    Console.WriteLine("{0}.  {1}  {2}  {3}  {4}  {5}  {6}  {7}", count, contact.name, contact.phone, contact.email, contact.address, contact.city, contact.state, contact.zip);
                    count++;
                }
            }
        }

        public void AddressBookSystem()
        {
            Console.WriteLine("Select an option: \n1. Create Contact \n2. Display Contacts\n0. Exit\n");
            Console.Write("Option:   ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        char choice;
                        do
                        {
                            Console.Clear();
                            addContact();
                            Console.WriteLine("\nDo you want to add more contacts?  (y/n)");
                            choice = char.Parse(Console.ReadLine());
                        } while (choice=='y');
                        DisplayContactDetails(addressBook);
                    }
                    break;
                case 2:
                    {
                        DisplayContactDetails(addressBook);
                    }
                    break;
                default:
                    Environment.Exit(-1);
                    break;
            }
        }
    }
}
