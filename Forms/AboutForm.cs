using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

namespace SieraDelta.Controls.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            this.Text = LanguageStrings.About;
        }

        /// <summary>
        /// Displays the About Dialog
        /// </summary>
        /// <param name="parent">Parent Form</param>
        /// <param name="updateName">Name of Update</param>
        /// <param name="productHelpID">Product Help ID</param>
        public static void ShowDialog(Form parent, string updateName, int productHelpID)
        {
            AboutForm form = new AboutForm();
            form.about1.ProductID = productHelpID;
            form.about1.UpdateName = updateName;
            form.ShowDialog(parent);
            form = null;
        }
    }
}
