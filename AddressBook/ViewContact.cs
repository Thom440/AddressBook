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
    public partial class ViewContact : Form
    {
        private Person currentPerson;
        public ViewContact(Person person)
        {
            InitializeComponent();
            currentPerson = person;
        }

        private void ViewContact_Load(object sender, EventArgs e)
        {
            firstNameTxtBox.Text = currentPerson.FirstName;
            lastNameTxtBox.Text = currentPerson.LastName;
            addressTxtBox.Text = currentPerson.Address;
            cityTxtBox.Text = currentPerson.City;
            stateTxtBox.Text = currentPerson.State;
            zipCodeTxtBox.Text = currentPerson.ZipCode;

            saveBtn.Enabled = false;
            saveBtn.Visible = false;

            cancelBtn.Enabled = false;
            cancelBtn.Visible = false;
        }

        private void EditContactBtn_Click(object sender, EventArgs e)
        {
            addressTxtBox.Enabled = true;
            cityTxtBox.Enabled = true;
            stateTxtBox.Enabled = true;
            zipCodeTxtBox.Enabled = true;

            editContactBtn.Enabled = false;
            editContactBtn.Visible = false;

            closeBtn.Enabled = false;
            closeBtn.Visible = false;

            mailLblBtn.Enabled = false;
            mailLblBtn.Visible = false;

            saveBtn.Enabled = true;
            saveBtn.Visible = true;

            cancelBtn.Enabled = true;
            cancelBtn.Visible = true;

            this.Text = "Edit Contact";

            this.Size = new Size(317, 267);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            addressTxtBox.Enabled = false;
            cityTxtBox.Enabled = false;
            stateTxtBox.Enabled = false;
            zipCodeTxtBox.Enabled = false;

            saveBtn.Enabled = false;
            saveBtn.Visible = false;

            cancelBtn.Enabled = false;
            cancelBtn.Visible = false;

            editContactBtn.Enabled = true;
            editContactBtn.Visible = true;

            closeBtn.Enabled = true;
            closeBtn.Visible = true;

            mailLblBtn.Enabled = true;
            mailLblBtn.Visible = true;

            this.Size = new Size(317, 337);
            this.Text = "View Contact";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            currentPerson.Address = addressTxtBox.Text;
            currentPerson.City = cityTxtBox.Text;
            currentPerson.State = stateTxtBox.Text;
            currentPerson.ZipCode = zipCodeTxtBox.Text;

            if (PersonDB.CheckForChanges(currentPerson))
            {
                PersonDB.SaveChanges(currentPerson);
                CancelBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("You have not made any changes");
            }
        }
    }
}
