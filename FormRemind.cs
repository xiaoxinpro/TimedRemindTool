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
    public partial class FormRemind : Form
    {
        private String strMessage;
        private const int POS = 3;
        private int timIndex = 0;
        private int x;
        private int y;

        public FormRemind(string strMessage)
        {
            this.strMessage = INIFILE.Config.RemindModel.Replace("{text}", strMessage);
            InitializeComponent();
        }

        private void FormRemind_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2);
            x = this.Left;
            y = this.Top;
            this.labelMessage.Text = this.strMessage;
            this.labelMessage.ForeColor = INIFILE.Convert.StringToColor(INIFILE.Config.RemindForeColor);
            this.labelMessage.Font = INIFILE.Convert.StringToFont(INIFILE.Config.RemindFont);
            timerForm.Start();
        }

        private void timerForm_Tick(object sender, EventArgs e)
        {
            if (++timIndex < 40)
            {
                switch (timIndex % 10)
                {
                    case 0:
                        this.Location = new Point(x - POS, y);
                        break;
                    case 1:
                        this.Location = new Point(x - POS, y - POS);
                        break;
                    case 2:
                        this.Location = new Point(x, y - POS);
                        break;
                    case 3:
                        this.Location = new Point(x + POS, y - POS);
                        break;
                    case 4:
                        this.Location = new Point(x + POS, y);
                        break;
                    case 5:
                        this.Location = new Point(x + POS, y + POS);
                        break;
                    case 6:
                        this.Location = new Point(x, y + POS);
                        break;
                    case 7:
                        this.Location = new Point(x - POS, y + POS);
                        break;
                    case 8:
                        this.Location = new Point(x - POS, y);
                        break;
                    case 9:
                    default:
                        this.Location = new Point(x, y);
                        break;
                }
            }
            else
            {
                timerForm.Stop();
            }
        }

        private void FormRemind_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
