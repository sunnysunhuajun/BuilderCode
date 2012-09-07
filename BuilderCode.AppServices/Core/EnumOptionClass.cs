using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderCode.AppServices.Core
{
    public enum DataServerType
    {
        SQLServer=1,
        Oracle=2
    }

    public enum SQLAuthTypes
    {
        WindowsAuthentication= 1,
        SQLServerAuthentication = 0
    }

    public enum DatabaseAttributeEumn
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
        Stopped = 2,
        Suspended = 3,
        Background = 4,
        Runnable = 5,
        All = 6
    }

    public enum CoreDataTypes
    {
        AllDatabaseTreeNode,
        CurrentViewedTreeNode,
        CurrentSelectedDatabase,
        CurrentDockContent,
        ActiveDockPanel,
        ActiveDockContent,
        ApplicationForm,
        HasNewVersion,
        HasServer
    }
}
