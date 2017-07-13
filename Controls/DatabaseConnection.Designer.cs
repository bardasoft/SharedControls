namespace SharedControls
{
    partial class DatabaseConnection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseConnection));
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cmbPacketSize = new System.Windows.Forms.ComboBox();
            this.lblPacketSize = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblCharacterSet = new System.Windows.Forms.Label();
            this.cmbCharacterSet = new System.Windows.Forms.ComboBox();
            this.tbFBCharSets = new SharedControls.Controls.TextBlock();
            this.tbMySQLCharSets = new SharedControls.Controls.TextBlock();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(1, 72);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(262, 20);
            this.txtServer.TabIndex = 3;
            this.txtServer.TextChanged += new System.EventHandler(this.SettingChangedEvent);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(-2, 56);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(38, 13);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Server";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(1, 241);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(128, 23);
            this.btnTestConnection.TabIndex = 16;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cmbPacketSize
            // 
            this.cmbPacketSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPacketSize.FormattingEnabled = true;
            this.cmbPacketSize.Items.AddRange(new object[] {
            "2048",
            "4096",
            "8192",
            "16384"});
            this.cmbPacketSize.Location = new System.Drawing.Point(135, 201);
            this.cmbPacketSize.Name = "cmbPacketSize";
            this.cmbPacketSize.Size = new System.Drawing.Size(128, 21);
            this.cmbPacketSize.TabIndex = 15;
            this.cmbPacketSize.SelectedIndexChanged += new System.EventHandler(this.SettingChangedEvent);
            // 
            // lblPacketSize
            // 
            this.lblPacketSize.AutoSize = true;
            this.lblPacketSize.Location = new System.Drawing.Point(132, 184);
            this.lblPacketSize.Name = "lblPacketSize";
            this.lblPacketSize.Size = new System.Drawing.Size(64, 13);
            this.lblPacketSize.TabIndex = 14;
            this.lblPacketSize.Text = "Packet Size";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 116);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(128, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.TextChanged += new System.EventHandler(this.SettingChangedEvent);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(132, 99);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(1, 116);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(128, 20);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.TextChanged += new System.EventHandler(this.SettingChangedEvent);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(-2, 99);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Username";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(1, 25);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(262, 20);
            this.txtDatabase.TabIndex = 1;
            this.txtDatabase.TextChanged += new System.EventHandler(this.SettingChangedEvent);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(-2, 9);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(53, 13);
            this.lblDatabase.TabIndex = 0;
            this.lblDatabase.Text = "Database";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(1, 201);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(128, 20);
            this.txtPort.TabIndex = 13;
            this.txtPort.TextChanged += new System.EventHandler(this.SettingChangedEvent);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(-2, 184);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 12;
            this.lblPort.Text = "Port";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(135, 155);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.PasswordChar = '*';
            this.txtRoleName.Size = new System.Drawing.Size(128, 20);
            this.txtRoleName.TabIndex = 11;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(135, 139);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(29, 13);
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Role";
            // 
            // lblCharacterSet
            // 
            this.lblCharacterSet.AutoSize = true;
            this.lblCharacterSet.Location = new System.Drawing.Point(-2, 139);
            this.lblCharacterSet.Name = "lblCharacterSet";
            this.lblCharacterSet.Size = new System.Drawing.Size(72, 13);
            this.lblCharacterSet.TabIndex = 8;
            this.lblCharacterSet.Text = "Character Set";
            // 
            // cmbCharacterSet
            // 
            this.cmbCharacterSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharacterSet.FormattingEnabled = true;
            this.cmbCharacterSet.Items.AddRange(new object[] {
            "NONE",
            "ASCII",
            "BIG_5",
            "BS_BA",
            "CP943C",
            "CP943C_UNICODE",
            "CS_CZ",
            "CYRL",
            "DA_DA",
            "DB_CSY",
            "DB_DAN865",
            "DB_DEU437",
            "DB_DEU850",
            "DB_ESP437",
            "DB_ESP850",
            "DB_FIN437",
            "DB_FRA437",
            "DB_FRA850",
            "DB_FRC850",
            "DB_FRC863",
            "DB_ITA437",
            "DB_ITA850",
            "DB_NLD437",
            "DB_NLD850",
            "DB_NOR865",
            "DB_PLK",
            "DB_PTB850",
            "DB_PTG860",
            "DB_RUS",
            "DB_SLO",
            "DB_SVE437",
            "DB_SVE850",
            "DB_TRK",
            "DB_UK437",
            "DB_UK850",
            "DB_US437",
            "DB_US850",
            "DE_DE",
            "DOS437",
            "DOS737",
            "DOS775",
            "DOS850",
            "DOS852",
            "DOS857",
            "DOS858",
            "DOS860",
            "DOS861",
            "DOS862",
            "DOS863",
            "DOS864",
            "DOS865",
            "DOS866",
            "DOS869",
            "DU_NL",
            "EN_UK",
            "EN_US",
            "ES_ES",
            "ES_ES_CI_AI",
            "EUCJ_0208",
            "FI_FI",
            "FR_CA",
            "FR_FR",
            "FR_FR_CI_AI",
            "GB18030",
            "GB18030_UNICODE",
            "GBK",
            "GBK_UNICODE",
            "GB_2312",
            "ISO8859_1",
            "ISO8859_13",
            "ISO8859_2",
            "ISO8859_3",
            "ISO8859_4",
            "ISO8859_5",
            "ISO8859_6",
            "ISO8859_7",
            "ISO8859_8",
            "ISO8859_9",
            "ISO_HUN",
            "ISO_PLK",
            "IS_IS",
            "IT_IT",
            "KOI8R",
            "KOI8R_RU",
            "KOI8U",
            "KOI8U_UA",
            "KSC_5601",
            "KSC_DICTIONARY",
            "LT_LT",
            "NEXT",
            "NO_NO",
            "NXT_DEU",
            "NXT_ESP",
            "NXT_FRA",
            "NXT_ITA",
            "NXT_US",
            "OCTETS",
            "PDOX_ASCII",
            "PDOX_CSY",
            "PDOX_CYRL",
            "PDOX_HUN",
            "PDOX_INTL",
            "PDOX_ISL",
            "PDOX_NORDAN4",
            "PDOX_PLK",
            "PDOX_SLO",
            "PDOX_SWEDFIN",
            "PT_BR",
            "PT_PT",
            "PXW_CSY",
            "PXW_CYRL",
            "PXW_GREEK",
            "PXW_HUN",
            "PXW_HUNDC",
            "PXW_INTL",
            "PXW_INTL850",
            "PXW_NORDAN4",
            "PXW_PLK",
            "PXW_SLOV",
            "PXW_SPAN",
            "PXW_SWEDFIN",
            "PXW_TURK",
            "SJIS_0208",
            "SV_SV",
            "TIS620",
            "TIS620_UNICODE",
            "UCS_BASIC",
            "UNICODE",
            "UNICODE_CI",
            "UNICODE_CI_AI",
            "UNICODE_FSS",
            "UTF8",
            "WIN1250",
            "WIN1251",
            "WIN1251_UA",
            "WIN1252",
            "WIN1253",
            "WIN1254",
            "WIN1255",
            "WIN1256",
            "WIN1257",
            "WIN1257_EE",
            "WIN1257_LT",
            "WIN1257_LV",
            "WIN1258",
            "WIN_CZ",
            "WIN_CZ_CI_AI",
            "WIN_PTBR"});
            this.cmbCharacterSet.Location = new System.Drawing.Point(1, 155);
            this.cmbCharacterSet.Name = "cmbCharacterSet";
            this.cmbCharacterSet.Size = new System.Drawing.Size(128, 21);
            this.cmbCharacterSet.TabIndex = 9;
            // 
            // tbFBCharSets
            // 
            this.tbFBCharSets.StringBlock = resources.GetString("tbFBCharSets.StringBlock");
            // 
            // tbMySQLCharSets
            // 
            this.tbMySQLCharSets.StringBlock = resources.GetString("tbMySQLCharSets.StringBlock");
            // 
            // DatabaseConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCharacterSet);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblCharacterSet);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.cmbPacketSize);
            this.Controls.Add(this.lblPacketSize);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Name = "DatabaseConnection";
            this.Size = new System.Drawing.Size(268, 267);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.ComboBox cmbPacketSize;
        private System.Windows.Forms.Label lblPacketSize;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblCharacterSet;
        private System.Windows.Forms.ComboBox cmbCharacterSet;
        private Controls.TextBlock tbFBCharSets;
        private Controls.TextBlock tbMySQLCharSets;
    }
}
