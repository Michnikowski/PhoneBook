using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Phone book - WELCOME!!!\n");

            PhoneBook phoneBook = new PhoneBook();

            phoneBook.DisplayAllContacts();

            phoneBook.AddContact("Rock", "Baloon", 745343214);
            phoneBook.AddContact("Lil", "Galon", 352876548);
            phoneBook.AddContact("Fany", "Red", 13634);

            phoneBook.DisplayAllContacts();

            phoneBook.AddContact("Fany", "Red", 13634);

            phoneBook.GetPersonByNumber(92334);
            phoneBook.GetPersonByNumber(11111);

            phoneBook.GetContactsByLastName("Galon");
            phoneBook.GetContactsByLastName("Brown");
            phoneBook.GetContactsByLastName("Green");

            phoneBook.GetContactsByLastName("own");

            Console.WriteLine("User interface:");
            Console.WriteLine("0 End program");
            Console.WriteLine("1 Add new contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 Display all contacts");
            Console.WriteLine("4 Search contacts by last name");
            Console.WriteLine("5 Remove contact by phone number");

            string userInput = default;
            string phoneNumberString = default;
            int phoneNumber = default;
            string lastName = default;
            string firstName = default;

            while (userInput != "0")
            {
                Console.WriteLine("\nType instructions:");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        Console.WriteLine("Insert number:");
                        phoneNumberString = Console.ReadLine();

                        int.TryParse(phoneNumberString, out phoneNumber);

                        if (!phoneBook.CorrectPhoneNumber(phoneNumber)) break;                        

                        Console.WriteLine("Insert first name: ");
                        firstName = Console.ReadLine();

                        Console.WriteLine("Insert last name: ");
                        lastName = Console.ReadLine();

                        if (firstName.Length < 4 || lastName.Length < 4)
                        {
                            Console.WriteLine("First name and last name need to be longer than 3 characters...");
                            break;
                        }                     

                        phoneBook.AddContact(firstName, lastName, phoneNumber);

                        break;

                    case "2":

                        Console.WriteLine("Insert number you looking for:");

                        phoneNumberString = Console.ReadLine();

                        int.TryParse(phoneNumberString, out phoneNumber);

                        if (!phoneBook.CorrectPhoneNumber(phoneNumber)) break;

                        phoneBook.GetPersonByNumber(phoneNumber);

                        break;

                    case "3":

                        phoneBook.DisplayAllContacts();
                        break;

                    case "4":

                        Console.WriteLine("Insert last name you looking for:");

                        lastName = Console.ReadLine();

                        if (lastName == "") break;

                        phoneBook.GetContactsByLastName(lastName);

                        break;

                    case "5":

                        Console.WriteLine("Insert number you want to remove:");

                        phoneNumberString = Console.ReadLine();

                        int.TryParse(phoneNumberString, out phoneNumber);

                        if (!phoneBook.CorrectPhoneNumber(phoneNumber)) break;

                        phoneBook.DeleteContactBasedOnPhoneNumber(phoneNumber);

                        break;

                    case "0":
                        Console.WriteLine("Thank you. Good bye.");
                        break;

                    default:
                        Console.WriteLine("This is wrong instruction... Try again or finish program typing '0'.");
                        break;
                }
            }            
        }
    }
}
