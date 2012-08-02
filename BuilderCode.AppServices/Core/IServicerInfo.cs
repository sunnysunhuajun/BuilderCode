using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BuilderCode.AppServices.Core
{
    public interface IServicerInfo
    {
        //public SQLAuthTypes SQLAuthType { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
    }
}
