using System;
using System.Collections.Generic;

namespace PhoneBook
{
    public class PhoneBook
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public PhoneBook()
        {
            SetInitialContactsList();
        }

        public void SetInitialContactsList()
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
            if (PhoneNumberExistOnList(phoneNumber))
            {
                Console.WriteLine($"\nPhone number: {phoneNumber} already exist in phone book and can't be added...");

                return;
            }

            Contacts.Add(new Contact(firstName, lastName, phoneNumber));

            Console.WriteLine($"\nContact {firstName} {lastName} with phone number: {phoneNumber} added to list...");
        }

        public void GetPersonByNumber(int phoneNumber)
        {
            if (!PhoneNumberExistOnList(phoneNumber))
            {
                Console.WriteLine($"\nPhone number: {phoneNumber} not exist on this list...");

                return;
            }

            Contact contact = Contacts.Find(x => x.PhoneNumber == phoneNumber);

            Console.WriteLine($"\nOwner of this phone number {contact.PhoneNumber} is {contact.FirstName} {contact.LastName}");
        }

        private bool PhoneNumberExistOnList(int phoneNumber)
        {
            return Contacts.Exists(x => x.PhoneNumber == phoneNumber);
        }

        public void GetContactsByLastName(string searchPhrase)
        {
            List<Contact> contacts = Contacts.FindAll(x => FindLastName(x, searchPhrase));

            if(contacts.Count == 0)
            {
                Console.WriteLine($"\nContact contains '{searchPhrase}' in last name not exist...");

                return;
            }

            Console.WriteLine($"\nFound records contains '{searchPhrase}' in last name:");

            foreach(Contact contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }

        private static bool FindLastName(Contact contact, string searchPhrase)
        {
            return contact.LastName.Contains(searchPhrase);
        }

        public void DeleteContactBasedOnPhoneNumber(int phoneNumber)
        {
            if (!PhoneNumberExistOnList(phoneNumber))
            {
                Console.WriteLine($"\nPhone number: {phoneNumber} not exist on this list...");

                return;
            }

            Contact contact = Contacts.Find(x => x.PhoneNumber == phoneNumber);

            Contacts.Remove(contact);

            Console.WriteLine($"\nContact with phone number {phoneNumber} deleted...");

        }

        public bool CorrectPhoneNumber(int phoneNumber)
        {
            if (phoneNumber == 0)
            {
                Console.WriteLine("Phone number need to be a number higher or equal 100 000 000 and lower or equal to 999 999 999...");
                return false;
            }

            if (phoneNumber < 100000000 || phoneNumber > 999999999)
            {
                Console.WriteLine("Phone number must be between 100 000 000 and 999 999 999");
                return false;
            }

            return true;
        }
    }
}
