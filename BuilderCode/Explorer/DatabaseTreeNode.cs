using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using BuilderCode.AppServices.Core;
using System.Threading;

namespace BuilderCode.Explorer
{
    public class DatabaseTreeNode<T>:TreeNode
    {
        private TreeNode selectNode = null;
        static NodeSorter ascendingSorter = new NodeSorter(SortOrder.Ascending);
        static NodeSorter descendingSorter = new NodeSorter(SortOrder.Descending);

        public TreeNode SelectNode
        {
            get { return selectNode;}
            set { selectNode = value; }
        }

        public void AddDataServer(DatabaseAttributeEumn nodetype,string message,BindingList<T> data)
        {
            TreeNode node=this.Nodes[nodetype.ToString()];
            TreeView treeview = node.TreeView;
            if (treeview.Nodes != null && treeview.InvokeRequired)
            {
                treeview.BeginInvoke(new ThreadStart(delegate() { AddDataServer(nodetype, message, data); }),null);
                return;
            }
            if (!node.Nodes.ContainsKey(message))
            {
 
            }
        }

        public void SetRoot(BindingList<TreeNode> Data)
        {
            this.Tag = Data;
        }

    }
}
