using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace BuilderCode.AppServices.Core
{
    public class OracleInfo
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
    }
}
