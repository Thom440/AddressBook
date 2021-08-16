using AddressBook.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class CreateContact : Form
    {
        /// <summary>
        /// Allows the address book to be accessed by all methods
        /// </summary>
        public Class.AddressBook CurrentAddressBook { get; set; }
        public CreateContact()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Creates a contact based off of user input
        /// </summary>
        private void CreateContactBtn_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTxtBox.Text;
            string lastName = lastNameTxtBox.Text;
            string address = addressTxtBox.Text;
            string city = cityTxtBox.Text;
            string state = stateTxtBox.Text;
            string zipCode = zipCodeTxtBox.Text;
            string phoneNumber = phoneNumberTxtBox.Text;

            // If there is an empty field a message will show alerting the user
            if (firstName.Trim() == string.Empty || lastName.Trim() == string.Empty || address.Trim() == string.Empty ||
                city.Trim() == string.Empty || state.Trim() == string.Empty || zipCode.Trim() == string.Empty || 
                phoneNumber.Trim() == string.Empty)
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                Regex regex = new Regex(@"^\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$");
                if (!regex.IsMatch(phoneNumber))
                {
                    MessageBox.Show("Phone number must be formatted in one of the following types\n" +
                        "(555) 555-5555\n" +
                        "555 555 5555\n" +
                        "555-555-555");
                    return;
                }
                Person person = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city,
                    State = state,
                    ZipCode = zipCode,
                    PhoneNumber = phoneNumber
                };
                person.AddressBook = AddressDB.GetCurrentAddressBook(CurrentAddressBook.AddressBookID);

                // Checks to see if that contact is already in the database
                if (PersonDB.CheckForExistingPerson(person, CurrentAddressBook.AddressBookID))
                {
                    // Prompts the user if the want to load the existing contact
                    DialogResult result = MessageBox.Show("That person already exists. \nDo you want to open that contact?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ViewContact viewContact = new ViewContact(PersonDB.GetExistingPerson(person.FirstName, person.LastName, CurrentAddressBook.AddressBookID));
                        viewContact.Show();
                        Close();
                    }
                    else
                    {
                        // Prompts the user if they want to save the contact
                        // anyway even though there is a contact with that name
                        // already in the address book
                        result = MessageBox.Show("Do you want to save anyway?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            PersonDB.Add(person);
                            PersonDB.NumberDuplicates(person.FirstName, person.LastName, CurrentAddressBook.AddressBookID);
                            Close();
                        }
                    }
                    
                }
                else
                {
                    PersonDB.Add(person);
                    Close();
                }
                
            }
        }
    }
}
