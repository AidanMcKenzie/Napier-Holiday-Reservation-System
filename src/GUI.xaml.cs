using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coursework2
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 09/12/2016
    // CLASS DESCRIPTION: The main window. All of the user interactability is on this window. Includes options to add a customer,
            // booking or guest. Also includes functionality to view, modify and delete these instances. Most of the project code
            // is a part of this class, only singleton classes and classes for booking/customer/guest containing separate code.
    public partial class GUI : Window
    {
        public GUI()
        {
            InitializeComponent();
        }
        private void txtForename_TextChanged(object sender, TextChangedEventArgs e) { }

        // Singleton instance
        ReferenceNumber rn = ReferenceNumber.CustRefInstance;
        BookingReferenceNum bn = BookingReferenceNum.BookRefInstance;
        // Lists declared for Customer, Booking, Guest
        List<Customer> custList = new List<Customer>();
        List<BookingClass> bookList = new List<BookingClass>();
        List<Guest> guestList = new List<Guest>();

        // Declare integers for use with guests
        int noOfGuests = 0;
        int ageCost = 0;

        // Code for when the user clicks on 'Create customer' button
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
                // New instance of Class 'Customer'
                Customer newCust = new Customer();
                // Checks if first name box is empty
                if (txtForename.Text == "")
                {
                    MessageBox.Show("Please enter your forename");
                }
                // Else customer's first name is what was entered in the FirstName box
                else
                {
                    newCust.Forename = txtForename.Text;
                }

                // Checks if last name box is empty
                if (txtSurname.Text == "")
                {
                    MessageBox.Show("Please enter your surname");
                }
                // Else customer's last name is what was entered in the LastName box
                else
                {
                    newCust.Surname = txtSurname.Text;
                }
                // Checks if address box is empty
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter an address");
                }
                // Else customer's address is what is enetered in the Address box
                else
                {
                    newCust.Address = txtAddress.Text;
                }
                // if Forename or Address textboxes are empty, display and error message. Else, continue woth the program
                if (txtForename.Text == "" || txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter valid values in the input boxes");
                }
                else
                {
                    // Customer Reference field of Customer is the accumulated int from the singleton class
                    newCust.CustomerReference = rn.custRefAccumulator();
                    // Add the instance of Customer to the customer List
                    custList.Add(newCust);
                    // MessageBox showing the successful creation of a customer
                    MessageBox.Show("Customer Created!\n\nName: " + newCust.Forename + " " + newCust.Surname + "\nAddress: " + newCust.Address + "\nCustomer Reference Number: " + newCust.CustomerReference);

                    // Set the text boxes to empty
                    txtForename.Text = null;
                    txtSurname.Text = null;
                    txtAddress.Text = null;
                }
        }

        // Code for when user clicks the 'Create booking' button
        private void btnCreateBook_Click(object sender, RoutedEventArgs e)
        {
            // If the number of guests in the booking is between 1 and 4, continue woth the program
            if (noOfGuests > 0 && noOfGuests < 5)
            {
                // Declare int that determines the total days in a booking
                int totalDays = (dateDeparture.SelectedDate.Value - dateArrival.SelectedDate.Value).Days;
                // Declare doubles for calculating cost
                double extrasCost = 0;
                double mealsCost = 0;
                double breakfastCost = 0;
                double carCost = 0;

                // New instance of Booking class
                BookingClass newBooking = new BookingClass();

                // If the total days stayed are less than 1 (i.e. impossible), display an error
                if (totalDays < 1)
                {
                    MessageBox.Show("Your departure date must be later than your arrival date");
                }
                // Else, continue with program
                else
                {
                    // Checks if Arrival Date has been selected
                    if (dateArrival.SelectedDate.ToString() == "")
                    {
                        MessageBox.Show("Please enter a valid Arrival Date");
                    }
                    // Else the selected date is incorporated into the class instance
                    else
                    {
                        newBooking.ArrivalDate = dateArrival.SelectedDate.Value;
                    }
                }

                    // Checks if first name box is empty
                    if (dateDeparture.SelectedDate.ToString() == "")
                    {
                        MessageBox.Show("Please select a valid Departure Date");
                    }
                    // Else the selected date is incorporated into the class instance
                    else
                    {
                        newBooking.DepartureDate = dateDeparture.SelectedDate.Value;
                    }


                    // If checkboxe was checked
                    if (chkMeals.IsChecked == true)
                    {
                        // Meals cost is set to 15 times the number of guests
                        mealsCost = 15 * noOfGuests;
                        // Meals cost is set to meals cost times the total days
                        mealsCost = mealsCost * totalDays;
                        // Extras cost adds on mealsCost
                        extrasCost = extrasCost + mealsCost;

                        // Confirms that meal checkbox was clicked
                        newBooking.Meal = true;
                    }

                    // If checkbox was clicked
                    if (chkBreakfast.IsChecked == true)
                    {
                        // breakfastCost is set to 5 times the number of guests 
                        breakfastCost = 5 * noOfGuests;
                        // BreakfastCost is set to breakfast cost times the total days
                        breakfastCost = breakfastCost * totalDays;
                        // Extras cost adds on breakfastCost
                        extrasCost = extrasCost + breakfastCost;

                        // Confirms that breakfast checkbox was clicked
                        newBooking.Breakfast = true;
                    }

                    // If checkbox was clicked
                    // Operation same as above checkboxes
                    if (chkCar.IsChecked == true)
                    {
                        carCost = ageCost * noOfGuests;
                        carCost = carCost * totalDays;

                        extrasCost = extrasCost + carCost;

                        newBooking.Car = true;
                    }

                    // If arrivalDate box or departureDate box is empty
                    if (dateArrival.SelectedDate.ToString() == "" || dateDeparture.SelectedDate.ToString() == "")
                    {
                        MessageBox.Show("Please enter valid values in the input boxes");
                    }
                    // Else continue with program
                    else
                    {
                        // Customer Reference field of Customer is the accumulated int from the singleton class
                        newBooking.BookingReference = bn.bookRefAccumulator();

                        // Add instance of Booking to Booking list
                        bookList.Add(newBooking);
                        // MessageBox showing the successful creation of a booking
                        MessageBox.Show("Booking Created!\nArrival Date: " + newBooking.ArrivalDate + "\nDeparture Date: " + newBooking.DepartureDate + "\nNumber of Guests: " + noOfGuests + "\nBooking Reference Number: " + newBooking.BookingReference);
                        MessageBox.Show("INVOICE\n\n\nTotal Cost: £" + ((ageCost * totalDays) + extrasCost) + "\n\nCost Per Night: £" + ageCost * totalDays + "\n\nCost of Extras: £" + extrasCost);

                        // Set boxes/checkboxes to empty
                        dateArrival.SelectedDate = null;
                        dateDeparture.SelectedDate = null;
                        chkMeals.IsChecked =! true;
                        chkBreakfast.IsChecked =! true;
                        chkCar.IsChecked =! true;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter details for a guest");
                }

        }

        // Button for amending customer details
        private void btnChangeCust_Click(object sender, RoutedEventArgs e)
        {
            // Loop through list
            for (int i = 0; i < custList.Count; i++)
            {
                // If the reference number user entered is equal to one found in list
                if (Int32.Parse(txtChangeCust.Text) == custList[i].CustomerReference)
                {
                    // Set list values to what is entered in the textboxes
                    custList[i].Forename = txtForename.Text;
                    custList[i].Surname = txtSurname.Text;
                    custList[i].Address = txtAddress.Text;

                    MessageBox.Show("Customer details for " + custList[i].Forename + " " + custList[i].Surname + " successfully changed!");
                    // Set textboxes to empty
                    txtForename.Text = null;
                    txtSurname.Text = null;
                    txtAddress.Text = null;
                }
            }
        }

        // Code for View Customer Button
        private void btnViewCust_Click(object sender, RoutedEventArgs e)
        {
            // If the textbox is empty
            if (txtChangeCust.Text != null && txtChangeCust.Text != "")
            {
                // Loop through list
                for (int i = 0; i < custList.Count; i++)
                {
                    // If the reference number entered is found in the list
                    if (Int32.Parse(txtChangeCust.Text) == custList[i].CustomerReference)
                    {
                        // Set textboxes to the data found in list
                        txtForename.Text = custList[i].Forename;
                        txtSurname.Text = custList[i].Surname;
                        txtAddress.Text = custList[i].Address;
                    }
                    else
                    {
                        MessageBox.Show("A customer record for this Customer Reference Number could not be found");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Customer Reference Number");
            }
        }


        // Code for View Booking
        private void btnViewBook_Click(object sender, RoutedEventArgs e)
        {
            // If textbox is empty
            if (txtChangeBook.Text != null && txtChangeBook.Text != "")
            {
                // Loop through list
                for (int i = 0; i < bookList.Count; i++)
                {
                    // If reference number entered is found in the list
                    if (Int32.Parse(txtChangeBook.Text) == bookList[i].BookingReference)
                    {
                        // Set textboxes to data found in list
                        dateArrival.SelectedDate = bookList[i].ArrivalDate;
                        dateDeparture.SelectedDate = bookList[i].DepartureDate;
                        chkMeals.IsChecked = bookList[i].Meal;
                        chkBreakfast.IsChecked = bookList[i].Breakfast;
                        chkCar.IsChecked = bookList[i].Car;
                    }
                    else
                    {
                        MessageBox.Show("A customer record for this Booking Reference Number could not be found");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Booking Reference Number");
            }
        }


        // Code for Delete Customer Button
        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            // If textbox is empty
            if (txtChangeCust.Text != null && txtChangeCust.Text != "")
            {
                // Loop through list
                for (int i = 0; i < custList.Count; i++)
                {
                    // If reference number entered is found in list
                    if (Int32.Parse(txtChangeCust.Text) == custList[i].CustomerReference)
                    {
                        // Set textbox to empty
                        txtChangeCust.Text = null;
                        // Remove entry from list
                        custList.Remove(custList[i]);

                        // Set textboxes to empty
                        txtForename.Text = null;
                        txtSurname.Text = null;
                        txtAddress.Text = null;

                        MessageBox.Show("Customer deleted");
                    }
                    else
                    {
                        MessageBox.Show("A customer record for this Customer Reference Number could not be found");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Customer Reference Number");
            }
        }

        // Code for 'Delete Booking' button
        private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            // If textbox is empty
            if (txtChangeBook.Text != null && txtChangeBook.Text != "")
            {
                // Loop through list
                for (int i = 0; i < bookList.Count; i++)
                {
                    // If reference number entered is found in list
                    if (Int32.Parse(txtChangeBook.Text) == bookList[i].BookingReference)
                    {
                        // Set textbox to empty
                        txtChangeBook.Text = null;
                        // Remove entry from list
                        bookList.Remove(bookList[i]);

                        // Set textboxes/checkboxes to empty
                        dateArrival.SelectedDate = null;
                        dateDeparture.SelectedDate = null;
                        chkMeals.IsChecked = null;
                        chkBreakfast.IsChecked = null;
                        chkCar.IsChecked = null;

                        MessageBox.Show("Booking deleted");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Booking Reference Number");
            }
        }

        // Code for 'Add Guest' button
        private void btnGuest1_Click(object sender, RoutedEventArgs e)
        {
            if (noOfGuests < 4)
            {
                // New instance of Guest class
                Guest newGuest = new Guest();

                // If Guest name box is empty, display error
                if (txtGuestName.Text == null || txtGuestName.Text == "")
                {
                    MessageBox.Show("Please enter a Guest name");
                }
                // Else what the user entered becomes the relevant class field
                else
                {
                    newGuest.Name = txtGuestName.Text;
                }


                // If Guest passport box is empty, display error
                if (txtGuestPassport.Text == null || txtGuestPassport.Text == "")
                {
                    MessageBox.Show("Please enter a Passport number");
                }
                // Else what the user entered becomes the relevant class field
                else
                {
                    newGuest.Passport = txtGuestPassport.Text;
                }

                // Ensures that only numericals are entered
                if (System.Text.RegularExpressions.Regex.IsMatch(txtGuestAge.Text, "[ ^ 0-9]"))
                {
                    // If guest age box is empty, display error
                    if (txtGuestAge.Text == null || txtGuestAge.Text == "")
                    {
                        MessageBox.Show("Please enter Guest Age");
                    }
                    // Else if the age is not within the accepted boundaries, display error
                    else if (Int32.Parse(txtGuestAge.Text) > 101 || Int32.Parse(txtGuestAge.Text) < 0)
                    {
                        MessageBox.Show("Please enter an age between 0-101");
                    }
                    // Else, continue with the program
                    else
                    {
                        // The age of the guest is what the user entered
                        newGuest.Age = Int32.Parse(txtGuestAge.Text);
                        // If the guest age is over 17, set ageCost to £50
                        if (Int32.Parse(txtGuestAge.Text) > 17)
                        {
                            ageCost = 50;
                        }
                        // Else set it to £30
                        else
                        {
                            ageCost = 30;
                        }
                    }
                }
                // if guest name box or the passport box is NOT empty
                if (txtGuestName.Text != "" || txtGuestPassport.Text != "")
                {
                    // Accumulate the number of guests
                    noOfGuests++;
                    // Add instance of Guest to Guest List
                    guestList.Add(newGuest);

                    // Display MessageBox with relevant info
                    MessageBox.Show("Guest " + noOfGuests + " Created!\n\nName: " + newGuest.Name + "\nPassport Number: " + newGuest.Passport + "\nAge: " + newGuest.Age);

                    // Set textboxes to empty
                    txtGuestName.Text = null;
                    txtGuestPassport.Text = null;
                    txtGuestAge.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Maximum number of guests reached.");
            }
        }
    }
}
