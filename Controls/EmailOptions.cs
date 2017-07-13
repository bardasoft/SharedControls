using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;
using SieraDelta.Shared;
using SieraDelta.Shared.Communication;

namespace SieraDelta.Controls
{
    public partial class EmailOptions : BaseSettings
    {
        #region Private Members

        private Email _email;

        #endregion Private Members

        #region Constructors

        public EmailOptions()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            gbCustom.Text = LanguageStrings.EmailCustom;

            rbCustomEmail.Text = LanguageStrings.EmailCustom;
            rbDefaultEmail.Text = LanguageStrings.EmailDefault;

            lblhost.Text = LanguageStrings.EmailHost;
            lblPassword.Text = LanguageStrings.EmailPassword;
            lblPort.Text = LanguageStrings.EmailPort;
            lblSenderEmail.Text = LanguageStrings.EmailSenderEmail;
            lblSenderName.Text = LanguageStrings.EmailSenderName;

            cbSSL.Text = LanguageStrings.EmailSSL;
            btnTest.Text = LanguageStrings.ButtonTest;
        }

        public override void SettingsControlLoaded()
        {
            _email = new Email();
            LoadEmailSettings(true);
        }

        public override bool Save()
        {
            if (rbCustomEmail.Checked)
            {
                _email.Default = false;
                _email.Host = txtHost.Text;
                _email.Password = txtPassword.Text;
                _email.Port = Convert.ToInt32(txtPort.Text);
                _email.Sender = txtSender.Text;
                _email.SSL = cbSSL.Checked;
                _email.User = txtEmail.Text;
            }
            else
            {
                _email.Default = true;
            }

            _email.Save();

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadEmailSettings(bool updateType)
        {
            if (_email.Default)
            {
                if (updateType)
                    rbDefaultEmail.Checked = true;

                txtHost.Text = String.Empty;
                txtPassword.Text = String.Empty;
                txtPort.Text = String.Empty;
                txtSender.Text = String.Empty;
                txtEmail.Text = String.Empty;
            }
            else
            {
                if (updateType)
                    rbCustomEmail.Checked = true;

                txtHost.Text = _email.Host;
                txtPassword.Text = _email.Password;
                txtPort.Text = _email.Port.ToString();
                txtSender.Text = _email.Sender;
                txtEmail.Text = _email.User;
                cbSSL.Checked = _email.SSL;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            _email.Default = false;
            _email.Host = txtHost.Text;
            _email.Password = txtPassword.Text;
            _email.Port = Convert.ToInt32(txtPort.Text);
            _email.Sender = txtSender.Text;
            _email.SSL = cbSSL.Checked;
            _email.User = txtEmail.Text;

            if (_email.SendTestEmail())
                ShowInformation("Test Email", "Success!");
            else
                ShowError("Test Email", "Email test failed!");
        }

        #endregion Private Methods

        private void rbDefaultEmail_CheckedChanged(object sender, EventArgs e)
        {
            gbCustom.Visible = rbCustomEmail.Checked;
            LoadEmailSettings(false);
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            btnTest.Enabled = !String.IsNullOrEmpty(txtPort.Text) && !String.IsNullOrEmpty(txtHost.Text) &&
                 !String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtPassword.Text) &&
                 !String.IsNullOrEmpty(txtSender.Text);
        }
    }
}
