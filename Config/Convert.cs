using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace INIFILE
{
    public class Convert
    {
        #region 公共函数
        /// <summary>
        /// 字符串转颜色
        /// </summary>
        /// <param name="strColor">字符串颜色</param>
        /// <returns>Color对象</returns>
        public static Color StringToColor(string strColor)
        {
            return ColorTranslator.FromHtml(strColor);
        }

        /// <summary>
        /// 颜色转字符串
        /// </summary>
        /// <param name="color">Color对象</param>
        /// <returns>字符串颜色</returns>
        public static string ColorToString(Color color)
        {
            return ColorTranslator.ToHtml(color);
        }

        /// <summary>
        /// 字符串转字体对象
        /// </summary>
        /// <param name="strFont">字体字符串</param>
        /// <returns>字体对象</returns>
        public static Font StringToFont(string strFont)
        {
            FontConverter fc = new FontConverter();
            return (Font)fc.ConvertFromString(strFont);
        }

        /// <summary>
        /// 字体对象转字符串
        /// </summary>
        /// <param name="font">字体对象</param>
        /// <returns>字体字符串</returns>
        public static string FontToString(Font font)
        {
            FontConverter fc = new FontConverter();
            return fc.ConvertToInvariantString(font);
        }
        #endregion
    }
}
