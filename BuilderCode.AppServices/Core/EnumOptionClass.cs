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

    public enum DatabaseStatusType
    {
        Running = 0,
        Sleeping = 1,
        Suspended = 2,
        Background = 3,
        Runnable = 4,
        All = 5
    }

    public enum CoreDataTypes
    {
        ALLTreeNode,
        CurrentViewedTreeNode,
        CurrentSelectedDatabase,
        CurrentDockContent,
        ActiveDockPanel,
        ActiveDockContent,
        ApplicationForm,
        HasNewVersion
    }
}
