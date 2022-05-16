using System;
using System.Collections.Generic;

namespace PhoneBook
{
    public class PhoneBook
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public PhoneBook()
        {
            GetInitialContactsList();
        }

        public void GetInitialContactsList()
        {
            Contacts.Add(new Contact("Henry", "Clark", 12345));
            Contacts.Add(new Contact("Lisa", "Mole", 23456));
            Contacts.Add(new Contact("Ben", "Robert", 34567));
            Contacts.Add(new Contact("Mike", "Row", 45678));
            Contacts.Add(new Contact("Wiliam", "Brown", 56789));
            Contacts.Add(new Contact("Robert", "Brown", 34234));
            Contacts.Add(new Contact("Bob", "Brown", 23456));
            Contacts.Add(new Contact("Mandy", "Grow", 12356));
        }

        private void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"Name: {contact.LastName} {contact.FirstName} number: {contact.PhoneNumber}");
        }

        public void DisplayAllContacts()
        {
            Console.WriteLine("\n*** PRINTING ALL CONTACTS - START ***\n");

            foreach (Contact contact in Contacts)
            {
                DisplayContactDetails(contact);
            }

            Console.WriteLine("\n*** END ***");
        }

        public void AddContact(string firstName, string lastName, int phoneNumber)
        {
            if(!PhoneNumberExistOnList(phoneNumber))
            {
                Contacts.Add(new Contact(firstName, lastName, phoneNumber));

                Console.WriteLine($"\nContact {firstName} {lastName} with phone number: {phoneNumber} added to list...");
            }
            else
            {
                Console.WriteLine($"\nPhone number: {phoneNumber} already exist in phone book and can't be added...");
            }
        }

        public void GetPersonByNumber(int phoneNumber)
        {
            if (PhoneNumberExistOnList(phoneNumber))
            {
                Contact contact = Contacts.Find(x => x.PhoneNumber == phoneNumber);

                Console.WriteLine($"\nOwner of this phone number {contact.PhoneNumber} is {contact.FirstName} {contact.LastName}");
            }
            else
            {
                Console.WriteLine($"\nPhone number: {phoneNumber} not exist on this list...");
            }
        }

        private bool PhoneNumberExistOnList(int phoneNumber)
        {
            return Contacts.Exists(x => x.PhoneNumber == phoneNumber);
        }

        public void GetContactsByLastName(string searchPhrase)
        {
            List<Contact> results = Contacts.FindAll(x => FindLastName(x, searchPhrase));

            if (results.Count > 0)
            {
                Console.WriteLine($"\nFound records contains '{searchPhrase}' in last name:");

                foreach(Contact contact in results)
                {
                    DisplayContactDetails(contact);
                }
            }
            else
            {
                Console.WriteLine($"\nContact contains '{searchPhrase}' in last name not exist...");
            }
        }

        private static bool FindLastName(Contact contact, string lastName)
        {
            if (contact.LastName.Contains(lastName))
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
