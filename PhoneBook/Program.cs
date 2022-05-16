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

            phoneBook.AddContact("Rock", "Baloon", 92334);
            phoneBook.AddContact("Lil", "Galon", 47435);
            phoneBook.AddContact("Fany", "Red", 13634);

            phoneBook.DisplayAllContacts();

            phoneBook.AddContact("Fany", "Red", 13634);

            phoneBook.GetPersonByNumber(92334);
            phoneBook.GetPersonByNumber(11111);

            phoneBook.GetContactsByLastName("Galon");
            phoneBook.GetContactsByLastName("Brown");
            phoneBook.GetContactsByLastName("Green");

            phoneBook.GetContactsByLastName("own");

        }        
    }
}
