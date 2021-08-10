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
            if (addressBookNameTxtBox.Text == string.Empty)
            {
                MessageBox.Show("Must enter a name for the Address Book");
            }
            else
            {
                Class.AddressBook addressBook = new Class.AddressBook()
                {
                    AddressBookName = addressBookNameTxtBox.Text
                };
                AddressDB.AddAddressBook(addressBook);
                Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
