using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    class UserList
    {
        //字段
        private User[] data;
        private int index;//需要操作的索引
        public int count//设置一个公共可读的已经新建用户的个数变量 count
        {
            get
            {
                return index;
            }
        }
        //构造函数
        public UserList()
        {
            data = new User[10];
        }
        /*
        此处等效写法：
        public UserList():this(10)
        {

        }
        */
        public UserList(int capacity)
        {
            data = new User[capacity];
        }
        //方法
        public void Add(User value)//添加用户的方法
        {
            CheckCapacity();//检查是否需要扩容
            data[index++] = value;//将用户输入的值输入数组当前正在操作的索引
        }
        private void CheckCapacity()//检查是否需要扩容的方法
        {
            if (index > data.Length -1)//如果正在操作的索引大于数组内的最后一个位置的索引则进行扩容
            {
                User[] newData = new User[data.Length * 2];
                data.CopyTo(newData,0);
                data = newData;
            }
        }
        public User GetUser(int index)
        {
            return data[index];
        }
    }
}
