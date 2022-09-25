using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    [Flags]
    enum PersonalStyle
    {
        height = 1,      //0000000000000001
        weight = 2,      //0000000000000010
        bloodType = 4,   //0000000000000100
        sex = 8          //0000000000001000
    }
    //按位或 | ：用于二进制之间的判断，判断二进制之中的每一位字符
    // 0000000000000010 | 0000000000000001 = 0000000000000011
    //两个二进制码中的对应的相同位，只要有一个是 1 ，则输出的二进制码中的对应位是 1  "一 1 则 1"
    //枚举可以进行多选的条件：
    /*
    (1)每一个标签对应的枚举值换算成二进制相同位不能同时有 1 (充要条件) (给每个标签赋枚举值顺序为 2 的 n 次幂)
    (2)在枚举前添加可多选标签 [Flags] (行规，必要条件)
    */
}
