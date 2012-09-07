using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BuilderCode.BaseControl;
using System.Windows.Forms;
using BuilderCode.AppServices.Core;

namespace BuilderCode.Explorer
{
    internal delegate void DatabaseSubTreeSelectionChangeEventHandler(DataCollection collection);
    
    public partial class DatabaseTreeView : TreeView
    {
        public DatabaseTreeView()
        {
            InitializeComponent();
        }

        public DatabaseTreeView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
            TreeNode node = e.Node;
            if (node == null)
                return;
            DataCollection database = node.Tag as DataCollection;
            CoreData.CoreDataContent[CoreDataTypes.CurrentSelectedDatabase] = database;
        }
    }
}
