using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace BuilderCode.AppServices.Core
{
    public delegate void NotifyBindingListItemRemoveEventHandler(int index);
    
    public class DatabaseCollection:SortableBindingList<DatabaseInfo>
    {
        public event NotifyBindingListItemRemoveEventHandler NotfiyRemove;
        DatabaseStatusType type;
        Dictionary<string, DatabaseInfo> dic;
        bool isAutoAdded;

        public DatabaseCollection(DatabaseStatusType Type)
        {
            dic = new Dictionary<string, DatabaseInfo>();
            type = Type;
            isAutoAdded = true;
            DatabaseInfo.OnDatabaseUpdated += new DatabaseUpdateEventHandler(DatabaseInfo_OnDatabaseUpdated);
        }

        public Dictionary<string, DatabaseInfo> KeyList
        {
            get { return dic; }
        }

        public DatabaseStatusType Type
        {
            get { return type; }
            set { type = value; }
        }

        public new void Add(DatabaseInfo database)
        {
            if (Contains(database))
                return;
            dic.Add(database.DatabaseName, database);
            base.Add(database);
        }

        public new bool Contains(DatabaseInfo database)
        {
            if (base.Contains(database))
                return true;
            return dic.ContainsKey(database.DatabaseName);
        }

        public new void Clear()
        {
            base.Clear();
            base.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted,-1));
            if (dic != null)
                dic.Clear();
        }



        protected override void RemoveItem(int index)
        {
            if (NotfiyRemove != null)
            {
                NotfiyRemove(index);
            }
            DatabaseInfo database = this[index];
            dic.Remove(database.DatabaseName);
            base.RemoveItem(index);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void DatabaseInfo_OnDatabaseUpdated(DatabaseInfo database)
        {
            int index = -1;
            if ((index = IndexOf(database)) >= 0)
                ResetItem(index);
        }
    }
}
