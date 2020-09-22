﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace INIFILE
{
    public class ConfigMain
    {
        private static IniFile _file;

        public static string DefaultTimedMode = "0";
        public static string DefaultTimeLoop = "0";
        public static string DefaultMarkValue = "";
        public static string DefaultTimeValue = "1:0:0";

        private static void Init()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TimedRemindTool";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            _file = new IniFile(path + "\\Config.ini");
        }

        public static void Load()
        {
            Init();
            DefaultTimedMode = _file.ReadString("Main", "DefaultTimedMode", DefaultTimedMode);
            DefaultTimeLoop = _file.ReadString("Main", "DefaultTimeLoop", DefaultTimeLoop);
            DefaultMarkValue = _file.ReadString("Main", "DefaultMarkValue", DefaultMarkValue);
            DefaultTimeValue = _file.ReadString("Main", "DefaultTimeValue", DefaultTimeValue);
        }

        public static void Save()
        {
            Init();
            _file.WriteString("Main", "DefaultTimedMode", DefaultTimedMode);
            _file.WriteString("Main", "DefaultTimeLoop", DefaultTimeLoop);
            _file.WriteString("Main", "DefaultMarkValue", DefaultMarkValue);
            _file.WriteString("Main", "DefaultTimeValue", DefaultTimeValue);
        }
    }
}