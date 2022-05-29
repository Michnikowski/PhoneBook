using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.Tests
{
    public class ContactTests
    {
        [Fact]

        public void Contact_ForNewInstance_ReturnContactInstance()
        {
            Contact contact = new Contact("Mike", "Case", 123123123);

            Assert.Equal("Mike", contact.FirstName);
            Assert.Equal( "Case", contact.LastName);
            Assert.Equal(123123123, contact.PhoneNumber);
        }
    }
}
