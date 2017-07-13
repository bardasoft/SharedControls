/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2012 Simon Carter
 *
 *  Purpose:  Splash Form to be shown when program loads
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
    /// Generic splash screen
    /// </summary>
    public partial class SplashForm : Form
    {
        #region Static Members

        private static SplashForm _splashForm = null;

        #endregion Static Members

        #region Constructors

        /// <summary>
        /// Constructor - Initialises new instance of splash form
        /// </summary>
        public SplashForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Shows the splash form
        /// </summary>
        /// <param name="image">Image to be displayed on form</param>
        public static void ShowSplashForm(Image image)
        {
            if (image == null)
                throw new ArgumentException("invalid image");

            if (_splashForm == null)
            {
                _splashForm = new SplashForm();
                _splashForm.BackgroundImage = image;
                _splashForm.Show();
                _splashForm.Invalidate();
                _splashForm.Refresh();
            }
        }

        /// <summary>
        /// Hides the splash form
        /// </summary>
        public static void HideSplashForm()
        {
            if (_splashForm != null)
            {
                _splashForm.Hide();
                _splashForm = null;
            }
        }

        #endregion Static Methods
    }
}
