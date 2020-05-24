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
        List<TimedRemind> listTimedRemind = new List<TimedRemind>();
        TimedRemind.EnmuTimedMode TimedMode = TimedRemind.EnmuTimedMode.Timekeep;
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
                    listViewItem.SubItems.Add("无限循环");
                    break;
                default:
                    listViewItem.SubItems.Add("未知");
                    break;
            }
            listViewItem.SubItems.Add(tr.Mark);
            listView.Items.Add(listViewItem);
        }

        #region 控制事件
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listTimedRemind.Add(new TimedRemind(dateTimeCtrl.Value, TimedMode, (TimedRemind.EnmuTimeLoop)comboBoxLoop.SelectedIndex, textBoxMark.Text));
            listTimedRemind[listTimedRemind.Count - 1].BindTimedDone(TimedRemindDone);
            listTimedRemind[listTimedRemind.Count - 1].Start();
            AddListViewTimed(listViewTimed, listTimedRemind[listTimedRemind.Count - 1]);
        }
        
        private void radioButtonTimedMode_CheckedChanged(object sender, EventArgs e)
        {
            TimedMode = (TimedRemind.EnmuTimedMode)((RadioButton)sender).Tag;
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
                MessageBox.Show(tm.Mark, "定时提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }
        #endregion

    }
}
