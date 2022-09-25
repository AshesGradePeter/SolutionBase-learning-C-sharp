using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    class Program
    {
        static void JaggedArray()
        {
            //交错数组
            /*
            交错数组的概念：一些一维数组的集合，每一个一维数组是交错数组的元素
            类似：(不规则的表格)
            0   [1] [ ] [ ] [ ]
            1   [ ] [2] [ ]
            2   [ ] [ ] [3] [ ]
            3   [4]
            4   [ ] [5]
            每一行都是一个一维数组，该交错数组包含 5 个元素，每一个元素都是一个一维数组
            */
            //声明交错数组： 数据类型[][] 数组名 = new 数据类型[元素数][];
            int[][] array = new int[5][];//声明了一个 5 个元素 int 类型的交错数组 array
            array[0] = new int[4];//给交错数组 array 第 1 个位置赋值一个一维数组，这个一维数组包含四个元素
            array[1] = new int[3];
            array[2] = new int[4];
            array[3] = new int[1];
            array[4] = new int[2];
            array[0][0] = 1;//给交错数组 array 的第 0 个元素的一维数组内的第 0 的位置赋值 1
            array[1][1] = 2;
            array[2][2] = 3;
            array[3][0] = 4;
            array[4][1] = 5;
            //使用 foreach foreach遍历交错数组
            foreach (int[] item in array)//先遍历交错数组里的一维数组
            {
                foreach (int element in item)//再遍历一维数组的元素
                {
                    Console.WriteLine(element);
                }
            }
            //使用for for 遍历交错数组
            for (int e = 0; e < array.Length; e++)//一共循环交错数组中，一维数组个数次
            {
                for (int i = 0; i < array[e].Length; i++)//每次循环遍历当前循环的一维数组中每一个元素
                {
                    Console.Write(array[e][i]);
                }
                Console.WriteLine();
            }
        }
        //参数数组 parmas
        //对于方法内部而言，就是个普通数组
        //对于方法外部(方法调用者)而言，传递参数时，可以传递数组，也可以传递一组数据类型相同的数据集合，甚至可以不传递
        //例如 定义一个整数相加的方法
        private static int IntAdd(params int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            return sum;
        }
        //调用时
        static void IntAddMain()
        {
            //传递数组调用
            int result1 = IntAdd(new int[] { 1, 2, 3, 4 });
            Console.WriteLine(result1);//10
            //传递相同数据类型集合调用
            int result2 = IntAdd(1, 2, 3, 4);
            Console.WriteLine(result2);//10
            //对于参数数组 params int[] array 两种方法等效
        }
        //参数数组的作用：简化调用者在调用方法时的代码
        //数据类型
        /*
                                        数值类型：int double float.....
                                结构    bool
                                        char
                    值类型-------------------------------------------

                                枚举

        数据类型------------------------------------------------

                                接口

                    引用类型-----------------------------------------
                                        string
                                类      Array
                                        委托
        */
        //栈和堆
        /*
        栈：内存中申请的一块小空间(Windows系统中通常为1Mb)，用于临时存放值类型，使用完毕后立即被释放
        堆：内存中申请的一块大空间，用于存放引用类型
        */
        static void LocalVariable()
        {
            //局部变量：定义在方法内部的变量
            //特点：没有初始值，必须自行设定初始值，否则不能使用
            //局部变量在调用时，会被储存在栈中，方法调用完毕会被清除
            //值类型声明在栈中，数据存在栈中
            //引用类型声明在栈中，数据存在堆中
            int number = 0;//number 是一个局部变量(内存地址)，只能在此方法中使用，"number" "0"都在栈中
            int[] array = { 1, 2, 3 };//"array" 在栈中 "1, 2, 3" 在堆中，"array" 在栈中存储的是 "1, 2, 3" 的地址
            Console.WriteLine(number);
            //方法执行在栈中，方法内部声明的变量都在栈中
        }
        static void Address()
        {
            int a = 1;
            int b = a;
            a = 2;
            Console.WriteLine(b);//1
            int[] array1 = { 1 };
            int[] array2 = array1;//将 array1 的内存地址赋给 array2，此时 array2 和 array1 同地址
            array1[0] = 2;
            Console.WriteLine(array2[0]);//2
            Console.WriteLine(array1[0]);//2
            //对于数组，若加了索引，则修改的是堆内的数据(索引对应的元素)，未加索引(数组名)，则修改的是栈内的数据(数据的内存地址)
            string str1 = "A";
            string str2 = str1;
            str1 = "B";//此处修改的是 str1 中栈的内存地址(新在堆中创建的数据 B 的内存地址)
            Console.WriteLine(str2);//A
            Console.WriteLine(str1);//B
            //对于字符串类，堆中已经新建的元素不能修改，它是只读的，只能新建元素并更改引用的内存地址
            //练习： 输出的结果为多少？(object 是引用数据类型)
            object obj1 = 1;
            object obj2 = obj1;
            obj1 = 2;
            Console.WriteLine(obj2);//1
        }
        //引用类型通过堆栈原理进行优化
        //调用方法时传递的参数为引用类型时，不需要传出返回值，因为数据已经在堆内更改，栈内所引用的内存地址没有变化
        //例如：给数组内数据排序的方法
        private static double[] ArraySort1(double[] array)
        {
            int count;
            double temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                count = i;
                for (int a = 0; a < array.Length - (i + 1); a++)
                {
                    count += 1;
                    if (array[i] > array[count])
                    {
                        temp = array[i];
                        array[i] = array[count];
                        array[count] = temp;
                    }
                }
            }
            return array;
        }
        //优化后：
        private static void ArraySort2(double[] array)
        {
            int count;
            double temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                count = i;
                for (int a = 0; a < array.Length - (i + 1); a++)
                {
                    count += 1;
                    if (array[i] > array[count])
                    {
                        temp = array[i];
                        array[i] = array[count];
                        array[count] = temp;
                    }
                }
            }
        }
        static void TestArraySortMain()
        {
            double[] array = { 3, 1, 0, 2, 1, 5, 0 };
            double[] result = ArraySort1(array);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //优化前后所生成的结果相同
            ArraySort2(array);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        //传入的参数是数组 array 的引用(内存地址)，故没有必要添加返回值
        //练习：去掉返回值 优化2048核心算法代码
        private static void MoveZero(int[] array)
        {
            int[] afterMoveZeroArray = new int[array.Length];
            int noZeroPosition = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    afterMoveZeroArray[noZeroPosition++] = array[i];
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = afterMoveZeroArray[i];
            }
        }
        private static void CombineNumber(int[] array)
        {
            MoveZero(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    array[i] += array[i + 1];
                    array[i + 1] = 0;
                }
            }
            MoveZero(array);
        }
        private static void CtrlUp(int[,] array)
        {
            int[] operatingArray = new int[array.GetLength(0)];
            for (int row = 0; row < array.GetLength(1); row++)
            {
                for (int line = 0; line < operatingArray.Length; line++)
                {
                    operatingArray[line] = array[line, row];
                }
                CombineNumber(operatingArray);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[i, row] = operatingArray[i];
                }
            }
        }
        private static void CtrlDown(int[,] array)
        {
            int[] operatingArray = new int[array.GetLength(0)];
            for (int row = 0; row < array.GetLength(1); row++)
            {
                for (int line = 0; line < operatingArray.Length; line++)
                {
                    operatingArray[line] = array[line, row];
                }
                Array.Reverse(operatingArray);
                CombineNumber(operatingArray);
                Array.Reverse(operatingArray);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[i, row] = operatingArray[i];
                }
            }
        }
        private static void CtrlLeft(int[,] array)
        {
            int[] operatingArray = new int[array.GetLength(1)];
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < operatingArray.Length; row++)
                {
                    operatingArray[row] = array[line, row];
                }
                CombineNumber(operatingArray);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[line, i] = operatingArray[i];
                }
            }
        }
        private static void CtrlRight(int[,] array)
        {
            int[] operatingArray = new int[array.GetLength(1)];
            for (int line = 0; line < array.GetLength(0); line++)
            {
                for (int row = 0; row < operatingArray.Length; row++)
                {
                    operatingArray[row] = array[line, row];
                }
                Array.Reverse(operatingArray);
                CombineNumber(operatingArray);
                Array.Reverse(operatingArray);
                for (int i = 0; i < operatingArray.Length; i++)
                {
                    array[line, i] = operatingArray[i];
                }
            }
        }
        static void TestMain()
        {
            int[,] array = new int[4, 4];
            //第一行
            array[0, 0] = 4;
            array[0, 1] = 2;
            array[0, 2] = 2;
            array[0, 3] = 2;
            //第二行
            array[1, 0] = 2;
            array[1, 1] = 2;
            array[1, 2] = 2;
            array[1, 3] = 4;
            //第三行
            array[2, 0] = 4;
            array[2, 1] = 4;
            array[2, 2] = 2;
            array[2, 3] = 2;
            //第四行
            array[3, 0] = 0;
            array[3, 1] = 4;
            array[3, 2] = 2;
            array[3, 3] = 4;
            CtrlUp(array);
            for (int line = 0; line < 4; line++)
            {
                for (int row = 0; row < 4; row++)
                {
                    Console.Write(array[line, row] + "\t");
                }
                Console.WriteLine();
            }
        }
        //C# 参数的三种类型
        private static void Function1(int element,int[] array)
        {
            Console.WriteLine();
        }
        private static void Function2(ref int a)//引用参数前要在形参前加 ref
        {
            //方法内部修改引用参数，实质上就是在修改引用变量
            a = 2;
        }
        private static void Function3(out int a)//输出参数前要在形参前加 out
        {
            a = 2;
        }
        static void ParameterType()
        {
            //值参数：按值传递的参数(传递实参变量所储存的内容)
            int element1 = 1;//实参变量 element 存储的是数值 1
            int[] array = new int[] { 1, 2, 3 }; //实参数组 array 存储的是 "{ 1, 2, 3 }" 的内存地址
            Function1(element1,array);//给方法 Function 所传递的都是实参变量的值
            //引用参数：传递实参变量自身的内存地址
            Function2(ref element1);//调用需要传递引用参数的方法时，也需要相应的加上 ref
            Console.WriteLine(element1);//2
            //方法 Function2 依照实参的内存地址，将实参修改
            //输出参数：传递实参变量自身的内存地址
            int element2 = 1;
            Function3(out element2);//调用需要传递输出参数的方法时，也需要相应的加上 out
            Console.WriteLine(element2);//2
            //引用参数和输出参数的区别
            /*
            (1)输出参数方法内部必须要给参数赋值
            (2)输出参数传递到方法内部之前可以不给参数赋值(参数是用来接收方法的结果)
            */
            //作用：
            //输出参数：返回结果，充当返回值
            //引用参数：改变数据(传递进去的变量随着方法内该参数而变化)
            //值参数：传递信息
        }
        //练习1：定义一个两个整数交换的方法
        //练习2：定义一个根据长和宽，计算矩形周长和面积的方法
        private static void ExChangeNumber(ref int a,ref int b)//参数 a b 作为引用参数输入到方法 ExChangeNumber 中
        {
            //此时修改的变量 a b 等同于修改实参的值
            int temp = a;
            a = b;
            b = temp;
        }
        private static double SoluteRectangle(double longSide,double widthSide,out double area)
        {
            double perimeter = 2 * (longSide + widthSide);
            area = longSide * widthSide;//输出参数 area 会直接赋值给调用此方法的方法中的变量 area
            return perimeter;
        }
        static void PractiseMain()
        {
            int a = 1, b = 2;
            ExChangeNumber(ref a, ref b);
            Console.WriteLine(a + " " + b);
            Console.WriteLine();
            double area;
            Console.WriteLine("请输入矩形的长：");
            double longSide = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入矩形的宽：");
            double widthSide = double.Parse(Console.ReadLine());
            double perimeter = SoluteRectangle(longSide,widthSide,out area);
            Console.WriteLine("矩形的周长是：{0}\t矩形的面积是：{1}",perimeter,area);
        }
        static void Box()
        {
            //拆装箱
            int a = 1;
            //装箱操作：相对值类型传入值类型 "比较" 消耗性能
            object o = a;
            //装箱：值类型隐式转换成 object 类型
            /*
            运行机制：
            (1)在堆内存中开 3 块空间
            (2)将值类型数据移动至堆的其中一块空间中
            (3)返回堆中新分配的内存地址
            */
            //拆箱操作 "比较" 消耗性能
            int b = (int)o;
            //拆箱：object 类型显式转换成值类型
            /*
            运行机制：
            (1)判断给定类型是否是装箱时的类型
            (2)返回已装箱的实例中属于原值类型字段的地址
            */
            //由于拆装箱比较消耗性能，所以在实际编程中应避免频繁进行拆装箱操作(值类型转化为 object 类型)
            //形参为 object 类型，实参传递为值类型则装箱，写方法时可通过方法的重载来避免
            int number = 0;
            //以下两种方法都可以将 number 转化成 string 类型，但第一种存在拆装箱影响性能
            string str1 = number + "";//实质调用了 string.Concat 方法，内部存在 object 类型转换，存在拆装箱
            string str2 = number.ToString();
        }
        static void StringType()
        {
            //对于 string 类型
            string str1 = "A";
            string str2 = "A";
            bool result1 = object.ReferenceEquals(str1,str2);//此方法用于判断字符串是否是同一个
            string str3 = new string(new char[] { 'A' });
            string str4 = new string(new char[] { 'A' });
            bool result2 = object.ReferenceEquals(str3, str4);
            Console.WriteLine(result1);//true
            //字符串的内容相同，则它们是同一个字符串(引用也相同)
            Console.WriteLine(result2);//false
            //new string 后的字符串不是同一个
            //字符串池：在创建字符串时，系统会先判断字符串池内是否有相同的字符串，如果有则会直接返回引用
            //字符串的不可变性：字符串在堆中创建完毕后不能再更改，只能新建传回新地址，原因是前一次新建的空间大小可能装不下新的字符串(破坏原有结构)
            //可变字符串： StringBuilder 可以在原有空间修改内容
            string str = "";
            for (int i = 0; i < 10; i++)
            {
                str += i.ToString();//每次进行字符串拼接都会产生一个垃圾，拼接次数越多将会产生垃圾越多，影响性能
            }
            Console.WriteLine(str);
            //使用 StringBuilder 拼接
            StringBuilder strBuilder = new StringBuilder(10);//一次开辟可以容纳 10 个字符大小的空间，不填是默认值
            for (int i = 0; i < 10; i++)
            {
                strBuilder.Append(i);//每次拼接字符用 Append
            }
            strBuilder.Append(11);//预先开辟的空间不足的情况下，原有的空间变为垃圾，生成新的空间存储
            string result = strBuilder.ToString();
            Console.WriteLine(result);
            //StringBuilder 在执行时会在堆中新建一块较大的空间，每次拼接将会在原有的空间中修改
            //优点：不产生垃圾，优化性能(预先开辟的空间足够的情况下)
            //缺点：预先开辟的空间不足仍会产生垃圾，预先设定的大小应准确
            //适用性：需要对字符串频繁的进行操作(增加，替换，移除)可以定义 StringBuilder 字符串，以免产生垃圾            
        }
        static void StringFunction()
        {
            //字符串常用实用功能：
            /*
            (1)ToArray
            (2)Insert
            (3)Contains
            (4)ToUpper
            (5)Substring
            (6)Split
            (7)string.Join
            (8)ToLower
            (9)IndexOf
            (10)Trim
            (11)Replace
            */
            //(1)ToArray：将字符串中的每个字符存入一个字符型数组
            string str = "ABC DEF GHI";
            string lowerCase = "abc";
            char[] charArray = str.ToArray();
            //存入的字符型数组为：[A] [B] [C] [ ] [D] [E] [F] [ ] [G] [H] [I]
            //(2)Insert(前几天演示过)：在字符串内插入新的字符串
            //(3)Contains(前几天演示过)：查找某段字符串是否出现在目标字符串中
            //(4)ToUpper：将小写字母转换成大写字母
            string upper = lowerCase.ToUpper();
            Console.WriteLine(upper);//ABC
            //(5)Substring：提取目标字符串从指定索引开始之后的字符串
            string result1 = str.Substring(2);
            Console.WriteLine(result1);//C DEF GHI
            //(6)Split：根据参数中的字符，将目标字符串分割成多个小字符串储存在数组中不同的位置中
            string[] strArray = str.Split('D','F');
            //存入的字符串型的数组为： [ABC ] [E] [ GHI]
            //用于分隔的字符不会存入
            //(7)string.Join：使用指定的连接字符连接若干个字符串
            string result2 = string.Join("-","a","b","c");
            Console.WriteLine(result2);//a-b-c
            //(8)ToLower：将大写字母转换成小写字母
            string lower = str.ToLower();
            Console.WriteLine(lower);//abc def ghi
            //(9)IndexOf(前几天演示过)：查找目标字符串中是否有指定字符：如果有返回索引，没有返回 -1
            //(10)Trim：删除字符串中开头的空格和结尾的空格
            string result3 = str.Trim();
            Console.WriteLine(result3);
            //(11)Replace(前几天演示过)：把目标字符串中指定的字符，替换成新的指定的字符
        }
        //练习：定义如下方法，使用字符串的功能实现以下问题
        //1.单词反转 例如：How old are you → you are old How
        //2.字符反转 例如：How are you → uoy era woH
        //3.查找指定字符串中不重复出现的文字(重复的文字保留一个)，要求尽可能不产生垃圾
        //(1)
        private static string WordInversion(string str)
        {
            string[] strArray = str.Split(' ');
            Array.Reverse(strArray);
            return string.Join(" ", strArray);
        }
        //(2)利用可变字符串可以不产生垃圾
        private static string CharInversion(string str)
        {
            char[] charArray = str.ToArray();
            Array.Reverse(charArray);
            StringBuilder builder = new StringBuilder(charArray.Length);
            for (int i = 0; i < charArray.Length; i++)
            {
                builder.Append(charArray[i]);
            }
            return builder.ToString();
        }
        //(3)
        private static string RemoveDuplicateText(string str)
        {
            StringBuilder builder = new StringBuilder(str.Length);
            foreach (char c in str)//使用 foreach 遍历字符串 str 中的每一个字符
            {
                //如果当前正在遍历的字符不存在于可变字符串中，就把正在遍历的字符放进去
                if (builder.ToString().IndexOf(c) == -1)//先将 builder 转化成字符串，再进行比较
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
        static void Main()
        {
            string str = "ABBCBA";
            string result = RemoveDuplicateText(str);
            Console.WriteLine(result);
        }
    }
}
