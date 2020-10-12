using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedRemindTool
{
    public partial class FormMain : Form
    {
        #region//创建对象及声明变量
        private string[] argsCommand;
        private List<TimedRemind> listTimedRemind = new List<TimedRemind>();
        private TimedRemind.EnmuTimedMode TimedMode = TimedRemind.EnmuTimedMode.Timekeep;
        private DateTime BakTimedValue;
        private Form formConfig;
        #endregion

        #region 窗体事件
        public FormMain(string[] args)
        {
            argsCommand = args;
            InitializeComponent();
            Global.Init();
        }

        /// <summary>
        /// 加载窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //加载配置文件
            INIFILE.Config.Load();

            //初始化托盘图标
            InitNotifyIcon(notifyIconCtrl);

            //初始化UI
            InitUI();
            
            //初始化表格
            InitListViewTimed(listViewTimed);

            //加载列表内容
            LoadListViewTimed(listViewTimed, Global.BackupPath);

            //创建配置界面
            formConfig = new FormConfig();

            //处理启动命令
            if (argsCommand.Length > 0 && argsCommand[0] == "-autorun")
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// 窗体调整大小事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideForm(this.notifyIconCtrl);
            }
        }

        /// <summary>
        /// 双击托盘图标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconCtrl_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowForm((NotifyIcon)sender);
            }
        }

        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.ToString() == "UserClosing")
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                CloseForm();
            }
        }
        #endregion

        #region 初始化函数
        /// <summary>
        /// 初始化UI
        /// </summary>
        private void InitUI()
        {
            //初始化下拉列表
            InitComboBoxLoop(comboBoxLoop);

            //初始化定时模式
            InitTimedMode();

            textBoxMark.Text = INIFILE.Config.DefaultMarkValue;

            DateTime dt = DateTime.Now;
            dateTimeCtrl.Value = new DateTime(dt.Year, dt.Month, dt.Day, 1, 0, 0);
            BakTimedValue = dateTimeCtrl.Value;
        }

        /// <summary>
        /// 初始化托盘图标
        /// </summary>
        /// <param name="notifyIcon">托盘图标控件</param>
        private void InitNotifyIcon(NotifyIcon notifyIcon)
        {
            this.ShowInTaskbar = true;
            notifyIcon.Visible = true;
            notifyIcon.Text = this.Text;
        }

        /// <summary>
        /// 初始化定时模式
        /// </summary>
        private void InitTimedMode()
        {
            switch ((TimedRemind.EnmuTimedMode)Convert.ToInt32(INIFILE.Config.DefaultTimedMode))
            {
                case TimedRemind.EnmuTimedMode.Timekeep:
                    radioButtonTimed.Checked = false;
                    radioButtonTimekeep.Checked = true;
                    break;
                case TimedRemind.EnmuTimedMode.Timed:
                    radioButtonTimekeep.Checked = false;
                    radioButtonTimed.Checked = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxLoop(ComboBox comboBox)
        {
            comboBox.SelectedIndex = Convert.ToInt32(INIFILE.Config.DefaultTimeLoop);
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        /// <param name="listView"></param>
        private void InitListViewTimed(ListView listView)
        {
            //基本属性设置
            listView.Clear();
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView.View = View.Details;

            //创建列表头
            listView.Columns.Add("序号", 40, HorizontalAlignment.Center);
            listView.Columns.Add("起始时间", 70, HorizontalAlignment.Center);
            listView.Columns.Add("结束时间", 70, HorizontalAlignment.Center);
            listView.Columns.Add("剩余时间", 70, HorizontalAlignment.Center);
            listView.Columns.Add("循环方式", 70, HorizontalAlignment.Center);
            listView.Columns.Add("备注", 100, HorizontalAlignment.Center);
        }

        /// <summary>
        /// 加载列表内容
        /// </summary>
        /// <param name="listView"></param>
        private void LoadListViewTimed(ListView listView, string path)
        {
            if (INIFILE.Config.IsSaveTimed)
            {
                listView.BeginUpdate();
                LoadTimedRemind(path);
                listView.EndUpdate();
            }
        }
        #endregion

        #region 公共函数
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="notifyIcon"></param>
        public void ShowForm(NotifyIcon notifyIcon)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            //notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }

        /// <summary>
        /// 隐藏窗体到最小化托盘
        /// </summary>
        /// <param name="notifyIcon"></param>
        public void HideForm(NotifyIcon notifyIcon)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            //notifyIcon.Visible = true;
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void CloseForm()
        {
            notifyIconCtrl.Visible = false;
            SaveTimedRemind(listTimedRemind, Global.BackupPath);
            foreach (TimedRemind tr in listTimedRemind)
            {
                tr.Stop();
            }
            this.Dispose();
        }

        #endregion

        #region 定时列表处理

        /// <summary>
        /// 获取定时剩余时间
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        private DateTime GetOverTime(TimedRemind tr)
        {
            DateTime over = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            try
            {
                over = over.AddSeconds(tr.EndTime.Subtract(DateTime.Now).TotalSeconds);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            return over;
        }

        /// <summary>
        /// 获取定时循环名称
        /// </summary>
        /// <param name="tr"></param>
        /// <returns></returns>
        private String GetTimeLoopName(TimedRemind tr)
        {
            String name;
            switch (tr.TimeLoop)
            {
                case TimedRemind.EnmuTimeLoop.One:
                    name = "单次运行";
                    break;
                case TimedRemind.EnmuTimeLoop.More:
                    name = "周期运行";
                    break;
                default:
                    name = "未知";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 添加定时到列表中
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tr"></param>
        private void AddListViewTimed(ListView listView, TimedRemind tr)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = (listView.Items.Count + 1).ToString();
            listViewItem.SubItems.Add(tr.StartTime.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(tr.EndTime.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(GetOverTime(tr).ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(GetTimeLoopName(tr));
            listViewItem.SubItems.Add(tr.Mark);
            listView.Items.Add(listViewItem);
        }

        /// <summary>
        /// 更新现有列表中的数据
        /// </summary>
        /// <param name="listViewItem"></param>
        /// <param name="tr"></param>
        private void UpdataListViewItem(ListViewItem listViewItem, TimedRemind tr)
        {
            if (listViewItem.SubItems[1].Text != tr.StartTime.ToString("HH:mm:ss"))
            {
                listViewItem.SubItems[1].Text = tr.StartTime.ToString("HH:mm:ss");
            }
            if (listViewItem.SubItems[2].Text != tr.EndTime.ToString("HH:mm:ss"))
            {
                listViewItem.SubItems[2].Text = tr.EndTime.ToString("HH:mm:ss");
            }
            if (listViewItem.SubItems[3].Text != GetOverTime(tr).ToString("HH:mm:ss"))
            {
                listViewItem.SubItems[3].Text = GetOverTime(tr).ToString("HH:mm:ss");
            }
            if (listViewItem.SubItems[4].Text != GetTimeLoopName(tr))
            {
                listViewItem.SubItems[4].Text = GetTimeLoopName(tr);
            }
            if (listViewItem.SubItems[5].Text != tr.Mark)
            {
                listViewItem.SubItems[5].Text = tr.Mark;
            }
        }

        /// <summary>
        /// 更新定时列表数据
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="trs"></param>
        private void UpdataListView(ListView listView, List<TimedRemind> trs)
        {
            if (listView.Items.Count == trs.Count)
            {
                for (int i = 0; i < trs.Count; i++)
                {
                    if (trs[i].Status == TimedRemind.EnmuTimedStatus.Done)
                    {
                        trs.RemoveAt(i);
                        listView.Items.RemoveAt(i);
                    }
                    else
                    {
                        if (Convert.ToInt32(listView.Items[i].Text) - 1 != i)
                        {
                            listView.Items[i].Text = (i + 1).ToString();
                        }
                        UpdataListViewItem(listView.Items[i], trs[i]);
                    }
                }
            }
            else
            {
                listView.Items.Clear();
                for (int i = 0; i < trs.Count; i++)
                {
                    if (trs[i].Status == TimedRemind.EnmuTimedStatus.Done)
                    {
                        trs.RemoveAt(i);
                    }
                    else
                    {
                        AddListViewTimed(listView, trs[i]);
                    }
                }
            }
        }

        #endregion

        #region 控件事件
        /// <summary>
        /// 添加按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                button.Enabled = false;
                if (AddTimedRemind(new TimedRemind(dateTimeCtrl.Value, TimedMode, (TimedRemind.EnmuTimeLoop)comboBoxLoop.SelectedIndex, textBoxMark.Text)))
                {
                    button.Text = "添加完成";
                }
                else
                {
                    button.Text = "添加失败";
                }
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(600);
                    this.Invoke(new Action(() =>
                    {
                        button.Text = "添加";
                        button.Enabled = true;
                    }));
                });
            }
        }

        /// <summary>
        /// 输入框输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxMark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CallOnClick(buttonAdd);
                listViewTimed.Select();
            }
        }

        /// <summary>
        /// 定时模式切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonTimedMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                TimedMode = (TimedRemind.EnmuTimedMode)Convert.ToInt32(rb.Tag);
                switch (TimedMode)
                {
                    case TimedRemind.EnmuTimedMode.Timekeep:
                        dateTimeCtrl.Value = BakTimedValue;
                        break;
                    case TimedRemind.EnmuTimedMode.Timed:
                        BakTimedValue = dateTimeCtrl.Value;
                        dateTimeCtrl.Value = DateTime.Now.AddHours(1);
                        break;
                    default:
                        BakTimedValue = dateTimeCtrl.Value;
                        break;
                }
            }

        }

        /// <summary>
        /// 定时器中断函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerListView_Tick(object sender, EventArgs e)
        {
            UpdataListView(listViewTimed, listTimedRemind);
        }

        /// <summary>
        /// 列表双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewTimed_DoubleClick(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count == 1)
            {
                RemoveTimedTemind(listView.SelectedItems[0].Index);
            }
        }

        /// <summary>
        /// 托盘菜单 - 打开/隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowForm(notifyIconCtrl);
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// 托盘菜单 - 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuConfig_Click(object sender, EventArgs e)
        {
            formConfig.Show();
        }

        /// <summary>
        /// 托盘菜单 - 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        #endregion

        #region 定时相关函数
        /// <summary>
        /// 添加定时
        /// </summary>
        /// <param name="tr"></param>
        private bool AddTimedRemind(TimedRemind tr, bool isRun = true)
        {
            listTimedRemind.Add(tr);
            listTimedRemind[listTimedRemind.Count - 1].BindTimedDone(TimedRemindDone);
            if (isRun == false || listTimedRemind[listTimedRemind.Count - 1].Start())
            {
                AddListViewTimed(listViewTimed, listTimedRemind[listTimedRemind.Count - 1]);
                //Task.Factory.StartNew(() =>
                //{
                //    Thread.Sleep(5000);
                //    this.Invoke(new Action(() =>
                //    {
                //        TimedRemind tmp = new TimedRemind(tr.ToString(), TimedRemindDone);
                //        tmp.Mark += " - Copy";
                //        if (tmp.Status != TimedRemind.EnmuTimedStatus.Done)
                //        {
                //            listTimedRemind.Add(tmp);
                //        }
                //    }));
                //});
                return true;
            }
            else
            {
                listTimedRemind.RemoveAt(listTimedRemind.Count - 1);
                return false;
            }
        }

        /// <summary>
        /// 删除定时
        /// </summary>
        /// <param name="index"></param>
        private void RemoveTimedTemind(int index)
        {
            if (index < listTimedRemind.Count)
            {
                listTimedRemind[index].Stop();
                listTimedRemind.RemoveAt(index);
            }
        }
        #endregion

        #region 定时事件
        private void TimedRemindDone(object sender)
        {
            try
            {
                TimedRemind tm = (TimedRemind)sender;
                this.Invoke(new Action(() =>
                {

                    ShowForm(this.notifyIconCtrl);
                    Form formMessage = new FormRemind(tm.Mark);
                    formMessage.Show();

                }));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }


        #endregion

        #region 私有函数

        /// <summary>
        /// 模拟按钮点击事件
        /// </summary>
        /// <param name="btn">按钮控件</param>
        private void CallOnClick(Button btn)
        {
            //建立一个类型  
            Type t = typeof(Button);
            //参数对象  
            object[] p = new object[1];
            //产生方法  
            MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
            //参数赋值。传入函数  
            p[0] = EventArgs.Empty;
            //调用  
            m.Invoke(btn, p);
            return;
        }

        /// <summary>
        /// 保存定时任务数据
        /// </summary>
        /// <param name="trList">定时任务列表</param>
        /// <param name="filePath">输出文件路径</param>
        private void SaveTimedRemind(List<TimedRemind> trList, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (trList.Count > 0)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (TimedRemind item in trList)
                    {
                        sw.WriteLine(item.ToString());
                    }
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// 加载任务定时文件
        /// </summary>
        /// <param name="filePath">加载文件路径</param>
        private void LoadTimedRemind(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs= new FileStream(filePath,FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        TimedRemind tr = new TimedRemind(sr.ReadLine());
                        if (tr.Status == TimedRemind.EnmuTimedStatus.Run)
                        {
                            AddTimedRemind(tr, false);
                        }
                    }
                }
            }
        }
        #endregion

    }
}
