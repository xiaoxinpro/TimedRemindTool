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
            INIFILE.Config.Save();
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

            //初始化浏览Lable
            InitRemindLabel(labelModel, textBoxModel);

            //初始化开机自启动
            checkBoxAutoRun.Checked = AutoRun.IsAutoRun();
        }

        /// <summary>
        /// 初始化模式下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxMode(ComboBox comboBox)
        {
            comboBox.SelectedIndex = Convert.ToInt32(INIFILE.Config.DefaultTimedMode);
        }

        /// <summary>
        /// 初始化条件下拉列表
        /// </summary>
        /// <param name="comboBox"></param>
        private void InitComboBoxLoop(ComboBox comboBox)
        {
            comboBox.SelectedIndex = Convert.ToInt32(INIFILE.Config.DefaultTimeLoop);
        }

        /// <summary>
        /// 初始备注输入框
        /// </summary>
        /// <param name="textBox"></param>
        private void InitTextBoxMark(TextBox textBox)
        {
            textBox.Text = INIFILE.Config.DefaultMarkValue;
        }

        private void InitRemindLabel(Label label, TextBox textModel)
        {
            textModel.Text = INIFILE.Config.RemindModel;
            label.Font = INIFILE.Convert.StringToFont(INIFILE.Config.RemindFont);
            label.ForeColor = INIFILE.Convert.StringToColor(INIFILE.Config.RemindForeColor);
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
            if (comboBox.SelectedIndex != Convert.ToInt32(INIFILE.Config.DefaultTimedMode))
            {
                INIFILE.Config.DefaultTimedMode = comboBox.SelectedIndex.ToString();
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
            if (comboBox.SelectedIndex != Convert.ToInt32(INIFILE.Config.DefaultTimeLoop))
            {
                INIFILE.Config.DefaultTimeLoop = comboBox.SelectedIndex.ToString();
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
            if (textBox.Text != INIFILE.Config.DefaultMarkValue)
            {
                INIFILE.Config.DefaultMarkValue = textBox.Text;
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
            if (checkBox.Checked != AutoRun.IsAutoRun())
            {
                if (checkBox.Checked)
                {
                    AutoRun.Open();
                }
                else
                {
                    AutoRun.Close();
                }
            }
        }

        /// <summary>
        /// 启动创建任务改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutoAdd_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked != INIFILE.Config.IsAutoAdd)
            {
                INIFILE.Config.IsAutoAdd = checkBox.Checked;
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
            if (checkBox.Checked != INIFILE.Config.IsSaveTimed)
            {
                INIFILE.Config.IsSaveTimed = checkBox.Checked;
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
            INIFILE.Config.RemindModel = textBox.Text;
            labelModel.Text = INIFILE.Config.RemindModel.Replace("{text}", "备注内容");
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
                INIFILE.Config.RemindFont = INIFILE.Convert.FontToString(fontDialog.Font);
                INIFILE.Config.RemindForeColor = INIFILE.Convert.ColorToString(fontDialog.Color);
                InitRemindLabel(labelModel, textBoxModel);
            }
        }
        #endregion


    }
}
