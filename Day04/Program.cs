using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    class Program
    {
        //方法重载：方法名称相同，参数列表不同
        //上一天的练习 写方法 根据 分钟 小时 天 计算总秒数
        private static int Time1(int minutes)
        {
            return minutes * 60;
        }
        private static int Time2(int minutes, int hours)
        {
            return Time1(minutes + hours * 60);
        }
        private static int Time3(int minutes, int hours, int days)
        {
            return Time2(minutes, hours + days * 24);
        }
        //弊端：方法使用者想解决同一问题，需要记忆大量的方法(Time1 Time2 Time3)
        //计算不同的数据需要不同的方法，很麻烦
        //例如 Console.WriteLine(); 包含了多种方法，但看起来是一个
        //目的是让调用者在不同条件下，解决同一类问题，仅仅调用一个方法
        //提示：使用他人的方法时，注意看重载列表(有几种用法)
        //做法：将方法名更改成同一个，在调用时会自动根据参数不同，定位到不同的方法
        //1
        private static int Time(int minutes)
        {
            return minutes * 60;
        }
        //2
        private static int Time(int minutes, int hours)//参数由 "," 分隔开
        {
            return Time(minutes + hours * 60);//此处调用的参数只有1个 minute ，所以调用的必定是方法 1
        }
        //3
        private static int Time(int minutes, int hours, int days)
        {
            return Time(minutes, hours + days * 24);//此处调用的参数有2个 minute hours ，所以调用的必定是方法 2 而不是方法 1，也不是自己
        }
        static void Overloading(string[] args)
        {
            //再想计算这个练习所述的相关问题，直接填写不同的参数即可
            int sec1 = Time(1,1,1);//此处填写了3个参数，所以调用的必定是方法 Time 内的第3个方法
            Console.WriteLine(sec1);//输出一分钟 一小时 一天 一共多少秒 90060
            int sec2 = Time(1);//此处填写了1个参数，所以调用的必定是方法 Time 内的第1个方法
            Console.WriteLine(sec2);//输出一分钟有多少秒 60
        }
        //递归：一种算法，方法内部调用自己的过程
        //案例：写一个计算阶乘的方法
        //循环写法：比较麻烦
        private static int GetFactorialC(int number)
        {
            int result = number;
            int a = number;
            for (int i = 0; i < number - 1; i++)
            {
                result *= (a - 1);
                a -= 1;
            }
            return result;
        }
        //递归写法：将问题转移给范围缩小的子问题
        /*
        例如这里算3的阶乘，调用者给变量 number 赋值 3
        程序运行过程：(省略判断的过程)
              ↓ return 3 * GetFactorialR(2);                      ↑ "3 * 2 * 1" → GetFactorialR(3) 将 3 * 2 * 1 返回给 GetFactorialR(3)
        递    ↓            return 2 * GetFactorialR(1);     归    ↑ "GetFactorialR(2);" = "2 * 1" 将 2 * 1 返回给 GetFactorialR(2)
              ↓                       return 1                    ↑ "GetFactorialR(1);" = "1" 将 1 返回给 GetFactorialR(1)
        */
        private static int GetFactorialR(int number)
        {
            if (number == 1) return 1;//判断 number 如果等于 1 就结束递，开始归
            //递：逐层向范围缩小的方向计算，递的过程不会立刻返回数值，等到递结束后通过归来逐层返回数值
            //归：逐层向范围增大的方向返回数值
            return number * GetFactorialR(number - 1);//逐层计算并逐层返回(逐层递，逐层归)
        }
        //递归的适用性：在解决问题时又遇到了相同的问题(能不用就不用)
        //练习：编写一个方法，计算当参数为任意数时，结果为多少？(使用递归算法实现)
        //表达式为：1-2+3-4+5......
        private static int Practise(int number)
        {
            if (number == 1) return 1;//当 number 剩余 1 时停止递
            if (number % 2 == 0)//判断奇数还是偶数
            {
                return Practise(number - 1) - number;//偶数前一个数减偶数
            }
            else
            {
                return Practise(number - 1) + number;//奇数前一个数加奇数
            }
        }
        //数组：一组数据类型相同的变量组合
        //数组创建完毕之后，存放的都是相应数据类型的默认值，需要时再修改
        static void ArrayIntroduce()
        {
            //声明一个数组 a
            int[] a;
            //初始化数组 a  语法：数组名 = new 数据类型[个数];
            a = new int[4];//为数组 a 在内存中开辟 4 块大小为 int 的空间
            //int[] a = new int[4];
            //读写数组时必须通过索引(位置)
            a[0] = 1;//往数组 a 的 0 号位置放数据 1
            a[1] = 2;//往数组 a 的 0 号位置放数据 2
            a[2] = 3;//往数组 a 的 0 号位置放数据 3
            a[3] = 4;//往数组 a 的 0 号位置放数据 4
            //读取数组中的数据时要加上想要读取的位置
            for (int i = 0; i < a.Length; i++)//a.Length 表示数组 a 的长度，这里就是 4
            {
                Console.WriteLine(a[i]);//循环3次，显示 1234
            }
            Console.WriteLine(a[0] + a[1] + a[2] + a[3]);//1 + 2 + 3 + 4 = 10
        }
        //练习：写一个方法录入学生成绩进入数组(百分制)
        //要求：(1)提示请输入学生总数，创建数组
        //      (2)成绩输入有误请重新输入
        private static double[] ScoreArray()//返回值是一个数组，所以返回值类型也应该是数组形式
        {
            Console.WriteLine("请输入学生总数：");
            int studentCount = int.Parse(Console.ReadLine());
            double[] scoreArray = new double[studentCount];//创建一个 double 类型数组，数组长度为 studentCount
            for (int i = 0; i < scoreArray.Length; i++)//循环显示并输入学生成绩，循环次数是学生总数(数组长度)
            {
                Console.WriteLine("请输入第{0}个学生成绩：",i+1);//要提示从第1个学生输入，所以 i 要加1(不加是0)
                double studentScore = double.Parse(Console.ReadLine());
                if (studentScore >= 0 && studentScore <= 100)//判断成绩是否符合规则
                {
                    scoreArray[i] = studentScore;//符合规则往数组内依次录入
                }
                else
                {
                    Console.WriteLine("成绩有误，请重新输入！");
                    i--;//不符合规则将 i 退回重新循环
                    continue;
                }
            }
            return scoreArray;//返回这个数组
        }
        //练习：定义一个查找数组内元素最大值的方法
        private static double GetMaxValue(double[] array)//要求调用者输入的参数是一个数组
        {
            double maxValue = array[0];//假定初始最大值为数组内第一个元素
            for (int i = 1; i < array.Length; i++)//循环进行比较(从数组的第二个元素开始)，循环次数为数组长度(逐个比较)
            {
                if (maxValue < array[i])//将最大值与数组内每个元素进行比较
                {
                    maxValue = array[i];//如果某个元素大于最大值，则将其值赋给变量 maxValue
                }
                else
                {
                    continue;//最大值仍最大将继续循环
                }
            }
            return maxValue;
        }
        static void GetMaxValueMain()
        {
            double[] a = new double[4];//定义一个测试数组 a
            a[0] = 10;
            a[1] = 2;
            a[2] = 235;
            a[3] = 14;
            double value = GetMaxValue(a);//调用方法 GetMaxValue
            Console.WriteLine(value);//得到最大值 235
        }
        //数组的其他写法
        static void OtherArrayWriteWay()
        {
            //对于该数组
            string[] array1 = new string[2];
            array1[0] = "Hello";
            array1[1] = "World!";
            //等效写法1：初始化数组 + 赋值(当定义数组时，已知数组内该放什么，可以直接用该方法)
            string[] array2 = new string[2] {"Hello","World!"};
            //等效写法2：声明 + 初始化 + 赋值(必须一句话全搞定)
            string[] array3 = {"Hello", "World!"};
            //该写法可以快速调用参数为数组的方法 例如：
            double value = GetMaxValue(new double[] { 10, 2, 235, 14 });
            Console.WriteLine(value);//235
            /*
            等效为：
            double[] temp = new double[4] {10,2,235,14};
            double value = GetMaxValue(temp);
            Console.WriteLine(value);
            */
        }
        //练习：定义一个方法，根据年月日确定这是该年的第几天
        //思想：将每月的天数储存到数组之中
        /// <summary>
        /// 判断是否为闰年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private static bool GetLeapYear(int year)
        {
            bool result = (year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0));//闰年给 GetLeapYear 返回 true 平年返回 false
            return result;
        }
        /// <summary>
        /// 根据年月日判断这是该年的第几天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        private static int GetDay(int year,int month,int day)
        {
            int[] normalYear = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };//平年的数组
            int[] LeapYear = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };//闰年的数组
            int days = 0;
            bool yearType = GetLeapYear(year);//调用方法 GetLeapYear 判断平闰年
            if (yearType == true)
            {
                for (int i = 0; i < month - 1; i++)//循环次数应是输入的月份的前一月，本月应该加上天数
                {
                    days += LeapYear[i];//闰年算法
                }
                days += day;//加上本月的天数
            }
            else
            {
                for (int i = 0; i < month - 1; i++)
                {
                    days += normalYear[i];//平年算法
                }
                days += day;
            }
            return days;
        }
        static void Foreach()
        {
            //foreach 循环 遍历
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //正序打印数组内全部元素
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            //倒序打印数组内全部元素
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
            //foreach 从头到尾依次读取数组内的全部元素
            //语法：foreach (数据类型 变量名 in 数组名) { 变量名表示数组内每个元素 }
            //缺点：没有 for 循环读取数组灵活
            //优点：语法使用简单方便(不用去想 for 的各种条件)
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
            //这种读取元素的过程叫做 "遍历"
        }
        static void Var()
        {
            //自动推断类型 var
            //var 数据类型会根据所赋值的类型自动变化，但是声明变量时必须立刻赋值以确定 var 的类型
            //适用情况：数据类型名称过长可以用 var 代替，正常的数据类型最好不要用
            var a = 1;//int a;
            var b = "1";//string b;
            var c = '1';//char c;
            var d = true;//bool d;
            var e = 1.0f;//float e;
            var f = 1.0;//double f;
            Console.WriteLine(a + " " + b + " " + c + " " + d + " " + e + " " + f);
            //泛类
            //定义一个数组，子类对象直接复制给父类，父类是一个泛类
            Array array1 = new int[3];//Array 可以接收 int 类型的数组
            Array array2 = new double[3];//Array 也可以接收 double 类型的数组
            //object 万类之祖 是 int double bool byte Array ....... 的父类
            //声明 object 类型可以赋值任意类型
            object a1 = 1;
            object b1 = "1";
            object c1 = array1;
        }
        //泛类举例：定义一个方法，作用是遍历数组中每一个元素
        private static void ForeachElement(Array array)//此处使用泛类 Array 可以接收所有类型的数组
        {
            foreach (var item in array)//此处使用 var 可以接收数组内的值为任意数据类型的数组
            {
                Console.WriteLine(item);
            }
        }
        static void ArrayFunction()
        {
            //常用数组的方法及介绍：
            /*
            (1)数组长度：数组名.Length
            (2)清除元素值：Array.Clear
            (3)复制元素：Array.copy  数组名.CopyTo
            (4)克隆：数组名.Clone
            (5)查找元素：Array.IndexOf  Array.LastIndexOf
            (6)排序：Arroy.Sort
            (7)反转：Array.Reverse
            */
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 6, 7, 8, 9, 10 };
            string[] array3 = { "a", "b", "c", "d", "e" };
            int[] array4 = { 0, 0, 0, 0, 0 };
            //1 数组名.Length
            int a = array1.Length;//将数组 array1 的长度值 5 赋值给变量 a
            Console.WriteLine(a);//5
            //2 Array.Clear
            Array.Clear(array3,0,2);//清除掉数组 array3 的从 0 号位开始连续两个位置的数据(转化为初始值(string 是 null))
            for (int i = 0; i < array3.Length; i++)
            {
                Console.WriteLine(array3[i]);//null null c d e
            }
            //3 Array.copy  数组名.CopyTo
            Array.Copy(array2,array4,2);//将数组 array2 的前两个位置的数据复制到数组 array4 的前两位
            for (int i = 0; i < array4.Length; i++)
            {
                Console.WriteLine(array4[i]);//6 7 0 0 0
            }
            array2.CopyTo(array4,0);//将数组 array2 的全部元素依次复制到数组 array4 从第 1 位开始之后的位置(数组array4剩余位置必须够长)
            for (int i = 0; i < array4.Length; i++)
            {
                Console.WriteLine(array4[i]);//6 7 8 9 10
            }
            //4 数组名.Clone
            int[] array5 = (int[]) array1.Clone();//将数组 array1 克隆一个新数组 array5 这里需要将 object 类型强制转换成 int 类型
            for (int i = 0; i < array5.Length; i++)
            {
                Console.WriteLine(array5[i]);//1 2 3 4 5
            }
            //5 Array.IndexOf  Array.LastIndexOf
            int[] array6 = { 1, 2, 3, 4, 3 };
            int index1 = Array.IndexOf(array1,2);//查找数组 array1 内 "2" 所在的位置
            Console.WriteLine(index1);//1(从 0 开始数)
            int index2 = Array.LastIndexOf(array6,3);//查找数组 array6 内 "3" 最后出现的位置
            Console.WriteLine(index2);//4
            //6 Arroy.Sort
            int[] array7 = { 10, 5, 2, 3, 1, 8 };
            Array.Sort(array7);//将数组 array7 内元素从小到大排序
            for (int i = 0; i < array7.Length; i++)
            {
                Console.WriteLine(array7[i]);//1 2 3 5 8 10
            }
            //7 Array.Reverse
            Array.Reverse(array1);//将数组内所有元素倒置
            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine(array1[i]);//5 4 3 2 1
            }
        }
        //练习：彩票生成器(双色球玩法)
        //游戏规则：
        /*
        红球号码数：1~33 随机抽 6 个 不能重复
        蓝球号码数：1~16 随机抽 1 个
        号码顺序不限
        */
        //制作以下方法：
        /*
        (1)在控制台中购买彩票的方法
        请输入第一个红球号码：
        ......
        要求：范围不能超过1~33且不能重复
        提示：Array.IndexOf 默认值为 -1
        (2)机选 随机产生一注彩票的方法(中奖号码)
        提示： static Random random = new Random();  放在方法外，类内
               int number = random.Next();  放在方法内
        要求：红球号码不能重复且从小到大排序
        (3)与中奖号码比较的方法并返回中奖等级
        中奖等级：
        一等奖：红6蓝1
        二等奖：红6蓝0
        三等奖：红5蓝1
        四等奖：红5蓝0 红4蓝1
        五等奖：红4蓝0 红3蓝1
        六等奖：红2蓝1 红1蓝1 红0蓝1
        提示：先计算蓝球 红球 中奖数量
        */
        /// <summary>
        /// 买彩票的方法
        /// </summary>
        /// <returns></returns>
        private static int[] BuyLottery()
        {
            int[] lottery = new int[7];//定义一个数组 lottery ，长度为 7 ，目的是储存用户输入的彩票信息
            for (int i = 0; i < 6;)//创建输入所有 "红球" 信息的过程
            {
                Console.WriteLine("请输入第{0}个红球号码(1~33)：", i + 1);
                int redBall = int.Parse(Console.ReadLine());
                int indexValue = Array.IndexOf(lottery,redBall);//判断用户输入的号码变量 redBall 是否已经存在于数组 lottery 中
                //Array.IndexOf();若判断变量不存在于数组中则会返回 -1
                if (indexValue >= 0)//变量存在于数组中或输入的是 int 型数组初始值(0)，则返回以下信息
                {
                    Console.WriteLine("您输入的号码是0或出现重复！");
                    continue;
                }
                else//输入的数不在数组中则进行接下来的判断
                {
                    if (redBall >= 1 && redBall <= 33)//输入的数符合游戏规则
                    {
                        lottery[i] = redBall;//给数组依次写入数值
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("您输入的数字不符合规则！");//不符合规则重新循环
                        continue;
                    }
                }
            }
            for (int i = 0; i < 1;)//创建输入所有 "蓝球" 信息的过程
            {
                Console.WriteLine("请输入蓝球号码(1~16)：");
                int blueBall = int.Parse(Console.ReadLine());
                if (blueBall >= 1 && blueBall <= 16)// 输入的数符合游戏规则
                {
                    lottery[6] = blueBall;//给数组 lottery 最后一位写入蓝球的数值
                    i++;
                }
                else
                {
                    Console.WriteLine("您输入的数字不符合规则！");//不符合规则重新循环
                    continue;
                }
            }
            return lottery;//返回数组 lottery
        }
        /// <summary>
        /// 机器生成中奖号码的方法
        /// </summary>
        static Random random = new Random();
        private static int[] MachineSelection()
        {
            int[] prizeNumber = new int[7];//创建一个用于储存中奖号码的数组 prizeNumber
            for (int i = 0; i < 6;)//进行 6 次循环，用于给数组 prizeNumber 前六位写入数值(红球)
            {
                int redrandomnum = random.Next(1,34);//随机产生 1~33 的数
                int indexValue = Array.IndexOf(prizeNumber, redrandomnum);//判断生成的数字是否存在于数组 prizeNumber 中
                if (indexValue >= 0)
                {
                    continue;//若存在重新循环
                }
                else
                {
                    prizeNumber[i] = redrandomnum;//不存在依次给数组 prizeNumber 写入 6 个数值
                    i++;
                }
            }
            Array.Sort(prizeNumber);//将生成的数在数组中重新由小到大排序
            //由于最后一位是 0(默认值)，重排后 0 会到第一位，所以要将整体向前移位
            prizeNumber[0] = prizeNumber[1];
            prizeNumber[1] = prizeNumber[2];
            prizeNumber[2] = prizeNumber[3];
            prizeNumber[3] = prizeNumber[4];
            prizeNumber[4] = prizeNumber[5];
            prizeNumber[5] = prizeNumber[6];
            int bluerandomnum = random.Next(1, 17);//随机一个蓝球数并写入到数组 prizeNumber 最后一位
            prizeNumber[6] = bluerandomnum;
            return prizeNumber;//返回数组 prizeNumber
        }
        /// <summary>
        /// 比较用户的号码与中奖号码判断奖品等级的方法
        /// </summary>
        /// <param name="userNum">用户号码数组</param>
        /// <param name="prizeNum">中奖号码数组</param>
        /// <returns></returns>
        private static string CompareResult(int[] userNum, int[] prizeNum)
        {
            int redBallCount = 0;//初始化两个计数器，用于记录中奖球的个数
            int blueBallCount = 0;
            int temp = prizeNum[6];//为了不影响红球个数的判断，先将蓝球写入缓存变量 temp
            prizeNum[6] = 0;//暂时清空蓝球数值
            for (int i = 0; i < 6; i++)//循环 6 次判断 6 个红球有几个数与中奖号码匹配
            {
                int indexValue = Array.IndexOf(prizeNum,userNum[i]);
                if (indexValue >= 0)//如果匹配红球数加一
                {
                    redBallCount += 1;
                }
            }
            prizeNum[6] = temp;//返回蓝球号码
            if (userNum[6] == prizeNum[6])//如果蓝球号码与中奖号码相同蓝球数加一
            {
                blueBallCount += 1;
            }
            //判断中奖条件并返回相应的字符串 
            if (redBallCount == 6 && blueBallCount == 1)
            {
                return "一等奖";
            }
            else if (redBallCount == 6 && blueBallCount == 0)
            {
                return "二等奖";
            }
            else if (redBallCount == 5 && blueBallCount == 1)
            {
                return "三等奖";
            }
            else if ((redBallCount == 5 && blueBallCount == 0) || (redBallCount == 4 && blueBallCount == 1))
            {
                return "四等奖";
            }
            else if ((redBallCount == 4 && blueBallCount == 0) || (redBallCount == 3 && blueBallCount == 1))
            {
                return "五等奖";
            }
            else if ((redBallCount == 2 && blueBallCount == 1) || (redBallCount == 1 && blueBallCount == 1) || (redBallCount == 0 && blueBallCount == 1))
            {
                return "六等奖";
            }
            else
            {
                return "未中奖";
            }
        }
        /// <summary>
        /// 彩票用户界面
        /// </summary>
        static void Main()
        {
            Console.WriteLine("欢迎购买彩票");
            int[] userNum = BuyLottery();
            int[] prizeNum = MachineSelection();
            string result = CompareResult(userNum, prizeNum);
            Console.WriteLine(result);
            Console.WriteLine("你的号码是：");
            foreach (var user in userNum)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("中奖号码是：");
            foreach (var prize in prizeNum)
            {
                Console.WriteLine(prize);
            }
            Console.ReadLine();
        }
    }
}
