namespace SieraDelta.Controls
{
    partial class EmailOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbDefaultEmail = new System.Windows.Forms.RadioButton();
            this.rbCustomEmail = new System.Windows.Forms.RadioButton();
            this.gbCustom = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cbSSL = new System.Windows.Forms.CheckBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblhost = new System.Windows.Forms.Label();
            this.lblSenderEmail = new System.Windows.Forms.Label();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.gbCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbDefaultEmail
            // 
            this.rbDefaultEmail.AutoSize = true;
            this.rbDefaultEmail.Location = new System.Drawing.Point(4, 4);
            this.rbDefaultEmail.Name = "rbDefaultEmail";
            this.rbDefaultEmail.Size = new System.Drawing.Size(87, 17);
            this.rbDefaultEmail.TabIndex = 0;
            this.rbDefaultEmail.Text = "&Default Email";
            this.rbDefaultEmail.UseVisualStyleBackColor = true;
            this.rbDefaultEmail.CheckedChanged += new System.EventHandler(this.rbDefaultEmail_CheckedChanged);
            // 
            // rbCustomEmail
            // 
            this.rbCustomEmail.AutoSize = true;
            this.rbCustomEmail.Location = new System.Drawing.Point(133, 4);
            this.rbCustomEmail.Name = "rbCustomEmail";
            this.rbCustomEmail.Size = new System.Drawing.Size(88, 17);
            this.rbCustomEmail.TabIndex = 1;
            this.rbCustomEmail.Text = "&Custom Email";
            this.rbCustomEmail.UseVisualStyleBackColor = true;
            this.rbCustomEmail.CheckedChanged += new System.EventHandler(this.rbDefaultEmail_CheckedChanged);
            // 
            // gbCustom
            // 
            this.gbCustom.Controls.Add(this.btnTest);
            this.gbCustom.Controls.Add(this.txtPort);
            this.gbCustom.Controls.Add(this.txtHost);
            this.gbCustom.Controls.Add(this.txtPassword);
            this.gbCustom.Controls.Add(this.txtEmail);
            this.gbCustom.Controls.Add(this.txtSender);
            this.gbCustom.Controls.Add(this.lblPassword);
            this.gbCustom.Controls.Add(this.cbSSL);
            this.gbCustom.Controls.Add(this.lblPort);
            this.gbCustom.Controls.Add(this.lblhost);
            this.gbCustom.Controls.Add(this.lblSenderEmail);
            this.gbCustom.Controls.Add(this.lblSenderName);
            this.gbCustom.Location = new System.Drawing.Point(4, 37);
            this.gbCustom.Name = "gbCustom";
            this.gbCustom.Size = new System.Drawing.Size(453, 303);
            this.gbCustom.TabIndex = 2;
            this.gbCustom.TabStop = false;
            this.gbCustom.Text = "Custom Email";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(13, 221);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 11;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(102, 149);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "25";
            this.txtPort.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(102, 116);
            this.txtHost.MaxLength = 150;
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(345, 20);
            this.txtHost.TabIndex = 7;
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(102, 86);
            this.txtPassword.MaxLength = 150;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(345, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(102, 55);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(345, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(102, 26);
            this.txtSender.MaxLength = 150;
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(345, 20);
            this.txtSender.TabIndex = 1;
            this.txtSender.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 89);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // cbSSL
            // 
            this.cbSSL.AutoSize = true;
            this.cbSSL.Location = new System.Drawing.Point(13, 187);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(103, 17);
            this.cbSSL.TabIndex = 10;
            this.cbSSL.Text = "SSL Connection";
            this.cbSSL.UseVisualStyleBackColor = true;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(10, 152);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 8;
            this.lblPort.Text = "Port";
            // 
            // lblhost
            // 
            this.lblhost.AutoSize = true;
            this.lblhost.Location = new System.Drawing.Point(10, 119);
            this.lblhost.Name = "lblhost";
            this.lblhost.Size = new System.Drawing.Size(29, 13);
            this.lblhost.TabIndex = 6;
            this.lblhost.Text = "Host";
            // 
            // lblSenderEmail
            // 
            this.lblSenderEmail.AutoSize = true;
            this.lblSenderEmail.Location = new System.Drawing.Point(10, 58);
            this.lblSenderEmail.Name = "lblSenderEmail";
            this.lblSenderEmail.Size = new System.Drawing.Size(69, 13);
            this.lblSenderEmail.TabIndex = 2;
            this.lblSenderEmail.Text = "Sender Email";
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(10, 29);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(72, 13);
            this.lblSenderName.TabIndex = 0;
            this.lblSenderName.Text = "Sender Name";
            // 
            // EmailOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCustom);
            this.Controls.Add(this.rbCustomEmail);
            this.Controls.Add(this.rbDefaultEmail);
            this.Name = "EmailOptions";
            this.gbCustom.ResumeLayout(false);
            this.gbCustom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbDefaultEmail;
        private System.Windows.Forms.RadioButton rbCustomEmail;
        private System.Windows.Forms.GroupBox gbCustom;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox cbSSL;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblhost;
        private System.Windows.Forms.Label lblSenderEmail;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.Button btnTest;
    }
}
