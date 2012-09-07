using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuilderCode.AppServices.Core;
using WeifenLuo.WinFormsUI.Docking;
using BuilderCode.Command;

namespace BuilderCode.Explorer
{
    public partial class ExplorerForm : IBuilderCodeDockContent
    {
        public ExplorerForm()
        {
            InitializeComponent();
            new DataServerXmlParser().LoadXML();
            CommandBase command = CommandManager.GetCommand(CommandFamily.Command_RefreshTreeNode);
            command.Execute(null, null);
            CoreData.CoreDataContent[CoreDataTypes.HasServer] = true;
            CoreData.CoreDataContent.PropertyChanged += new PropertyChangedEventHandler(CoreDataContent_PropertyChanged);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetCurrentTreeViewNode();
        }

        void CoreDataContent_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CoreDataTypes.CurrentSelectedDatabase.ToString())
            {
                SetCurrentTreeViewNode();
            }
        }

        private void SetCurrentTreeViewNode()
        {
            TreeNode Node = CoreData.CoreDataContent[CoreDataTypes.CurrentSelectedDatabase] as TreeNode;
            if (Node != null)
            {
                if (databaseTreeView1.Nodes.Count == 0 || databaseTreeView1.Nodes[0] != Node)
                {
 
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            databaseTreeView1.Nodes.Clear();
            base.OnClosing(e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SelectDatabaseForm form = new SelectDatabaseForm();
            form.ShowDialog();
        }
    }
}
