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

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tr">配置字符串</param>
        /// <param name="e">提醒回调函数</param>
        public TimedRemind(string tr, DelegateTimedDone e = null)
        {
            string[] arr = tr.Split(new char[1] { '|'});
            if (arr.Length > 5)
            {
                try
                {
                    TimedMode = (EnmuTimedMode)Enum.Parse(typeof(EnmuTimedMode), arr[0], true);
                    TimeLoop = (EnmuTimeLoop)Enum.Parse(typeof(EnmuTimeLoop), arr[1], true);
                    TimeDate = Convert.ToDateTime(arr[2]);
                    Mark = arr[3];
                    DateTime dtStart = Convert.ToDateTime(arr[4]);
                    DateTime dtEnd = Convert.ToDateTime(arr[5]);
                    Status = EnmuTimedStatus.Ready;
                    if (e != null)
                    {
                        BindTimedDone(e);
                    }
                    Start(dtStart, dtEnd);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    Status = EnmuTimedStatus.Done;
                }
            }
            else
            {
                Status = EnmuTimedStatus.Done;
            }
        }

        #endregion

        #region 公共函数
        /// <summary>
        /// 开始定时
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            DateTime now = DateTime.Now;
            bool ret;
            switch (TimedMode)
            {
                case EnmuTimedMode.Timekeep:
                    ret = Start(now, GetEndTime(TimeDate, now));
                    break;
                case EnmuTimedMode.Timed:
                    ret = Start(now, TimeDate);
                    break;
                default:
                    ret = false;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 指定时间开始定时
        /// </summary>
        /// <param name="dtStart">开始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public bool Start(DateTime dtStart, DateTime dtEnd)
        {
            DateTime now = DateTime.Now;
            int delayTime = GetDelayTime(TimeDate, TimedMode);
            if (now > dtEnd)
            {
                if (TimeLoop == EnmuTimeLoop.More)
                {
                    if (TimedMode == EnmuTimedMode.Timekeep)
                    {
                        while (dtEnd <= now)
                        {
                            dtStart = dtStart.AddSeconds(delayTime);
                            dtEnd = dtEnd.AddSeconds(delayTime);
                        }
                    }
                    else
                    {
                        dtStart = now;
                        dtEnd = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, TimeDate.Hour, TimeDate.Minute, TimeDate.Second);
                        while (dtEnd <= dtStart)
                        {
                            dtEnd = dtEnd.AddDays(1);
                        }
                    }
                }
                else
                {
                    Status = EnmuTimedStatus.Done;
                    return false;
                }
            }
            StartTime = dtStart;
            EndTime = dtEnd;
            if (EndTime <= DateTime.Now)
            {
                Status = EnmuTimedStatus.Done;
                return false;
            }
            Status = EnmuTimedStatus.Run;
            TimedThread = new Thread(() =>
            {
                while (Status != EnmuTimedStatus.Done)
                {
                    while (EndTime >= DateTime.Now)
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
                    if (TimeLoop == EnmuTimeLoop.More)
                    {
                        if (TimedMode == EnmuTimedMode.Timed)
                        {
                            StartTime = StartTime.AddDays(1);
                            EndTime = EndTime.AddDays(1);
                        }
                        else
                        {
                            StartTime = DateTime.Now;
                            EndTime = GetEndTime(TimeDate, StartTime);
                        }
                    }
                    EventTimedDone?.Invoke(this);
                }
            });
            TimedThread.Start();
            return true;
        }

        /// <summary>
        /// 停止定时
        /// </summary>
        public void Stop()
        {
            Status = EnmuTimedStatus.Done;
        }

        /// <summary>
        /// 定时转字符串
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            List<string> tr = new List<string>();
            tr.Add(TimedMode.ToString());
            tr.Add(TimeLoop.ToString());
            tr.Add(TimeDate.ToString());
            tr.Add(Mark);
            tr.Add(StartTime.ToString());
            tr.Add(EndTime.ToString());
            tr.Add(Status.ToString());
            return string.Join("|", tr.ToArray());
        }

        #endregion

        #region 私有函数
        /// <summary>
        /// 获取指定时间剩余秒数
        /// </summary>
        /// <param name="dt">指定未来时间</param>
        /// <param name="mode">定时模式</param>
        /// <returns>待延时的秒数</returns>
        private int GetDelayTime(DateTime dt, EnmuTimedMode mode = EnmuTimedMode.Timekeep)
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

        /// <summary>
        /// 获取结束事件
        /// </summary>
        /// <param name="dt">时间长度</param>
        /// <param name="now">当前时间</param>
        /// <returns></returns>
        private DateTime GetEndTime(DateTime dt, DateTime now = default)
        {
            if (now == default)
            {
                now = DateTime.Now;
            }
            return now.AddHours(dt.Hour).AddMinutes(dt.Minute).AddSeconds(dt.Second);
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
