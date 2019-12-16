using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework2
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 09/12/2016
    // CLASS DESCRIPTION: BookingClass class contains the values with relation to an instance of booking, such as arrivalDate,
        // bookingReference, meal and car. These are used when adding, viewing, amending and deleting a booking in the GUI window.
    class BookingClass
    {
        private DateTime arrivalDate;
        private DateTime departureDate;
        private int bookingReference;
        private bool meal;
        private bool breakfast;
        private bool car;

        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; }
        }

        public int BookingReference
        {
            get { return bookingReference; }
            set { bookingReference = value; }
        }

        public bool Meal
        {
            get { return meal; }
            set { meal = value; }
        }

        public bool Breakfast
        {
            get { return breakfast; }
            set { breakfast = value; }
        }

        public bool Car
        {
            get { return car; }
            set { car = value; }
        }

    }
}
