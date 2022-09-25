//调用工具
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01//定义命名空间
{
    class Program//定义类
    {
        static void Main(string[] args)//Main方法，程序的入口
        {
            //Console(工具).WriteLine(方法)
            Console.WriteLine("请输入枪的名称：");//控制台.写一行("内容");
            String gunName = Console.ReadLine();//定义字符串类型的变量 gunName 并通过控制台的输入给它赋值
            Console.WriteLine("请输入弹匣容量：");
            String magazineCapacity = Console.ReadLine();
            Console.WriteLine("请输入当前弹匣内子弹数量：");
            String bulletCapacity = Console.ReadLine();
            Console.WriteLine("请输入备弹数量：");
            String noAmmunition = Console.ReadLine();
            Console.WriteLine("枪的名称是：" + gunName + "，弹匣容量是：" + magazineCapacity + "，当前弹匣内子弹数量是：" + bulletCapacity + "，备弹数量是：" + noAmmunition);
            Console.ReadLine();//控制台.读一行(); 可临时暂停程序，作用是向控制台输入信息
        }
        static void HelloWorld(string[] args)
        {
            //Console(工具).Title(参数)
            Console.Title = "Hello World!";//向 Title(标题) 参数赋予 Hello World!
            Console.WriteLine("Hello World!");
            string input = Console.ReadLine();
            Console.WriteLine(input);
            Console.ReadLine();
            float number = 1.2f;
            int intAge = 18;
            string gunName = "AK_47";
            Console.WriteLine(gunName);
            Console.WriteLine(number);
            Console.WriteLine(intAge);
            Console.ReadLine();
        }
    }
}
