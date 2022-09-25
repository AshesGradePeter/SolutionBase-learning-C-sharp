using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    /// <summary>
    /// 创建一个类 类名是 "老婆"
    /// </summary>
    class Wife
    {
        //数据成员：需要用变量去存储的 "名词性" 成员
        //访问级别不写默认是 private，但是最好是写访问级别
        //这是一个抽象的 "老婆" ，不需要对成员赋值(老婆生产器)
        private string name;//字段
        //在 C# 中，可以通过设置属性来保护字段
        //属性：对字段实时保护，仅能实现读写功能，需要在字段下面写
        //语法：
        /*
        [访问级别] 数据类型 属性名
        {
            get {return 字段;}
            set {字段 = value;}
        }
        */
        public string Name//本质是两个方法
        {
            get
            {
                return name;//读取时执行的代码
            }
            set
            {
                this.name = value;//设置时执行的代码 value 就是要传进的参数
            }
        }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                this.age = value;
            }
        }
        //方法成员：行为上的(功能上的) "动词性" 成员
        //以下方法均可通过调用属性实现，调用方法也可实现
        public void SetName(string name)
        {
            this.name = name;//this 指的是数据成员的 name
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
        public string FunctionName()
        {
            return name;
        }
        public int FunctionAge()
        {
            return age;
        }
        //成员变量：定义在方法外，类内的变量为成员变量
        //例如： 17 18 行的 name age
        //特点：
        /*
        (1)具有默认值
        (2)所在类被实例化后储存在堆中(new 以后)，对象被回收后，成员变量从堆中移除
        (3)可以与局部变量重名(局部变量在栈里，成员变量在堆里)，方法内要使用堆中的局部变量加 this
        */
        //构造函数 public 类名(参数列表){}
        //使用构造函数参见 Day07 中的 Program.cs
        public Wife(int age,string name):this()//构造函数调用构造函数需要加 :this(参数) 会根据重载自动调用
        //执行顺序 79 → 86 → 88 → 82 → 83
        {
            this.age = age;//调用者将 age 直接传递给成员变量 age，属性里的代码块不会执行
            this.Name = name;//将 name 传递给属性，属性代码块才会执行
        }
        //构造函数的重载：构造函数仍然可以重载
        public Wife()//创建一个没有参数的构造函数，使之前没加参数的代码不报错
        {
            Console.WriteLine("调用一次这个构造函数，就会看到这句话");
        }
        //如不想在类外创建对象，请将构造函数私有化
        //构造函数本质是一个方法，没有返回值，与类同名，在创建对象时(new时)自动调用，不能手动调用
    }

}
