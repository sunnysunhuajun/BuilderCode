using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BuilderCode.AppServices.Core
{
    public class DatabaseInfo
    {
        public string DatabaseName { get; set; }
        public List<TableInfo> TablesInfo { get; set; }
        public List<ViewInfo> ViewsInfo { get; set; }
        public List<SPInfo> SPsInfo { get; set; }
        public List<FunctionInfo> FunctionsInfo { get; set; }
    }
}
