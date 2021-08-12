﻿using AddressBook.Class;
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

                currentAddressBook = addressBook;
                List<Person> people = PersonDB.GetAllPeople(addressBook.AddressBookID);
                people = people.OrderBy(p => p.LastName)
                    .ThenBy(p => p.FirstName).ToList();
                addressListBox.DataSource = people;

                this.Text = $"{addressBook.AddressBookName}";
            }
            
        }

        private void CreateContactBtn_Click(object sender, EventArgs e)
        {
            CreateContact createContact = new CreateContact();
            createContact.CurrentAddressBook = currentAddressBook;
            createContact.ShowDialog();
            UpdateContactList(currentAddressBook.AddressBookID);
        }

        private void UpdateContactList(int id)
        {
            Class.AddressBook addressBook = AddressDB.GetAddressBook(id);
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
                AddressDB.Delete(addressBook);
            }
            
        }

        private void CloseAddressBookBtn_Click(object sender, EventArgs e)
        {
            openAddressBook.Enabled = true;
            openAddressBook.Visible = true;

            addAddressBook.Enabled = true;
            addAddressBook.Visible = true;

            deleteAddressBook.Enabled = true;
            deleteAddressBook.Visible = true;

            createContactBtn.Enabled = false;
            createContactBtn.Visible = false;

            openContactBtn.Enabled = false;
            openContactBtn.Visible = false;

            closeAddressBookBtn.Enabled = false;
            closeAddressBookBtn.Visible = false;

            deleteContactBtn.Enabled = false;
            deleteContactBtn.Visible = false;

            List<Class.AddressBook> addressBooks = AddressDB.GetAddressBooks();
            addressListBox.DataSource = addressBooks;

            this.Text = "Address Book";
        }

        private void OpenContactBtn_Click(object sender, EventArgs e)
        {
            Person p = (Person)addressListBox.SelectedItem;
            Person person = PersonDB.GetPerson(p.PersonID);
            ViewContact viewContact = new ViewContact(person);
            viewContact.ShowDialog();
        }
    }
}
