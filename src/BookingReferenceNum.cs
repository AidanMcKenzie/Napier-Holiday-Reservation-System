using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework2
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 09/12/2016
    // CLASS DESCRIPTION: BookingReferenceNumber is a class which provides the Booking Reference Number for use with the Booking
            // class. It contains an implementaton of a singleton pattern. An accumulator is also found within this class.

    // Implementation of Singleton Pattern for Booking Reference Number
    class BookingReferenceNum
    {
        private static BookingReferenceNum bookRefInstance;

        private BookingReferenceNum() { }

        public static BookingReferenceNum BookRefInstance
        {
            get
            {
                if (bookRefInstance == null)
                {
                    bookRefInstance = new BookingReferenceNum();
                }
                return bookRefInstance;
            }
        }

        // Declare private and public integers for the Booking Reference Number
        private int currentBookRef = 1;
        public int CurrentBookRef
        {
            get { return currentBookRef; }
            set { currentBookRef = value; }
        }

        // Method for accumulating Booking Reference Number
        public int bookRefAccumulator()
        {
            return currentBookRef++;
        }
    }
}
