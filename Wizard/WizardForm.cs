/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2014 Simon Carter
 *
 *  Purpose:  Wizard Form for showing items to user using a wizard interface
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SharedControls.Forms;

namespace SharedControls.WizardBase
{
    /// <summary>
    /// Wizard Form
    /// </summary>
    public partial class WizardForm : BaseForm
    {
        #region Private Members

        private int _page;
        private int _maxPages;
        private BaseWizardPage _currentPage;
        private BaseWizardPage[] _pages;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title of wizard</param>
        /// <param name="pages">Individual pages to be included in the wizard</param>
        public WizardForm(string title, BaseWizardPage[] pages)
        {
            InitializeComponent();
            this.Text = title;
            _page = 0;
            _maxPages = pages.Length -1;
            _pages = pages;

            foreach (BaseWizardPage page in pages)
            {
                page.MainWizardForm = this;
            }

            LoadWizard();
            SetButtons();
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Show's the wizard 
        /// </summary>
        /// <param name="title">Title of wizard</param>
        /// <param name="pages">Collection of pages to be shown within the wizard</param>
        /// <returns>true if user copletes, otherwise false if cancelled</returns>
        public static bool ShowWizard(string title, params BaseWizardPage[] pages)
        {
            WizardForm form = new WizardForm(title, pages);
            DialogResult wizardResult = form.ShowDialog();

            return (wizardResult == DialogResult.OK);
        }

        #endregion Static Methods

        #region Public Methods

        /// <summary>
        /// Instructs the wizard to save data
        /// </summary>
        /// <param name="fileName">Name of file data is to be saved to</param>
        /// <param name="nodeName">Current node</param>
        public void SaveAllSavedPageData(string fileName, string nodeName)
        {
            if (!String.IsNullOrEmpty(fileName) && !String.IsNullOrEmpty(nodeName))
            {
                if (!System.IO.File.Exists(fileName))
                {
                    System.IO.File.AppendAllText(fileName, String.Format("<{0}>\r\n</{0}>", nodeName));
                }
            }

            foreach (BaseWizardPage page in _pages)
            {
                page.SaveToFile(fileName);
            }
        }

        /// <summary>
        /// Instructs the wizard to load saved data
        /// </summary>
        /// <param name="fileName">Name of file to get settings from</param>
        public void LoadAllSavedPageData(string fileName)
        {
            Shared.XML.BeginUpdate(fileName);
            try
            {
                foreach (BaseWizardPage page in _pages)
                {
                    page.LoadFromFile(fileName);
                }
            }
            finally
            {
                Shared.XML.EndUpdate(fileName, false);
            }
        }

        /// <summary>
        /// Forces the wizard to select the next page
        /// </summary>
        public void SelectNextPage()
        {
            if (_page >= _maxPages)
                return;

            if (!_currentPage.NextClicked())
                return;

            flowPanelWizard.Controls.Clear();

            _page = NextPage(_page);

            _currentPage = _pages[_page];

            flowPanelWizard.Controls.Add(_currentPage);
            _currentPage.PageShown();

            SetButtons();
        }

        /// <summary>
        /// Selects the previous page in the wizard
        /// </summary>
        public void SelectPreviousPage()
        {
            if (_page == 0)
                return;

            if (!_currentPage.PreviousClicked())
                return;

            flowPanelWizard.Controls.Clear();

            _page = PreviousPage(_page);

            _currentPage = _pages[_page];

            flowPanelWizard.Controls.Add(_currentPage);
            _currentPage.PageShown();

            SetButtons();
        }

        /// <summary>
        /// Set's the cursor which is displayed when the mouse moves over the form
        /// </summary>
        /// <param name="cursor">Cursor to use</param>
        public void SetCursor(System.Windows.Forms.Cursor cursor)
        {
            this.Cursor = cursor;

            foreach (BaseWizardPage page in _pages)
            {
                page.Cursor = cursor;
            }
        }

        /// <summary>
        /// Forces the wizard to update it's UI buttons
        /// </summary>
        public void UpdateUI()
        {
            SetButtons();
        }

        /// <summary>
        /// Forces the wizard to finish
        /// </summary>
        public void ForceFinish()
        {
            btnFinish_Click(this, EventArgs.Empty);
        }

        #endregion Public Methods

        #region Private Methods

        private void LoadWizard()
        {
            _currentPage = _pages[0];
            flowPanelWizard.Controls.Add(_currentPage);
            _page = 0;
            _currentPage.PageShown();
        }

        private int NextPage(int currPage)
        {
            int Result = currPage + 1;

            if (Result < _maxPages)
                if (_pages[Result].SkipPage())
                    Result = NextPage(Result);

            return (Result);
        }

        private int PreviousPage(int currPage)
        {
            int Result = currPage - 1;

            if (Result < _maxPages && Result >= 0)
                if (_pages[Result].SkipPage())
                    Result = PreviousPage(Result);

            return (Result);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (_currentPage.BeforeFinish())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SelectNextPage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SelectPreviousPage();
        }

        private void SetButtons()
        {
            btnCancel.Enabled = _currentPage.CanCancel();
            btnPrevious.Enabled = _page > 0 && _currentPage.CanGoPrevious();
            btnNext.Enabled = _page < _maxPages && _currentPage.CanGoNext();
            btnFinish.Enabled = _page == _maxPages && _currentPage.CanGoFinish();
        }

        private void WizardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnCancel.Enabled)
            {
                if (btnFinish.Enabled)
                    return;

                e.Cancel = true;
                ShowInformation("Closing", "Wizard can not be cancelled, please complete the wizard");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_currentPage.CancelClicked())
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion Private Methods
    }
}
