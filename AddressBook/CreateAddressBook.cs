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
    public partial class CreateAddressBook : Form
    {
        public CreateAddressBook()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            // Checks to make sure that the text box is not empty or white space
            if (addressBookNameTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Must enter a name for the Address Book");
            }
            // Checking to make sure address book does not already exist
            else if (!AddressDB.CheckForExistingAddressBook(addressBookNameTxtBox.Text))
            {
                Class.AddressBook addressBook = new Class.AddressBook()
                {
                    AddressBookName = addressBookNameTxtBox.Text
                };
                AddressDB.AddAddressBook(addressBook);
                Close();
            }
            else
            {
                MessageBox.Show("An Address Book with that name already exists");
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
