using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework2
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 09/12/2016
    // CLASS DESCRIPTION: Customer class contains the values with relation to an instance of customer, such as Forename,
            // Surname, Address and CustomerReference. These are used when adding, viewing, amending and deleting customers in the GUI window.

    class Customer
    {
        // Declaring strings/ints for use with Customer class
        private string forename;
        private string surname;
        private string address;
        private int customerReference;

        // Public getters and setters
        public string Forename
        {
            get { return forename; }
            set { forename = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public int CustomerReference
        {
            get { return customerReference; }
            set { customerReference = value; }
        }
    }
}
