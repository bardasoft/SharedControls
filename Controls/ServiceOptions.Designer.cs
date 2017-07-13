namespace SieraDelta.Controls
{
    partial class ServiceOptions
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
            this.components = new System.ComponentModel.Container();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblUptimeDesc = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblNotRunning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(4, 13);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Sto&p";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(86, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(168, 13);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "&Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblUptimeDesc
            // 
            this.lblUptimeDesc.AutoSize = true;
            this.lblUptimeDesc.Location = new System.Drawing.Point(4, 62);
            this.lblUptimeDesc.Name = "lblUptimeDesc";
            this.lblUptimeDesc.Size = new System.Drawing.Size(82, 13);
            this.lblUptimeDesc.TabIndex = 3;
            this.lblUptimeDesc.Text = "Service Uptime:";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(93, 62);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(68, 13);
            this.lblUptime.TabIndex = 4;
            this.lblUptime.Text = "Calculating...";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblNotRunning
            // 
            this.lblNotRunning.AutoSize = true;
            this.lblNotRunning.Location = new System.Drawing.Point(4, 79);
            this.lblNotRunning.Name = "lblNotRunning";
            this.lblNotRunning.Size = new System.Drawing.Size(140, 13);
            this.lblNotRunning.TabIndex = 5;
            this.lblNotRunning.Text = "WebDefender is not running";
            // 
            // ServiceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNotRunning);
            this.Controls.Add(this.lblUptime);
            this.Controls.Add(this.lblUptimeDesc);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Name = "ServiceOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblUptimeDesc;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblNotRunning;
    }
}
