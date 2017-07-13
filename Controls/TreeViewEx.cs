/*
 *  The contents of this file are subject to MIT Licence.  Please
 *  view License.txt for further details. 
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2014 Simon Carter
 *
 *  Purpose:  Extended TreeView component
 *
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SharedControls.Controls
{
    /// <summary>
    /// TreeViewEx - Extension to treeview which adds the RightClickSelect property/event as well as other properties/methods
    /// </summary>
    public class TreeViewEx : TreeView
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public TreeViewEx()
            : base()
        {
            RightClickSelect = true;
            AllowNoNodeSelected = true;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates that right click on the treeview will select the node
        /// </summary>
        public bool RightClickSelect { get; set; }

        /// <summary>
        /// If true, the active node can be deselected, if false, there will always be a node selected
        /// </summary>
        public bool AllowNoNodeSelected { get; set; }

        /// <summary>
        /// Makes the selected node bold if set to true
        /// </summary>
        public bool SelectedNodeBold { get; set; }

        /// <summary>
        /// Currently selected Node
        /// </summary>
        public new TreeNode SelectedNode
        {
            get
            {
                return (base.SelectedNode);
            }

            set
            {
                if (SelectedNodeBold && base.SelectedNode != null)
                {
                    base.SelectedNode.NodeFont = new Font(this.Font, FontStyle.Regular);
                }

                if (!AllowNoNodeSelected && value == null)
                {
                    // do nothing, keep the node selected
                }
                else
                    base.SelectedNode = value;

                if (SelectedNodeBold && base.SelectedNode != null)
                {
                    base.SelectedNode.NodeFont = new Font(this.Font, FontStyle.Bold);
                    base.SelectedNode.Text = base.SelectedNode.Text;
                }
            }
        }

        #endregion Properties

        #region Overridden Methods

        
        /// <summary>
        /// Overridde OnMouseDown method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (RightClickSelect)
            {
                this.SelectedNode = GetNodeAt(e.X, e.Y);
            }

            if (!AllowNoNodeSelected)
            {

            }
        }

        #endregion Overridden Methods
    }
}
