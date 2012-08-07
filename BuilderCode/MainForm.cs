using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BuilderCode
{
    public partial class MainForm : Form
    {
        static string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Layout.config");
        
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
