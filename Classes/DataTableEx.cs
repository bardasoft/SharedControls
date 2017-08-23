/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Unknown
 *
 *  Copyright (c) 2014 unknown
 *
 *  Purpose:  Cache Item, used in conjunction with CacheManager
 *
 */
using System.Data;

namespace SharedControls.Classes
{
    /// <summary>
    /// Extra methods for DataTable
    /// </summary>
    public static class DataTableEx
    {
        private static DataRow currentRow = null;

        /// <summary>
        /// Returns the first row in a Table
        /// </summary>
        /// <param name="table">Table operation being performed on</param>
        /// <returns>First DataRow if a row exists, otherwise false</returns>
        public static DataRow First(this System.Data.DataTable table)
        {
            currentRow = table.Rows[0];

            return (currentRow);
        }

        /// <summary>
        /// Returns the next row in the Table
        /// </summary>
        /// <param name="table">Table operation being performed on</param>
        /// <returns>DataRow if found, otherwise null</returns>
        public static DataRow Next(this System.Data.DataTable table)
        {
            if (currentRow == null)
                return (First(table));

            int index = table.Rows.IndexOf(currentRow);

            if (index == table.Rows.Count - 1)
                return (currentRow);

            currentRow = table.Rows[index + 1];
            return (currentRow);
        }

        /// <summary>
        /// Returns the previous row in the Table
        /// </summary>
        /// <param name="table">Table operation being performed on</param>
        /// <returns>DataRow if found, otherwise false</returns>
        public static DataRow Previous(this System.Data.DataTable table)
        {
            if (currentRow == null)
                return (First(table));

            int index = table.Rows.IndexOf(currentRow);

            if (index == 0)
                return (currentRow);

            currentRow = table.Rows[index - 1];
            return (currentRow);
        }

        /// <summary>
        /// Determines wether the Table is on the last row
        /// </summary>
        /// <param name="table">Table operation being performed on</param>
        /// <returns>true if last row, otherwise false</returns>
        public static bool LastRow(this System.Data.DataTable table)
        {
            if (currentRow == null)
                return (false);

            int index = table.Rows.IndexOf(currentRow);

            return (index == table.Rows.Count - 1);
        }
    }
}
