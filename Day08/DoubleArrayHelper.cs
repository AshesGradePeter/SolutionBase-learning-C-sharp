using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    /// <summary>
    /// 二维数组助手类
    /// </summary>
    static class DoubleArrayHelper
    {
        /// <summary>
        /// 获取指定方向上的元素
        /// </summary>
        /// <param name="targetArray">目标数组</param>
        /// <param name="rIndex">指定位置的行索引</param>
        /// <param name="cIndex">指定位置的列索引</param>
        /// <param name="dir">方向</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public static string[] GetElements(string[,] targetArray, int rIndex, int cIndex, Direction dir, int count)
        {
            List<string> resultElements = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                rIndex += dir.X;
                cIndex += dir.Y;
                if (rIndex >= 0 && rIndex < targetArray.GetLength(0) && cIndex >= 0 && cIndex < targetArray.GetLength(1))
                    resultElements.Add(targetArray[rIndex, cIndex]);
            }

            //List<string>  ==>  string[]
            return resultElements.ToArray();
        }
    }
}
