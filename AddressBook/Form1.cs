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
    public partial class Form1 : Form
    {
        private Class.AddressBook currentAddressBook = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Class.AddressBook> addressBooks = AddressDB.GetAddressBooks();
            addressListBox.DataSource = addressBooks.ToList();
        }

        private void AddAddressBook_Click(object sender, EventArgs e)
        {
            CreateAddressBook createAddressBook = new CreateAddressBook();
            createAddressBook.ShowDialog();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            List<Class.AddressBook> addressBooks = AddressDB.GetAddressBooks();
            addressListBox.DataSource = addressBooks;
        }

        private void OpenAddressBook_Click(object sender, EventArgs e)
        {
            Class.AddressBook addressBook = (Class.AddressBook)addressListBox.SelectedItem;
            if (addressBook == null)
            {
                MessageBox.Show("Must select an address book from the list");
            }
            else
            {
                openAddressBook.Enabled = false;
                openAddressBook.Visible = false;

                addAddressBook.Enabled = false;
                addAddressBook.Visible = false;

                deleteAddressBook.Enabled = false;
                deleteAddressBook.Visible = false;

                createContactBtn.Enabled = true;
                createContactBtn.Visible = true;

                openContactBtn.Enabled = true;
                openContactBtn.Visible = true;

                closeAddressBookBtn.Enabled = true;
                closeAddressBookBtn.Visible = true;

                deleteContactBtn.Enabled = true;
                deleteContactBtn.Visible = true;

                Class.AddressBook currentBook = AddressDB.GetAddressBook(addressBook.AddressBookName);
                currentAddressBook = currentBook;
                List<Person> people = currentBook.People;
                people = people.OrderBy(p => p.LastName)
                    .ThenBy(p => p.FirstName).ToList();
                addressListBox.DataSource = people;
            }
            
        }

        private void CreateContactBtn_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact();
            createContact.CurrentAddressBook = currentAddressBook;
            createContact.ShowDialog();
            UpdateContactList(currentAddressBook.AddressBookName);
        }

        private void UpdateContactList(string addressBookName)
        {
            Class.AddressBook addressBook = AddressDB.GetAddressBook(addressBookName);
            List<Person> people = addressBook.People;
            people = people.OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName).ToList();
            addressListBox.DataSource = people;
        }

        private void DeleteAddressBook_Click(object sender, EventArgs e)
        {
            Class.AddressBook addressBook = (Class.AddressBook)addressListBox.SelectedItem;
            DialogResult result = MessageBox.Show($"Do you want to delete {addressBook.AddressBookName}", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AddressDB.Delete(addressBook.AddressBookName);
            }
            
        }
    }
}
