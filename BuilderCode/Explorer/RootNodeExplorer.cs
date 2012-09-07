using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuilderCode.Properties;
using BuilderCode.AppServices.Core;
using System.Threading;

namespace BuilderCode.Explorer
{
    public delegate TreeNode GetTreeNodeEventHandler();

    public class RootNodeExplorer
    {
        //#region Instance
        TreeNode rootNode;

        public void CreateSubNodes(TreeNode Node)
        {
            if (Node == null)
                return;
            this.rootNode = Node;
            this.rootNode.ImageKey = "Data Servers";
            this.rootNode.SelectedImageKey = "Data Servers";
            this.rootNode.Nodes.Clear();

            TreeNode TablesNode = new TreeNode(Resources.Tables);
            TreeNode ViewsNode = new TreeNode(Resources.Views);
            TreeNode SPNode = new TreeNode(Resources.SP);
            TreeNode FunctionNode = new TreeNode(Resources.Function);

            TablesNode.Name = DatabaseAttributeEumn.Tables.ToString();
            TablesNode.SelectedImageKey = TablesNode.ImageKey = DatabaseAttributeEumn.Tables.ToString();
            ViewsNode.Name = DatabaseAttributeEumn.Views.ToString();
            ViewsNode.SelectedImageKey = ViewsNode.ImageKey = DatabaseAttributeEumn.Views.ToString();
            SPNode.Name = DatabaseAttributeEumn.Tables.ToString();
            SPNode.SelectedImageKey = SPNode.ImageKey = DatabaseAttributeEumn.SP.ToString();
            FunctionNode.Name = DatabaseAttributeEumn.Tables.ToString();
            FunctionNode.SelectedImageKey = FunctionNode.ImageKey = DatabaseAttributeEumn.Function.ToString();


            if (rootNode.TreeView != null)
            {
                this.rootNode.TreeView.BeginInvoke(new ThreadStart(delegate()
                    {
                        rootNode.Nodes.AddRange(new TreeNode[]{
                        TablesNode,
                        ViewsNode,
                        SPNode,
                        FunctionNode
                        });
                    }));
            }
            else
            {
                rootNode.Nodes.AddRange(new TreeNode[] {
                    TablesNode,
                    ViewsNode,
                    SPNode,
                    FunctionNode
                });
            }
        }

        static RootNodeExplorer explorer;

        static RootNodeExplorer()
        {
            explorer = new RootNodeExplorer();
        }

        static void BuildSubNodes(TreeNode node)
        {
            explorer.CreateSubNodes(node);
        }

        public static TreeNode GetDataNode()
        {
            DatabaseTreeNode<SQLServer> servers = ((Dictionary<string, TreeNode>)CoreData.CoreDataContent[CoreDataTypes.AllDatabaseTreeNode])["All"] as DatabaseTreeNode<SQLServer>;
            if (servers == null)
                servers = new DatabaseTreeNode<SQLServer>();
            BuildSubNodes(servers);
            servers.Name = "All";
            servers.Tag = "all";
            return servers;
        }
    }
}