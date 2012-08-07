using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BuilderCode.BaseControl;
using System.Windows.Forms;

namespace BuilderCode.Explorer
{
    //internal void
    
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
    }
}
