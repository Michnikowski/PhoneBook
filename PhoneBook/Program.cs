using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact mike = new Contact("Mike", "Case", 1234);

            Console.WriteLine($"Name: {mike.FirstName} {mike.LastName} number: {mike.PhoneNumber}");

            List<Contact> contacts = new List<Contact>();

            getContactsList(contacts);

            printAllContacts(contacts);

            addNewContact("Rock", "Baloon", 92334, contacts);
            addNewContact("Lil", "Galon", 47435, contacts);
            addNewContact("Fany", "Red", 13634, contacts);

            printAllContacts(contacts);

            addNewContact("Fany", "Red", 13634, contacts);

            getPersonByNumber(92334, contacts);
            getPersonByNumber(11111, contacts);

            getPersonByLastName("Galon", contacts);
            getPersonByLastName("Brown", contacts);
            getPersonByLastName("Green", contacts);

        }

        public static void getContactsList(List<Contact> contacts)
        {
            contacts.Add(new Contact("Henry", "Clark", 12345));
            contacts.Add(new Contact("Lisa", "Mole", 23456));
            contacts.Add(new Contact("Ben", "Robert", 34567));
            contacts.Add(new Contact("Mike", "Row", 45678));
            contacts.Add(new Contact("Wiliam", "Brown", 56789));
            contacts.Add(new Contact("Robert", "Brown", 34234));
            contacts.Add(new Contact("Bob", "Brown", 23456));
            contacts.Add(new Contact("Mandy", "Grow", 12356));
        }

        public static void printAllContacts(List<Contact> contacts)
        {
            Console.WriteLine("*** PRINTING ALL CONTACTS START ***");

            foreach(Contact contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName} number: {contact.PhoneNumber}");
            }

            Console.WriteLine("*** END ***");
        }

        public static void addNewContact(string firstName, string lastName, int phoneNumber, List<Contact> contacts)
        {
            bool phoneNumberOnList = phoneNumberExistOnList(phoneNumber, contacts);

            if(!phoneNumberOnList)
            {
                contacts.Add(new Contact(firstName, lastName, phoneNumber));

                Console.WriteLine($"Contact {firstName} {lastName} with phone number {phoneNumber} added to list...");
            }
            else
            {
                Console.WriteLine($"Phone number: {phoneNumber} already exist in phone book and can't be added...");
            }
            
        }

        public static void getPersonByNumber(int phoneNumber, List<Contact> contacts)
        {
            bool phoneNumberOnList = phoneNumberExistOnList(phoneNumber, contacts);

            if (phoneNumberOnList)
            {
                Contact contact = contacts.Find(x => x.PhoneNumber == phoneNumber);

                Console.WriteLine($"Owner of this phone number {contact.PhoneNumber} is {contact.FirstName} {contact.LastName}");
            }
            else
            {
                Console.WriteLine($"Phone number: {phoneNumber} not exist on this list...");
            }
        }

        public static bool phoneNumberExistOnList (int phoneNumber, List<Contact> contacts)
        {
            return contacts.Exists(x => x.PhoneNumber == phoneNumber);
        }

        public static void getPersonByLastName(string lastName, List<Contact> contacts)
        {
            List<Contact> results = contacts.FindAll(x => FindLastName(x, lastName));

            if(results.Count > 0)
            {
                Console.WriteLine("Found records by last name...");

                printAllContacts(results);

                Console.WriteLine("**** --- ****");
            }
            else
            {
                Console.WriteLine($"Contact with last name {lastName} not exist...");
            }
        }

        private static bool FindLastName (Contact contact, string lastName)
        {
            if(contact.LastName == lastName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
