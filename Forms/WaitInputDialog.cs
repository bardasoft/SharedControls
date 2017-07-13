/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2012 Simon Carter
 *
 *  Purpose:  Wait input dialog, show user information on long running tasks
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SharedControls.Forms
{
    /// <summary>
    /// Wait Input Dialog Box, displayed to users when there will be a delay in loading something
    /// </summary>
    public partial class WaitInputDialog : SharedControls.Forms.BaseForm
    {
        private static WaitInputDialog _waitDialog = null;

        /// <summary>
        /// Constructor - Initialises a new instance
        /// </summary>
        public WaitInputDialog()
        {
            InitializeComponent();
        }

        #region Static Methods

        /// <summary>
        /// Shows the wait dialog
        /// </summary>
        public static void ShowWaitScreen()
        {
            if (_waitDialog == null)
            {
                _waitDialog = new WaitInputDialog();
                _waitDialog.Show();
            }
        }

        /// <summary>
        /// Hides the wait dialog
        /// </summary>
        public static void HideWaitScreen()
        {
            if (_waitDialog != null)
            {
                _waitDialog.Close();
                _waitDialog.Dispose();
                _waitDialog = null;
            }
        }

        /// <summary>
        /// Updates the text displayed on the wait dialog
        /// </summary>
        /// <param name="text">Text to be displayed</param>
        public static void UpdateWaitScreen(string text)
        {
            if (_waitDialog != null)
            {
                _waitDialog.Update(text);
            }
        }

        /// <summary>
        /// Updates the text and progress position displayed on the wait dialog
        /// </summary>
        /// <param name="text">Text to be displayed</param>
        /// <param name="position">Position (percentage) of progress bar</param>
        public static void UpdateWaitScreen(string text, int position)
        {
            if (_waitDialog != null)
            {
                _waitDialog.Update(text, position);
            }
        }

        #endregion Static Methods

        #region Overridden Methods

        /// <summary>
        /// Overridden Language changed method
        /// </summary>
        /// <param name="culture"></param>
        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = "Please wait";
        }

        #endregion Overridden Methods

        /// <summary>
        /// Updates the text being displayed
        /// </summary>
        /// <param name="Text">Message to show user</param>
        public void Update(string Text)
        {
            lblProgress.Text = Text;
            Refresh();
        }

        /// <summary>
        /// Updates the text and progress bar being displayed
        /// </summary>
        /// <param name="Text">Message to show user</param>
        /// <param name="Pos">Position of progress bar</param>
        public void Update(string Text, int Pos)
        {
            lblProgress.Text = Text;
            Refresh();
        }

        /// <summary>
        /// Updates the progress bar
        /// </summary>
        /// <param name="Position">Position of progress bar</param>
        public void UpdateProgress(int Position)
        {
            Refresh();
        }

        /// <summary>
        /// Updates the progress bar
        /// </summary>
        /// <param name="Max">MAximum value of progress bar</param>
        /// <param name="Position">Position of progress bar</param>
        public void Update(int Max, int Position)
        {
        }
    }
}
