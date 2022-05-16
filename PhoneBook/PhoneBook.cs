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
            Contacts.Add(new Contact("Henry", "Clark", 123456789));
            Contacts.Add(new Contact("Lisa", "Mole", 234567890));
            Contacts.Add(new Contact("Ben", "Robert", 345678901));
            Contacts.Add(new Contact("Mike", "Row", 456789012));
            Contacts.Add(new Contact("Wiliam", "Brown", 567890123));
            Contacts.Add(new Contact("Robert", "Brown", 123424567));
            Contacts.Add(new Contact("Bob", "Brown", 837475829));
            Contacts.Add(new Contact("Mandy", "Grow", 937482398));
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

        public void DeleteContactBasedOnPhoneNumber(int phoneNumber)
        {
            if (PhoneNumberExistOnList(phoneNumber))
            {
                Contact contact = Contacts.Find(x => x.PhoneNumber == phoneNumber);

                Contacts.Remove(contact);

                Console.WriteLine($"\nContact with phone number {phoneNumber} deleted...");
            }
            else
            {
                Console.WriteLine($"\nPhone number: {phoneNumber} not exist on this list...");
            }
        }
    }
}
