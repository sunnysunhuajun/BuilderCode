using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderCode.AppServices.Core
{
    public class TableInfo
    {
        public string TableName { get; set; }
        public List<ColumnInfo> ColumnsInfo { get; set; }
        public string TableScripts { get; set; }
    }
}
