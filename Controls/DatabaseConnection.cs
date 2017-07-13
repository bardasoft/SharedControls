/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2012 Simon Carter
 *
 *  Purpose:  Database connection settings for MySQL/Firebird/MSSQL
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using Shared;

namespace SharedControls
{
    /// <summary>
    /// Control for connecting to a database
    /// </summary>
    public partial class DatabaseConnection : BaseControl
    {
        #region Private Members

        private bool _testConnectionClicked = false;

        private bool _localHostOnly;

        private DatabaseConnectionType _connectionType;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor - Initialises new instance
        /// </summary>
        public DatabaseConnection()
        {
            InitializeComponent();
            AllowSaveSettings = false;

            CheckVisualSettings();
        }

        /// <summary>
        /// Constructor - Initialises new instance
        /// </summary>
        /// <param name="localHostOnly">if true, connections to local host only, otherwise connections to any server</param>
        public DatabaseConnection(bool localHostOnly)
        {
            InitializeComponent();
            AllowSaveSettings = false;

            if (localHostOnly)
            {
                txtServer.Text = "127.0.0.1";
                txtServer.Enabled = false;
            }

            CheckVisualSettings();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Connection String Suffix
        /// 
        /// Only use a-z 0-9
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Returns the connection string
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return (CreateConnectionString());
            }

            set
            {
                LoadSettings(value);
            }
        }

        /// <summary>
        /// Determines wether the user clicked the test button
        /// </summary>
        public bool TestClicked
        {
            get
            {
                return (_testConnectionClicked);
            }
        }

        /// <summary>
        /// Indicates wether you can only connect to localhost
        /// </summary>
        public bool LocalHostOnly
        {
            get
            {
                return (_localHostOnly);
            }

            set
            {
                _localHostOnly = value;
                txtServer.Enabled = !value;

                if (value)
                    txtServer.Text = "127.0.0.1";
            }
        }

        /// <summary>
        /// Get's sets the database connection type
        /// </summary>
        public DatabaseConnectionType ConnectionType
        {
            get
            {
                return (_connectionType);
            }

            set
            {
                _connectionType = value;
                txtPort.Text = ((int)value).ToString();
                cmbCharacterSet.Items.Clear();

                switch (value)
                {
                    case DatabaseConnectionType.Firebird:
                        txtPort.Visible = true;
                        lblPort.Visible = true;

                        lblRole.Visible = true;
                        txtRoleName.Visible = true;

                        cmbCharacterSet.Visible = true;
                        lblCharacterSet.Visible = true;

                        LoadCharacterSets(tbFBCharSets);

                        txtServer.Enabled = !LocalHostOnly;

                        cmbPacketSize.Visible = true;
                        lblPacketSize.Visible = true;
                        break;
                    case DatabaseConnectionType.MySQL:
                        txtPort.Visible = true;
                        lblPort.Visible = true;
                        txtServer.Enabled = !LocalHostOnly;
                        cmbPacketSize.Visible = false;
                        lblPacketSize.Visible = false;

                        lblRole.Visible = false;
                        txtRoleName.Visible = false;
                        LoadCharacterSets(tbMySQLCharSets);
                        cmbCharacterSet.Visible = true;
                        lblCharacterSet.Visible = true;
                        break;
                    case DatabaseConnectionType.MSSQL:
                        txtPort.Visible = false;
                        lblPort.Visible = false;
                         cmbPacketSize.Visible = false;
                        lblPacketSize.Visible = false;

                        txtServer.Enabled = true;

                        lblRole.Visible = false;
                        txtRoleName.Visible = false;
                        LoadCharacterSets(null);
                        cmbCharacterSet.Visible = false;
                        lblCharacterSet.Visible = false;
                       break;
                    default:
                       throw new Exception("Invalid connection type");
                }
            }
        }

        /// <summary>
        /// Determines wether settings are saved to local config file or not
        /// </summary>
        public bool AllowSaveSettings { get; set; }

        #endregion Properties

        #region Overridden Methods

        /// <summary>
        /// Overridden Language changed method
        /// </summary>
        /// <param name="culture"></param>
        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDatabase.Text = "Database";
            lblPacketSize.Text = "Packet Size";
            lblPassword.Text = "Password";
            lblPort.Text = "Port";
            lblServer.Text = "Server Name";
            lblUserName.Text = "Username";
            lblCharacterSet.Text = "Character Set";
            lblRole.Text = "Role";
            
            btnTestConnection.Text = "Test Connection";
        }

        #endregion Overridden Methods

        #region Public Methods

        /// <summary>
        /// Saves connection details
        /// </summary>
        public void SaveSettings()
        {
            if (AllowSaveSettings)
                Shared.XML.SetXMLValue("Connection", String.Format("ConnectionString{0}", Connection), CreateConnectionString());
        }

        /// <summary>
        /// Loads saved connection details
        /// </summary>
        /// <param name="connectionString"></param>
        public void LoadSettings(string connectionString = "")
        {
            string connString = connectionString;
            
            if (String.IsNullOrEmpty(connString) && AllowSaveSettings)
                connString = Shared.XML.GetXMLValue("Connection", String.Format("ConnectionString{0}", Connection));

            string[] parts = connString.Split(';');

            foreach (string s in parts)
            {
                if (String.IsNullOrEmpty(s))
                    continue;

                string[] values = s.Split('=');
                
                switch (values[0].ToLower())
                {
                    case "user": //fb
                    case "uid": //mysql
                    case "user id": // ms sql
                        txtUsername.Text = values[1];
                        break;
                    case "password": //fb and ms sql
                    case "pwd": //mysql
                        txtPassword.Text = values[1];
                        break;
                    case "role": //fb
                        txtRoleName.Text = values[1];
                        break;
                    case "database":// fb and mysql
                    case "initial catalog": // ms sql
                        txtDatabase.Text = values[1].Replace("\\\\", "\\");
                        break;
                    case "packet size": // fb
                        cmbPacketSize.SelectedIndex = cmbPacketSize.Items.IndexOf(values[1]);
                        break;
                    case "datasource": //fb and mysql
                    case "data source": //mssql
                    case "server": //mysql
                        txtServer.Text = values[1];
                        break;
                    case "port": // fb and mysql
                    case "port number":
                        txtPort.Text = values[1];
                        break;
                    case "integrated security": // ms sql means don't use user/password
                        txtUsername.Text = String.Empty;
                        txtPassword.Text = String.Empty;
                        break;
                    case "charset": // fb and mysql
                        int idx = cmbCharacterSet.FindString(values[1]);
                        cmbCharacterSet.SelectedIndex = idx > -1 ? idx : 0;
                        break;
                    case "dialect": // fb
                        break;
                    case "pooling": // fb
                        break;
                    case "minpoolsize": // fb
                        break;
                    case "maxpoolsize": // fb
                        break;
                    case "connection lifetime": //fb
                        break;
                    case "multipleactiveresultsets": //MS SQL
                        break;
                    case "no garbage collect": //fb
                        break;
                    default:
                        //throw new Exception();
                        // do nothing just ignore
                        break;
                }
            }

            if (cmbCharacterSet.SelectedIndex == -1)
                cmbCharacterSet.SelectedIndex = cmbCharacterSet.FindString("UTF8");

            CheckVisualSettings();
        }

        /// <summary>
        /// Creates a connection string, optionally encrypting the password
        /// </summary>
        /// <param name="encryptPassword"></param>
        /// <param name="poolSize"></param>
        /// <returns>Valid connection string</returns>
        public string CreateConnectionString(bool encryptPassword = false, int poolSize = 80)
        {
            string Result = String.Empty;

            switch (_connectionType)
            {
                case DatabaseConnectionType.Firebird:
                    if (cmbPacketSize.SelectedIndex == -1)
                        cmbPacketSize.SelectedIndex = 0;

                    Result = String.Format("User={0};Password={1};Database={2};DataSource={4};Role={9};Port={5};Dialect=3;Pooling={6};MinPoolSize=1;MaxPoolSize={7};Connection Lifetime=600;Packet Size={3};CharSet={8}",
                        txtUsername.Text, encryptPassword ? txtPassword.Text : txtPassword.Text, txtDatabase.Text, cmbPacketSize.Items[cmbPacketSize.SelectedIndex], txtServer.Text,
                        String.IsNullOrEmpty(txtPort.Text) ? "3050" : txtPort.Text, poolSize == 1 ? "false" : "true", poolSize, cmbCharacterSet.SelectedItem, txtRoleName.Text);
                    break;

                case DatabaseConnectionType.MySQL:
                    if (LocalHostOnly)
                        Result = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};CharSet={5};",
                            txtServer.Text, txtPort.Text, txtDatabase.Text, txtUsername.Text,
                            txtPassword.Text, cmbCharacterSet.SelectedItem);
                    else
                        Result = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};CharSet={5};",
                            txtServer.Text, txtPort.Text, txtDatabase.Text, txtUsername.Text, 
                            txtPassword.Text, cmbCharacterSet.SelectedItem);

                    break;

                case DatabaseConnectionType.MSSQL:

                    if (LocalHostOnly & !txtServer.Text.StartsWith(Environment.MachineName))
                        txtServer.Text = Environment.MachineName + "\\" + txtServer.Text;

                    if (String.IsNullOrEmpty(txtPassword.Text) && String.IsNullOrEmpty(txtUsername.Text))
                        Result = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;MultipleActiveResultSets=True",
                            txtServer.Text, txtDatabase.Text);
                    else
                        Result = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=False;User Id={2};Password={3};MultipleActiveResultSets=True",
                            txtServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);

                    break;

                default:
                    throw new Exception("Invalid Connection Type");
            }

            return (Result);
        }

        #endregion Public Methods

        #region Private Methds

        private void LoadCharacterSets(SharedControls.Controls.TextBlock textBlock)
        {
            cmbCharacterSet.Items.Clear();

            if (textBlock != null)
            {
                string[] lines = textBlock.StringBlock.Replace("\n", "").Trim().Split('\r');

                foreach (string s in lines)
                {
                    if (String.IsNullOrEmpty(s))
                        continue;

                    cmbCharacterSet.Items.Add(s);
                }
            }
        }

        private void cbEmbedded_CheckedChanged(object sender, EventArgs e)
        {
            CheckVisualSettings();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string resultMessage = String.Empty;
            bool testResult = false;

            Cursor = Cursors.WaitCursor;
            try
            {
                switch (_connectionType)
                {
                    case DatabaseConnectionType.Firebird:
                        testResult = ConnectFirebird(CreateConnectionString(), ref resultMessage);
                        break;
                    case DatabaseConnectionType.MySQL:
                        testResult = ConnectMySQL(CreateConnectionString(), ref resultMessage);
                        break;
                    case DatabaseConnectionType.MSSQL:
                        testResult = ConnectMSSQL(CreateConnectionString(), ref resultMessage);
                        break;
                    default:
                        throw new Exception("Invalid Connection Type");
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }

            if (testResult)
            {
                MessageBox.Show(String.Format("{1}\r\n\r\nResult: {0}", resultMessage, "Succesfully tested connection"), 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _testConnectionClicked = true;

                RaiseTestConnection();
            }
            else
            {
                MessageBox.Show(resultMessage, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Makes a physical connection and tests that the storage is ready to use
        /// </summary>
        /// <param name="connectionString">connection string</param>
        /// <param name="resultMessage">Message returned from server when connection test complete</param>
        /// <returns>true if all ok, otherwise false</returns>
        private bool ConnectFirebird(string connectionString, ref string resultMessage)
        {
            bool Result = false;

            FbConnection db = new FbConnection(connectionString);
            try
            {
                db.Open();
                resultMessage = String.Format("OK - Server Version: {0}", db.ServerVersion);

                Result = true;
            }
            catch (Exception error)
            {
                Shared.EventLog.Add(error);
                resultMessage = error.Message;
                Result = false;
            }
            finally
            {
                db.Close();
                db.Dispose();
                db = null;
            }

            return (Result);
        }

        private bool ConnectMySQL(string connectionString, ref string resultMessage)
        {
            bool Result = false;

            MySqlConnection db = new MySqlConnection(connectionString);
            try
            {
                db.Open();
                resultMessage = String.Format("OK - Server Version: {0}", db.ServerVersion);

                Result = true;
            }
            catch (Exception error)
            {
                Shared.EventLog.Add(error);
                resultMessage = error.Message;
                Result = false;
            }
            finally
            {
                db.Close();
                db.Dispose();
                db = null;
            }

            return (Result);
        }


        private bool ConnectMSSQL(string connectionString, ref string resultMessage)
        {
            bool Result = false;

            SqlConnection db = new SqlConnection(connectionString);
            try
            {
                db.Open();
                resultMessage = String.Format("OK - Server Version: {0}", db.ServerVersion);

                Result = true;
            }
            catch (Exception error)
            {
                Shared.EventLog.Add(error);
                resultMessage = error.Message;
                Result = false;
            }
            finally
            {
                db.Close();
                db.Dispose();
                db = null;
            }

            return (Result);
        }

        private void SettingChangedEvent(object sender, EventArgs e)
        {
            _testConnectionClicked = false;
            CheckVisualSettings();
        }

        private void CheckVisualSettings()
        {

        }

        private void RaiseTestConnection()
        {
            if (TestConnectionSuccess != null)
                TestConnectionSuccess(this, EventArgs.Empty);
        }


        #endregion Private Methds

        #region Events

        /// <summary>
        /// Event raised when test connection is successful
        /// </summary>
        public event EventHandler TestConnectionSuccess;

        #endregion Events
    }
}
