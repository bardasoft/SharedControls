/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2014 unknown
 *
 *  Purpose:  Control extender to suspend/prevent drawing
 *
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace SharedControls.Classes
{
    /// <summary>
    /// Control Extender
    /// 
    /// Overrides all controls, providing a method to suspend/resume drawing to prevent flickering
    /// </summary>
    public static class ControlExtender
    {
        /// <summary>
        /// SendMessage method from Windows API
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);
        private const int WM_SETREDRAW = 11;

        internal static IntPtr SendMessage(this Control control, int msg, int wparam, int lparam)
        {
            return SendMessage(new HandleRef(control, control.Handle), msg, wparam, lparam);
        }

        /// <summary>
        /// Suspends drawing of the control to prevent flickering
        /// </summary>
        /// <param name="control">current control</param>
        public static void SuspendDrawing(this Control control)
        {
            SendMessage(new HandleRef(control, control.Handle), WM_SETREDRAW, 0, 0);
        }

        /// <summary>
        /// Resumes drawing of the control
        /// </summary>
        /// <param name="control">current control</param>
        public static void ResumeDrawing(this Control control)
        {
            SendMessage(new HandleRef(control, control.Handle), WM_SETREDRAW, 1, 0);
            control.Refresh();
        }
    }
}
