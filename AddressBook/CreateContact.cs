using AddressBook.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class CreateContact : Form
    {
        public Class.AddressBook CurrentAddressBook { get; set; }
        public CreateContact()
        {
            InitializeComponent();
    }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateContactBtn_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTxtBox.Text;
            string lastName = lastNameTxtBox.Text;
            string address = addressTxtBox.Text;
            string city = cityTxtBox.Text;
            string state = stateTxtBox.Text;
            string zipCode = zipCodeTxtBox.Text;
            if (firstName == string.Empty || lastName == string.Empty || address == string.Empty ||
                city == string.Empty || state == string.Empty || zipCode == string.Empty)
            {
                MessageBox.Show("All fields are required");
            }
            else
            {
                Person person = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city,
                    State = state,
                    ZipCode = zipCode
                };
                person.AddressBook = AddressDB.GetCurrentAddressBook(CurrentAddressBook.AddressBookID);
                if (PersonDB.CheckForExistingPerson(person, CurrentAddressBook.AddressBookID))
                {
                    DialogResult result = MessageBox.Show("That person already exists in this address book. \n Do You want to save anyway?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        PersonDB.Add(person);
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
