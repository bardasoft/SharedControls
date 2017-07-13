namespace SharedControls.SpellChecker
{
    partial class SpellChecker
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
#if DEBUG
            System.GC.SuppressFinalize(this);
#endif
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
            this.lblNotInDictionary = new System.Windows.Forms.Label();
            this.lblSuggestions = new System.Windows.Forms.Label();
            this.txtNotFound = new System.Windows.Forms.TextBox();
            this.lstSuggestions = new System.Windows.Forms.ListBox();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnIgnoreAll = new System.Windows.Forms.Button();
            this.btnAddToDictionary = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnChangeAll = new System.Windows.Forms.Button();
            this.lblDictionary = new System.Windows.Forms.Label();
            this.cmbDictionary = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReplacement = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNotInDictionary
            // 
            this.lblNotInDictionary.AutoSize = true;
            this.lblNotInDictionary.Location = new System.Drawing.Point(13, 13);
            this.lblNotInDictionary.Name = "lblNotInDictionary";
            this.lblNotInDictionary.Size = new System.Drawing.Size(86, 13);
            this.lblNotInDictionary.TabIndex = 3;
            this.lblNotInDictionary.Text = "Not in dictionary:";
            // 
            // lblSuggestions
            // 
            this.lblSuggestions.AutoSize = true;
            this.lblSuggestions.Location = new System.Drawing.Point(12, 131);
            this.lblSuggestions.Name = "lblSuggestions";
            this.lblSuggestions.Size = new System.Drawing.Size(68, 13);
            this.lblSuggestions.TabIndex = 7;
            this.lblSuggestions.Text = "Suggestions:";
            // 
            // txtNotFound
            // 
            this.txtNotFound.Location = new System.Drawing.Point(15, 30);
            this.txtNotFound.Name = "txtNotFound";
            this.txtNotFound.ReadOnly = true;
            this.txtNotFound.Size = new System.Drawing.Size(373, 20);
            this.txtNotFound.TabIndex = 4;
            // 
            // lstSuggestions
            // 
            this.lstSuggestions.FormattingEnabled = true;
            this.lstSuggestions.Location = new System.Drawing.Point(16, 148);
            this.lstSuggestions.Name = "lstSuggestions";
            this.lstSuggestions.Size = new System.Drawing.Size(372, 95);
            this.lstSuggestions.TabIndex = 8;
            this.lstSuggestions.Click += new System.EventHandler(this.lstSuggestions_Click);
            this.lstSuggestions.DoubleClick += new System.EventHandler(this.lstSuggestions_DoubleClick);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Location = new System.Drawing.Point(408, 30);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(105, 23);
            this.btnIgnore.TabIndex = 0;
            this.btnIgnore.Text = "&Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnIgnoreAll
            // 
            this.btnIgnoreAll.Location = new System.Drawing.Point(408, 60);
            this.btnIgnoreAll.Name = "btnIgnoreAll";
            this.btnIgnoreAll.Size = new System.Drawing.Size(105, 23);
            this.btnIgnoreAll.TabIndex = 1;
            this.btnIgnoreAll.Text = "Ignore &All";
            this.btnIgnoreAll.UseVisualStyleBackColor = true;
            this.btnIgnoreAll.Click += new System.EventHandler(this.btnIgnoreAll_Click);
            // 
            // btnAddToDictionary
            // 
            this.btnAddToDictionary.Location = new System.Drawing.Point(408, 90);
            this.btnAddToDictionary.Name = "btnAddToDictionary";
            this.btnAddToDictionary.Size = new System.Drawing.Size(105, 23);
            this.btnAddToDictionary.TabIndex = 2;
            this.btnAddToDictionary.Text = "Add to &Dictionary";
            this.btnAddToDictionary.UseVisualStyleBackColor = true;
            this.btnAddToDictionary.Click += new System.EventHandler(this.btnAddToDictionary_Click);
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(408, 148);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(105, 23);
            this.btnChange.TabIndex = 9;
            this.btnChange.Text = "&Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnChangeAll
            // 
            this.btnChangeAll.Enabled = false;
            this.btnChangeAll.Location = new System.Drawing.Point(408, 178);
            this.btnChangeAll.Name = "btnChangeAll";
            this.btnChangeAll.Size = new System.Drawing.Size(105, 23);
            this.btnChangeAll.TabIndex = 10;
            this.btnChangeAll.Text = "C&hange All";
            this.btnChangeAll.UseVisualStyleBackColor = true;
            this.btnChangeAll.Click += new System.EventHandler(this.btnChangeAll_Click);
            // 
            // lblDictionary
            // 
            this.lblDictionary.AutoSize = true;
            this.lblDictionary.Location = new System.Drawing.Point(15, 263);
            this.lblDictionary.Name = "lblDictionary";
            this.lblDictionary.Size = new System.Drawing.Size(57, 13);
            this.lblDictionary.TabIndex = 11;
            this.lblDictionary.Text = "Dictionary:";
            // 
            // cmbDictionary
            // 
            this.cmbDictionary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDictionary.FormattingEnabled = true;
            this.cmbDictionary.Location = new System.Drawing.Point(78, 260);
            this.cmbDictionary.Name = "cmbDictionary";
            this.cmbDictionary.Size = new System.Drawing.Size(161, 21);
            this.cmbDictionary.TabIndex = 12;
            this.cmbDictionary.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbDictionary_Format);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Change to:";
            // 
            // txtReplacement
            // 
            this.txtReplacement.Location = new System.Drawing.Point(15, 77);
            this.txtReplacement.Name = "txtReplacement";
            this.txtReplacement.Size = new System.Drawing.Size(373, 20);
            this.txtReplacement.TabIndex = 6;
            this.txtReplacement.TextChanged += new System.EventHandler(this.txtReplacement_TextChanged);
            // 
            // SpellChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 302);
            this.Controls.Add(this.txtReplacement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDictionary);
            this.Controls.Add(this.lblDictionary);
            this.Controls.Add(this.btnChangeAll);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAddToDictionary);
            this.Controls.Add(this.btnIgnoreAll);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.lstSuggestions);
            this.Controls.Add(this.txtNotFound);
            this.Controls.Add(this.lblSuggestions);
            this.Controls.Add(this.lblNotInDictionary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpellChecker";
            this.SaveState = true;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Spell Checker";
            this.Shown += new System.EventHandler(this.SpellChecker_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotInDictionary;
        private System.Windows.Forms.Label lblSuggestions;
        private System.Windows.Forms.TextBox txtNotFound;
        private System.Windows.Forms.ListBox lstSuggestions;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnIgnoreAll;
        private System.Windows.Forms.Button btnAddToDictionary;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnChangeAll;
        private System.Windows.Forms.Label lblDictionary;
        private System.Windows.Forms.ComboBox cmbDictionary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReplacement;
    }
}