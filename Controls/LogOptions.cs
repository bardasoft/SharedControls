using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

namespace SieraDelta.Controls
{
    public partial class LogOptions : BaseSettings
    {
        public LogOptions()
        {
            InitializeComponent();

            udRemoveLogs.Value = SieraDelta.Shared.XML.GetXMLValue64("LogFiles", "MaximumAge", 5);
        }

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblRemove1.Text = LanguageStrings.LogFileRemoveDesc1;
            lblRemove2.Text = LanguageStrings.LogFileRemoveDesc2;
        }

        public override bool Save()
        {
            SieraDelta.Shared.XML.SetXMLValue("LogFiles", "MaximumAge", Convert.ToInt32(udRemoveLogs.Value).ToString());

            UpdateSettings();

            return (true);
        }

        #endregion Overridden Methods

    }
}
