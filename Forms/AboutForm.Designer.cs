namespace SieraDelta.Controls.Forms
{
    partial class AboutForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.about1 = new SieraDelta.Controls.About();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(378, 350);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // about1
            // 
            this.about1.HelpID = 0;
            this.about1.Location = new System.Drawing.Point(0, 0);
            this.about1.MaximumSize = new System.Drawing.Size(460, 343);
            this.about1.MinimumSize = new System.Drawing.Size(460, 343);
            this.about1.Name = "about1";
            this.about1.ProductID = 1;
            this.about1.SettingsChanged = false;
            this.about1.SettingsParentForm = null;
            this.about1.Size = new System.Drawing.Size(460, 343);
            this.about1.TabIndex = 0;
            this.about1.UpdateName = null;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 382);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.about1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private About about1;
        private System.Windows.Forms.Button btnOK;
    }
}