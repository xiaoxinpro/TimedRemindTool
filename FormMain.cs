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
        //创建NotifyIcon对象
        NotifyIcon notifyicon = new NotifyIcon();
        //创建托盘图标对象
        //Icon ico = new Icon("Clock2.ico");

        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

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
        /// 初始化UI
        /// </summary>
        private void InitUI()
        {
            //初始化下拉列表
            InitComboBoxLoop(comboBoxLoop);

            radioButtonTimed.Checked = false;
            radioButtonTimekeep.Checked = true;

            dateTimeCtrl.Value = new DateTime(2020,1,1,1,0,0);
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
    }
}
