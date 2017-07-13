namespace SieraDelta.Controls
{
    partial class LicenceOptions
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblRegToDesc = new System.Windows.Forms.Label();
            this.lblRegisteredTo = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblServerDesc = new System.Windows.Forms.Label();
            this.lblExpires = new System.Windows.Forms.Label();
            this.lblExpiresDesc = new System.Windows.Forms.Label();
            this.gbUpdateLicence = new System.Windows.Forms.GroupBox();
            this.btnTrialLicence = new System.Windows.Forms.Button();
            this.lblUpdateDescription = new System.Windows.Forms.Label();
            this.btnUpdateLicence = new System.Windows.Forms.Button();
            this.txtNewLicence = new System.Windows.Forms.TextBox();
            this.gbUpdateLicence.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "lblDescription";
            // 
            // lblRegToDesc
            // 
            this.lblRegToDesc.AutoSize = true;
            this.lblRegToDesc.Location = new System.Drawing.Point(4, 31);
            this.lblRegToDesc.Name = "lblRegToDesc";
            this.lblRegToDesc.Size = new System.Drawing.Size(77, 13);
            this.lblRegToDesc.TabIndex = 1;
            this.lblRegToDesc.Text = "Registered To:";
            // 
            // lblRegisteredTo
            // 
            this.lblRegisteredTo.AutoSize = true;
            this.lblRegisteredTo.Location = new System.Drawing.Point(110, 31);
            this.lblRegisteredTo.Name = "lblRegisteredTo";
            this.lblRegisteredTo.Size = new System.Drawing.Size(81, 13);
            this.lblRegisteredTo.TabIndex = 2;
            this.lblRegisteredTo.Text = "lblRegisteredTo";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(110, 55);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(48, 13);
            this.lblServer.TabIndex = 4;
            this.lblServer.Text = "lblServer";
            // 
            // lblServerDesc
            // 
            this.lblServerDesc.AutoSize = true;
            this.lblServerDesc.Location = new System.Drawing.Point(4, 55);
            this.lblServerDesc.Name = "lblServerDesc";
            this.lblServerDesc.Size = new System.Drawing.Size(95, 13);
            this.lblServerDesc.TabIndex = 3;
            this.lblServerDesc.Text = "Server IP Address:";
            // 
            // lblExpires
            // 
            this.lblExpires.AutoSize = true;
            this.lblExpires.Location = new System.Drawing.Point(110, 80);
            this.lblExpires.Name = "lblExpires";
            this.lblExpires.Size = new System.Drawing.Size(51, 13);
            this.lblExpires.TabIndex = 6;
            this.lblExpires.Text = "lblExpires";
            // 
            // lblExpiresDesc
            // 
            this.lblExpiresDesc.AutoSize = true;
            this.lblExpiresDesc.Location = new System.Drawing.Point(4, 80);
            this.lblExpiresDesc.Name = "lblExpiresDesc";
            this.lblExpiresDesc.Size = new System.Drawing.Size(44, 13);
            this.lblExpiresDesc.TabIndex = 5;
            this.lblExpiresDesc.Text = "Expires:";
            // 
            // gbUpdateLicence
            // 
            this.gbUpdateLicence.Controls.Add(this.btnTrialLicence);
            this.gbUpdateLicence.Controls.Add(this.lblUpdateDescription);
            this.gbUpdateLicence.Controls.Add(this.btnUpdateLicence);
            this.gbUpdateLicence.Controls.Add(this.txtNewLicence);
            this.gbUpdateLicence.Location = new System.Drawing.Point(3, 160);
            this.gbUpdateLicence.Name = "gbUpdateLicence";
            this.gbUpdateLicence.Size = new System.Drawing.Size(454, 180);
            this.gbUpdateLicence.TabIndex = 7;
            this.gbUpdateLicence.TabStop = false;
            this.gbUpdateLicence.Text = "Update Licence";
            // 
            // btnTrialLicence
            // 
            this.btnTrialLicence.Location = new System.Drawing.Point(288, 151);
            this.btnTrialLicence.Name = "btnTrialLicence";
            this.btnTrialLicence.Size = new System.Drawing.Size(75, 23);
            this.btnTrialLicence.TabIndex = 2;
            this.btnTrialLicence.Text = "Trial";
            this.btnTrialLicence.UseVisualStyleBackColor = true;
            this.btnTrialLicence.Click += new System.EventHandler(this.btnTrialLicence_Click);
            // 
            // lblUpdateDescription
            // 
            this.lblUpdateDescription.AutoSize = true;
            this.lblUpdateDescription.Location = new System.Drawing.Point(7, 17);
            this.lblUpdateDescription.Name = "lblUpdateDescription";
            this.lblUpdateDescription.Size = new System.Drawing.Size(89, 13);
            this.lblUpdateDescription.TabIndex = 0;
            this.lblUpdateDescription.Text = "Enter licence text";
            // 
            // btnUpdateLicence
            // 
            this.btnUpdateLicence.Location = new System.Drawing.Point(369, 151);
            this.btnUpdateLicence.Name = "btnUpdateLicence";
            this.btnUpdateLicence.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateLicence.TabIndex = 3;
            this.btnUpdateLicence.Text = "Update";
            this.btnUpdateLicence.UseVisualStyleBackColor = true;
            this.btnUpdateLicence.Click += new System.EventHandler(this.btnUpdateLicence_Click);
            // 
            // txtNewLicence
            // 
            this.txtNewLicence.Location = new System.Drawing.Point(7, 36);
            this.txtNewLicence.MaxLength = 3000;
            this.txtNewLicence.Multiline = true;
            this.txtNewLicence.Name = "txtNewLicence";
            this.txtNewLicence.Size = new System.Drawing.Size(437, 109);
            this.txtNewLicence.TabIndex = 1;
            // 
            // LicenceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUpdateLicence);
            this.Controls.Add(this.lblExpires);
            this.Controls.Add(this.lblExpiresDesc);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.lblServerDesc);
            this.Controls.Add(this.lblRegisteredTo);
            this.Controls.Add(this.lblRegToDesc);
            this.Controls.Add(this.lblDescription);
            this.Name = "LicenceOptions";
            this.gbUpdateLicence.ResumeLayout(false);
            this.gbUpdateLicence.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblRegToDesc;
        private System.Windows.Forms.Label lblRegisteredTo;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblServerDesc;
        private System.Windows.Forms.Label lblExpires;
        private System.Windows.Forms.Label lblExpiresDesc;
        private System.Windows.Forms.GroupBox gbUpdateLicence;
        private System.Windows.Forms.Label lblUpdateDescription;
        private System.Windows.Forms.Button btnUpdateLicence;
        private System.Windows.Forms.TextBox txtNewLicence;
        private System.Windows.Forms.Button btnTrialLicence;
    }
}
