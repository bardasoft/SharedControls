/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2013 Simon Carter
 *
 *  Purpose:  Extended textbox control
 *
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;

#pragma warning disable IDE0017 // initialization can be simplified

namespace SharedControls
{
    /// <summary>
    /// TextBox Ex - Textbox with extra methods / events 
    /// </summary>
    public class TextBoxEx : TextBox
    {
        #region Private Members

        private bool _pasteDetected = false;
        private bool _copyDetected = false;
        private bool _cutDetected = false;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor - Initialises new instance
        /// </summary>
        public TextBoxEx()
            : base()
        {
            AllowBackSpace = true;
            AllowCopy = true;
            AllowCut = true;
            AllowPaste = true;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates wether to raise a Paste event in response to windows paste from clipboard
        /// </summary>
        [Description("Indicates wether to raise a Paste event in response to windows paste from clipboard")]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool RaiseCustomPasteEvent { get; set; }

        /// <summary>
        /// List of allowed characters within the list box
        /// </summary>
        [Description("List of allowed characters within the list box")]
        [Category("Behavior")]
        [DefaultValue("")]
        public string AllowedCharacters { get; set; }

        /// <summary>
        /// Allow back space
        /// </summary>
        [Description("Allow back space")]
        [Category("Behavior")]
        [DefaultValue("true")]
        public bool AllowBackSpace { get; set; }

        /// <summary>
        /// Allow copy command
        /// </summary>
        [Description("Allow Copy")]
        [Category("Behavior")]
        [DefaultValue("true")]
        public bool AllowCopy { get; set; }

        /// <summary>
        /// Allow paste command
        /// </summary>
        [Description("Allow Paste")]
        [Category("Behavior")]
        [DefaultValue("true")]
        public bool AllowPaste { get; set; }

        /// <summary>
        /// Allow Cut command
        /// </summary>
        [Description("Allow Cut")]
        [Category("Behavior")]
        [DefaultValue("true")]
        public bool AllowCut { get; set; }

        #endregion Properties

        #region Delegates

        
        #endregion Delegates

        #region Events

        /// <summary>
        /// Custom event handler for copy/paste
        /// </summary>
        [Description("Custom Event Handler for Copy/Paste")]
        [Category("CopyPaste")]
        public event CustomPasteEventHandler OnPaste;

        #endregion Events

        #region Overridden Methods

        /// <summary>
        /// Overridden OnKeyPress method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (AllowPaste && RaiseCustomPasteEvent && _pasteDetected && OnPaste != null)
            {
                PasteEventArgs args = new PasteEventArgs();
                args.Text = Clipboard.GetText();

                OnPaste(this, args);

                SelectedText = args.Text;
                e.Handled = true;
            }
            else if ((AllowCut && _cutDetected) || (AllowCopy && _copyDetected))
            {
                e.Handled = false;
            }
            else if (AcceptsReturn && e.KeyChar == '\r')
            {
                e.Handled = false;
            }
            else
            {
                if (!String.IsNullOrEmpty(AllowedCharacters))
                {
                    e.Handled = !AllowedCharacters.Contains(e.KeyChar.ToString());

                    if (e.Handled && e.KeyChar == '\b' && AllowBackSpace)
                        e.Handled = !e.Handled;
                }
                else
                    base.OnKeyPress(e);
            }

            if (_pasteDetected)
                _pasteDetected = false;
        }

        /// <summary>
        /// Overridden OnPreviewKeyDown method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                //paste
                _pasteDetected = true;
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                //paste
                _cutDetected = true;
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                //paste
                _copyDetected = true;
            }
            
            base.OnPreviewKeyDown(e);
        }

        #endregion Overridden Methods
    }

    /// <summary>
    /// Event arguments for custom paste event
    /// </summary>
    public class PasteEventArgs
    {
        /// <summary>
        /// Text to be pasted
        /// </summary>
        public string Text { get; set; }
    }

    /// <summary>
    /// Custom Paste Event Handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">Paste Event Arguments</param>
    public delegate void CustomPasteEventHandler(object sender, PasteEventArgs e);
}
