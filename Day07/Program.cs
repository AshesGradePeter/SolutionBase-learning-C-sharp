using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    class Program
    {
        //枚举
        //简单枚举：列举某种数据的所有可能取值
        //语法： enum 枚举名 {值1,值2,值3......}
        //枚举默认数据类型为 int (可以修改数据类型)初始值为 0，以后每一个枚举的值依次递增 1 (可以修改值)
        //对于2048的核心算法
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
        //方法的调用者需要记忆上下左右移动的四个方法
        //通过枚举可以简化调用者的记忆过程
        //观察以下代码
        private static void CommonMove(int[,] array,int moveDirection)
        {
            switch (moveDirection)
            {
                case 0:
                    CtrlUp(array);
                    break;
                case 1:
                    CtrlDown(array);
                    break;
                case 2:
                    CtrlLeft(array);
                    break;
                case 3:
                    CtrlRight(array);
                    break;
            }
        }
        //在调用时：
        static void CommonUseMain()
        {
            //调用上移
            CommonMove(new int[0, 0], 0);
            //调用下移
            CommonMove(new int[0, 0], 1);
            //调用左移
            CommonMove(new int[0, 0], 2);
            //调用右移
            CommonMove(new int[0, 0], 3);
        }
        //由于方法调用者无法与方法设计者沟通，所以无法知道 0 1 2 3 的具体含义，且 0 1 2 3 与移动方向毫无联系，故应用枚举
        //创建枚举标签列表：详见 Day07 内 MoveDirection.cs
        //使用枚举创建方法
        private static void EnumerateMove(int[,] array, MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    CtrlUp(array);
                    break;
                case MoveDirection.Down:
                    CtrlDown(array);
                    break;
                case MoveDirection.Left:
                    CtrlLeft(array);
                    break;
                case MoveDirection.Right:
                    CtrlRight(array);
                    break;
            }
        }
        //在调用时：
        static void EnumerateMain()
        {
            //调用上移
            EnumerateMove(new int[0, 0], MoveDirection.Up);
            //调用下移
            EnumerateMove(new int[0, 0], MoveDirection.Down);
            //调用左移
            EnumerateMove(new int[0, 0], MoveDirection.Left);
            //调用右移
            EnumerateMove(new int[0, 0], MoveDirection.Right);
        }
        //通过枚举，增强了代码的可读性，方便了方法的调用者，也限定了调用者的取值(调用者做选择题)
        //适用性：为了使选择的数与实际方法贴合，应用枚举(CtrlUp = 0 .....)
        //枚举多选
        //定义一个枚举：参见 Day07 中的 PersonalStyle.cs
        //定义一个方法，用于设定个人参数：
        //按位与 &：用于二进制之间的判断，判断二进制之中的每一位字符
        // 0000000000000110 & 0000000000000101 = 0000000000000100
        //两个二进制码中的对应的相同位，只要有一个是 0 ，则输出的二进制码中的对应位是 0 "一 0 则 0"
        private static void Style(PersonalStyle style)
        {
            //输入的值与对应枚举值进行按位与判断，如果判断不是 0，说明传递进此方法的并列内容至少有一项与条件相同
            if ((style & PersonalStyle.height) != 0)
            {
                Console.WriteLine("高个子");
            }
            if ((style & PersonalStyle.sex) != 0)
            {
                Console.WriteLine("男性");
            }
            if ((style & PersonalStyle.weight) != 0)
            {
                Console.WriteLine("苗条");
            }
            if ((style & PersonalStyle.bloodType) != 0)
            {
                Console.WriteLine("A型血");
            }
        }
        //调用方法：
        static void MultipleChoiceEnumerateMain()
        {
            //在对枚举进行多选时，使用运算符 "按位或" "|" 解释参见 Day07 中的 PersonalStyle.cs
            Style(PersonalStyle.bloodType | PersonalStyle.height);
            //枚举的数据类型转换
            //有些情况不清楚枚举的标签，只知道枚举值，可以使用枚举的数据类型转换
            //例如我不知道体重的标签 weight，只知道体重的枚举值为 2
            Style((PersonalStyle)2);//可以强制将 2 转换成对应枚举中的 2 对应的标签
            //枚举是一个数据类型，它可以和任意数据类型做转换
        }
        //类与对象
        //创建一个 "老婆" 类 参见 Day07 中的 Wife.cs
        static void UseClass()
        {
            //使用 "老婆生产器" Wife 类，生产老婆
            //声明 Wife 类型的引用
            Wife wife1;
            //指向 Wife 类型的对象(实例化 Wife 类型的对象)
            wife1 = new Wife();
            //设置老婆
            wife1.SetAge(18);//调用设置年龄的方法
            wife1.SetName("妮露");
            Console.WriteLine(wife1.FunctionName());
            Console.WriteLine(wife1.FunctionAge());
            //可以通过调用字段属性方法创建 "老婆"，属性参见 Day07 中的 Wife.cs (18)
            Wife wife2 = new Wife();
            wife2.Name = "凌华";//调用创建的 Name 属性
            Console.WriteLine(wife2.Name);
        }
        //成员变量 参见 Day07 中的 Wife.cs
        static void Constructor()
        {
            //构造函数：一个用于创建类的对象的函数
            //若一个类没有构造函数，系统将会自动创建一个没有参数的构造函数
            //构造函数语法参见 Day07 中的 Wife.cs
            //在创建一个对象时，将会使用构造函数
            //语法：类名 变量名 = new 构造函数(参数列表);
            //构造函数的作用：
            //在创建对象时，还要调用方法去给参数赋值
            /*
            Wife wife = new Wife();
            wife.Name = "妮露";
            */
            //使用构造函数可以直接将参数传递进去
            Wife wife = new Wife(18,"妮露");
            Console.WriteLine(wife.Name);
            Console.WriteLine(wife.Age);
        }
        //类和对象的练习
        //要求：
        /*
        (1)新建一个敌人的类 Enemy.cs
        (2)敌人拥有名字 血量(0~100)
        (3)定义一个方法，新建 5 个敌人，查找血量最少的敌人，返回他的引用
        */
        private static Enemy FindEnemy(Enemy[] array)
        {
            Enemy lowblood = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (lowblood.Blood > array[i].Blood)
                {
                    lowblood = array[i];
                }
            }
            return lowblood;
        }
        static void FindEnemyMain()
        {
            Enemy[] enemyArray = new Enemy[5];
            enemyArray[0] = new Enemy("Enemy1", 100);
            enemyArray[1] = new Enemy("Enemy2", 20);
            enemyArray[2] = new Enemy("Enemy3", 60);
            enemyArray[3] = new Enemy("Enemy4", 40);
            enemyArray[4] = new Enemy("Enemy5", 80);
            Enemy result = FindEnemy(enemyArray);
        }
        //练习：
        //新建一个类，用于采集用户信息 参见 Day07 内的 User.cs
        //新建一个用户集合类 UserList.cs 用于扩展数组的功能
        //用法：
        /*
        (1)新建一个表： UserList list = new UserList(); 要求表的大小可以写可以不写
        (2)新建用户：list.Add(user1); 
        (3)显示用户信息
        */
        static void PracticeMain()
        {
            UserList userList = new UserList(5);//创建一个储存五个用户信息的表
            userList.Add(new User("妮露","123456"));
            userList.Add(new User("瓦格纳", "1234567"));
            userList.Add(new User("迪娜泽黛", "12345678"));
            userList.Add(new User("提纳里", "123456789"));
            userList.Add(new User("科莱", "1234567890"));
            for (int i = 0; i < userList.count; i++)
            {
                User result = userList.GetUser(i);
                result.PrintUser();
            }
        }
        //介绍 C# 泛型 List<数据类型>
        static void Main()
        {
            //以下代码可以独立使用，不需要调用 UserList 类，与上端代码等效
            //User[] ↓            new User[] ↓
            List<User> userList = new List<User>();//List 本质是一个数组
            userList.Add(new User("妮露", "123456"));
            userList.Add(new User("瓦格纳", "1234567"));
            userList.Add(new User("迪娜泽黛", "12345678"));
            userList.Add(new User("提纳里", "123456789"));
            userList.Add(new User("科莱", "1234567890"));
            for (int i = 0; i < userList.Count; i++)
            {
                User result = userList[i];
                result.PrintUser();
            }
            //介绍 C# 字典集合 通过简介查找内容
            Dictionary <string, User> dic = new Dictionary<string, User>();//创建一本字典，这本字典的用法是通过某个字符串查找 User 数据类型的内容
            //给字典写内容：
            dic.Add("NL",new User("妮露", "123456"));//可以通过 "NL" 来寻找 "妮露"
            User dicresult = dic["NL"];//在字典里找 "NL" 代表什么
        }
    }
}
