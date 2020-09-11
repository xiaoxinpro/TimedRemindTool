namespace TimedRemindTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBoxAddTimed = new System.Windows.Forms.GroupBox();
            this.comboBoxLoop = new System.Windows.Forms.ComboBox();
            this.textBoxMark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.radioButtonTimed = new System.Windows.Forms.RadioButton();
            this.radioButtonTimekeep = new System.Windows.Forms.RadioButton();
            this.dateTimeCtrl = new System.Windows.Forms.DateTimePicker();
            this.groupBoxTimdeLIst = new System.Windows.Forms.GroupBox();
            this.listViewTimed = new System.Windows.Forms.ListView();
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconCtrl = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerListView = new System.Windows.Forms.Timer(this.components);
            this.groupBoxAddTimed.SuspendLayout();
            this.groupBoxTimdeLIst.SuspendLayout();
            this.notifyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAddTimed
            // 
            this.groupBoxAddTimed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAddTimed.Controls.Add(this.comboBoxLoop);
            this.groupBoxAddTimed.Controls.Add(this.textBoxMark);
            this.groupBoxAddTimed.Controls.Add(this.label2);
            this.groupBoxAddTimed.Controls.Add(this.label1);
            this.groupBoxAddTimed.Controls.Add(this.buttonAdd);
            this.groupBoxAddTimed.Controls.Add(this.radioButtonTimed);
            this.groupBoxAddTimed.Controls.Add(this.radioButtonTimekeep);
            this.groupBoxAddTimed.Controls.Add(this.dateTimeCtrl);
            this.groupBoxAddTimed.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAddTimed.Name = "groupBoxAddTimed";
            this.groupBoxAddTimed.Size = new System.Drawing.Size(460, 72);
            this.groupBoxAddTimed.TabIndex = 0;
            this.groupBoxAddTimed.TabStop = false;
            this.groupBoxAddTimed.Text = "添加定时";
            // 
            // comboBoxLoop
            // 
            this.comboBoxLoop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoop.FormattingEnabled = true;
            this.comboBoxLoop.Items.AddRange(new object[] {
            "单次运行",
            "周期运行"});
            this.comboBoxLoop.Location = new System.Drawing.Point(187, 19);
            this.comboBoxLoop.Name = "comboBoxLoop";
            this.comboBoxLoop.Size = new System.Drawing.Size(133, 20);
            this.comboBoxLoop.TabIndex = 5;
            // 
            // textBoxMark
            // 
            this.textBoxMark.Font = new System.Drawing.Font("宋体", 10.5F);
            this.textBoxMark.Location = new System.Drawing.Point(187, 42);
            this.textBoxMark.Name = "textBoxMark";
            this.textBoxMark.Size = new System.Drawing.Size(133, 23);
            this.textBoxMark.TabIndex = 2;
            this.textBoxMark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMark_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "条件：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "备注：";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAdd.Location = new System.Drawing.Point(348, 19);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(96, 46);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // radioButtonTimed
            // 
            this.radioButtonTimed.AutoSize = true;
            this.radioButtonTimed.Location = new System.Drawing.Point(72, 20);
            this.radioButtonTimed.Name = "radioButtonTimed";
            this.radioButtonTimed.Size = new System.Drawing.Size(47, 16);
            this.radioButtonTimed.TabIndex = 4;
            this.radioButtonTimed.Tag = "1";
            this.radioButtonTimed.Text = "闹钟";
            this.radioButtonTimed.UseVisualStyleBackColor = true;
            this.radioButtonTimed.CheckedChanged += new System.EventHandler(this.radioButtonTimedMode_CheckedChanged);
            // 
            // radioButtonTimekeep
            // 
            this.radioButtonTimekeep.AutoSize = true;
            this.radioButtonTimekeep.Checked = true;
            this.radioButtonTimekeep.Location = new System.Drawing.Point(19, 20);
            this.radioButtonTimekeep.Name = "radioButtonTimekeep";
            this.radioButtonTimekeep.Size = new System.Drawing.Size(47, 16);
            this.radioButtonTimekeep.TabIndex = 3;
            this.radioButtonTimekeep.TabStop = true;
            this.radioButtonTimekeep.Tag = "0";
            this.radioButtonTimekeep.Text = "计时";
            this.radioButtonTimekeep.UseVisualStyleBackColor = true;
            this.radioButtonTimekeep.CheckedChanged += new System.EventHandler(this.radioButtonTimedMode_CheckedChanged);
            // 
            // dateTimeCtrl
            // 
            this.dateTimeCtrl.CustomFormat = "HH:dd";
            this.dateTimeCtrl.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dateTimeCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeCtrl.Location = new System.Drawing.Point(19, 42);
            this.dateTimeCtrl.Name = "dateTimeCtrl";
            this.dateTimeCtrl.ShowUpDown = true;
            this.dateTimeCtrl.Size = new System.Drawing.Size(100, 23);
            this.dateTimeCtrl.TabIndex = 1;
            this.dateTimeCtrl.Value = new System.DateTime(2020, 5, 22, 1, 0, 0, 0);
            // 
            // groupBoxTimdeLIst
            // 
            this.groupBoxTimdeLIst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimdeLIst.Controls.Add(this.listViewTimed);
            this.groupBoxTimdeLIst.Location = new System.Drawing.Point(12, 90);
            this.groupBoxTimdeLIst.Name = "groupBoxTimdeLIst";
            this.groupBoxTimdeLIst.Size = new System.Drawing.Size(460, 369);
            this.groupBoxTimdeLIst.TabIndex = 1;
            this.groupBoxTimdeLIst.TabStop = false;
            this.groupBoxTimdeLIst.Text = "定时列表";
            // 
            // listViewTimed
            // 
            this.listViewTimed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTimed.HideSelection = false;
            this.listViewTimed.Location = new System.Drawing.Point(6, 20);
            this.listViewTimed.Name = "listViewTimed";
            this.listViewTimed.Size = new System.Drawing.Size(448, 343);
            this.listViewTimed.TabIndex = 0;
            this.listViewTimed.UseCompatibleStateImageBehavior = false;
            this.listViewTimed.DoubleClick += new System.EventHandler(this.listViewTimed_DoubleClick);
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.notifyContextMenu.Name = "contextMenuStrip1";
            this.notifyContextMenu.Size = new System.Drawing.Size(131, 54);
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemOpen.Text = "显示/隐藏";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemExit.Text = "退出";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // notifyIconCtrl
            // 
            this.notifyIconCtrl.ContextMenuStrip = this.notifyContextMenu;
            this.notifyIconCtrl.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconCtrl.Icon")));
            this.notifyIconCtrl.Text = "notifyIconCtrl";
            this.notifyIconCtrl.Visible = true;
            this.notifyIconCtrl.DoubleClick += new System.EventHandler(this.notifyIconCtrl_DoubleClick);
            // 
            // timerListView
            // 
            this.timerListView.Enabled = true;
            this.timerListView.Tick += new System.EventHandler(this.timerListView_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 471);
            this.Controls.Add(this.groupBoxTimdeLIst);
            this.Controls.Add(this.groupBoxAddTimed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时提醒工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBoxAddTimed.ResumeLayout(false);
            this.groupBoxAddTimed.PerformLayout();
            this.groupBoxTimdeLIst.ResumeLayout(false);
            this.notifyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAddTimed;
        private System.Windows.Forms.GroupBox groupBoxTimdeLIst;
        private System.Windows.Forms.ListView listViewTimed;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.NotifyIcon notifyIconCtrl;
        private System.Windows.Forms.DateTimePicker dateTimeCtrl;
        private System.Windows.Forms.ComboBox comboBoxLoop;
        private System.Windows.Forms.TextBox textBoxMark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.RadioButton radioButtonTimed;
        private System.Windows.Forms.RadioButton radioButtonTimekeep;
        private System.Windows.Forms.Timer timerListView;
    }
}

