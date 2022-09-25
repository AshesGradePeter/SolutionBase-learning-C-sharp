using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    class Program
    {
        static void BasicOperator(string[] args)
        {
            //基础运算符的简单使用
            int a = 22, b = 5;
            float c = 20.5f, d = 5.0f;
            int result1 = a / b;//a除以b取商赋予结果1
            int result2 = a % b;//a除以b取余赋予结果2
            float result3 = c / d;
            float result4 = c % d;
            float result5 = a + c;
            float result6 = b - d;
            int result7 = a % 10;//对a取个位数字 2 赋予结果7
            bool result8 = b / 2 == 0;//判断b是否为偶数，偶数赋予结果8为True，奇数赋予False
            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", result1, result2, result3, result4, result5, result6, result7, result8);
            Console.ReadLine();
        }
        static void OtherOperators(string[] args)
        {
            //快捷运算符 修改变量自身值 += *= /= %=
            int a = 1;
            a = a + 1;//同写法为 a += 1; 结果 2
            Console.WriteLine(a);
            //以下代码写法结果同上
            int b = 1;
            b += 1;//变量 b 自身值 +1 结果 2
            Console.WriteLine(b);
            //二元运算符
            //被操作的变量(操作数)为两个的均为二元运算符 eg. int result1 = a / b; 被操作的变量(操作数)为 a 和 b 所以 / 为二元运算符
            //一元运算符 ++ --
            int c = 1;
            c++;//对下一条指令 变量 c 自增1
            Console.WriteLine(c);//在此变量 c 先自增1，然后返回变量 c 的值 结果为2
            int d = 1;
            ++d;//变量 d 先自增1 然后执行下一条指令
            Console.WriteLine(d);//结果为2
            int e = 1;
            Console.WriteLine(e++);//先返回变量 e 的值，然后变量 e 自增1 结果为1
            int f = 1;
            Console.WriteLine(++f);//变量 f 先自增1，然后返回变量 f 的值 结果为2
            Console.WriteLine(e);//先前变量 e 自增了1(31)，所以此处变量 e 的值为2
            //三元运算符 语法："数据类型 变量 = 条件 ? 满足条件赋的值 : 不满足条件赋的值;"  判断是否满足条件并给变量赋予相应的值
            string str = 1 > 2 ? "A" : "B";//判断 1>2 是否成立，显然不成立，所以赋予变量 str 值 B
            Console.WriteLine(str);
            Console.ReadLine();
            //优先级 遵循数学规律 先乘除后加减，有括号先算括号里的
        }
        static void LogicalOperators(string[] args)
        {
            //逻辑运算符 与 && 或 || 非 !  用于控制 bool 类型关系
            //与门 全真为真，一假则假
            bool a = true && true;//真
            bool b = true && false;//假
            bool c = false && true;//假
            bool d = false && false;//假
            //或门 一真为真，全假则假
            bool e = true || true;//真
            bool f = true || false;//真
            bool g = false || true;//真
            bool h = false || false;//假
            //非门 取反值
            bool i = !true;//假
            bool j = !false;//真
            Console.WriteLine("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n{6}\r\n{7}\r\n{8}\r\n{9}", a, b, c, d, e, f, g, h, i, j);
            Console.ReadLine();
        }
        static void ComparisonOperator(string[] args)
        {
            //比较运算符 > < >= <= 等于== 不等于!=
            int a = 10, b = 10;
            bool result9 = a != b;
            bool result10 = a == b;
            string word1 = "我", word2 = "你";
            bool result11 = word1 == word2;//比较字符串是否相等 字符、字符串仅可使用 ==
            Console.WriteLine("{0}\r\n{1}\r\n{2}", result9, result10, result11);// \r\n 换行输出结果 9 10 11
            Console.ReadLine();
        }
        static void Str(string[] args)
        {
            //标准数字格式字符串
            Console.Title = "Day02";
            Console.WriteLine("{0:c}", 10);//以货币格式显示
            Console.WriteLine("{0:d2}", 5);//不足两位前一位补0 05
            Console.WriteLine("{0:f1}", 1.77);//保留小数，四舍六入五凑偶
            Console.WriteLine("{0:p0}", 0.2);//以百分数格式显示
            Console.WriteLine("我爱\"Unity！\"");//转义符 "\" 换行"\r\n" 空字符"\0" Tab"\t"
            Console.ReadLine();
        }
        static void Placeholder(string[] args)
        {
            //占位符的使用
            Console.WriteLine("请输入枪的名称：");
            String gunName = Console.ReadLine();
            Console.WriteLine("请输入弹匣容量：");
            String magazineCapacity = Console.ReadLine();
            Console.WriteLine("请输入当前弹匣内子弹数量：");
            String bulletCapacity = Console.ReadLine();
            Console.WriteLine("请输入备弹数量：");
            String noAmmunition = Console.ReadLine();
            //定义变量 strOut 以指定格式输出
            String strOut = String.Format("枪的名称：{0}，弹匣容量：{1}，当前弹量：{2}，备弹数量：{3}。", gunName, magazineCapacity, bulletCapacity, noAmmunition);
            Console.WriteLine(strOut);//输出变量 strOut 的值
            Console.ReadLine();
        }
        static void DataTypeConversion(string[] args)
        {
            //数据类型的转换
            //Parse转换 只能由 string 类型向其他类型转换
            string str = "18";
            int intAge = int.Parse(str);
            float floatAge = float.Parse(str);
            Console.WriteLine("{0}\r\n{1}", intAge, floatAge);
            //ToString转换 任意类型转换为 string 类型
            string strAge1 = intAge.ToString();
            string strAge2 = floatAge.ToString();
            Console.WriteLine("{0}\r\n{1}", strAge1, strAge2);
            //显式转换(强制转换) 遇到溢出会自动舍弃 byte 二进制代码后八位以外的数，精度损失
            int ia = 100;
            byte ba = (byte)ia;//高转低需要在转后变量前加上需要转的数据类型
            //隐式转换(自动转换)
            byte a = 100;
            int ib = a;
            Console.WriteLine(a);//此时变量 b 为 int 类型，值为100
            short sa = 10;
            short result = (short)(a + sa);//byte + short = int (防止溢出，自动转换为高级别数据类型) 必须显式转换成 short 数据类型
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static void Practise1(string[] args)
        {
            //练习1：数据类型的转换
            //用户输入四位数字，输出每位数字相加的结果
            //方案1 数组
            Console.WriteLine("请输入一个四位数");
            string cinNumber1 = Console.ReadLine();
            char a = cinNumber1[0];//截取字符串中第一个字符 千位
            char b = cinNumber1[1];//百位
            char c = cinNumber1[2];//十位
            char d = cinNumber1[3];//个位
            string a1 = a.ToString();//开始转换数据类型 由 char 型转为 string 型(ToString)
            string a2 = b.ToString();
            string a3 = c.ToString();
            string a4 = d.ToString();
            int aa = int.Parse(a1);//开始转换数据类型 由 string 型转为 int 型(Parse)
            int bb = int.Parse(a2);
            int cc = int.Parse(a3);
            int dd = int.Parse(a4);
            int result1 = aa + bb + cc + dd;//计算
            Console.WriteLine("每位数字相加的结果为" + result1);
            //方案2 取余 写法1 定义新变量
            Console.WriteLine("请输入一个四位数");
            string cinNumber2 = Console.ReadLine();
            int number1 = int.Parse(cinNumber2);//开始转换数据类型 由 string 型转为 int 型(Parse)
            int aaa = number1 % 10;//取余法截取数字 个位
            int bbb = number1 / 10 % 10;//十位
            int ccc = number1 / 100 % 10;//百位
            int ddd = number1 / 1000 % 10;//千位
            int result2 = aaa + bbb + ccc + ddd;//计算
            Console.WriteLine("每位数字相加的结果为" + result2);
            //方案2 取余 写法2 快捷运算符
            Console.WriteLine("请输入一个四位数");
            string cinNumber3 = Console.ReadLine();
            int number2 = int.Parse(cinNumber3);//开始转换数据类型 由 string 型转为 int 型(Parse)
            int result3 = number2 % 10;//取余法截取数字 个位
            result3 += number2 / 10 % 10;//加上十位
            result3 += number2 / 100 % 10;//加上百位
            result3 += number2 / 1000 % 10;//加上千位
            Console.WriteLine("每位数字相加的结果为" + result3);//输出结果
            Console.ReadLine();
        }
        static void Statement(string[] args)
        {
            //语句 选择 循环 跳转
            //选择语句 "if" "else" "else if"
            Console.WriteLine("请输入您的性别：( Man / Woman )");
            string sex = Console.ReadLine();
            if (sex == "Man")//输入的内容满足条件，执行下面括号内语句，跳过 else if 之后的内容，不成立执行else if之后的内容
            {
                Console.WriteLine("Hello Sir!");
            }
            else if (sex == "Woman")//输入的内容既不满足 if 也不满足 if else 的条件，执行 else 之后的内容
            {
                Console.WriteLine("Hello Lady!");
            }
            //else 只属于离他最近上面的 if
            else//输入的内容满足 if  else if 中的一个，这个括号内的不执行
            {
                Console.WriteLine("Sex Unknown!");
            }
            //选择语句 switch case
            //重写练习2(241)
            Console.WriteLine("请输入第一个数：");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入第二个数：");
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符：(+ - * /)");
            string strOp = Console.ReadLine();
            double result;
            switch (strOp)//switch (要判断的变量)
            {
                case "+"://情况1：如果变量 strOp 为 "+" 执行 case 下面的语句，case 后只能加确定的值，不能填写表达式
                    result = num1 + num2;
                    Console.WriteLine("运算结果为：" + result);
                    break;//在此中断执行，跳出 switch
                case "-":
                    result = num1 - num2;
                    Console.WriteLine("运算结果为：" + result);
                    break;
                case "*":
                    result = num1 * num2;
                    Console.WriteLine("运算结果为：" + result);
                    break;
                case "/":
                    if (num2 == 0)//此处仍可嵌套 switch 结构
                    {
                        Console.WriteLine("被除数不能为0！");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine("运算结果为：" + result);
                    }
                    break;
                default://如果要判断的变量不是上述 case 中的，执行下面的语句
                    Console.WriteLine("运算符不正确！");
                    break;
            }
            Console.ReadLine();
        }
        static void Practise2(string[] args)
        {
            //练习2：if else 的使用
            //用户输入两个数，一个运算符，使用该三个操作数运算
            //提取信息
            Console.WriteLine("请输入第一个数：");
            string str1 = Console.ReadLine();
            Console.WriteLine("请输入第二个数：");
            string str2 = Console.ReadLine();
            double num1 = double.Parse(str1);//数据类型的Parse转换(117)
            double num2 = double.Parse(str2);//可以直接写成 double num2 = double.Parse(Console.ReadLine()); 省略第185行
            Console.WriteLine("请输入运算符：(+ - * /)");
            string str3 = Console.ReadLine();
            //逻辑运算并显示结果
            double result = 0;
            if (str3 == "+")
            {
                result = num1 + num2;
                Console.WriteLine("运算结果为：" + result);//可直接写为 Console.WriteLine("运算结果为：" + num1 + num2);
            }
            else if (str3 == "-")
            {
                result = num1 - num2;
                Console.WriteLine("运算结果为：" + result);
            }
            else if (str3 == "*")
            {
                result = num1 * num2;
                Console.WriteLine("运算结果为：" + result);
            }
            else if (str3 == "/")//考虑被除数用户输入为 0 的情况
            {
                if (num2 == 0)
                {
                    Console.WriteLine("被除数不能为0！");
                }
                else
                {
                    result = num1 / num2;
                    Console.WriteLine("运算结果为：" + result);
                }
            }
            else
            {
                Console.WriteLine("运算符不正确！");
            }
            Console.ReadLine();
        }
        static void Practise3(string[] args)
        {
            //练习3：if else 综合使用
            //成绩等级判定 用户输入成绩(百分制)，判定等级
            //90以上(含90) 优秀 80~90(含80) 良好 60~80(含60) 及格 60以下 不及格
            //输入的成绩大于100 小于0 输出成绩有误
            Console.WriteLine("请输入成绩：");
            double score = double.Parse(Console.ReadLine());
            if (score >= 90 && score <= 100)
            {
                Console.WriteLine("您的成绩是优秀！");
            }
            else if (score >= 80 && score < 90)
            {
                Console.WriteLine("您的成绩是良好！");
            }
            else if (score >= 60 && score < 80)
            {
                Console.WriteLine("您的成绩是及格！");
            }
            else if (score < 60 && score >= 0)
            {
                Console.WriteLine("您的成绩是不及格！");
            }
            else if (score > 100 || score < 0)
            {
                Console.WriteLine("成绩有误");
            }
            Console.ReadLine();
        }
        static void Practise4(string[] args)
        {
            //练习4：switch 的用法
            //用户输入一个月份，输出该月多少天(此处2月按28天计算)
            //switch 写法
            Console.WriteLine("请输入一个月份：(数字)");
            int month1 = int.Parse(Console.ReadLine());
            if (month1 >= 1 && month1 <= 12)
            {
                switch (month1)
                {
                    case 2:
                        Console.WriteLine("28天");
                        break;
                    case 4://执行相同代码的对应的 case 可放在一起，可以不用 break
                    case 6://4 6 9 11全都执行 Console.WriteLine("30天");
                    case 9:
                    case 11:
                        Console.WriteLine("30天");
                        break;
                    default:
                        Console.WriteLine("31天");
                        break;
                }
            }
            else
            {
                Console.WriteLine("月份输入错误！");
            }
            //if else写法
            Console.WriteLine("请输入一个月份：(数字)");
            int month2 = int.Parse(Console.ReadLine());
            if (month2 == 1 || month2 == 3 || month2 == 5 || month2 == 7 || month2 == 8 || month2 == 10 || month2 == 12)
            {
                Console.WriteLine("31天");
            }
            else if (month2 == 2)
            {
                Console.WriteLine("28天");
            }
            else if (month2 == 4 || month2 == 6 || month2 == 9 || month2 == 11)
            {
                Console.WriteLine("30天");
            }
            else
            {
                Console.WriteLine("月份输入错误！");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            //综合练习 计算个人所得税 个税计算器
            Console.Title = "个税计算器";
            Console.WriteLine("请输入税前薪资总额：");
            double income = double.Parse(Console.ReadLine());//收入 income
            Console.WriteLine("请输入代缴公积金金额：");
            double providentFund = double.Parse(Console.ReadLine());//公积金 providentFund
            if (income > (3500 + providentFund))
            {
                double taxableIncome = income - providentFund - 3500;//应纳税所得额 taxableIncome
                double pTax = 0;//个人所得税 pTax
                if (taxableIncome <= 1500)
                {
                    pTax = taxableIncome * 0.03;
                }
                else if (taxableIncome > 1500 && taxableIncome <= 4500)
                {
                    pTax = taxableIncome * 0.1 - 105;
                }
                else if (taxableIncome > 4500 && taxableIncome <= 9000)
                {
                    pTax = taxableIncome * 0.2 - 555;
                }
                else if (taxableIncome > 9000 && taxableIncome <= 35000)
                {
                    pTax = taxableIncome * 0.25 - 1005;
                }
                else if (taxableIncome > 35000 && taxableIncome <= 55000)
                {
                    pTax = taxableIncome * 0.3 - 2755;
                }
                else if (taxableIncome > 55000 && taxableIncome <= 80000)
                {
                    pTax = taxableIncome * 0.35 - 5505;
                }
                else if (taxableIncome > 80000)
                {
                    pTax = taxableIncome * 0.45 - 13505;
                }
                Console.WriteLine("您应该缴纳的个人所得税为：" + pTax + "\r\n税后工资为(公积金代扣" + providentFund + "元)：" + (income - providentFund - pTax));
            }
            else if (income < 0)
            {
                Console.WriteLine("输入的钱数不正确！");
            }
            else
            {
                Console.WriteLine("无需缴纳个人所得税！\r\n到手工资为(公积金代扣"+ providentFund + "元)：" + (income - providentFund));
            }
            Console.ReadLine();
        }
    }
}
