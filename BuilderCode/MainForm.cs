using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using BuilderCode.AppServices.Core;
using BuilderCode.Command;

namespace BuilderCode
{
    public partial class MainForm : Form
    {
        static string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Layout.config");
        #region DockContents
        DockContent tree;

        #endregion
        DeserializeDockContent deserializeDockContent;
        public MainForm()
        {
            InitializeComponent();
            CreateMDIForm();
            //iReaperNotifyManager.InitSysIcon(this.components);
            Application.Idle += new EventHandler(Application_Idle);
            CoreData.CoreDataContent[CoreDataTypes.ApplicationForm] = this;
            this.deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        }

        private void CreateMDIForm()
        {

            //welcome = new Browser.iReaperBrowserForm();
            tree = new Explorer.ExplorerForm();
            //course = new CourseData.CoursesPanel();
            //download = new FileData.FilePanel();
            //courseDetail = new CourseDetailViewer();
            //videoPlayList = new PlayListForm();
        }

        private void LoadMDIForm()
        {
            CoreData.CoreDataContent[CoreDataTypes.ActiveDockPanel] = this.dockPanel1;
            tree.Show();
            
        }

        //系统空闲时载入提醒数据
        private void Application_Idle(object sender, EventArgs e)
        {
            LoadReminder();

            Application.Idle -= new EventHandler(Application_Idle);
        }

        private void LoadReminder()
        {
            //IReaper.Statues.LoadReminderWork load = new IReaper.Statues.LoadReminderWork();
            //load.RunWorkerAsync();
        }

        /// <summary>
        /// 系统关闭处理函数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            //保存页面状态
            this.dockPanel1.SaveAsXml(configFile);
            CommandBase command = CommandManager.GetCommand(CommandFamily.Command_CloseSystem);
            command.ExecuteAsync(this, null);
            e.Cancel = true;
        }

        /// <summary>
        /// 当激活的窗体变化时，更换全局数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnActiveContentChanged(object sender, EventArgs e)
        {
            CoreData.CoreDataContent[CoreDataTypes.ActiveDockContent] = this.dockPanel1.ActiveContent;
        }

        /// <summary>
        /// 最小化时，隐藏本程序
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            base.OnResize(e);
        }

        //private void OpenAboutForm(object sender, EventArgs e)
        //{
        //    AboutForm about = new AboutForm();
        //    about.ShowDialog();
        //}

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(Explorer.ExplorerForm).ToString())
                return this.tree;
            //else if (persistString == typeof(CourseData.CoursesPanel).ToString())
            //    return this.course;
            //else if (persistString == typeof(FileData.FilePanel).ToString())
            //    return this.download;
            //else if (persistString == typeof(CourseDetailViewer).ToString())
            //    return this.courseDetail;
            return null;
        }

        /// <summary>
        /// 页面装载时，载入页面配置文件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (File.Exists(configFile))
            {
                try
                {
                    this.dockPanel1.LoadFromXml(configFile, this.deserializeDockContent);
                    CoreData.CoreDataContent[CoreDataTypes.ActiveDockPanel] = this.dockPanel1;
                }
                catch
                {
                    LoadMDIForm();
                }
            }
            else
            {
                LoadMDIForm();
            }
            //welcome.LoadWelcomeWeb();
            base.OnLoad(e);
        }


    }
}
