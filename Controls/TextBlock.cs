/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2012 Simon Carter
 *
 *  Purpose:  Allows non visible text to be stored within a form
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SharedControls.Controls
{
    /// <summary>
    /// TextBlock control - allows for non visible block of text to be placed on a form
    /// </summary>
    public partial class TextBlock : Component
    {
        /// <summary>
        /// Constructor - Initialises new instance
        /// </summary>
        public TextBlock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Text to be saved within form
        /// </summary>
        [Description("Block of text")]
        [Category("General")]
        [EditorAttribute("System.ComponentModel.Design.MultilineStringEditor, System.Design", "System.Drawing.Design.UITypeEditor")]
        public string StringBlock { get; set; }
    }
}
