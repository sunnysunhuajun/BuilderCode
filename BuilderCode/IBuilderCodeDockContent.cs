using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using BuilderCode.AppServices.Core;

namespace BuilderCode
{
    public partial class IBuilderCodeDockContent : DockContent
    {
        public IBuilderCodeDockContent()
        {
            InitializeComponent();
            CoreData.CoreDataContent.PropertyChanged += new PropertyChangedEventHandler(CoreDataContent_PropertyChanged);
            this.DockPanel = CoreData.CoreDataContent[CoreDataTypes.ActiveDockPanel] as DockPanel;
        }

        void CoreDataContent_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CoreDataTypes.ActiveDockPanel.ToString())
            {
                DockPanel panel = CoreData.CoreDataContent[CoreDataTypes.ActiveDockPanel] as DockPanel;
                if (this.DockPanel != panel)
                {
                    this.DockPanel = panel;
                }
            }
        }
    }
}
