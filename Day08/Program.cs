using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    class Program
    {
        static void Inherit()
        {
            //继承
            //新建三个类 其中父类 Person.cs 子类 Student.cs Teacher.cs
            //语法参见子类 Student.cs Teacher.cs
            Student student = new Student();
            student.Score = 100;//学生自己的成员可以调用
            student.Name = "妮露";//学生的父类 Person 的成员也可以调用
            Person person1 = new Person();
            //person.Money = 100; 父类不可以调用子类的成员
            //父类型的引用可以指向子类型的引用
            //受类型的影响，声明的父类变量只能引用父类的成员
            Person person2 = new Student();
            //如果需要访问子类成员，需要使用显式强制转换
            Student person3 = (Student)person2;
        }
        //静态 static 见PPT
        //结构和类 类似 具体区别见PPT
        static void Main()
        {

        }
    }
}
