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
    public partial class ViewContact : Form
    {
        // Making the contact available to all methods
        private Person currentPerson;
        public ViewContact(Person person)
        {
            InitializeComponent();
            currentPerson = person;
        }

        /// <summary>
        /// Fills in the contact information on form load
        /// </summary>
        private void ViewContact_Load(object sender, EventArgs e)
        {
            firstNameTxtBox.Text = currentPerson.FirstName;
            lastNameTxtBox.Text = currentPerson.LastName;
            addressTxtBox.Text = currentPerson.Address;
            cityTxtBox.Text = currentPerson.City;
            stateTxtBox.Text = currentPerson.State;
            zipCodeTxtBox.Text = currentPerson.ZipCode;
            phoneNumberTxtBox.Text = currentPerson.PhoneNumber;

            // Disabling and hiding buttons that are not needed
            // at the moment
            SetVisibilityAndEnableDisableButton(saveBtn, false);
            SetVisibilityAndEnableDisableButton(cancelBtn, false);
        }

        /// <summary>
        /// Changes the form for editing contact information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactBtn_Click(object sender, EventArgs e)
        {
            // Enables fields for editing
            addressTxtBox.Enabled = true;
            cityTxtBox.Enabled = true;
            stateTxtBox.Enabled = true;
            zipCodeTxtBox.Enabled = true;
            phoneNumberTxtBox.Enabled = true;

            // Enabling and disabling buttons for editing contact information
            SetVisibilityAndEnableDisableButton(editContactBtn, false);
            SetVisibilityAndEnableDisableButton(closeBtn, false);
            SetVisibilityAndEnableDisableButton(mailLblBtn, false);
            SetVisibilityAndEnableDisableButton(saveBtn, true);
            SetVisibilityAndEnableDisableButton(cancelBtn, true);

            // Changes the name of the form to edit contact
            this.Text = "Edit Contact";

            // Changes the size of the form to get rid of wasted space
            this.Size = new Size(317, 283);
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Changes the form back to viewing contact information
        /// </summary>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            // Disabling the fields so they cannot be altered
            addressTxtBox.Enabled = false;
            cityTxtBox.Enabled = false;
            stateTxtBox.Enabled = false;
            zipCodeTxtBox.Enabled = false;
            phoneNumberTxtBox.Enabled = false;

            // Enabling and disabling buttons
            SetVisibilityAndEnableDisableButton(saveBtn, false);
            SetVisibilityAndEnableDisableButton(cancelBtn, false);
            SetVisibilityAndEnableDisableButton(editContactBtn, true);
            SetVisibilityAndEnableDisableButton(closeBtn, true);
            SetVisibilityAndEnableDisableButton(mailLblBtn, true);

            // Changing the size of the form back to its original
            this.Size = new Size(317, 322);
            // Changing the name of the form to view contact
            this.Text = "View Contact";
        }

        /// <summary>
        /// Saves changes to the contact information
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (addressTxtBox.Text.Trim() != string.Empty && cityTxtBox.Text.Trim() != string.Empty &&
                stateTxtBox.Text.Trim() != string.Empty && zipCodeTxtBox.Text.Trim() != string.Empty &&
                phoneNumberTxtBox.Text.Trim() != string.Empty)
            {
                currentPerson.Address = addressTxtBox.Text;
                currentPerson.City = cityTxtBox.Text;
                currentPerson.State = stateTxtBox.Text;
                currentPerson.ZipCode = zipCodeTxtBox.Text;
                currentPerson.PhoneNumber = phoneNumberTxtBox.Text;
                Regex regex = new Regex(@"^\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$");
                if (!regex.IsMatch(phoneNumberTxtBox.Text))
                {
                    MessageBox.Show("Phone number must be formatted in one of the following types\n" +
                        "(555) 555-5555\n" +
                        "555 555 5555\n" +
                        "555-555-555");
                    return;
                }
            }
            else
            {
                MessageBox.Show("A field cannot be left blank.");
                return;
            }

            // Verifies that information has changed
            if (!PersonDB.CheckForChanges(currentPerson))
            {
                PersonDB.SaveChanges(currentPerson);
                cancelBtn.PerformClick();
            }
            else
            {
                MessageBox.Show("You have not made any changes");
            }
        }

        /// <summary>
        /// Opens the mailing label form
        /// </summary>
        private void MailLblBtn_Click(object sender, EventArgs e)
        {
            MailingLabel mailingLabel = new MailingLabel(currentPerson);
            mailingLabel.ShowDialog();
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
