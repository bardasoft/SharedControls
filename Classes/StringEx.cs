/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2014 Simon Carter
 *
 *  Purpose:  String extender to obtain word/line/paragraph/sentence counts
 *
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace SharedControls
{
    /// <summary>
    /// Extends the string class adding methods to retrieve 
    ///   ~ Line Count
    ///   ~ Word Count
    ///   ~ Paragraph Count
    ///   ~ Sentence Count
    /// </summary>
    public static class StringExtender
    {
        #region Extension Methods

        /// <summary>
        /// Returns the number of lines
        /// </summary>
        /// <param name="value">Current Control</param>
        /// <param name="lineFeed">Current line feed being used</param>
        /// <returns></returns>
        public static int LineCount(this string value, string lineFeed = "\r\n")
        {
            MatchCollection collection = Regex.Matches(value.Trim(), String.Format(@"[{0}]+", lineFeed));

            int Result = collection.Count;

            return (Shared.Utilities.CheckMinMax(Result, String.IsNullOrEmpty(value) ? 1 : Result + 1, int.MaxValue));
        }

        /// <summary>
        /// Retrieves the number of words
        /// </summary>
        /// <param name="value">Current control</param>
        /// <returns>int, number of words in the textbox</returns>
        public static int WordCount(this string value)
        {
            MatchCollection collection = Regex.Matches(value, @"[\S]+");

            int Result = collection.Count;

            return (Shared.Utilities.CheckMinMax(Result, value.Length > 0 ? 1 : 0, int.MaxValue));
        }

        /// <summary>
        /// Retrieves the paragraphs
        /// </summary>
        /// <param name="value">Current Control</param>
        /// <returns>int, number of words in the textbox</returns>
        public static int ParagraphCount(this string value)
        {
            MatchCollection collection = Regex.Matches(value, @"[\r\n]+");

            int Result = collection.Count;

            return (Shared.Utilities.CheckMinMax(Result, value.Length > 0 ? 1 : 0, int.MaxValue));
        }

        /// <summary>
        /// Retrieves the number sentences
        /// </summary>
        /// <param name="value"></param>
        /// <returns>int, number of words in the textbox</returns>
        public static int SentenceCount(this string value)
        {
            MatchCollection collection = Regex.Matches(value, @"[.]+");
            MatchCollection semiColon = Regex.Matches(value, @"[;]+");

            int Result = collection.Count + semiColon.Count;

            return (Shared.Utilities.CheckMinMax(Result, value.Length > 0 ? 1 : 0, int.MaxValue));
        }

        #endregion Extension Methods

    }
}
