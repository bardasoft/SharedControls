/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2014 Simon Carter
 *
 *  Purpose:  Extended text box functions to get word/sentence and paragraph count
 *
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharedControls
{
    /// <summary>
    /// TextBox extender class, provides static methods that can be used on all TextBox controls
    /// </summary>
    public static class TextBoxExtender
    {
        #region Extension Methods

        /// <summary>
        /// Retrieves the number of words
        /// </summary>
        /// <param name="control"></param>
        /// <returns>int, number of words in the textbox</returns>
        public static int WordCount(this TextBox control)
        {
            MatchCollection collection = Regex.Matches(control.Text, @"[\S]+");

            int Result = collection.Count;

            return (Shared.Utilities.CheckMinMax(Result, control.Text.Length > 0 ? 1 : 0, int.MaxValue));
        }

        /// <summary>
        /// Retrieves the paragraphs
        /// </summary>
        /// <param name="control"></param>
        /// <returns>int, number of words in the textbox</returns>
        public static int ParagraphCount(this TextBox control)
        {
            MatchCollection collection = Regex.Matches(control.Text, @"[\r\n]+");

            int Result = collection.Count;

            return (Shared.Utilities.CheckMinMax(Result, control.Text.Length > 0 ? 1 : 0, int.MaxValue));
        }

        /// <summary>
        /// Retrieves the number sentences
        /// </summary>
        /// <param name="control"></param>
        /// <returns>int, number of words in the textbox</returns>
        public static int SentenceCount(this TextBox control)
        {
            MatchCollection collection = Regex.Matches(control.Text, @"[.]+");
            MatchCollection semiColon = Regex.Matches(control.Text, @"[;]+");

            int Result = collection.Count + semiColon.Count;

            return (Shared.Utilities.CheckMinMax(Result, control.Text.Length > 0 ? 1 : 0, int.MaxValue));
        }

        #endregion Extension Methods
    }
}
