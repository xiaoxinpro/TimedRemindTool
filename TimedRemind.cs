using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimedRemindTool
{
    public class TimedRemind
    {
        #region 内部变量
        private Thread TimedThread;
        #endregion

        #region 属性
        public EnmuTimedMode TimedMode { get; set; }
        public EnmuTimeLoop TimeLoop { get; set; }
        public DateTime TimeDate { get; set; }
        public string Mark { get; set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public EnmuTimedStatus Status { get; private set; }

        #endregion

        #region 事件函数
        public delegate void DelegateTimedDone(object sender);
        public event DelegateTimedDone EventTimedDone;
        public void BindTimedDone(DelegateTimedDone e)
        {
            EventTimedDone = e;
        }

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="tm">定时模式</param>
        /// <param name="tl">定时条件</param>
        /// <param name="mark">备注</param>
        public TimedRemind(DateTime dt, EnmuTimedMode tm = EnmuTimedMode.Timekeep, EnmuTimeLoop tl = EnmuTimeLoop.One, String mark = "" )
        {
            TimeDate = dt;
            TimedMode = tm;
            TimeLoop = tl;
            Mark = mark;
            Status = EnmuTimedStatus.Ready;
        }

        #endregion

        #region 公共函数
        /// <summary>
        /// 开始定时
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            int delayTime = getDelayTime(TimeDate, TimedMode);
            return Start(DateTime.Now, DateTime.Now.AddSeconds(delayTime));
        }

        /// <summary>
        /// 指定时间开始定时
        /// </summary>
        /// <param name="dtStart">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public bool Start(DateTime dtStart, DateTime dtEnd)
        {
            int delayTime = getDelayTime(TimeDate, TimedMode);
            if (DateTime.Now > dtEnd)
            {
                if (TimeLoop == EnmuTimeLoop.More)
                {
                    if (TimedMode == EnmuTimedMode.Timekeep)
                    {
                        while (dtEnd <= DateTime.Now)
                        {
                            dtStart.AddSeconds(delayTime);
                            dtEnd.AddSeconds(delayTime);
                        }
                    }
                    else
                    {
                        dtStart = DateTime.Now;
                        dtEnd = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, TimeDate.Hour, TimeDate.Minute, TimeDate.Second);
                        while (dtEnd <= dtStart)
                        {
                            dtEnd.AddDays(1);
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            StartTime = dtStart;
            EndTime = dtEnd;
            delayTime = Convert.ToInt32(EndTime.Subtract(DateTime.Now).TotalSeconds);
            Status = EnmuTimedStatus.Ready;
            if (delayTime <= 0)
            {
                return false;
            }
            TimedThread = new Thread(() =>
            {
                while (true)
                {
                    int delay = delayTime;
                    StartTime = DateTime.Now;
                    EndTime = StartTime.AddSeconds(delay);
                    while (delay-- > 0)
                    {
                        if (Status == EnmuTimedStatus.Done)
                        {
                            return;
                        }
                        Thread.Sleep(1000);
                    }
                    if (TimeLoop == EnmuTimeLoop.One)
                    {
                        Status = EnmuTimedStatus.Done;
                    }
                    if (TimeLoop == EnmuTimeLoop.More && TimedMode == EnmuTimedMode.Timed)
                    {
                        delayTime = 24 * 3600;
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

        #endregion

        #region 私有函数
        /// <summary>
        /// 获取指定时间剩余秒数
        /// </summary>
        /// <param name="dt">指定未来时间</param>
        /// <param name="mode">定时模式</param>
        /// <returns>待延时的秒数</returns>
        private int getDelayTime(DateTime dt, EnmuTimedMode mode = EnmuTimedMode.Timekeep)
        {
            int delayTime = 0;
            if (mode == EnmuTimedMode.Timekeep)
            {
                delayTime = dt.Second + dt.Minute * 60 + dt.Hour * 3600;
            }
            else if (mode == EnmuTimedMode.Timed)
            {
                DateTime now = DateTime.Now;
                delayTime = Convert.ToInt32(dt.Subtract(now).TotalSeconds);
                if (delayTime < 0)
                {
                    delayTime += 24 * 3600;
                }
            }
            return delayTime;
        }
        #endregion

        #region 公共枚举
        public enum EnmuTimedMode
        {
            Timekeep = 0,   //计时器
            Timed = 1,      //闹钟
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

        #endregion
    }
}
