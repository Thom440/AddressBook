
namespace AddressBook
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addressListBox = new System.Windows.Forms.ListBox();
            this.addAddressBook = new System.Windows.Forms.Button();
            this.openAddressBook = new System.Windows.Forms.Button();
            this.deleteAddressBook = new System.Windows.Forms.Button();
            this.closeAddressBookBtn = new System.Windows.Forms.Button();
            this.createContactBtn = new System.Windows.Forms.Button();
            this.openContactBtn = new System.Windows.Forms.Button();
            this.deleteContactBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressListBox
            // 
            this.addressListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressListBox.FormattingEnabled = true;
            this.addressListBox.ItemHeight = 31;
            this.addressListBox.Location = new System.Drawing.Point(13, 13);
            this.addressListBox.Name = "addressListBox";
            this.addressListBox.Size = new System.Drawing.Size(402, 407);
            this.addressListBox.TabIndex = 0;
            // 
            // addAddressBook
            // 
            this.addAddressBook.Location = new System.Drawing.Point(437, 13);
            this.addAddressBook.Name = "addAddressBook";
            this.addAddressBook.Size = new System.Drawing.Size(182, 43);
            this.addAddressBook.TabIndex = 1;
            this.addAddressBook.Text = "Add New Address Book";
            this.addAddressBook.UseVisualStyleBackColor = true;
            this.addAddressBook.Click += new System.EventHandler(this.AddAddressBook_Click);
            // 
            // openAddressBook
            // 
            this.openAddressBook.Location = new System.Drawing.Point(437, 63);
            this.openAddressBook.Name = "openAddressBook";
            this.openAddressBook.Size = new System.Drawing.Size(182, 43);
            this.openAddressBook.TabIndex = 2;
            this.openAddressBook.Text = "Open Address Book";
            this.openAddressBook.UseVisualStyleBackColor = true;
            this.openAddressBook.Click += new System.EventHandler(this.OpenAddressBook_Click);
            // 
            // deleteAddressBook
            // 
            this.deleteAddressBook.Location = new System.Drawing.Point(437, 113);
            this.deleteAddressBook.Name = "deleteAddressBook";
            this.deleteAddressBook.Size = new System.Drawing.Size(182, 43);
            this.deleteAddressBook.TabIndex = 3;
            this.deleteAddressBook.Text = "Delete Address Book";
            this.deleteAddressBook.UseVisualStyleBackColor = true;
            this.deleteAddressBook.Click += new System.EventHandler(this.DeleteAddressBook_Click);
            // 
            // closeAddressBookBtn
            // 
            this.closeAddressBookBtn.Enabled = false;
            this.closeAddressBookBtn.Location = new System.Drawing.Point(437, 14);
            this.closeAddressBookBtn.Name = "closeAddressBookBtn";
            this.closeAddressBookBtn.Size = new System.Drawing.Size(182, 43);
            this.closeAddressBookBtn.TabIndex = 4;
            this.closeAddressBookBtn.Text = "Close Address Book";
            this.closeAddressBookBtn.UseVisualStyleBackColor = true;
            this.closeAddressBookBtn.Visible = false;
            this.closeAddressBookBtn.Click += new System.EventHandler(this.CloseAddressBookBtn_Click);
            // 
            // createContactBtn
            // 
            this.createContactBtn.Enabled = false;
            this.createContactBtn.Location = new System.Drawing.Point(437, 63);
            this.createContactBtn.Name = "createContactBtn";
            this.createContactBtn.Size = new System.Drawing.Size(182, 43);
            this.createContactBtn.TabIndex = 5;
            this.createContactBtn.Text = "Create Contact";
            this.createContactBtn.UseVisualStyleBackColor = true;
            this.createContactBtn.Visible = false;
            this.createContactBtn.Click += new System.EventHandler(this.CreateContactBtn_Click);
            // 
            // openContactBtn
            // 
            this.openContactBtn.Enabled = false;
            this.openContactBtn.Location = new System.Drawing.Point(437, 113);
            this.openContactBtn.Name = "openContactBtn";
            this.openContactBtn.Size = new System.Drawing.Size(182, 43);
            this.openContactBtn.TabIndex = 6;
            this.openContactBtn.Text = "Open Contact";
            this.openContactBtn.UseVisualStyleBackColor = true;
            this.openContactBtn.Visible = false;
            // 
            // deleteContactBtn
            // 
            this.deleteContactBtn.Enabled = false;
            this.deleteContactBtn.Location = new System.Drawing.Point(437, 162);
            this.deleteContactBtn.Name = "deleteContactBtn";
            this.deleteContactBtn.Size = new System.Drawing.Size(182, 43);
            this.deleteContactBtn.TabIndex = 7;
            this.deleteContactBtn.Text = "Delete Contact";
            this.deleteContactBtn.UseVisualStyleBackColor = true;
            this.deleteContactBtn.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.deleteContactBtn);
            this.Controls.Add(this.openContactBtn);
            this.Controls.Add(this.createContactBtn);
            this.Controls.Add(this.closeAddressBookBtn);
            this.Controls.Add(this.deleteAddressBook);
            this.Controls.Add(this.openAddressBook);
            this.Controls.Add(this.addAddressBook);
            this.Controls.Add(this.addressListBox);
            this.Name = "Form1";
            this.Text = "Address Book";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox addressListBox;
        private System.Windows.Forms.Button addAddressBook;
        private System.Windows.Forms.Button openAddressBook;
        private System.Windows.Forms.Button deleteAddressBook;
        private System.Windows.Forms.Button closeAddressBookBtn;
        private System.Windows.Forms.Button createContactBtn;
        private System.Windows.Forms.Button openContactBtn;
        private System.Windows.Forms.Button deleteContactBtn;
    }
}

