using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BuilderCode.AppServices
{
    public class SortCompare<T>:IComparer<T>
    {
        ListSortDirection m_Direction = ListSortDirection.Ascending;
        PropertyDescriptor m_Descriptor = null;

        public SortCompare(PropertyDescriptor prop, ListSortDirection direction)
        {
            m_Descriptor = prop;
            m_Direction = direction;
        }

        int IComparer<T>.Compare(T x, T y)
        {
            object xValue = m_Descriptor.GetValue(x);
            object yValue = m_Descriptor.GetValue(y);
            int retValue = 0;
            if (xValue is IComparable)
                retValue = ((IComparable)xValue).CompareTo(yValue);
            else if (yValue is IComparable)
                retValue = ((IComparable)yValue).CompareTo(xValue);
            else if (!xValue.Equals(yValue))
                retValue = xValue.ToString().CompareTo(yValue.ToString());
            if (m_Direction == ListSortDirection.Ascending)
            {
                return retValue;
            }
            else
            {
                return retValue * -1;
            }
        }
    }
}
