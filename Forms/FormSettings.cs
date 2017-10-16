/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2012 Simon Carter
 *
 *  Purpose:  Shared Settings form, allows applications to dynamically add settings panel in tree
 *
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Shared;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace SharedControls.Forms
{
    /// <summary>
    /// Settings Form
    /// </summary>
    public partial class FormSettings : BaseForm, IMessageFilter
    {
        #region Private Members

        private const int WM_KEYDOWN = 0x100;

        private Dictionary<TreeNode, Setting> _settings = new Dictionary<TreeNode, Setting>();

        /// <summary>
        /// Name of application
        /// </summary>
        private string _applicationName = "Unknown";

        /// <summary>
        /// Helpdesk location
        /// </summary>
        private string _helpDeskLocation;

        #endregion Private Member

        #region Constructors

        /// <summary>
        /// Constructor - initialises new instance
        /// </summary>
        public FormSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor - initialises new instance
        /// </summary>
        /// <param name="applicationName">Name of application</param>
        /// <param name="helpDeskLocation">url for helpdesk location</param>
        public FormSettings(string applicationName, string helpDeskLocation)
        {
            _applicationName = applicationName;
            _helpDeskLocation = helpDeskLocation;

            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        /// <summary>
        /// LanguageChanged method - called when UI culture is changed
        /// </summary>
        /// <param name="culture">Current UI culture</param>
        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = String.Format("{0} {1}", _applicationName, "Settings");
            lblDescription.Text = "Settings";
            btnCancel.Text = "Cancel";
            btnSave.Text = "Save";

            foreach (KeyValuePair<TreeNode, Setting> value in _settings)
                value.Value.SettingsPanel.LanguageChanged(culture);
        }

        /// <summary>
        /// Loads child settings controls
        /// </summary>
        protected override void LoadSettings()
        {
            this.Cursor = Cursors.WaitCursor;
            tvOptions.BeginUpdate();
            try
            {
                if (tvOptions.SelectedNode != null)
                {
                    Setting setting = _settings[tvOptions.SelectedNode];
                    UnloadSettingPanel(setting);
                }

                tvOptions.Nodes.Clear();
                _settings.Clear();
                TreeNode parent = null;

                RaiseAddSettings(new SettingsLoadArgs(parent));

                tvOptions.ExpandAll();

                if (tvOptions.Nodes.Count > 0)
                {
                    if (tvOptions.SelectedNode == null)
                        tvOptions.SelectedNode = tvOptions.Nodes[0];

                    tvOptions.Nodes[0].EnsureVisible();
                }
            }
            finally
            {
                tvOptions.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        #endregion Overridden Methods

        #region Properties


        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Loads a new setting option to the form
        /// </summary>
        /// <param name="name">Name of setting control</param>
        /// <param name="description">Description of setting</param>
        /// <param name="parent">Parent tree node, or null if no parent</param>
        /// <param name="settingsPanel">Settings Panel to be shown when user selects the setting</param>
        /// <returns>TreeNode item which controls the settings panel</returns>
        public TreeNode LoadControlOption(string name, string description, TreeNode parent, BaseSettings settingsPanel)
        {
            TreeNode Result = null;

            if (parent == null)
            {
                Result = tvOptions.Nodes.Add(name);
            }
            else
            {
                Result = parent.Nodes.Add(name);
            }

            Setting setting = new Setting(name, description, settingsPanel);
            _settings.Add(Result, setting);
            settingsPanel.SettingsParentForm = this;
            settingsPanel.SettingsLoaded();
            settingsPanel.TreeNode = Result;

            return (Result);
        }

        /// <summary>
        /// Forces the settings form to load all settings
        /// </summary>
        public void LoadAllSettings()
        {
            LoadSettings();
        }

        /// <summary>
        /// Updates settings
        /// </summary>
        public void UpdateSettings()
        {

        }

        #endregion Public Methods

        #region Private Methods

        private void LoadSettingsPanel(Setting setting)
        {
            lblDescription.Text = setting.Description;

            if (setting.SettingsPanel != null)
            {
                setting.SettingsPanel.Parent = this;
                setting.SettingsPanel.Left = 206;
                setting.SettingsPanel.Top = 41;
                setting.SettingsPanel.Visible = true;
                setting.SettingsPanel.SettingShown();
            }
        }

        private void UnloadSettingPanel(Setting setting)
        {
            if (setting.SettingsPanel != null)
            {
                setting.SettingsPanel.Visible = false;
                setting.SettingsPanel.Parent = null;
                setting.SettingsPanel.SettingHidden();
            }
        }

        private void tvOptions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Setting setting = _settings[e.Node];

            LoadSettingsPanel(setting);
        }

        private void tvOptions_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (tvOptions.SelectedNode != null)
            {
                Setting setting = _settings[tvOptions.SelectedNode];

                UnloadSettingPanel(setting);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<TreeNode, Setting> setting in _settings)
            {
                if (setting.Value.SettingsPanel != null)
                {
                    if (!setting.Value.SettingsPanel.SettingsConfirm())
                    {
                        Setting currentSetting = _settings[tvOptions.SelectedNode];

                        UnloadSettingPanel(currentSetting);

                        LoadSettingsPanel(setting.Value);

                        return;
                    }

                    if (!setting.Value.SettingsPanel.SettingsSave())
                    {
                        Setting currentSetting = _settings[tvOptions.SelectedNode];

                        UnloadSettingPanel(currentSetting);

                        LoadSettingsPanel(setting.Value);
                        
                        return;
                    }
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormSettings_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {

            }
        }

        private void FormSettings_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        /// Filter for windows messages
        /// </summary>
        /// <param name="m">Message being received</param>
        /// <returns>always returns false, indicating that other filters should also process messages</returns>
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                    switch ((int)m.WParam)
                    {
                        case 112: //f1
                            Setting setting = _settings[tvOptions.SelectedNode];

                            if (setting.SettingsPanel.HelpID > 0)
                                System.Diagnostics.Process.Start(String.Format(_helpDeskLocation, setting.SettingsPanel.HelpID));

                            break;
                    }

                    break;
            }

            return (false);
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            SplashForm.HideSplashForm();
        }

        #endregion Private Methods

        #region Event Wrappers

        private void RaiseAddSettings(SettingsLoadArgs args)
        {
            if (AddSettings != null)
                AddSettings(this, args);
        }

        #endregion Event Wrappers

        #region Events

        /// <summary>
        /// Event raised when calling application can add custom setting panels to the Settings Form
        /// </summary>
        public event SettingsLoadDelegate AddSettings;

        #endregion Events 
    }
}
