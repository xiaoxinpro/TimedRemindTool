using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimedRemindTool
{
    public partial class FormMain : Form
    {
        #region//创建对象及声明变量
        private List<TimedRemind> listTimedRemind = new List<TimedRemind>();
        private TimedRemind.EnmuTimedMode TimedMode = TimedRemind.EnmuTimedMode.Timekeep;
        private DateTime BakTimedValue;
        #endregion

        #region 窗体事件
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //初始化托盘图标
            InitNotifyIcon(notifyIconCtrl);

            //初始化UI
            InitUI();
            
            //初始化表格
            InitListViewTimed(listViewTimed);
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
            notifyIconCtrl.Visible = false;
            foreach (TimedRemind tr in listTimedRemind)
            {
                tr.Stop();
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

            radioButtonTimed.Checked = false;
            radioButtonTimekeep.Checked = true;

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
        /// 初始化下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxLoop(ComboBox comboBox)
        {
            comboBox.SelectedIndex = 0;
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
            notifyIcon.Visible = false;
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
            notifyIcon.Visible = true;
        }

        #endregion

        #region 定时列表处理

        /// <summary>
        /// 添加定时到列表中
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tr"></param>
        void AddListViewTimed(ListView listView, TimedRemind tr)
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
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = (listView.Items.Count + 1).ToString();
            listViewItem.SubItems.Add(tr.StartTime.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(tr.EndTime.ToString("HH:mm:ss"));
            listViewItem.SubItems.Add(over.ToString("HH:mm:ss"));
            switch (tr.TimeLoop)
            {
                case TimedRemind.EnmuTimeLoop.One:
                    listViewItem.SubItems.Add("单次运行");
                    break;
                case TimedRemind.EnmuTimeLoop.More:
                    listViewItem.SubItems.Add("周期运行");
                    break;
                default:
                    listViewItem.SubItems.Add("未知");
                    break;
            }
            listViewItem.SubItems.Add(tr.Mark);
            listView.Items.Add(listViewItem);
        }
        #endregion

        #region 控件事件
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listTimedRemind.Add(new TimedRemind(dateTimeCtrl.Value, TimedMode, (TimedRemind.EnmuTimeLoop)comboBoxLoop.SelectedIndex, textBoxMark.Text));
            listTimedRemind[listTimedRemind.Count - 1].BindTimedDone(TimedRemindDone);
            if (listTimedRemind[listTimedRemind.Count - 1].Start())
            {
                AddListViewTimed(listViewTimed, listTimedRemind[listTimedRemind.Count - 1]);
            }
            else
            {
                listTimedRemind.RemoveAt(listTimedRemind.Count - 1);
            }
        }

        
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

        private void timerListView_Tick(object sender, EventArgs e)
        {
            listViewTimed.BeginUpdate();
            listViewTimed.Items.Clear();

            for (int i = 0; i < listTimedRemind.Count; i++)
            {
                if (listTimedRemind[i].Status == TimedRemind.EnmuTimedStatus.Done)
                {
                    listTimedRemind.RemoveAt(i);
                }
                else
                {
                    AddListViewTimed(listViewTimed, listTimedRemind[i]);
                }
            }
            listViewTimed.EndUpdate();
        }
        #endregion

        #region 定时事件
        void TimedRemindDone(object sender)
        {
            TimedRemind tm = (TimedRemind)sender;
            this.Invoke(new Action(() =>
            {
                ShowForm(this.notifyIconCtrl);
                Form formMessage = new FormRemind(tm.Mark);
                formMessage.Show();
                //this.TopMost = true;
                //MessageBox.Show(tm.Mark, "定时提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.TopMost = false;
            }));
        }

        #endregion

    }
}
