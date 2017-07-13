/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2016 Simon Carter
 *
 *  Purpose:  Toast notification form
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Shared;
using SharedControls.Interfaces;

namespace SharedControls.Forms
{
    /// <summary>
    /// Popup notification window
    /// </summary>
    public partial class Notification : Form
    {
        #region Constants

        private const int OFFSET_LEFT_RIGHT = 10;
        private const int OFFSET_TOP_BOTTOM = 10;

        private const int FORM_SLIDE_AMOUNT = 25;

        #endregion Constants

        #region Static Members

        private static List<Notification> _currentControls = new List<Notification>();

        #endregion Static Members

        #region Private Members

        /// <summary>
        /// indicates whether the control is loading or not, used
        /// for animation effects
        /// </summary>
        private bool _loading = false;

        private bool _raiseCancel = true;

        private NotificationEffect _notifyEffect;

        private DateTime _loadTime = DateTime.Now;

        private INotifyAction _parent;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        /// <param name="initialWidth"></param>
        /// <param name="initialHeight"></param>
        public Notification(INotifyAction parent, string title, string message, 
            Image icon = null, int initialWidth = 300, int initialHeight = 70)
            : base ()
        {
            if (parent == null)
                throw new NotSupportedException("invalid parent");

            InitializeComponent();
            this.Text = title;
            _currentControls.Add(this);

            if (String.IsNullOrEmpty(title))
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            else
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            OpacitySpeed = 0.2;
            NotifyPosition = NotificationPosition.TopRight;
            NotifyEffect = NotificationEffect.Slide;
            AutomaticallyClose = 10;
            FadeOut = true;

            _parent = parent;

            Size size = Shared.Utilities.MeasureText(message, lblMessage.Font, initialWidth -20);

            if (icon == null)
            {
                this.Width = size.Width < initialWidth ? initialWidth : size.Width + 6;
                this.Height = size.Height < initialHeight ? initialHeight : size.Height + 6;
                lblMessage.Left = 3;
                lblMessage.Width = this.Width - 6;
                lblMessage.Height = this.Height - 6;
                lblClickForInformation.Left = 3;
                pictureBox1.Visible = false;
            }
            else
            {
                lblMessage.Left = 70;
                lblMessage.Width = this.Width - 73;
                pictureBox1.Image = icon;
                lblClickForInformation.Left = 63;
                this.Width = size.Width < initialWidth ? initialWidth : size.Width + 6;
                this.Height = size.Height < initialHeight ? initialHeight : size.Height + 6;
            }

            lblMessage.Height = this.Height - (lblMessage.Top * 2);

            lblMessage.Text = message;
            lblClickForInformation.Text = "Click for Info";
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for form, user defined
        /// </summary>
        public string UniqueID { get; set; }

        /// <summary>
        /// Position of notification window
        /// </summary>
        public NotificationPosition NotifyPosition { get; set; }

        /// <summary>
        /// Type of notification
        /// </summary>
        public NotificationEffect NotifyEffect
        { 
            get
            {
                return (_notifyEffect);
            }

            set
            {
                _notifyEffect = value;

                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            }
        }

        /// <summary>
        /// Font used for message
        /// </summary>
        public override Font Font
        {
            get
            {
                return (base.Font);
            }

            set
            {
                base.Font = value;
                lblMessage.Font = value;
                lblClickForInformation.Font = new Font(base.Font.FontFamily, 8.25f);
            }
        }

        /// <summary>
        /// Indicates the form will fade out
        /// </summary>
        public bool FadeOut { get; set; }

        /// <summary>
        /// if true, clicking anywhere on the notification will close it
        /// </summary>
        public bool ClickToClose { get; set; }

        /// <summary>
        /// if true, a label is shown with "Click for more information"
        /// </summary>
        public bool ClickForInformation 
        { 
            get
            {
                return (lblClickForInformation.Visible);
            }

            set
            {
                lblClickForInformation.Visible = value;
            }
        }

        /// <summary>
        /// Back color of notification window
        /// </summary>
        public override Color BackColor 
        { 
            get
            {
                return (base.BackColor);
            }

            set
            {
                base.BackColor = value;
                lblMessage.BackColor = value;
                lblClickForInformation.BackColor = value;
            }
        }

        /// <summary>
        /// Color of the text
        /// </summary>
        public Color TextColor
        {
            get
            {
                return (lblMessage.ForeColor);
            }

            set
            {
                lblMessage.ForeColor = value;
                lblClickForInformation.ForeColor = value;
            }
        }

        /// <summary>
        /// speed of opacity 
        /// </summary>
        public double OpacitySpeed { get; set; }

        /// <summary>
        /// Number of seconds after which the form is automatically closed
        /// 
        /// 0 = does not auto close
        /// </summary>
        public int AutomaticallyClose { get; set; }

        #endregion Properties

        #region Static Methods

        //public static 
        #endregion Static Methods

        #region Overridden Methods

        /// <summary>
        /// Overridden on load method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UpdateInitialPosition();

            switch (_notifyEffect)
            {
                case NotificationEffect.FadeIn:
                case NotificationEffect.FadeInOut:
                    this.Opacity = 0.0;
                    break;
            }

            _loading = true;
            timer1.Start();
        }

        /// <summary>
        /// overridden on closing method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            timer1.Stop();

            if (FadeOut)
            {
                while (this.Opacity > 0.0)
                {
                    this.Opacity -= OpacitySpeed /2;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
            
            _currentControls.Remove(this);

            base.OnClosing(e);
        }

        private delegate void FormClosedDelegate(FormClosedEventArgs e);

        /// <summary>
        /// overridden on closed method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                FormClosedDelegate fceh = new FormClosedDelegate(OnFormClosed);
                this.Invoke(fceh, new object[] { e });
            }
            else
            {
                int startHeight = 0;

                switch (NotifyPosition)
                {
                    case NotificationPosition.TopLeft:
                    case NotificationPosition.TopRight:
                        startHeight = Screen.PrimaryScreen.WorkingArea.Top + OFFSET_TOP_BOTTOM;
                        break;
                    case NotificationPosition.BottomRight:
                    case NotificationPosition.BottomLeft:
                        startHeight = (Screen.PrimaryScreen.WorkingArea.Bottom - this.Height) - OFFSET_TOP_BOTTOM;
                        break;
                }

                foreach (Notification form in _currentControls)
                {
                    if (form.NotifyPosition == this.NotifyPosition)
                    {
                        switch (form.NotifyPosition)
                        {
                            case NotificationPosition.TopRight:
                            case NotificationPosition.TopLeft:
                                form.Top = startHeight;
                                startHeight += (form.Height + OFFSET_TOP_BOTTOM);
                                break;
                            case NotificationPosition.BottomLeft:
                            case NotificationPosition.BottomRight:
                                form.Top = startHeight;
                                startHeight -= (form.Height + OFFSET_TOP_BOTTOM);
                                break;
                        }
                    }
                }

                base.OnFormClosed(e);

                if (_raiseCancel)
                    _parent.NotifyCancelled(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// overridden on shown method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _parent.NotifyFocus(this, EventArgs.Empty);
        }

        #endregion Overridden Methods

        #region Private Methds

        private int GetAllNotificationsHeight()
        {
            int Result = 10;

            foreach (Notification form in _currentControls)
            {
                if (form != this && form.NotifyPosition == this.NotifyPosition)
                    Result += form.Height + 10;
            }

            return (Result);
        }

        private void UpdateInitialPosition()
        {
            switch (_notifyEffect)
            {
                case NotificationEffect.Slide:
                    switch (NotifyPosition)
                    {
                        case NotificationPosition.TopLeft:
                            this.Left = Screen.PrimaryScreen.WorkingArea.Left - this.Width;
                            this.Top = Screen.PrimaryScreen.WorkingArea.Top + GetAllNotificationsHeight();
                            break;
                        case NotificationPosition.TopRight:
                            this.Top = Screen.PrimaryScreen.WorkingArea.Top + GetAllNotificationsHeight();
                            this.Left = Screen.PrimaryScreen.WorkingArea.Width + this.Width;
                            break;
                        case NotificationPosition.BottomRight:
                            this.Top = (Screen.PrimaryScreen.WorkingArea.Bottom - this.Height) - GetAllNotificationsHeight();
                            this.Left = Screen.PrimaryScreen.WorkingArea.Width + this.Width;
                            break;
                        case NotificationPosition.BottomLeft:
                            this.Top = (Screen.PrimaryScreen.WorkingArea.Bottom - this.Height) - GetAllNotificationsHeight();
                            this.Left = Screen.PrimaryScreen.WorkingArea.Left - this.Width;;
                            break;
                    }

                    break;
                default:
                    switch (NotifyPosition)
                    {
                        case NotificationPosition.TopLeft:
                            this.Left = Screen.PrimaryScreen.WorkingArea.Left;
                            this.Top = Screen.PrimaryScreen.WorkingArea.Top + GetAllNotificationsHeight();
                            break;
                        case NotificationPosition.TopRight:
                            this.Top = Screen.PrimaryScreen.WorkingArea.Top + GetAllNotificationsHeight();
                            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                            break;
                        case NotificationPosition.BottomRight:
                            this.Top = (Screen.PrimaryScreen.WorkingArea.Bottom - this.Height) - GetAllNotificationsHeight();
                            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                            break;
                        case NotificationPosition.BottomLeft:
                            this.Top = (Screen.PrimaryScreen.WorkingArea.Bottom - this.Height) - GetAllNotificationsHeight();
                            this.Left = 0;
                            break;
                    }

                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_loading)
            {
                switch (_notifyEffect)
                {
                    case NotificationEffect.FadeIn:
                    case NotificationEffect.FadeInOut:
                        if (this.Opacity < 1.0)
                            this.Opacity += OpacitySpeed;
                        else
                            _loading = false;
                        break;
                    case NotificationEffect.Slide:
                        UpdatePosition();
                        break;
                }
            }

            TimeSpan span = DateTime.Now - _loadTime;

            if (AutomaticallyClose > 0 &&
                span.TotalSeconds > AutomaticallyClose)
            {
                _raiseCancel = false;
                Close();
                timer1.Stop();
                _parent.NotifyTimeOut(this, EventArgs.Empty);
            }
        }

        private void UpdatePosition()
        {
            int newLeft;
            if (_notifyEffect == NotificationEffect.Slide)
            {
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                switch (NotifyPosition)
                {
                    case NotificationPosition.TopRight:
                    case NotificationPosition.BottomRight:
                        newLeft = this.Left - FORM_SLIDE_AMOUNT;
                        if (newLeft < (screenWidth - this.Width))
                        {
                            newLeft = (screenWidth - OFFSET_LEFT_RIGHT) - this.Width;
                            _loading = false;
                        }

                        this.Left = newLeft;
                        break;
                    case NotificationPosition.BottomLeft:
                    case NotificationPosition.TopLeft:
                        newLeft = this.Left + FORM_SLIDE_AMOUNT;
                        if (newLeft > 0)
                        {
                            newLeft = OFFSET_LEFT_RIGHT;
                            _loading = false;
                        }

                        this.Left = newLeft;
                        break;
                }
            }
        }

        private void Notification_Click(object sender, EventArgs e)
        {
            _raiseCancel = false;

           if (ClickToClose)
            {
                Close();
            }

           _parent.NotifyClicked(this, EventArgs.Empty);
        }

        private void Notification_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (_notifyEffect)
            {
                case NotificationEffect.FadeInOut:
                case NotificationEffect.FadeOut:
                    while (this.Opacity > 0.0)
                    {
                        this.Opacity -= OpacitySpeed;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(timer1.Interval);
                        Application.DoEvents();
                    }

                    break;
            }
        }

        #endregion Private Methods
    }
}
