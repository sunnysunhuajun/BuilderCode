using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuilderCode.AppServices.Core
{
    public class CoreData
    {
        static NotifiedDictionary coreData;

        /// <summary>
        /// 获取或者设置核心数据
        /// </summary>
        public static NotifiedDictionary CoreDataContent
        {
            get { return coreData; }
            set { coreData = value; }
        }

        static CoreData()
        {
            CoreDataContent = new NotifiedDictionary();
            InitCoreData();

        }

        /// <summary>
        /// 执行一些可能的数据初始化
        /// </summary>
        static void InitCoreData()
        {
            Dictionary<string, TreeNode> allNodes = new Dictionary<string, TreeNode>();
            //allNodes.Add("Completed", null);
            //allNodes.Add("New", null);
            allNodes.Add("All", null);
            //allNodes.Add("Last", null);
            //遍历枚举，添加到字典中
            foreach (CoreDataTypes Key in System.Enum.GetValues(typeof(CoreDataTypes)))
            {
                CoreDataContent.Add(Key, null);
            }
            CoreDataContent[CoreDataTypes.ALLTreeNode] = allNodes;
            CoreDataContent[CoreDataTypes.HasNewVersion] = false;
        }
    }
}
