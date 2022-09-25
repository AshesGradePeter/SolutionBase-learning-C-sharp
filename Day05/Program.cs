using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        static void ForFor()
        {
            //for for 循环嵌套
            //观察以下代码
            Console.Write("Hello World!\t");
            Console.Write("Hello World!\t");
            Console.Write("Hello World!\t");
            Console.Write("Hello World!\t");
            Console.WriteLine();
            Console.Write("Hello World!\t");
            Console.Write("Hello World!\t");
            Console.Write("Hello World!\t");
            Console.Write("Hello World!\t");
            Console.WriteLine();
            //以上代码生成了两行四列的 "Hello World!"
            /*
            Hello World!    Hello World!    Hello World!    Hello World!
            Hello World!    Hello World!    Hello World!    Hello World!
            */
            //等效 for for 嵌套代码：
            for (int line = 0; line < 2; line++)//生成两行
            {
                for (int row = 0; row < 4; row++)//生成四列，本循环结束再执行外面的代码和外面的循环
                {
                    Console.Write("Hello World!\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //练习 使用 for for 循环绘制图形
            /*
                #
                ##
                ###
                ####
            */
            for (int line = 1; line <= 4; line++)//一共四行
            {
                for (int row = 0; row < line; row++)//生成的列数等于当前的行数
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //练习 使用 for for 循环绘制图形
            /*
                ####
                 ###
                  ##
                   #
            */
            int blank = -1;//定义空格计数器，因为第一行没空格所以初始值为 -1
            for (int line = 1; line <= 4; line++)//一共生成四行
            {
                //先生成空格
                for (int rowblank = 1; rowblank <= line - 1; rowblank++)//生成空格数等于当前生成的行数减 1
                {
                    Console.Write(" ");
                }
                blank += 1;//空格计数器加 1
                //生成 #
                for (int row = 1; row <= 4 - blank; row++)//生成的 # 数等于 4 减当前生成的行数所包含的空格数
                {
                    Console.Write("#");
                }
                Console.WriteLine();//换行
            }
        }
        //练习：冒泡排序法(满足条件的元素向前移) 定义一个方法，将自定义数组内的数据由小到大排序(使用 for for 循环嵌套)
        //缺点：交换次数可能过多，影响性能
        private static double[] ArraySort(double[] array)
        {
            int count;//定义计数器变量用于计算数组内用于与最小值比较的元素的索引
            double temp;//定义中间变量用于交换数据
            for (int i = 0; i < array.Length - 1; i++)//循环 数组长度 减 1 轮 次
            {
                count = i;//初始化计数器(索引为 i 的元素之前的元素都不进行比较)
                for (int a = 0; a < array.Length - (i + 1); a++)//每轮循环比较 数组长度 减 轮数 次
                {
                    count += 1;//每次将索引加 1 用于比较接下来的元素
                    if (array[i] > array[count])//比较第 i 个元素是否大于接下来的元素，若大于交换两个元素
                    {
                        temp = array[i];
                        array[i] = array[count];
                        array[count] = temp;
                    }
                }
            }
            return array;//返回被操作之后的数组
        }
        //练习：定义一个方法：用于检查数组中是否存在相同的元素
        //基本原理同上一个练习，不再解释
        private static string InspectElement(double[] array)
        {
            int count;
            for (int i = 0; i < array.Length - 1; i++)
            {
                count = i;
                for (int c = 0; c < array.Length - (i + 1); c++)
                {
                    count += 1;
                    if (array[i] == array[count])//一旦发现被比较元素和比较元素相同时返回 "存在相同的元素" 并跳出比较
                    {
                        return "存在相同的元素";
                    }                    
                }
            }
            return "不存在相同的元素";//到最后循环全部结束时仍没发现相同的元素时返回 "不存在相同的元素"
        }
        static void TwoDimensionalArray()
        {
            //数组的分类：
            /*
             * 一维数组(int[] string[] double[] ......)
             * 多维数组(二维数组 ......)
             * 交错数组
            */
            //二维数组  索引[行,列] (索引仍然从 0 开始数)
            //声明：
            int[,] array = new int[5,3];//声明了一个 5 行 3 列且名叫 array 的二维数组
            Console.WriteLine(array.Length);// 5 x 3 = 15，数组长度为 15
            Console.WriteLine();
            array[0, 2] = 6;//将数字 6 赋值给数组的第 1 行第 3 列
            array[1, 1] = 9;
            array[2, 1] = 7;
            array[3, 0] = 5;
            array[4, 1] = 4;
            /*
            array:(行 → 列 ↓)
               0   1   2
            0 [ ] [ ] [6]
            1 [ ] [9] [ ]
            2 [ ] [7] [ ]
            3 [5] [ ] [ ]
            4 [ ] [4] [ ]
            */
            //以表格的形式输出数组到控制台上
            for (int line = 0; line < 5; line++)//共生成 5 行
            //for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < 3; row++)//共生成 3 列
                //for (int row = 0; row < array.GetLength(1); row++)
                {
                    Console.Write(array[line,row] + "\t");//输出第几行第几列的数
                }
                Console.WriteLine();//每行生成完了换行
            }
            Console.WriteLine();
            //在二维数组中可用 数组名.GetLength(0) 来获取二维数组行数， 数组名.GetLength(1) 获取列数
            Console.WriteLine(array.GetLength(0));//5
            Console.WriteLine(array.GetLength(1));//3
        }
        //练习1：定义一个方法，创建学生成绩表二维数组
        /*
        规则：
        (1)输入学生总数
        (2)输入科目数
        (3)输入第几个学生第几科成绩
        样式：
                科目1    科目2
        学生1
        学生2
        学生3
        要求：不考虑成绩的范围，只需填写内容即可
        */
        private static string[,] GradeSheet()
        {
            //输入建表信息
            Console.WriteLine("请输入学生总数：");
            int studentCount = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入科目数：");
            int classCount = int.Parse(Console.ReadLine());
            string[,] sheet = new string[studentCount + 1,classCount + 1];//建立二维数组，记得要加上表头所在的行和列
            //创建行表头
            for (int line1 = 1; line1 < sheet.GetLength(1); line1++)//前面空一格，生成的数量是列的数量
            {
                sheet[0, line1] = "科目" + line1;
            }
            //创建列表头
            for (int row1 = 1; row1 < sheet.GetLength(0); row1++)//上面空一格，生成的数量是行的数量
            {
                sheet[row1, 0] = "学生" + row1;
            }
            //输入成绩
            for (int line = 1; line < sheet.GetLength(0); line++)//再按行的数量写列
            {
                for (int row = 1; row < sheet.GetLength(1); row++)//先按列的数量写行
                {
                    Console.WriteLine("请输入第{0}个学生的第{1}个成绩：",line,row);
                    string score = Console.ReadLine();
                    sheet[line, row] = score;
                }
            }
                return sheet;
        }
        //练习2：定义一个方法，在控制台中显示任意行列的 String 类型的二维数组
        //内容上面已经陈述，不再解释以下代码
        private static void FormatTwoDimensionalArray(string[,] array)
        {
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < array.GetLength(1); row++)
                {
                    Console.Write(array[line, row] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void StudentGradeSheetMain()//学生成绩程序入口
        {
            string[,] result = GradeSheet();
            FormatTwoDimensionalArray(result);
        }
        //**********************************************************************2048游戏逻辑**********************************************************************
        //2048核心算法
        //分析：
        /*
        定义四个方法：上移 下移 左移 右移
        上移：
        (1)获取列数据，从上到下形成一个一维数组
        (2)合并数据：
            (2.1)去零：将全部的 0 元素移动到后方(移到下面)
            (2.2)相邻相同的元素合并：后一个元素累加到前一个元素上，后一个元素清零
            (2.3)去零：合并之后可能还会产生 0 元素，需要再次将全部 0 元素移动到后方(移到下面)
        (3)还原列数据：将一维数组中的数据还原到原二维数组中被操作的列
        下移1.0：
        (1)获取列数据，从上到下形成一个一维数组
        (2)合并数据：
            (2.1)去零：将全部的 0 元素移动到前方(移到上面)
            (2.2)相邻相同的元素合并：前一个元素累加到后一个元素上，前一个元素清零
            (2.3)去零：合并之后可能还会产生 0 元素，需要再次将全部 0 元素移动到前方(移到上面)
        (3)还原列数据：将一维数组中的数据还原到原二维数组中被操作的列
        为了简化代码，同一段代码可以多次使用，可改进下移算法
        下移2.0：
        (1)获取列数据：从下到上形成一个一维数组
        (2)合并数据：
            (2.1)去零：将全部的 0 元素移动到后方(移到下面)
            (2.2)相邻相同的元素合并：后一个元素累加到前一个元素上，后一个元素清零
            (2.3)去零：合并之后可能还会产生 0 元素，需要再次将全部 0 元素移动到后方(移到下面)
        (3)还原列数据：将一维数组中的数据还原到原二维数组中被操作的列
        此时只有第一步与上移不同，其余步骤相同
        左移：
        右移：
        左移右移操作类似于上移下移
        */
        //实施：
        /*
        (1)定义去零方法(针对一维数组做操作)：将全部 0 元素移动至末尾，输入一个数组，输出操作之后的数组
        (2)定义合并数据方法(针对一维数组做操作)：
            合并数据：
                (1)调用去零方法去零
                (2)相邻相同的元素合并
                (3)调用去零方法去零
            输入一个数组，输出操作之后的数组
        (3)定义上移的方法：
            上移：
                (1)从上到下获取列数据
                (2)调用合并数据方法
                (3)还原列数据
            输入一个数组，输出操作之后的数组
        (4)定义下移的方法：
            下移：
                (1)从下到上获取列数据
                (2)调用合并数据方法
                (3)还原列数据
            输入一个数组，输出操作之后的数组
        (5)定义左移的方法：
        (6)定义右移的方法：
        左移右移操作类似于上移下移
        2048游戏地图：(4 x 4)
               0   1   2   3
            0 [ ] [ ] [ ] [ ]

            1 [ ] [ ] [ ] [ ]

            2 [ ] [ ] [ ] [ ]

            3 [ ] [ ] [ ] [ ]
        */
        //代码部分
        /// <summary>
        /// 去零方法
        /// </summary>
        /// <param name="array">输入数组</param>
        /// <returns></returns>
        private static int[] MoveZero(int[] array)
        {
            int[] afterMoveZeroArray = new int[array.Length];//定义一个新的数组 afterMoveZeroArray 用于装去零后的数组         
            int noZeroPostion = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)//将非 0 元素依次赋值给新数组 afterMoveZeroArray
                {
                    afterMoveZeroArray[noZeroPostion++] = array[i];
                }
            }
            return afterMoveZeroArray;//返回 afterMoveZeroArray 数组
        }
        /// <summary>
        /// 合并数据方法
        /// </summary>
        /// <param name="array">输入数组</param>
        /// <returns></returns>
        private static int[] CombineNumber(int[] array)
        {
            int[] firstZeroArray = MoveZero(array);//第一次去零
            for (int i = 0; i < array.Length - 1; i++)//逐位判断，判断次数是数组长度减 1
            {
                if (firstZeroArray[i] == firstZeroArray [i + 1])//如果被判断元素与后一个元素相等，则后一个元素累加到前一个元素上，后一个元素清零
                {
                    firstZeroArray[i] += firstZeroArray[i + 1];
                    firstZeroArray[i + 1] = 0;
                }
            }
            int[] secondZeroArray = MoveZero(firstZeroArray);//第二次去零
            return secondZeroArray;//返回数组 secondZeroArray
        }
        /// <summary>
        /// 上移操作方法
        /// </summary>
        /// <param name="array">输入数组</param>
        /// <returns></returns>
        private static int[,] CtrlUp(int[,] array)
        {
            int[,] resultArray = new int[array.GetLength(0), array.GetLength(1)];//定义一个二维数组，用于装最后操作完成的数组
            int[] operatingArray = new int[array.GetLength(0)];//定义一个数组用于装被提取的列
            int[] temp;//定义一个中间数组，用于装被合并后但还没写给 resultArray 的元素
            for (int row = 0; row < array.GetLength(1); row++)//循环列，循环次数是列数
            {
                for (int line = 0; line < operatingArray.Length; line++)//循环行，循环次数是被提取出的列的长度
                {
                    operatingArray[line] = array[line, row];//逐个提取 row 列 line 行的数据存入到 operatingArray 的对应位置
                }
                temp = CombineNumber(operatingArray);//合并数据后临时存给 temp
                for (int i = 0; i < operatingArray.Length; i++)//将数据逐列写入 resultArray
                {
                    resultArray[i, row] = temp[i];
                }
            }
            return resultArray;
        }
        /// <summary>
        /// 下移操作方法
        /// </summary>
        /// <param name="array">输入数组</param>
        /// <returns></returns>
        private static int[,] CtrlDown(int[,] array)
        {
            //结构与上移相同，仅仅局部不同，故不再详细陈述
            int[,] resultArray = new int[array.GetLength(0), array.GetLength(1)];
            int[] operatingArray = new int[array.GetLength(0)];
            int[] temp;
            for (int row = 0; row < array.GetLength(1); row++)
            {
                for (int line = 0; line < operatingArray.Length; line++)
                {
                    operatingArray[line] = array[line, row];
                }
                Array.Reverse(operatingArray);//数据调转一次，变成由下到上读取
                temp = CombineNumber(operatingArray);//合并数据
                Array.Reverse(temp);//调转回来
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    resultArray[i, row] = temp[i];
                }
            }
            return resultArray;
        }
        //左右移动与上下移动仅是更改了行列关系，故不加以注释
        /// <summary>
        /// 左移操作方法
        /// </summary>
        /// <param name="array">输入数组</param>
        /// <returns></returns>
        private static int[,] CtrlLeft(int[,] array)
        {
            int[,] resultArray = new int[array.GetLength(0), array.GetLength(1)];
            int[] operatingArray = new int[array.GetLength(1)];
            int[] temp;
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < operatingArray.Length; row++)
                {
                    operatingArray[row] = array[line, row];
                }
                temp = CombineNumber(operatingArray);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    resultArray[line, i] = temp[i];
                }
            }
            return resultArray;
        }
        /// <summary>
        /// 右移操作方法
        /// </summary>
        /// <param name="array">输入数组</param>
        /// <returns></returns>
        private static int[,] CtrlRight(int[,] array)
        {
            int[,] resultArray = new int[array.GetLength(0), array.GetLength(1)];
            int[] operatingArray = new int[array.GetLength(1)];
            int[] temp;
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < operatingArray.Length; row++)
                {
                    operatingArray[row] = array[line, row];
                }
                Array.Reverse(operatingArray);
                temp = CombineNumber(operatingArray);
                Array.Reverse(temp);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    resultArray[line, i] = temp[i];
                }
            }
            return resultArray;
        }
        //算法验证
        static void Main()
        {
            int[,] array = new int[4, 4];
            //第一行
            array[0, 0] = 4;
            array[0, 1] = 2;
            array[0, 2] = 4;
            array[0, 3] = 0;
            //第二行
            array[1, 0] = 2;
            array[1, 1] = 2;
            array[1, 2] = 4;
            array[1, 3] = 4;
            //第三行
            array[2, 0] = 2;
            array[2, 1] = 2;
            array[2, 2] = 2;
            array[2, 3] = 2;
            //第四行
            array[3, 0] = 2;
            array[3, 1] = 4;
            array[3, 2] = 2;
            array[3, 3] = 4;
            int[,] result = CtrlUp(array);
            for (int line = 0; line < 4; line++)
            {
                for (int row = 0; row < 4; row++)
                {
                    Console.Write(result[line, row] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
