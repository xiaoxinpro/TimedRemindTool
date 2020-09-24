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
    public partial class FormConfig : Form
    {
        #region 窗体事件
        /// <summary>
        /// 创建配置页面
        /// </summary>
        public FormConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载配置页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConfig_Load(object sender, EventArgs e)
        {
            //初始化UI
            InitUI();
        }

        /// <summary>
        /// 关闭配置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            INIFILE.ConfigMain.Save();
        }
        #endregion

        #region 初始化函数
        /// <summary>
        /// 初始化UI
        /// </summary>
        private void InitUI()
        {
            //初始化模式下拉列表
            InitComboBoxMode(comboBoxMode);

            //初始化条件下拉列表
            InitComboBoxLoop(comboBoxLoop);

            //初始备注输入框
            InitTextBoxMark(textBoxMark);
        }

        /// <summary>
        /// 初始化模式下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxMode(ComboBox comboBox)
        {
            comboBox.SelectedIndex = Convert.ToInt32(INIFILE.ConfigMain.DefaultTimedMode);
        }

        /// <summary>
        /// 初始化条件下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxLoop(ComboBox comboBox)
        {
            comboBox.SelectedIndex = Convert.ToInt32(INIFILE.ConfigMain.DefaultTimeLoop);
        }

        /// <summary>
        /// 初始备注输入框
        /// </summary>
        /// <param name="textBox"></param>
        private void InitTextBoxMark(TextBox textBox)
        {
            textBox.Text = INIFILE.ConfigMain.DefaultMarkValue;
        }
        #endregion

        #region 控件事件
        /// <summary>
        /// 默认模式改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex != Convert.ToInt32(INIFILE.ConfigMain.DefaultTimedMode))
            {
                INIFILE.ConfigMain.DefaultTimedMode = comboBox.SelectedIndex.ToString();
            }
        }

        /// <summary>
        /// 默认条件改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLoop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex != Convert.ToInt32(INIFILE.ConfigMain.DefaultTimeLoop))
            {
                INIFILE.ConfigMain.DefaultTimeLoop = comboBox.SelectedIndex.ToString();
            }
        }

        /// <summary>
        /// 默认备注改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxMark_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != INIFILE.ConfigMain.DefaultMarkValue)
            {
                INIFILE.ConfigMain.DefaultMarkValue = textBox.Text;
            }
        }

        /// <summary>
        /// 开机自启动改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
        }

        /// <summary>
        /// 启动创建任务改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutoAdd_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked != INIFILE.ConfigMain.IsAutoAdd)
            {
                INIFILE.ConfigMain.IsAutoAdd = checkBox.Checked;
            }
        }

        /// <summary>
        /// 保留上次运行任务改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxSave_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked != INIFILE.ConfigMain.IsSaveTimed)
            {
                INIFILE.ConfigMain.IsSaveTimed = checkBox.Checked;
            }
        }

        /// <summary>
        /// 提示模板改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxModel_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            labelModel.Text = textBox.Text.Replace("{text}", "提示内容");
        }

        /// <summary>
        /// 字体样式按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.Font = labelModel.Font;
            fontDialog.Color = labelModel.ForeColor;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                labelModel.Font = fontDialog.Font;
                labelModel.ForeColor = fontDialog.Color;
            }
        }
        #endregion


    }
}
