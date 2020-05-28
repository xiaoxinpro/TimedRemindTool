namespace TimedRemindTool
{
    partial class FormRemind
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemind));
            this.labelMessage = new System.Windows.Forms.Label();
            this.timerForm = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMessage.Location = new System.Drawing.Point(12, 49);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(380, 35);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = " 定时提醒事件【】";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerForm
            // 
            this.timerForm.Interval = 10;
            this.timerForm.Tick += new System.EventHandler(this.timerForm_Tick);
            // 
            // FormRemind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 141);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRemind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时提醒";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRemind_FormClosed);
            this.Load += new System.EventHandler(this.FormRemind_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Timer timerForm;
    }
}