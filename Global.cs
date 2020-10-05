using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TimedRemindTool
{
    /// <summary>
    /// 全局静态类
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// 用户文件夹
        /// </summary>
        public static readonly string UserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TimedRemindTool";
        
        /// <summary>
        /// 配置文件目录
        /// </summary>
        public static readonly string ConfigPath = UserDirectory + "\\Config.ini";
        
        /// <summary>
        /// 定时备份文件目录
        /// </summary>
        public static readonly string BackupPath = UserDirectory + "\\Backup.trs";

        /// <summary>
        /// 初始化全局类
        /// </summary>
        public static void Init()
        {
            // 检查目录是否存在
            if (Directory.Exists(UserDirectory) == false)
            {
                Directory.CreateDirectory(UserDirectory);
            }
        }
    }
}
