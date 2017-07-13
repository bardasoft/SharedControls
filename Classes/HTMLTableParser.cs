/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2013 Simon Carter
 *
 *  Purpose:  Parse html finding table information
 *
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedControls.Classes
{
    /// <summary>
    /// Parse text for html tables
    /// </summary>
    public class HTMLTableParser
    {
        #region Private Members

        private string _textToParse;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textToParse">Text to parse</param>
        public HTMLTableParser(string textToParse)
        {
            _textToParse = textToParse;
        }

        #endregion Constructros

        #region Properties

        /// <summary>
        /// Converts <th> </th> to <td> </td>
        /// </summary>
        public bool ConvertCellHeaderToNormalCell { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Start's the parsing of the text
        /// </summary>
        public void Execute()
        {

            int posTableStart = 0;

            while (posTableStart < _textToParse.Length)
            {
                posTableStart = _textToParse.IndexOf("<table", posTableStart, StringComparison.OrdinalIgnoreCase);

                if (posTableStart == -1)
                    break;

                int posTableEnd = _textToParse.IndexOf("/table>", posTableStart + 1, StringComparison.OrdinalIgnoreCase);
                string table = _textToParse.Substring(posTableStart + 7, (posTableEnd -8) - posTableStart).Trim();

                ParseTable(table);

                posTableStart = posTableEnd;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ParseTable(string tableData)
        {
            RaiseTableStart();
            try
            {
                if (tableData.Contains("<tr>"))
                {
                    if (ConvertCellHeaderToNormalCell)
                    {
                        tableData = tableData.Replace("<th", "<td").Replace("/th>", "/td>");
                    }

                    int posRowStart = 0;

                    while (posRowStart < tableData.Length)
                    {
                        posRowStart = tableData.IndexOf("<tr", posRowStart, StringComparison.OrdinalIgnoreCase);

                        if (posRowStart == -1)
                            break;

                        //posRowStart = tableData.IndexOf("<tr", posRowStart, StringComparison.OrdinalIgnoreCase);
                        int posRowEnd = tableData.IndexOf("/tr>", posRowStart + 1, StringComparison.OrdinalIgnoreCase);
                        string rowData = tableData.Substring(posRowStart + 4, (posRowEnd - 5) - posRowStart).Trim();

                        posRowStart = posRowEnd;
                        ParseRow(rowData);
                    }
                }
            }
            finally
            {
                RaiseTableEnd();
            }
        }

        private void ParseRow(string rowData)
        {
            RaiseRowStart();
            try
            {
                if (rowData.Contains("<td"))
                {
                    int posCellStart = 0;
                    List<string> cells = new List<string>();
                    try
                    {
                        while (posCellStart < rowData.Length)
                        {
                            posCellStart = rowData.IndexOf("<td", posCellStart, StringComparison.OrdinalIgnoreCase);

                            if (posCellStart == -1)
                                break;

                            int posCellEnd = rowData.IndexOf("/td>", posCellStart + 1, StringComparison.OrdinalIgnoreCase);
                            string cellData = rowData.Substring(posCellStart + 4, (posCellEnd - 5) - posCellStart).Trim();

                            posCellStart = posCellEnd;
                            cells.Add(cellData);
                        }
                    }
                    finally
                    {
                        RaiseRowFound(cells);
                        cells = null;
                    }
                }
            }
            finally
            {
                RaiseRowEnd();
            }
        }

        #endregion Private Methods

        #region Event Wrappers

        /// <summary>
        /// raises table start event
        /// </summary>
        private void RaiseTableStart()
        {
            if (TableStart != null)
                TableStart(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises table end event
        /// </summary>
        private void RaiseTableEnd()
        {
            if (TableEnd != null)
                TableEnd(this, EventArgs.Empty);
        }

        /// <summary>
        /// raises Row start event
        /// </summary>
        private void RaiseRowStart()
        {
            if (RowStart != null)
                RowStart(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises row end event
        /// </summary>
        private void RaiseRowEnd()
        {
            if (RowEnd != null)
                RowEnd(this, EventArgs.Empty);
        }

        private void RaiseRowFound(List<string> cellValues)
        {
            if (RowFound != null)
                RowFound(this, new RowFoundArgs(cellValues));
        }

        #endregion Event Wrappers

        #region Events

        /// <summary>
        /// Table found and parsing of table will begin
        /// </summary>
        public event EventHandler TableStart;

        /// <summary>
        /// End of table reached
        /// </summary>
        public event EventHandler TableEnd;

        /// <summary>
        /// Start of row parsing
        /// </summary>
        public event EventHandler RowStart;

        /// <summary>
        /// End of row parsing
        /// </summary>
        public event EventHandler RowEnd;

        /// <summary>
        /// Row Found Args
        /// </summary>
        public event RowFoundEventHandler RowFound;

        #endregion Events

    }

    /// <summary>
    /// Event arguments for when row found
    /// </summary>
    public sealed class RowFoundArgs : EventArgs
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cellValues">List of cell values</param>
        public RowFoundArgs(List<string> cellValues)
        {
            CellValues = cellValues;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Cell Values for Row
        /// </summary>
        public List<string> CellValues { private set; get; }

        #endregion Properties
    }

    /// <summary>
    /// Row found event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void RowFoundEventHandler(object sender, RowFoundArgs e);
}
