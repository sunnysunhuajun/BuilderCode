using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace BuilderCode.AppServices.Core
{
    public delegate void OnDataSetEventHandler(CoreDataTypes key, object value);

    public class NotifiedDictionary : Dictionary<CoreDataTypes, object>, INotifyPropertyChanged
    {
        Dictionary<CoreDataTypes, PropertyChangedEventArgs> properties = new Dictionary<CoreDataTypes, PropertyChangedEventArgs>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public new void Add(CoreDataTypes key, object value)
        {
            base.Add(key, value);
            if (properties.ContainsKey(key))
            {
                return;
            }
            else
            {
                properties.Add(key, new PropertyChangedEventArgs(key.ToString()));
            }
        }

        /// <summary>
        /// 一个同步的索引器
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>

        public new object this[CoreDataTypes Key]
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return base[Key];
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                base[Key] = value;
                this.InvokeCoreDataTypeNotification(Key);
            }
        }

        /// <summary>
        /// 触发指定类型数据的更新信息
        /// </summary>
        /// <param name="Type"></param>
        public void InvokeCoreDataTypeNotification(CoreDataTypes Type)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, properties[Type]);
            }
        }

        /// <summary>
        /// 外部事件挂接接口。任何外部事件，可以通过编程调用这个方法。
        /// 当这个方法被调用后，
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="paras"></param>
        public void OnExternalMethodsInvoked(CoreDataTypes Type, params object[] paras)
        {

        }

        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
