using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BuilderCode.AppServices
{
    public class SortableBindingList<T>:BindingList<T>
    {
        ListSortDirection m_SortDirection = ListSortDirection.Ascending;
        PropertyDescriptor m_SortDescriptor = null;
        static ListChangedEventArgs resetChangedEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
        bool m_Sort = false;
        
        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            m_SortDescriptor = prop;
            m_SortDirection = direction;
            List<T> list = Items as List<T>;
            if (list == null)
                return;
            SortCompare<T> compare = new SortCompare<T>(prop, direction);
            list.Sort(compare);
            m_Sort = true;
            OnListChanged(resetChangedEvent);
        }

        protected override bool IsSortedCore
        {
            get
            {
                return true;
            }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return m_SortDirection;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return m_SortDescriptor;
            }
        }
    }
}
