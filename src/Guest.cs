using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework2
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 09/12/2016
    // CLASS DESCRIPTION: Guest class contains the values with relation to an instance of guest, such as Name, Passport and Age.
            // These are used when adding guests in the GUI window.

    class Guest
    {
        private int noOfGuests;
        private string name;
        private string passport;
        private int age;

        public int NoOfGuests
        {
            get { return noOfGuests; }
            set { noOfGuests = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
