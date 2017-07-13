/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2016 Simon Carter
 *
 *  Purpose:  SMS Send interface
 *
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedControls.Interfaces
{
    /// <summary>
    /// Interface for sending SMS messages
    /// </summary>
    public interface ISMSSend
    {
        /// <summary>
        /// Request an SMS be sent
        /// </summary>
        /// <param name="from"></param>
        /// <param name="telephone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool SendSMS(string from, string telephone, string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="telephone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool SendSMS(string telephone, string message);
    }
}
