using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderCode.AppServices.Core
{
    public enum SQLAuthTypes
    {
        Windows = 1,
        SQLServer = 0
    }

    public enum DatabaseType
    {
        Tables = 1,
        Views = 2,
        SP = 3,
        Function = 4
    }

    public enum CoreDataTypes
    {
        ALLTreeNode,
        CurrentViewTreeNode,
        CurrentDockContent,
        ActiveDockPanel,
        ActiveDockContent,
        ApplicationForm,
        HasNewVersion
    }
}
