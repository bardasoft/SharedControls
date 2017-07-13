/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2014 Simon Carter
 *
 *  Purpose:  Class for entering column value
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Shared;

namespace SharedControls.Controls
{
    /// <summary>
    /// Column Value Control
    /// </summary>
    public partial class ColumnValue : UserControl
    {
        #region Private Members

        private NumericUpDown _numberValue;

        private TextBox _stringValue;

        private CheckBox _booleanValue;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ColumnValue()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="columnType"></param>
        public ColumnValue(string columnName, ColumnType columnType)
            :this()
        {
            ColumnType = columnType;
            ColumnName = columnName;

            lblDescription.Text = String.Format("Enter the value for {0}", columnName);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="columnType"></param>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public ColumnValue(string columnName, ColumnType columnType, decimal value, decimal minValue, decimal maxValue)
            : this(columnName, columnType)
        {
            _numberValue = new NumericUpDown();
            _numberValue.Minimum = minValue;
            _numberValue.Maximum = maxValue;
            _numberValue.Value = value;
            _numberValue.ValueChanged += _numberValue_ValueChanged;

            this.Controls.Add(_numberValue);

            _numberValue.Top = 18;
            _numberValue.Width = this.Width - 20;
            _numberValue.Left = 10;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="columnType"></param>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        public ColumnValue(string columnName, ColumnType columnType, string value, int maxLength)
            : this(columnName, columnType)
        {
            _stringValue = new TextBox();
            _stringValue.MaxLength = maxLength;
            _stringValue.Text = value;
            _stringValue.TextChanged += _stringValue_TextChanged;

            this.Controls.Add(_stringValue);

            _stringValue.Top = 18;
            _stringValue.Width = this.Width - 20;
            _stringValue.Left = 10;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="columnType"></param>
        /// <param name="value"></param>
        public ColumnValue(string columnName, ColumnType columnType, string value)
            : this(columnName, columnType)
        {
            _booleanValue = new CheckBox();
            _booleanValue.CheckedChanged += _booleanValue_CheckChanged;
            _booleanValue.Text = value;

            this.Controls.Add(_booleanValue);

            _booleanValue.Top = 18;
            _booleanValue.Width = this.Width - 20;
            _booleanValue.Left = 10;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// type of column
        /// </summary>
        public ColumnType ColumnType { get; private set; }

        /// <summary>
        /// Name of column
        /// </summary>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Value of column
        /// </summary>
        public object ColValue { get; private set; }

        #endregion Properties

        #region Private Methods

        private void _stringValue_TextChanged(object sender, EventArgs e)
        {
            ColValue = _stringValue.Text;
        }

        private void _numberValue_ValueChanged(object sender, EventArgs e)
        {
            ColValue = _numberValue.Value;
        }

        private void _booleanValue_CheckChanged(object sender, EventArgs e)
        {
            ColValue = _booleanValue.Checked;
        }

        #endregion Private Methods
    }
}
