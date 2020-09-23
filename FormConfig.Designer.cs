namespace TimedRemindTool
{
    partial class FormConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.groupBoxDefault = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoRun = new System.Windows.Forms.CheckBox();
            this.textBoxMark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLoop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxRemind = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.btnModelFont = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.groupBoxDefault.SuspendLayout();
            this.groupBoxRemind.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDefault
            // 
            this.groupBoxDefault.Controls.Add(this.checkBoxAutoAdd);
            this.groupBoxDefault.Controls.Add(this.checkBoxSave);
            this.groupBoxDefault.Controls.Add(this.checkBoxAutoRun);
            this.groupBoxDefault.Controls.Add(this.textBoxMark);
            this.groupBoxDefault.Controls.Add(this.label3);
            this.groupBoxDefault.Controls.Add(this.comboBoxLoop);
            this.groupBoxDefault.Controls.Add(this.label1);
            this.groupBoxDefault.Controls.Add(this.comboBoxMode);
            this.groupBoxDefault.Controls.Add(this.label2);
            this.groupBoxDefault.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDefault.Name = "groupBoxDefault";
            this.groupBoxDefault.Size = new System.Drawing.Size(360, 109);
            this.groupBoxDefault.TabIndex = 0;
            this.groupBoxDefault.TabStop = false;
            this.groupBoxDefault.Text = "全局配置";
            // 
            // checkBoxAutoAdd
            // 
            this.checkBoxAutoAdd.AutoSize = true;
            this.checkBoxAutoAdd.Enabled = false;
            this.checkBoxAutoAdd.Location = new System.Drawing.Point(101, 80);
            this.checkBoxAutoAdd.Name = "checkBoxAutoAdd";
            this.checkBoxAutoAdd.Size = new System.Drawing.Size(108, 16);
            this.checkBoxAutoAdd.TabIndex = 10;
            this.checkBoxAutoAdd.Text = "启动时创建任务";
            this.checkBoxAutoAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Location = new System.Drawing.Point(215, 80);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(132, 16);
            this.checkBoxSave.TabIndex = 10;
            this.checkBoxSave.Text = "保留上次为完成任务";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoRun
            // 
            this.checkBoxAutoRun.AutoSize = true;
            this.checkBoxAutoRun.Location = new System.Drawing.Point(11, 80);
            this.checkBoxAutoRun.Name = "checkBoxAutoRun";
            this.checkBoxAutoRun.Size = new System.Drawing.Size(84, 16);
            this.checkBoxAutoRun.TabIndex = 10;
            this.checkBoxAutoRun.Text = "开机自启动";
            this.checkBoxAutoRun.UseVisualStyleBackColor = true;
            // 
            // textBoxMark
            // 
            this.textBoxMark.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxMark.Location = new System.Drawing.Point(70, 46);
            this.textBoxMark.Name = "textBoxMark";
            this.textBoxMark.Size = new System.Drawing.Size(277, 23);
            this.textBoxMark.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "默认备注：";
            // 
            // comboBoxLoop
            // 
            this.comboBoxLoop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoop.FormattingEnabled = true;
            this.comboBoxLoop.Items.AddRange(new object[] {
            "单次运行",
            "周期运行"});
            this.comboBoxLoop.Location = new System.Drawing.Point(241, 20);
            this.comboBoxLoop.Name = "comboBoxLoop";
            this.comboBoxLoop.Size = new System.Drawing.Size(106, 20);
            this.comboBoxLoop.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "默认条件：";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "计时",
            "闹钟"});
            this.comboBoxMode.Location = new System.Drawing.Point(70, 20);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(86, 20);
            this.comboBoxMode.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "默认模式：";
            // 
            // groupBoxRemind
            // 
            this.groupBoxRemind.Controls.Add(this.groupBox2);
            this.groupBoxRemind.Controls.Add(this.btnModelFont);
            this.groupBoxRemind.Controls.Add(this.textBoxModel);
            this.groupBoxRemind.Controls.Add(this.label4);
            this.groupBoxRemind.Location = new System.Drawing.Point(12, 127);
            this.groupBoxRemind.Name = "groupBoxRemind";
            this.groupBoxRemind.Size = new System.Drawing.Size(360, 157);
            this.groupBoxRemind.TabIndex = 2;
            this.groupBoxRemind.TabStop = false;
            this.groupBoxRemind.Text = "提醒弹窗";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "提示模板：";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxModel.Location = new System.Drawing.Point(70, 20);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(196, 23);
            this.textBoxModel.TabIndex = 8;
            // 
            // btnModelFont
            // 
            this.btnModelFont.Location = new System.Drawing.Point(272, 20);
            this.btnModelFont.Name = "btnModelFont";
            this.btnModelFont.Size = new System.Drawing.Size(75, 23);
            this.btnModelFont.TabIndex = 10;
            this.btnModelFont.Text = "字体样式";
            this.btnModelFont.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelModel);
            this.groupBox2.Location = new System.Drawing.Point(6, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "预览";
            // 
            // labelModel
            // 
            this.labelModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelModel.Location = new System.Drawing.Point(6, 17);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(336, 75);
            this.labelModel.TabIndex = 0;
            this.labelModel.Text = "预览";
            this.labelModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 291);
            this.Controls.Add(this.groupBoxRemind);
            this.Controls.Add(this.groupBoxDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.groupBoxDefault.ResumeLayout(false);
            this.groupBoxDefault.PerformLayout();
            this.groupBoxRemind.ResumeLayout(false);
            this.groupBoxRemind.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDefault;
        private System.Windows.Forms.ComboBox comboBoxLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxAutoAdd;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.CheckBox checkBoxAutoRun;
        private System.Windows.Forms.TextBox textBoxMark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxRemind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Button btnModelFont;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label label4;
    }
}