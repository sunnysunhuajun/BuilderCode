using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BuilderCode.AppServices.Core
{
    public class ColumnInfo
    {
        private Int16? _ColumnOrder;
        private string _ColumnName;
        private string _TypeName;
        private int? _Length;
        private int? _Preci;
        private int? _Scale;
        private string _IsIdentity;
        private string _IsPK;
        private string _IsNull;
        private string _DefaultValue;
        private string _deText;

        /// <summary>
        /// 列序号
        /// </summary>
        [XmlAttribute]
        public Int16? ColumnOrder
        {
            set { _ColumnOrder = value; }
            get { return _ColumnOrder; }
        }

        /// <summary>
        /// 列名
        /// </summary>
        [XmlAttribute]
        public string ColumnName
        {
            set { _ColumnName = value; }
            get { return _ColumnName; }
        }

        /// <summary>
        /// 字段类型
        /// </summary>
        [XmlAttribute]
        public string TypeName
        {
            set { _TypeName = value; }
            get { return _TypeName; }
        }

        /// <summary>
        /// 字段长度
        /// </summary>
        [XmlAttribute]
        public int? Length
        {
            set { _Length = value; }
            get { return _Length; }
        }

        /// <summary>
        /// 精度
        /// </summary>
        [XmlAttribute]
        public int? Preci
        {
            set { _Preci = value; }
            get { return _Preci; }
        }

        /// <summary>
        /// 小数位数
        /// </summary>
        [XmlAttribute]
        public int? Scale
        {
            set { _Scale = value; }
            get { return _Scale; }
        }

        /// <summary>
        /// 是否唯一值
        /// </summary>
        [XmlAttribute]
        public string IsIdentity
        {
            set { _IsIdentity = value; }
            get { return _IsIdentity; }
        }

        /// <summary>
        /// 是否主键 
        /// </summary>
        [XmlAttribute]
        public string IsPK
        {
            set { _IsPK = value; }
            get { return _IsPK; }
        }

        [XmlAttribute]
        public string IsNull
        {
            set { _IsNull = value; }
            get { return _IsNull; }
        }

        /// <summary>
        /// 默认值
        /// </summary>
        [XmlAttribute]
        public string DefaultValue
        {
            set { _DefaultValue = value; }
            get { return _DefaultValue; }
        }

        /// <summary>
        /// 字段说明
        /// </summary>
        [XmlAttribute]
        public string DeText
        {
            set { _deText = value; }
            get { return _deText; }
        }

    }
}
