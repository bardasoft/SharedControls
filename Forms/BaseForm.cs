/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2012 Simon Carter
 *
 *  Purpose:  Base Form, extra events, methods and optional state saving
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SharedControls.Forms
{
    /// <summary>
    /// Base form with extra methods/properties 
    /// </summary>
    public class BaseForm : Form
    {
        #region Properties

        /// <summary>
        /// Determines wether form state is saved automatically or not
        /// </summary>
        [Description("Determines wether form state is saved automatically or not")]
        [Category("Layout")]
        [DefaultValue(true)]
        public bool SaveState { get; set; }


        /// <summary>
        /// determines wether the control is in design mode within an editor
        /// </summary>
        protected bool IsDesignMode
        {
            get
            {
                return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            }
        }

        #endregion Properties

        #region General Methods

        /// <summary>
        /// Returns current path for application
        /// </summary>
        /// <returns></returns>
        public string CurrentPath()
        {
            return (Shared.Utilities.CurrentPath(true));
        }

        #endregion General Methods

        #region Static Methods

        /// <summary>
        /// Checks the position of the form, within the screen and ensures it fit's with the screen
        /// </summary>
        /// <param name="form">Form to check</param>
        public static void CheckFormPosition(Form form)
        {
            form.WindowState = FormWindowState.Normal;

            if (form.Width < 200 | (form.Width + form.Left) > Screen.PrimaryScreen.WorkingArea.Width)
                form.Width = 200;

            if (form.Height < 100 | form.Height > Screen.PrimaryScreen.WorkingArea.Height)
                form.Height = 100;

            if (form.Left < 0 | form.Left > Screen.PrimaryScreen.WorkingArea.Width)
                form.Left = 0;

            if (form.Top < 0 | (form.Top + form.Height) > Screen.PrimaryScreen.WorkingArea.Bottom)
                form.Top = 0;

        }

        #endregion Static Methods

        #region Message Dialogs

        /// <summary>
        /// Shows a message box with Stop icon
        /// </summary>
        /// <param name="title">Title of dialog box</param>
        /// <param name="message">Message to be displayed to user</param>
        /// <param name="yesNoButtons">if true then yes/no buttons are shown, otherwise ok button is shown</param>
        /// <returns>true if user click yes button, otherwise false</returns>
        public bool ShowHardConfirm(string title, string message, bool yesNoButtons = true)
        {
            return (MessageBox.Show(message, title, yesNoButtons ? MessageBoxButtons.YesNo : MessageBoxButtons.OK, 
                MessageBoxIcon.Stop) == DialogResult.Yes);
        }

        /// <summary>
        /// Shows a message box with Question icon
        /// </summary>
        /// <param name="title">Title of dialog box</param>
        /// <param name="message">Message to be displayed to user</param>
        /// <param name="yesNoButtons">if true then yes/no buttons are shown, otherwise ok button is shown</param>
        /// <returns>true if user click yes button, otherwise false</returns>
        public bool ShowQuestion(string title, string message, bool yesNoButtons = true)
        {
            return (MessageBox.Show(message, title, yesNoButtons ? MessageBoxButtons.YesNo : MessageBoxButtons.OK, 
                MessageBoxIcon.Question) == DialogResult.Yes);
        }

        /// <summary>
        /// Shows a message box with Information icon
        /// </summary>
        /// <param name="title">Title of dialog box</param>
        /// <param name="message">Message to be displayed to user</param>
        /// <param name="yesNoButtons">if true then yes/no buttons are shown, otherwise ok button is shown</param>
        /// <returns>true if user click yes button, otherwise false</returns>
        public void ShowInformation(string title, string message, bool yesNoButtons = false)
        {
            MessageBox.Show(message, title, yesNoButtons ? MessageBoxButtons.YesNo : MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a message box with Error icon
        /// </summary>
        /// <param name="title">Title of dialog box</param>
        /// <param name="message">Message to be displayed to user</param>
        /// <param name="yesNoButtons">if true then yes/no buttons are shown, otherwise ok button is shown</param>
        /// <returns>true if user click yes button, otherwise false</returns>
        public bool ShowErrorMessage(string title, string message, bool yesNoButtons = true)
        {
            return (MessageBox.Show(message, title, yesNoButtons ? MessageBoxButtons.YesNo : MessageBoxButtons.OK, 
                MessageBoxIcon.Error) == DialogResult.Yes);
        }

        /// <summary>
        /// Shows a message box with Warning icon
        /// </summary>
        /// <param name="title">Title of dialog box</param>
        /// <param name="message">Message to be displayed to user</param>
        /// <param name="yesNoButtons">if true then yes/no buttons are shown, otherwise ok button is shown</param>
        /// <returns>true if user click yes button, otherwise false</returns>
        public bool ShowWarning(string title, string message, bool yesNoButtons = true)
        {
            return (MessageBox.Show(message, title, yesNoButtons ? MessageBoxButtons.YesNo : MessageBoxButtons.OK, 
                MessageBoxIcon.Warning) == DialogResult.Yes);
        }

        /// <summary>
        /// Shows a message box with Error icon
        /// 
        /// message is wrapped in a message stating contac support
        /// </summary>
        /// <param name="title">Title of dialog box</param>
        /// <param name="message">Message to be displayed to user</param>
        /// <param name="yesNoButtons">if true then yes/no buttons are shown, otherwise ok button is shown</param>
        /// <returns>true if user click yes button, otherwise false</returns>
        public void ShowError(string title, string message, bool yesNoButtons = false)
        {
            string msg = String.Format("An error has occured\r\r{0}\r\rPlease contact support", message);
            MessageBox.Show(message, title, yesNoButtons ? MessageBoxButtons.YesNo : MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Message Dialogs

        #region Abstract Methods

        /// <summary>
        /// Method used to indicate a change of language within the application
        /// </summary>
        /// <param name="culture"></param>
        protected virtual void LanguageChanged(CultureInfo culture)
        {

        }

        /// <summary>
        /// Method used by descendants to indicate it should load it's settings
        /// </summary>
        protected virtual void LoadSettings()
        {

        }

        /// <summary>
        /// Method used by descendants to indicate settings should be saved
        /// </summary>
        protected virtual void SaveSettings()
        {

        }

        #endregion Abstract Methods

        #region Protected Methods

        #region Save Settings

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, string settingValue)
        {
            Shared.XML.SetXMLValue(this.Name, settingName, settingValue, String.Format("{0}.xml", Application.ProductName));
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, int settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, long settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, uint settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, bool settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, DateTime settingValue)
        {
            SettingSave(settingName, settingValue.ToString("R"));
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, double settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, decimal settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, ulong settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, ushort settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, float settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        /// <summary>
        /// Saves a setting value to the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="settingValue">Value of setting</param>
        protected void SettingSave(string settingName, short settingValue)
        {
            SettingSave(settingName, settingValue.ToString());
        }

        #endregion Save Settings

        #region Settings Get

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected string SettingGet(string settingName, string defaultValue)
        {
            return (Shared.XML.GetXMLValue(this.Name, settingName, defaultValue, String.Format("{0}.xml", Application.ProductName)));
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected int SettingGet(string settingName, int defaultValue)
        {
            int Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!int.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected long SettingGet(string settingName, long defaultValue)
        {
            long Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!long.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected uint SettingGet(string settingName, uint defaultValue)
        {
            uint Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!uint.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected bool SettingGet(string settingName, bool defaultValue)
        {
            bool Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!bool.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected DateTime SettingGet(string settingName, DateTime defaultValue)
        {
            DateTime Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!DateTime.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected double SettingGet(string settingName, double defaultValue)
        {
            double Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!double.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected decimal SettingGet(string settingName, decimal defaultValue)
        {
            decimal Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!decimal.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected ulong SettingGet(string settingName, ulong defaultValue)
        {
            ulong Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!ulong.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected ushort SettingGet(string settingName, ushort defaultValue)
        {
            ushort Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!ushort.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected float SettingGet(string settingName, float defaultValue)
        {
            float Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!float.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        /// <summary>
        /// Retrieves a setting value from the configuration file
        /// </summary>
        /// <param name="settingName">Name of setting</param>
        /// <param name="defaultValue">Default value to be returned if setting not set</param>
        protected short SettingGet(string settingName, short defaultValue)
        {
            short Result = defaultValue;
            string savedValue = SettingGet(settingName, defaultValue.ToString());

            if (!short.TryParse(savedValue, out Result))
                Result = defaultValue;

            return (Result);
        }

        #endregion Save Settings

        /// <summary>
        /// Forces a change of culture for all active forms
        /// </summary>
        /// <param name="culture">Culture being changed</param>
        protected void LanguageUpdate(CultureInfo culture)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            Cursor = Cursors.WaitCursor;
            try
            {
                if (culture == null)
                    throw new ArgumentException("Invalid Culture");

                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;

                bool isRightToLeft = Shared.Utilities.IsRightToLeftCharacter(culture.NativeName);

                foreach (Form form in Application.OpenForms)
                {
                    if (form is BaseForm)
                    {
                        ((BaseForm)form).LanguageChanged(culture);

                        foreach (Control control in ((BaseForm)form).Controls)
                            UpdateControlLanguage(control, culture, isRightToLeft);
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        #endregion Protected Methods

        #region Overridden Methods

        /// <summary>
        /// Overridden OnClosing method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!e.Cancel)
            {
                try
                {
                    //save settings
                    if (SaveState)
                        SaveSettings(String.Format("{0}.xml", Application.ProductName));

                    SaveSettings();
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err, String.Format("{0}.xml", Application.ProductName));
                }
            }
        }

        /// <summary>
        /// Overridden OnLoad method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LanguageUpdate(System.Threading.Thread.CurrentThread.CurrentUICulture);

            //restore settings
            if (SaveState)
                LoadSettings(String.Format("{0}.xml", Application.ProductName));

            LoadSettings();

            // auto load saved ListViewEx controls
            RestoreListViews(this.Controls);
        }

        /// <summary>
        /// Overridden OnShown method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        #endregion Overridden Methods

        #region Private Methods

        /// <summary>
        /// recursively finds ListViewEx controls and forces them to load their configuration
        /// </summary>
        /// <param name="controls"></param>
        private void RestoreListViews(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (System.Windows.Forms.Control ctl in controls)
            {
                if (ctl is SharedControls.Classes.ListViewEx)
                {
                    ((SharedControls.Classes.ListViewEx)ctl).LoadLayout();
                }

                RestoreListViews(ctl.Controls);
            }
        }

        /// <summary>
        /// Recursively go through all controls changing the language if it's a BaseControl type
        /// </summary>
        /// <param name="control">Control to update</param>
        /// <param name="culture">Current UI culture</param>
        /// <param name="rightToLeft">Indicates wether the language is right to left (if true) or left to right (if false)</param>
        private void UpdateControlLanguage(Control control, CultureInfo culture, bool rightToLeft)
        {
            if (control is BaseControl)
            {
                ((BaseControl)control).LanguageChanged(culture);
            }

            foreach (Control subControl in control.Controls)
                UpdateControlLanguage(subControl, culture, rightToLeft);
        }

        /// <summary>
        /// Saves form state to settings file
        /// </summary>
        /// <param name="settingsFile">Name of file for settings to be saved to</param>
        private void SaveSettings(string settingsFile)
        {
            Shared.XML.SetXMLValue(this.Name, "Culture", System.Threading.Thread.CurrentThread.CurrentUICulture.Name, settingsFile);

            if (this.WindowState == FormWindowState.Normal)
            {
                Shared.XML.SetXMLValue(this.Name, "Top", this.Top.ToString(), settingsFile);
                Shared.XML.SetXMLValue(this.Name, "Left", this.Left.ToString(), settingsFile);
                Shared.XML.SetXMLValue(this.Name, "Width", this.Width.ToString(), settingsFile);
                Shared.XML.SetXMLValue(this.Name, "Height", this.Height.ToString(), settingsFile);
            }

            Shared.XML.SetXMLValue(this.Name, "State", this.WindowState.ToString(), settingsFile);
        }

        /// <summary>
        /// Restores form state from settings file
        /// </summary>
        /// <param name="settingsFile">Name of file for settings to be saved to</param>
        private void LoadSettings(string settingsFile)
        {
            try
            {
                string culture = String.Empty;

                if (String.IsNullOrEmpty(culture))
                    culture = Application.CurrentCulture.Name;

                string state = Shared.XML.GetXMLValue(this.Name, "State", settingsFile);

                if (String.IsNullOrEmpty(state))
                    state = this.WindowState.ToString();

                this.Top = Shared.XML.GetXMLValue(this.Name, "Top", this.Top, settingsFile);
                this.Left = Shared.XML.GetXMLValue(this.Name, "Left", this.Left, settingsFile);
                this.Width = Shared.XML.GetXMLValue(this.Name, "Width", this.Width, settingsFile);
                this.Height = Shared.XML.GetXMLValue(this.Name, "Height", this.Height, settingsFile);

                LanguageUpdate(new CultureInfo(culture));

                this.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), state);
            }
            catch
            {
                //default position for some settings
                WindowState = FormWindowState.Normal;
                LanguageUpdate(Application.CurrentCulture);
            }
        }

        #endregion Private Methods
    }
}
