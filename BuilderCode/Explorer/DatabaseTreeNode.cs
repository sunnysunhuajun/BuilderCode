using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

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

        public void SetRoot(BindingList<TreeNode> Data)
        {
            this.Tag = Data;
        }
    }
}
