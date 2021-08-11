
namespace AddressBook
{
    partial class MailingLabel
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
            this.labelTxtBox = new System.Windows.Forms.RichTextBox();
            this.printBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTxtBox
            // 
            this.labelTxtBox.Location = new System.Drawing.Point(13, 13);
            this.labelTxtBox.Name = "labelTxtBox";
            this.labelTxtBox.Size = new System.Drawing.Size(250, 96);
            this.labelTxtBox.TabIndex = 0;
            this.labelTxtBox.Text = "";
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(13, 116);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(121, 34);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(141, 116);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(121, 34);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MailingLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 160);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.labelTxtBox);
            this.Name = "MailingLabel";
            this.Text = "MailingLabel";
            this.Load += new System.EventHandler(this.MailingLabel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox labelTxtBox;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}