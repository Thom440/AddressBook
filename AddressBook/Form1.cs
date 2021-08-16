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
        // Making currently selected address book available
        // to other methods when the address book is opened
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

        /// <summary>
        /// Opens form to create a new address book
        /// </summary>
        private void AddAddressBook_Click(object sender, EventArgs e)
        {
            CreateAddressBook createAddressBook = new CreateAddressBook();
            createAddressBook.ShowDialog();
            UpdateListBox();
        }

        /// <summary>
        /// After an address book is created the list is updated
        /// on the form
        /// </summary>
        private void UpdateListBox()
        {
            List<Class.AddressBook> addressBooks = AddressDB.GetAddressBooks();
            addressListBox.DataSource = addressBooks;
        }

        /// <summary>
        /// Opens the selected address book
        /// </summary>
        private void OpenAddressBook_Click(object sender, EventArgs e)
        {
            Class.AddressBook addressBook = (Class.AddressBook)addressListBox.SelectedItem;

            // This block of code disables and enables buttons on the form
            SetVisibilityAndEnableDisableButton(openAddressBook, false);
            SetVisibilityAndEnableDisableButton(addAddressBook, false);
            SetVisibilityAndEnableDisableButton(deleteAddressBook, false);
            SetVisibilityAndEnableDisableButton(createContactBtn, true);
            SetVisibilityAndEnableDisableButton(openContactBtn, true);
            SetVisibilityAndEnableDisableButton(closeAddressBookBtn, true);
            SetVisibilityAndEnableDisableButton(deleteContactBtn, true);

            // Now that the address book is open it needs to be
            // available to other methods that need to reference the
            // address book
            currentAddressBook = addressBook;

            // Filling the list box with the contacts in the address book
            List<Person> people = PersonDB.GetAllPeople(addressBook.AddressBookID);
            people = people.OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName).ToList();
            addressListBox.DataSource = people;

            // Changing the name of the form to the name of the address book
            this.Text = $"{addressBook.AddressBookName}";
        }

        /// <summary>
        /// Opens the form to create a new contact
        /// </summary>
        private void CreateContactBtn_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact();
            createContact.CurrentAddressBook = currentAddressBook;
            createContact.ShowDialog();
            UpdateContactList(currentAddressBook.AddressBookID);
        }

        /// <summary>
        /// Updates the list of contacts after a new contact has been created
        /// </summary>
        /// <param name="id">The id for the current address book</param>
        private void UpdateContactList(int id)
        {
            Class.AddressBook addressBook = AddressDB.GetAddressBook(id);
            List<Person> people = addressBook.People;
            people = people.OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName).ToList();
            addressListBox.DataSource = people;
        }

        /// <summary>
        /// Deletes the selected address book from the database
        /// </summary>
        private void DeleteAddressBook_Click(object sender, EventArgs e)
        {
            Class.AddressBook addressBook = (Class.AddressBook)addressListBox.SelectedItem;
            DialogResult result = MessageBox.Show($"Do you want to delete {addressBook.AddressBookName}", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AddressDB.Delete(addressBook);
            }
            
        }

        /// <summary>
        /// Closes the currently open address book
        /// </summary>
        private void CloseAddressBookBtn_Click(object sender, EventArgs e)
        {
            // This block of code enables and disables buttons on the form
            SetVisibilityAndEnableDisableButton(openAddressBook, true);
            SetVisibilityAndEnableDisableButton(addAddressBook, true);
            SetVisibilityAndEnableDisableButton(deleteAddressBook, true);
            SetVisibilityAndEnableDisableButton(createContactBtn, false);
            SetVisibilityAndEnableDisableButton(openContactBtn, false);
            SetVisibilityAndEnableDisableButton(closeAddressBookBtn, false);
            SetVisibilityAndEnableDisableButton(deleteContactBtn, false);

            // Changes the list box back to showing the address books
            List<Class.AddressBook> addressBooks = AddressDB.GetAddressBooks();
            addressListBox.DataSource = addressBooks;

            // Changes the name of the form to address book
            this.Text = "Address Book";
        }

        /// <summary>
        /// Opens the form to view the selected contact
        /// </summary>
        private void OpenContactBtn_Click(object sender, EventArgs e)
        {
            Person p = (Person)addressListBox.SelectedItem;
            Person person = PersonDB.GetPerson(p.PersonID);
            ViewContact viewContact = new ViewContact(person);
            viewContact.ShowDialog();
        }

        /// <summary>
        /// Deletes the selected contact from the database
        /// </summary>
        private void DeleteContactBtn_Click(object sender, EventArgs e)
        {
            Person person = (Person)addressListBox.SelectedItem;
            DialogResult result = MessageBox.Show($"Are you sure that you want to delete { person.FirstName} {person.LastName}", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                PersonDB.Delete(person);
                // If the number identifying the duplicate is not null
                // redo the numbers to keep them in order
                if (person.Number != null)
                {
                    PersonDB.NumberDuplicates(person.FirstName, person.LastName, currentAddressBook.AddressBookID);
                }
                UpdateContactList(currentAddressBook.AddressBookID);
            }
        }

        /// <summary>
        /// Sets button to visible or invisible based on boolean being passed in.
        /// Sets Button to enabled or disabled based on boolean.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        private void SetVisibilityAndEnableDisableButton(Control control, bool value)
        {
            control.Enabled = value;
            control.Visible = value;
        }
    }
}
