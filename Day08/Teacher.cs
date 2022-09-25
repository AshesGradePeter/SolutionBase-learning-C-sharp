using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    class Teacher: Person//类名后 :父类，子类可以继承父类的内容
    {
        public int Money { get; set; }
        //子类继承父类的信息后，父类的私有内容子类可以继承过来，但是不能使用
        //父类 protected 级别的可以在子类中使用
    }
}
