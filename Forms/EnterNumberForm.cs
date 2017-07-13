/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2012 Simon Carter
 *
 *  Purpose:  Simple form for entering numbers
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
    /// Dialog box for entering a number
    /// </summary>
    public partial class EnterNumberForm : SharedControls.Forms.BaseForm
    {
        #region Constructors

        /// <summary>
        /// Constructor - Initialises a new instance of the control
        /// </summary>
        public EnterNumberForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Shows the enter number dialog box
        /// </summary>
        /// <param name="parent">Parent form</param>
        /// <param name="title">Title of dialog box</param>
        /// <param name="prompt">Prompt used for user</param>
        /// <param name="number">number entered by user</param>
        /// <returns>true if user entered a valid number, otherwise false</returns>
        public static bool ShowEnterNumber(Form parent, string title, string prompt, ref int number)
        {
            bool Result = false;

            EnterNumberForm form = new EnterNumberForm();
            try
            {
                form.Text = title;
                form.lblDescription.Text = prompt;
                form.txtNumber.Text = number.ToString();
                Result = form.ShowDialog(parent) == DialogResult.OK;

                number = Shared.Utilities.StrToInt(form.txtNumber.Text, 0);
            }
            finally
            {
                form.Dispose();
                form = null;
            }

            return (Result);
        }

        #endregion Static Methods

        #region Overridden Methods

        /// <summary>
        /// Overridden LanguageChanged method
        /// </summary>
        /// <param name="culture">New Culture being used</param>
        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = "Cancel";
            btnOK.Text = "OK";
        }

        #endregion Overridden Methods
    }
}
