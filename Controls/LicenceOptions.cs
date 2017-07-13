using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;
using SieraDelta.Shared;

using WebDefender;

namespace SieraDelta.Controls
{
    public partial class LicenceOptions : BaseSettings
    {
        private LicenceType _licenceType;

        public LicenceOptions()
        {
            InitializeComponent();

            LoadLicenceDetails();
        }

        public LicenceOptions(LicenceType licenceType)
        {
            _licenceType = licenceType;
            InitializeComponent();

            LoadLicenceDetails();
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnTrialLicence.Text = LanguageStrings.ButtonTrial;
            btnUpdateLicence.Text = LanguageStrings.ButtonUpdate;

            gbUpdateLicence.Text = LanguageStrings.LicenceUpdate;

            lblUpdateDescription.Text = LanguageStrings.LicenceEnterLicence;
            lblExpiresDesc.Text = String.Format("{0}:", LanguageStrings.Expires);
            lblServerDesc.Text = String.Format("{0}:", LanguageStrings.ServerIPAddress);
            lblRegToDesc.Text = String.Format("{0}:", LanguageStrings.LicenceRegisteredTo);

            LoadLicenceDetails();
        }

        private void LoadLicenceDetails()
        {
            WebDefenderLicence licence = WebDefenderLicence.Load(_licenceType);

            lblDescription.Text = LanguageStrings.LicenceNotFound;
            lblExpires.Visible = licence != null;
            lblRegisteredTo.Visible = licence != null;
            lblServer.Visible = licence != null;
            lblExpiresDesc.Visible = licence != null;
            lblRegToDesc.Visible = licence != null;
            lblServerDesc.Visible = licence != null;

            if (licence != null)
            {
                lblDescription.Text = licence.IsTrial ? LanguageStrings.LicenceTrial2 : String.Empty;
                lblDescription.Text += licence.LicenceValid(_licenceType) ? LanguageStrings.LicenceValidUptoDate : LanguageStrings.LicenceNotValid2;
                lblExpires.Text = licence.ExpireDate.ToShortDateString();
                lblRegisteredTo.Text = licence.LicencedTo;
                lblServer.Text = licence.Domain;
            }
        }

        /// <summary>
        /// Updates the licence for the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateLicence_Click(object sender, EventArgs e)
        {
            try
            {
                WebDefenderLicence.Save(_licenceType, txtNewLicence.Text);
                WebDefenderLicence licence = WebDefenderLicence.Load(_licenceType);

                if (licence == null)
                    throw new Exception(LanguageStrings.LicenceInvalidDescription);

                LoadLicenceDetails();
                txtNewLicence.Text = String.Empty;
            }
            catch (Exception err)
            {
                if (err.Message.Contains(LanguageStrings.LicenceInvalid))
                {
                    MessageBox.Show(err.Message, LanguageStrings.LicenceUpdate, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    throw;
            }
        }

        private void btnTrialLicence_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.sieradelta.com/Members/Licences.aspx");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, LanguageStrings.LicenceTrial, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
