using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    /// <summary>
    /// 方向
    /// </summary>
    struct Direction
    {
        private int x;
        public int X
        {
            get
            { return x; }
            set
            { x = value; }
        }

        public int Y { get; set; }

        //结构体一定提供无参数构造函数
        //所以不能写无参数构造函数
        //public Direction()
        //{ } 

        public Direction(int x, int y) : this()
        {//在构造函数中，必须先初始化所有字段 （可以使用无参数构造函数进行初始化）
            this.X = x;
            this.Y = y;
        }

        public static Direction Up
        {
            get
            {
                return new Direction(-1, 0);
            }
        }

        public static Direction Down
        {
            get
            {
                return new Direction(1, 0);
            }
        }

        public static Direction Left
        {
            get
            {
                return new Direction(0, -1);
            }
        }

        public static Direction Right
        {
            get
            {
                return new Direction(0, 1);
            }
        }
    }
}
