/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2016 Simon Carter
 *
 *  Purpose:  Toast notification component
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SharedControls.Interfaces;
using Shared;

namespace SharedControls
{
    /// <summary>
    /// Toast Notification
    /// </summary>
    public sealed partial class ToastNotification : Component, INotifyAction
    {
        #region Constants

        private const string DEFAULT_FONT_SANS_SERIF = "Microsoft Sans Serif, 8.25pt";

        #endregion Constants

        #region Private Members


        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ToastNotification()
        {
            InitializeComponent();
            BackColor = Color.Black;
            TextColor = Color.White;
            NotifyEffect = NotificationEffect.Slide;
            NotifyPosition = NotificationPosition.BottomRight;
            FadeOut = true;
            Font = new Font(FontFamily.GenericSansSerif, 8.25f);
            OpacitySpeed = 0.2;
            AutomaticallyClose = 30;
            ClickToClose = true;
            ClickForInformation = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container"></param>
        public ToastNotification(IContainer container)
            : this()
        {
            container.Add(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Position of notification window
        /// </summary>
        [Description("Location of Toast Notification")]
        [Category("Location")]
        [DefaultValue(NotificationPosition.BottomRight)]
        public NotificationPosition NotifyPosition { get; set; }

        /// <summary>
        /// Type of notification
        /// </summary>
        [Description("Notification effect")]
        [Category("Effect")]
        [DefaultValue(NotificationEffect.Slide)]
        public NotificationEffect NotifyEffect { get; set; }

        /// <summary>
        /// Font used for message
        /// </summary>
        [Description("Notification Effect")]
        [Category("Appearance")]
        [DefaultValue(typeof(Font), DEFAULT_FONT_SANS_SERIF)]
        public Font Font { get; set; }

        /// <summary>
        /// Indicates the form will fade out
        /// </summary>
        [Description("Determines wether the toast notification fades out or not.")]
        [Category("Effect")]
        [DefaultValue(true)]
        public bool FadeOut { get; set; }

        /// <summary>
        /// if true, clicking anywhere on the notification will close it
        /// </summary>
        [Description("Determines wether the toast notification will close when clicked")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool ClickToClose { get; set; }

        /// <summary>
        /// if true, clicking anywhere on the notification will close it
        /// </summary>
        [Description("Determines wether the toast notification shows a click for information item")]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool ClickForInformation { get; set; }

        /// <summary>
        /// Back color of notification window
        /// </summary>
        [Description("Back Colour of toast notification window")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BackColor { get; set; }

        /// <summary>
        /// Color of the text
        /// </summary>
        [Description("Text Colour of toast notification text")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        public Color TextColor { get; set; }

        /// <summary>
        /// speed of opacity 
        /// </summary>
        [Description("Speed at which the toast notification dissapears.")]
        [Category("Effect")]
        [DefaultValue(0.2)]
        public double OpacitySpeed { get; set; }

        /// <summary>
        /// Number of seconds after which the form is automatically closed
        /// 
        /// 0 = does not auto close
        /// </summary>
        [Description("Number of seconds after which the form is automatically closed. 0 (zero) does not automatically close.")]
        [Category("Effect")]
        [DefaultValue(30)]
        public int AutomaticallyClose { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Show's a toast notification
        /// </summary>
        /// <param name="message"></param>
        public string Show(string message)
        {
            return (Show(message, String.Empty));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string Show(string message, string title)
        {
            return (Show(message, title, Guid.NewGuid().ToString()));
        }

        /// <summary>
        /// Show's a toast notification
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="uniqueID"></param>
        public string Show(string message, string title, string uniqueID)
        {
            SharedControls.Forms.Notification notify = new SharedControls.Forms.Notification(this, title, message);
            notify.BackColor = this.BackColor;
            notify.TextColor = this.TextColor;
            notify.ClickToClose = this.ClickToClose;
            notify.ClickForInformation = this.ClickForInformation;
            notify.OpacitySpeed = this.OpacitySpeed;
            notify.FadeOut = this.FadeOut;
            notify.AutomaticallyClose = this.AutomaticallyClose;
            Random rnd = new Random(DateTime.Now.Second);

            notify.NotifyPosition = this.NotifyPosition;

            notify.NotifyEffect = this.NotifyEffect;
            notify.UniqueID = uniqueID;
            notify.Show();
            return (notify.UniqueID);
        }

        #endregion Public Methods

        #region Events

        /// <summary>
        /// Toast item has been clicked
        /// </summary>
        [Description("Toast notification has been clicked")]
        [Category("Action")]
        public event ToastNotificationHandler OnClicked;

        /// <summary>
        /// Toast notification has timed out and will be closed
        /// </summary>
        [Description("Toast notification has timed out")]
        [Category("Action")]
        public event ToastNotificationHandler OnTimeOut;

        /// <summary>
        /// Toast Item has been Cancelled
        /// </summary>
        [Description("Toast notification has been cancelled")]
        [Category("Action")]
        public event ToastNotificationHandler OnCancelled;

        /// <summary>
        /// Toast Item has received Focus
        /// </summary>
        [Description("Toast notification has received focus")]
        [Category("Action")]
        public event ToastNotificationHandler OnFocus;

        #endregion Events

        #region Toast Notification Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotifyClicked(object sender, EventArgs e)
        {
            ((SharedControls.Forms.Notification)sender).Close();

            if (OnClicked != null)
                OnClicked(this, new ToastNotificationArgs(((SharedControls.Forms.Notification)sender).UniqueID, ToastEventType.Clicked));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotifyCancelled(object sender, EventArgs e)
        {
            if (OnCancelled != null)
                OnCancelled(this, new ToastNotificationArgs(((SharedControls.Forms.Notification)sender).UniqueID, 
                    ToastEventType.Cancelled));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotifyFocus(object sender, EventArgs e)
        {
            if (this.Container != null && this.Container.GetType() == typeof(Form))
            {
                ((Form)this.Container).Focus();
            }

            if (OnFocus != null)
                OnFocus(this, new ToastNotificationArgs(((SharedControls.Forms.Notification)sender).UniqueID, ToastEventType.Focused));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotifyTimeOut(object sender, EventArgs e)
        {
            if (OnTimeOut != null)
                OnTimeOut(this, new ToastNotificationArgs(((SharedControls.Forms.Notification)sender).UniqueID, ToastEventType.Timeout));
        }

        #endregion Toast Notification Events
    }
}
