using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.Tests
{
    public class PhoneBookTests
    {
        PhoneBook phoneBook = new PhoneBook();
        
        [Fact]        

        public void AddContact_AppendContactToPhoneBook_ReturnPhoneBookContactsCountBeforeAndAfter()
        {
            int phoneBookCountBefore = phoneBook.Contacts.Count;

            phoneBook.AddContact("Adam", "Boll", 123123123);

            Assert.Equal(phoneBookCountBefore + 1, phoneBook.Contacts.Count);
        }
    }
}
