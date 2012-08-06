using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BuilderCode.BaseControl
{
    public partial class SerialNumberDataGridView : DataGridView
    {
        SolidBrush solidBrush;

        public SerialNumberDataGridView()
        {
            InitializeComponent();
            solidBrush = new SolidBrush(this.RowHeadersDefaultCellStyle.ForeColor);
        }

        public SerialNumberDataGridView(IContainer container):this()
        {
            container.Add(this);
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            while (strRowNumber.Length < this.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (this.RowHeadersWidth < (int)(size.Width + 20)) this.RowHeadersWidth = (int)(size.Width + 20);
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

            base.OnRowPostPaint(e);
        }
    }
}
