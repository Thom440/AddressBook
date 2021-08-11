using AddressBook.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class MailingLabel : Form
    {
        private Person currentPerson;
        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();
        public MailingLabel(Person person)
        {
            InitializeComponent();
            currentPerson = person;
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
        }

        private void MailingLabel_Load(object sender, EventArgs e)
        {
            labelTxtBox.Text = currentPerson.PrintMailingLabel();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(labelTxtBox.Text, new Font("Ariel", 12, FontStyle.Regular), Brushes.Black, 20, 20);
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }
    }
}
