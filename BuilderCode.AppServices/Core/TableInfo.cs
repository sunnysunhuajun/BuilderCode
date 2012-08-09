using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderCode.AppServices.Core
{
    public delegate void TableUpdateEventHandler(TableInfo table);
    
    public class TableInfo
    {
        public string TableName { get; set; }
        public List<ColumnInfo> ColumnsInfo { get; set; }
        public string TableScripts { get; set; }

        public static event TableUpdateEventHandler OnTableUpdated;

        public void InvokeTableUpdate()
        {
            if (OnTableUpdated != null)
            {
                OnTableUpdated(this); 
            }
        }
    }
}
