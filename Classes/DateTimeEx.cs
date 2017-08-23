/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Unknown
 *
 *  Copyright (c) 2011 dtb
 *
 *  Purpose:  Extends datetime class
 *
 */
using System;

namespace SharedControls.Classes
{
    /// <summary>
    /// DateTime extender
    /// </summary>
    public static class DateTimeExtender
    {
        /// <summary>
        /// Rounds up time to nearest xx minutes
        /// 
        /// Originally found at 
        /// 
        /// https://stackoverflow.com/questions/7029353/how-can-i-round-up-the-time-to-the-nearest-x-minutes
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime RoundUp(this DateTime dt, TimeSpan d)
        {
            return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
        }
    }
}
