namespace SieraDelta.Controls
{
    partial class LogOptions
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
            this.lblRemove1 = new System.Windows.Forms.Label();
            this.udRemoveLogs = new System.Windows.Forms.NumericUpDown();
            this.lblRemove2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udRemoveLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemove1
            // 
            this.lblRemove1.AutoSize = true;
            this.lblRemove1.Location = new System.Drawing.Point(4, 14);
            this.lblRemove1.Name = "lblRemove1";
            this.lblRemove1.Size = new System.Drawing.Size(112, 13);
            this.lblRemove1.TabIndex = 0;
            this.lblRemove1.Text = "Remove log files after ";
            // 
            // udRemoveLogs
            // 
            this.udRemoveLogs.Location = new System.Drawing.Point(157, 12);
            this.udRemoveLogs.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.udRemoveLogs.Name = "udRemoveLogs";
            this.udRemoveLogs.Size = new System.Drawing.Size(61, 20);
            this.udRemoveLogs.TabIndex = 1;
            this.udRemoveLogs.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblRemove2
            // 
            this.lblRemove2.AutoSize = true;
            this.lblRemove2.Location = new System.Drawing.Point(241, 14);
            this.lblRemove2.Name = "lblRemove2";
            this.lblRemove2.Size = new System.Drawing.Size(29, 13);
            this.lblRemove2.TabIndex = 2;
            this.lblRemove2.Text = "days";
            // 
            // LogOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRemove2);
            this.Controls.Add(this.udRemoveLogs);
            this.Controls.Add(this.lblRemove1);
            this.Name = "LogOptions";
            ((System.ComponentModel.ISupportInitialize)(this.udRemoveLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemove1;
        private System.Windows.Forms.NumericUpDown udRemoveLogs;
        private System.Windows.Forms.Label lblRemove2;
    }
}
