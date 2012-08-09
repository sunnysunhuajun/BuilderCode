using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuilderCode.Explorer
{
    public class NodeSorter:IComparer<TreeNode>
    {
        private SortOrder order;

        public NodeSorter(SortOrder theOrder)
        {
            order = theOrder;
        }

        public int Compare(TreeNode x, TreeNode y)
        {
            int result = string.Compare(x.Text, y.Text);
            if (order == SortOrder.Ascending)
                return -result;
            else
                return +result;
        }
    }
}
