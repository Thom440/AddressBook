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
                    DialogResult result = MessageBox.Show("That person already exists. \nDo you want to open that contact?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ViewContact viewContact = new ViewContact(PersonDB.GetExistingPerson(person.FirstName, person.LastName, CurrentAddressBook.AddressBookID));
                        viewContact.Show();
                        Close();
                    }
                    else
                    {
                        result = MessageBox.Show("Do You want to save anyway?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            PersonDB.Add(person);
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
