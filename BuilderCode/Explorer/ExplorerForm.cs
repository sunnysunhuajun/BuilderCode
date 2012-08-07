using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuilderCode.AppServices.Core;

namespace BuilderCode.Explorer
{
    public partial class ExplorerForm : IBuilderCodeDockContent
    {
        public ExplorerForm()
        {
            InitializeComponent();
            CoreData.CoreDataContent.PropertyChanged += new PropertyChangedEventHandler(CoreDataContent_PropertyChanged);
        }

        void CoreDataContent_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SetCurrentTreeViewNode()
        {
 
        }
    }
}
