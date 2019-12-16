using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework2
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 09/12/2016
    // CLASS DESCRIPTION: ReferenceNumber is a class which provides the Customer Reference Number for use with the Customer class.
            // It contains an implementaton of a singleton pattern. An accumulator is also found within this class.


    // Implementation of Singleton Pattern for Customer Reference Number
    class ReferenceNumber
    {
        private static ReferenceNumber custRefInstance;

        private ReferenceNumber() {}

        public static ReferenceNumber CustRefInstance
        {
            get
            {
                if (custRefInstance == null)
                {
                    custRefInstance = new ReferenceNumber();
                }
                return custRefInstance;
            }
        }

        // Declare private and public integers for the Customer Reference Number
        private int currentCustRef = 1;
        public int CurrentCustRef
        {
            get { return currentCustRef; }
            set { currentCustRef = value; }
        }

        // Method for accumulating Customer Reference Number
        public int custRefAccumulator()
        {
            return currentCustRef++;
        }
    }
}