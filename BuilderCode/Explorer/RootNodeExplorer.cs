using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuilderCode.Properties;
using BuilderCode.AppServices.Core;

namespace BuilderCode.Explorer
{
    public delegate TreeNode GetTreeNodeEventHandler(); 

    public class RootNodeExplorer
    {
        #region Instance
        TreeNode rootNode;

        public void CreateSubNodes(TreeNode Node)
        {
            if (Node == null)
                return;
            this.rootNode = Node;
            this.rootNode.Nodes.Clear();

            TreeNode TablesNode = new TreeNode(Resources.Tables);
            TreeNode ViewsNode = new TreeNode(Resources.Views);
            TreeNode SPNode = new TreeNode(Resources.SP);
            TreeNode FunctionNode = new TreeNode(Resources.Function);

            TablesNode.Name = DatabaseType.Tables.ToString();
            TablesNode.SelectedImageKey = TablesNode.ImageKey = DatabaseType.Tables.ToString();
            ViewsNode.Name = DatabaseType.Views.ToString();
            ViewsNode.SelectedImageKey = ViewsNode.ImageKey = DatabaseType.Views.ToString();
            SPNode.Name = DatabaseType.Tables.ToString();
            SPNode.SelectedImageKey = SPNode.ImageKey = DatabaseType.SP.ToString();
            FunctionNode.Name = DatabaseType.Tables.ToString();
            FunctionNode.SelectedImageKey = FunctionNode.ImageKey = DatabaseType.Function.ToString();
               
        }
    }
}
