using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimedRemindTool
{
    public class TimedRemind
    {
        private Thread TimedThread;
        private Boolean isStop;

        public EnmuTimedMode TimedMode { get; set; }
        public EnmuTimeLoop TimeLoop { get; set; }
        public DateTime TimeDate { get; set; }
        public string Mark { get; set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public EnmuTimedStatus Status { get; private set; }

        public delegate void DelegateTimedDone(object sender);
        public event DelegateTimedDone EventTimedDone;
        public void BindTimedDone(DelegateTimedDone e)
        {
            EventTimedDone = e;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tm"></param>
        /// <param name="tl"></param>
        /// <param name="mark"></param>
        public TimedRemind(DateTime dt, EnmuTimedMode tm = EnmuTimedMode.Timekeep, EnmuTimeLoop tl = EnmuTimeLoop.One, String mark = "" )
        {
            TimeDate = dt;
            TimedMode = tm;
            TimeLoop = tl;
            Mark = mark;
            Status = EnmuTimedStatus.Ready;
        }

        public bool Start()
        {
            int delay = TimeDate.Second + TimeDate.Minute * 60 + TimeDate.Hour * 3600;
            Status = EnmuTimedStatus.Ready;
            if (delay <= 0)
            {
                return false;
            }
            TimedThread = new Thread(() =>
            {
                while (true)
                {
                    StartTime = DateTime.Now;
                    EndTime = StartTime.AddSeconds(delay);
                    while (delay-- > 0)
                    {
                        Thread.Sleep(1000);
                        if (Status == EnmuTimedStatus.Done)
                        {
                            return;
                        }
                    }
                    if (TimeLoop == EnmuTimeLoop.One)
                    {
                        Status = EnmuTimedStatus.Done;
                    }
                    EventTimedDone?.Invoke(this);
                }
            });
            TimedThread.Start();
            return true;
        }

        public void Stop()
        {
            Status = EnmuTimedStatus.Done;
        }

        public enum EnmuTimedMode
        {
            Timekeep = 0,
            Timed = 1,
        }

        public enum EnmuTimeLoop
        {
            One = 0,
            More = 1,
        }

        public enum EnmuTimedStatus
        {
            Ready,
            Run,
            Done,
        }
    }
}
