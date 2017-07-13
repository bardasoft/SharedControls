/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2016 Simon Carter
 *
 *  Purpose:  Interface for toast notifications
 *
 */
using System;
using System.Collections.Generic;
using System.Text;

using SharedControls.Forms;

namespace SharedControls.Interfaces
{
    /// <summary>
    /// Interface for Notification control
    /// </summary>
    public interface INotifyAction
    {
        /// <summary>
        /// Method called when the notify control is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NotifyClicked(object sender, EventArgs e);

        /// <summary>
        /// Method called when the notify control is cancelled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NotifyCancelled(object sender, EventArgs e);

        /// <summary>
        /// Method called when the notify control receives focus, allowing application to get focus back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NotifyFocus(object sender, EventArgs e);

        /// <summary>
        /// Method called when the notify control is times out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NotifyTimeOut(object sender, EventArgs e);
    }
}
