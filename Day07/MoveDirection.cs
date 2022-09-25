using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    enum MoveDirection:int//创建枚举排序列表 enum 枚举名 冒号后加枚举数据类型，不加默认为 int
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
        //枚举的值可以修改，需要兼容当前枚举的数据类型
    }
}
