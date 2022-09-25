using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static void ShortCircuitLogic()
        {
            //短路逻辑
            int n1 = 1, n2 = 2;
            bool re1 = n1 > n2 && n1++ > 1;//&& 一假俱假，n1 > n2 判断为假，&& 后不再执行
            Console.WriteLine(n1);//结果为 1
            bool re2 = n1 < n2 || n2++ < 1;//|| 一真则真，n1 < n2 判断为真，|| 后不再执行
            Console.WriteLine(n2);//结果为 2
            Console.ReadLine();
        }
        //语句
        static void ForCirculation()
        {
            //for 循环
            //语法： for (初始值;循环条件;增减变量){循环体}
            //       1 ↓    2 5 ↓  4 ↓
            for (int i = 0; i < 5; i++)//先初始化，然后判断循环条件是否成立，若循环条件成立执行循环体，然后执行增减变量
            {//      3 6 ... ↓
                Console.WriteLine("循环5次，您将会看到5行这句话！");//一旦循环条件不满足，立刻跳出循环体
            }
            for (int i = 0; i <= 6 ; i += 2)
            {
                Console.WriteLine(i);//0 2 4 6
            }
            //例子 作用域 对比两种写法的区别
            int a = 0;
            for (; a <= 10;)
            {
                Console.WriteLine(a);//0 3 6 9
                a += 3;
            }
            Console.ReadLine();
            //下段代码和上段运行结果相同，因为 int a = 0 只执行一次 a += 3 每个循环执行一次
            //区别：上段代码变量 a 是全局变量(仅在此方法里)，for 外可访问，下段代码变量 a 为局部变量，仅可在 for 中使用(变量 a 的作用域不同)
            /*
            for (int a = 0; a <= 10; a += 3)
            {
                Console.WriteLine(a);
            }
            */
            //变量的作用域：从变量声明开始到同一层次的 "}" 结束，例如35行所声明的变量 a 的范围是35行到50行
        }
        static void Practise1()
        {
            //练习1 一张纸的厚度为 0.01mm ，问对折30次之后厚度为多少米？
            double thickness = 0.01;//初始厚度
            for (int i = 1; i <= 30; i++)//折30次
            {
                thickness = thickness * 2;//计算每折一次的厚度
                //thinkness *= 2;
            }
            Console.WriteLine(thickness / 1000 + "米");//输出并换算单位
            //练习2 累加 1到100的和 5050
            int sum1 = 0;//声明一个累加变量 sum1
            for (int i = 1; i <= 100; i++)//每次循环变量 i 都加一
            {
                sum1 = sum1 + i;//把每次的变量 i 加到累加变量 sum1 里
                //sum1 += i;
            }
            Console.WriteLine(sum1);//输出结果
            //练习3 跳过并继续循环 1到100能被3整除的数的和 1683
            int sum2 = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 != 0) continue;//continue 的作用是如果满足 if 的条件将结束本次循环并继续下次循环(参见跳转语句)
                sum2 = sum2 + i;
            }
            Console.WriteLine(sum2);
            Console.ReadLine();
        }
        static void WhileCirculation(string[] args)
        {
            //while 当型循环
            //语法：while(条件){循环体} 满足条件执行循环体，不满足跳出循环
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine("看见五次这句话！");
                i++;
            }
            Console.ReadLine();
        }
        static void Practise2()
        {
            //练习3：一个小球从 100m 高度落下，每次弹起高度是原来的一半
            //问：(1)小球弹起了多少次？(离地面高度 0.01m 时算落地)
            //问：(2)球落地前经过了多少米？落地了几次？
            int times = 0;//累计弹起的次数
            float distance = 0;//累计经过的距离
            float high = 100;//初始高度
            while (high / 2 >= 0.01)//当弹起之后的高度大于等于 0.01m 时，进入循环再弹一次
            {
                distance = distance + high;//计算下落高度
                high /= 2;//每弹一次高度减半
                times++;
                distance = distance + high;//计算回弹高度
                Console.WriteLine("第{0}次弹起到最高点经过的距离为{1}m，距离地面高度{2}m",times,distance,high);
            }
            Console.WriteLine("小球一共弹起了{0}次最终落地\r\n经过了{1:0}m的距离\r\n落地次数为{2}次",times,distance,(times + 1));//距离保留至整数
            Console.ReadLine();
        }
        static void doWhile()
        {
            //do while 循环
            //语法：do{循环体}while(条件);
            //先执行一次循环体，判断条件是否成立，成立继续循环，不成立跳出循环
            //猜数字 产生一个随机数 1~100 让用户输入数字
            //提示 "大了" "小了" "猜对了"，并记录一共猜了多少次
            Random random = new Random();//创建一个随机数方法 random
            int number = random.Next(1,101);//生成一个随机数，范围是 1~100(Next 后为左闭右开区间)
            int times = 0;//累计猜的次数
            int cinNum;
            do
            {
                Console.WriteLine("请输入一个 1~100 的整数");
                string strNum = Console.ReadLine();
                cinNum = int.Parse(strNum);//上面已经声明过了变量 cinNum
                //cinNum = int.Parse(Console.ReadLine());
                if (cinNum < 0 || cinNum > 100)
                {
                    Console.WriteLine("您输入的数字不符合游戏规则！");
                }
                else if (cinNum > number)
                {
                    Console.WriteLine("大了");
                    times++;
                }
                else if (cinNum < number)
                {
                    Console.WriteLine("小了");
                    times++;
                }
            } while (cinNum != number);//猜错了重新循环，猜对了跳出循环
            times++;//最后猜的一次也要算上
            Console.WriteLine("猜对了！您一共猜了{0}次",times);
            Console.ReadLine();
        }
        //此为一个方法，命名为 "JumpStatement" ，含义是这个方法集合里写的是关于跳转语句的内容
        static void JumpStatement()
        {
            //跳转语句 break continue(74) return goto
            //将控制转移给另一段代码
            //改写上段代码，使用 break 跳出循环
            Random random = new Random();
            int number = random.Next(1, 101);
            int times = 0;
            int cinNum;
            while (true)//建立死循环
            {
                times++;
                Console.WriteLine("请输入一个 1~100 的整数");
                cinNum = int.Parse(Console.ReadLine());
                if (cinNum > number)
                {
                    Console.WriteLine("大了");
                }
                else if (cinNum < number)
                {
                    Console.WriteLine("小了");
                }
                else
                {
                    Console.WriteLine("猜对了！您一共猜了{0}次", times);
                    break;//此为跳转语句，目的是跳出死循环(猜对了就离开，猜错了接着死循环)
                }
            }
            Console.ReadLine();
        }
        //方法
        static void UseFun()
        {
            //方法：一段代码的集合，将一段代码封装并起一个名字，需要的时候去调用执行(147)
            //定义方法(做功能)
            /*
            [访问修饰符] [可选修饰符] 返回值类型 方法名称(参数列表)
            {
                方法体
                return 结果;
            }
            */
            //调用无返回值方法(用功能)
            //语法：方法名称(参数);
            //例如我想在这里玩猜数字游戏
            doWhile();      
        }
        //返回值：功能(方法)执行结束后的结果(方法定义者告诉方法调用者的结果)
        //类型：指数据类型 int byte float......
        //返回值类型：返回值的数据类型，如果返回值类型写 void 则没有返回值不用写 return
        private static int Function1()//表示定义一个私有的静态方法，返回值需要是整型(int)，名字是 "Function1"
        {
            Console.WriteLine("Hello World!");
            return 0;//返回值是整型(int)数字 "0",返回值必须与返回值类型兼容
            Console.WriteLine("Goodbye World!");//该行之前已经使用跳转语句 return 跳出方法，故该方法内 return 之后的语句等于没有
        }
        //传递参数
        //参数：方法制作者要求方法使用者提供的数据(调用时括号内的内容)
        private static void Function2(int a,string b)//此处的参数变量 a b 叫形式参数(实际上暂时没有值的参数)
        {
            //该方法在调用时(Main中调用)，变量 a 和 b 已经被赋值，以下可以直接使用
            Console.WriteLine(a + b);//结果是 "1Hello World"
        }
        static void ReturnNum()
        {
            //调用有返回值方法
            //语法：数据类型 变量 = 方法名称(参数); 数据类型需要与返回值数据类型兼容
            //例如调用上端自定义的方法 "Function1"
            int x = Function1();//变量 x 会被赋予方法 "Function1" 执行后的返回值 0
            Console.WriteLine(x);//结果 0
            //有返回值的方法也可直接舍弃掉返回值直接调用，使用与否看自己，取决于是否有变量来接收它
            Function1();
            //传递参数：在第207行定义一个方法，参数设定一个整型变量 a 一个字符串变量 b
            //在调用方法 "Function2" 时，参数使用者直接设定该参数的值并直接传递到该方法(Function2)内进行使用
            Function2(1,"Hello World");//此处将第207行的变量 a 和 b 直接设定为 "1" 和 "Hello World"，设定时必须与定义的方法内参数相兼容，此时设置的参数叫实际参数
            return;//无返回值(void)的方法也可以用 return ,但不能给 return 添值，作用是退出方法
        }
        /*
        学会调用其他人制作的方法
        (1)看名字猜这个方法实现的是什么功能，看该方法的描述。
        (2)看参数(类型，名称，描述)。
        (3)看是否有返回值，返回值是什么类型。
        (4)自己测试用法。
        */
        //练习：制作一个两个数相加的方法
        private static double NumAdd(double a,double b)
        {
            double result = a + b;
            return result;
        }
        //综合练习：万年历生成器 制作一个在控制台输入一个年份，显示一年的日历
        /// <summary>
        /// 根据年月日计算星期数
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>星期</returns>
        private static int GetWeekByDay(int year,int month,int day)
        {
            DateTime dt = new DateTime(year, month, day);
            return (int)dt.DayOfWeek;
        }
        /// <summary>
        /// 判断一个年份是否为闰年
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>true为闰年，false为平年</returns>
        private static bool GetLeapYear(int year)
        {
            bool result = (year % 400 == 0) || ((year % 4 == 0) && (year % 100 != 0));//闰年给 GetLeapYear 返回 true 平年返回 false
            return result;
        }
        /// <summary>
        /// 给定年份和月份确定该月有多少天
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>天数</returns>
        private static int GetDays(int year, int month)
        {
            //这个方法根据不同月份返回不同的整型值来确定天数
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return 31;//给 GetDays 返回值 31
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                return 30;
            }
            else if (month == 2)
            {
                bool days = GetLeapYear(year);//调用 GetLeapYear 方法，确定是否为闰年，是闰年给变量 days 赋值 true
                if (days == true)
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
            return 0;//所有阶段必须给返回值，此方法不会执行到这里，所以此处随意设置返回值
        }
        /// <summary>
        /// 生成任意月历
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        private static void MonthlyCalendar(int year,int month)
        {
            //生成表头
            Console.WriteLine(year + "年" + month + "月");
            Console.WriteLine("\r\n");
            Console.WriteLine("日\t一\t二\t三\t四\t五\t六\r\n");
            int day = 1;//此处的给 day 初始化的值 1 代表获取某月的第1天的星期数
            int week = GetWeekByDay(year, month, day);//调用 GetWeekByDay 方法，将某月第1天的星期数赋值给变量 week
            int days = GetDays(year, month);//调用 GetDays 方法，确定某年某月的天数，赋值给变量 days
            int leftdays = 7 - week;//计算第1周除去空星期剩余几天
            for (int i = 0; i < week; i++)//生成第一周的空星期
            {
                Console.Write("\t");
            }
            int nextDay = 1;//记录第二星期从哪一天开始
            for (int i = 1; i <= leftdays; i++)//生成第一星期
            {
                Console.Write(i + "\t");
                nextDay += 1;
            }
            Console.WriteLine("\r\n");//第一星期生成完毕换行
            leftdays = 7;//初始化换行计数器
            for (int i = nextDay; i <= days; i++)//开始生成剩余星期
            {
                Console.Write(i + "\t");
                leftdays -= 1;//每生成一天换行计数器减 1
                if (leftdays == 0)//当换行计数器归零时重置计数器并换行然后继续生成
                {
                    leftdays = 7;
                    Console.WriteLine("\r\n");
                    continue;
                }
                else//计数器没归零继续生成
                {
                    continue;
                }
            }
            Console.WriteLine("\r\n");
        }
        /// <summary>
        /// 生成年历
        /// </summary>
        /// <param name="year">年</param>
        private  static void AnnualCalendar(int year)
        {
            int month = 1;//从1月开始生成
            for (int i = 0; i < 12; i++)
            {
                MonthlyCalendar(year,month);//调用 MonthlyCalendar 方法循环12次
                month++;
                Console.WriteLine("\r\n");
            }
        }
        /// <summary>
        /// 万年历程序入口
        /// </summary>
        static void Main1()
        {
            Console.Title = "万年历生成器";
            Console.WriteLine("请输入想要生成的年份：");
            int year = int.Parse(Console.ReadLine());
            AnnualCalendar(year);
            Console.ReadLine();
        }
        //练习 写以下三个方法
        //(1)根据分钟数计算总秒数
        //(2)根据分钟数 小时数 计算总秒数
        //(3)根据分钟数 小时数 天数 计算总秒数
        //用户输入数据后计算总秒数
        private static int Time1(int minutes)//分钟转化成秒
        {
            return minutes * 60;
        }
        private static int Time2(int minutes,int hours)//小时转化成分钟
        {
            return Time1(minutes + hours * 60);
        }
        private static int Time3(int minutes,int hours,int days)//天转化为小时
        {
            return Time2(minutes, hours + days * 24);
        }
        static void Main()
        {
            Console.WriteLine("请输入分钟数：");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入小时数：");
            int hours = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入天数：");
            int days = int.Parse(Console.ReadLine());
            int result = Time3(min,hours,days);
            Console.WriteLine("一共{0}秒",result);
            Console.ReadLine();
        }
    }
}
