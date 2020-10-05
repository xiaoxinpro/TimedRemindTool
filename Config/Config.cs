using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace INIFILE
{
    public class Config
    {
        #region 内部变量
        private static IniFile _file;

        #endregion

        #region 全局配置变量
        public static string DefaultTimedMode = "0";
        public static string DefaultTimeLoop = "0";
        public static string DefaultMarkValue = "";
        public static string DefaultTimeValue = "1:0:0";
        public static bool IsAutoAdd = false;
        public static bool IsSaveTimed = false;

        #endregion

        #region 提醒弹出变量
        public static string RemindModel = " 定时提醒事件【{text}】";
        public static string RemindFont = "微软雅黑, 15pt";
        public static string RemindForeColor = "ControlText";

        #endregion


        #region 公共函数
        /// <summary>
        /// 加载全部配置
        /// </summary>
        public static void Load()
        {
            Init();

            DefaultTimedMode = _file.ReadString("Main", "DefaultTimedMode", DefaultTimedMode);
            DefaultTimeLoop = _file.ReadString("Main", "DefaultTimeLoop", DefaultTimeLoop);
            DefaultMarkValue = _file.ReadString("Main", "DefaultMarkValue", DefaultMarkValue);
            DefaultTimeValue = _file.ReadString("Main", "DefaultTimeValue", DefaultTimeValue);
            IsAutoAdd = System.Convert.ToBoolean(_file.ReadString("Main", "IsAutoAdd", IsAutoAdd.ToString()));
            IsSaveTimed = System.Convert.ToBoolean(_file.ReadString("Main", "IsAutoAdd", IsSaveTimed.ToString()));

            RemindModel = _file.ReadString("Remind", "RemindModel", RemindModel);
            RemindFont = _file.ReadString("Remind", "RemindFont", RemindFont);
            RemindForeColor = _file.ReadString("Remind", "RemindForeColor", RemindForeColor);
        }

        /// <summary>
        /// 保存全部配置
        /// </summary>
        public static void Save()
        {
            Init();

            _file.WriteString("Main", "DefaultTimedMode", DefaultTimedMode);
            _file.WriteString("Main", "DefaultTimeLoop", DefaultTimeLoop);
            _file.WriteString("Main", "DefaultMarkValue", DefaultMarkValue);
            _file.WriteString("Main", "DefaultTimeValue", DefaultTimeValue);
            _file.WriteString("Main", "IsAutoAdd", IsAutoAdd.ToString());
            _file.WriteString("Main", "IsAutoAdd", IsSaveTimed.ToString());

            _file.WriteString("Remind", "RemindModel", RemindModel);
            _file.WriteString("Remind", "RemindFont", RemindFont);
            _file.WriteString("Remind", "RemindForeColor", RemindForeColor);
        }

        #endregion

        #region 私有函数
        /// <summary>
        /// 初始化配置文件
        /// </summary>
        private static void Init()
        {
            _file = new IniFile(TimedRemindTool.Global.ConfigPath);
        }

        #endregion
    }
}
