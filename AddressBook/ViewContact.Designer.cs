
namespace AddressBook
{
    partial class ViewContact
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.editContactBtn = new System.Windows.Forms.Button();
            this.zipCodeTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.stateTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cityTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addressTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastNameTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mailLblBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(159, 185);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(124, 32);
            this.closeBtn.TabIndex = 27;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // editContactBtn
            // 
            this.editContactBtn.Location = new System.Drawing.Point(15, 185);
            this.editContactBtn.Name = "editContactBtn";
            this.editContactBtn.Size = new System.Drawing.Size(124, 32);
            this.editContactBtn.TabIndex = 26;
            this.editContactBtn.Text = "Edit Contact";
            this.editContactBtn.UseVisualStyleBackColor = true;
            this.editContactBtn.Click += new System.EventHandler(this.EditContactBtn_Click);
            // 
            // zipCodeTxtBox
            // 
            this.zipCodeTxtBox.Enabled = false;
            this.zipCodeTxtBox.Location = new System.Drawing.Point(77, 150);
            this.zipCodeTxtBox.MaxLength = 5;
            this.zipCodeTxtBox.Name = "zipCodeTxtBox";
            this.zipCodeTxtBox.Size = new System.Drawing.Size(206, 20);
            this.zipCodeTxtBox.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Zip Code";
            // 
            // stateTxtBox
            // 
            this.stateTxtBox.Enabled = false;
            this.stateTxtBox.Location = new System.Drawing.Point(77, 118);
            this.stateTxtBox.Name = "stateTxtBox";
            this.stateTxtBox.Size = new System.Drawing.Size(206, 20);
            this.stateTxtBox.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "State";
            // 
            // cityTxtBox
            // 
            this.cityTxtBox.Enabled = false;
            this.cityTxtBox.Location = new System.Drawing.Point(77, 89);
            this.cityTxtBox.Name = "cityTxtBox";
            this.cityTxtBox.Size = new System.Drawing.Size(206, 20);
            this.cityTxtBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "City";
            // 
            // addressTxtBox
            // 
            this.addressTxtBox.Enabled = false;
            this.addressTxtBox.Location = new System.Drawing.Point(77, 57);
            this.addressTxtBox.Name = "addressTxtBox";
            this.addressTxtBox.Size = new System.Drawing.Size(206, 20);
            this.addressTxtBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Address";
            // 
            // lastNameTxtBox
            // 
            this.lastNameTxtBox.Enabled = false;
            this.lastNameTxtBox.Location = new System.Drawing.Point(77, 30);
            this.lastNameTxtBox.Name = "lastNameTxtBox";
            this.lastNameTxtBox.Size = new System.Drawing.Size(206, 20);
            this.lastNameTxtBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Last Name";
            // 
            // firstNameTxtBox
            // 
            this.firstNameTxtBox.Enabled = false;
            this.firstNameTxtBox.Location = new System.Drawing.Point(77, 6);
            this.firstNameTxtBox.Name = "firstNameTxtBox";
            this.firstNameTxtBox.Size = new System.Drawing.Size(206, 20);
            this.firstNameTxtBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "First Name";
            // 
            // mailLblBtn
            // 
            this.mailLblBtn.Location = new System.Drawing.Point(87, 240);
            this.mailLblBtn.Name = "mailLblBtn";
            this.mailLblBtn.Size = new System.Drawing.Size(124, 32);
            this.mailLblBtn.TabIndex = 28;
            this.mailLblBtn.Text = "View Mail Label";
            this.mailLblBtn.UseVisualStyleBackColor = true;
            this.mailLblBtn.Click += new System.EventHandler(this.MailLblBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(15, 185);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(124, 32);
            this.saveBtn.TabIndex = 29;
            this.saveBtn.Text = "Save Changes";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(159, 185);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(124, 32);
            this.cancelBtn.TabIndex = 30;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ViewContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 298);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.mailLblBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.editContactBtn);
            this.Controls.Add(this.zipCodeTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stateTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cityTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addressTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastNameTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstNameTxtBox);
            this.Controls.Add(this.label1);
            this.Name = "ViewContact";
            this.Text = "View Contact";
            this.Load += new System.EventHandler(this.ViewContact_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button editContactBtn;
        private System.Windows.Forms.TextBox zipCodeTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox stateTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cityTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addressTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastNameTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mailLblBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}