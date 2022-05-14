using System;
namespace PhoneBook
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; } 

        public Contact(string firstName, string lastName, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        
    }
}
