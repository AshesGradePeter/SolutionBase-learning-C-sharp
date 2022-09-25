using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2048
{
    /// <summary>
    /// 用户数据类
    /// </summary>
    class User
    {
        //***********字段*******************
        private string loginId;
        //***********属性*******************
        //属性（包含2个方法）
        /// <summary>
        /// 账号
        /// </summary>
        public string LoginId
        {
            get
            { 
                return loginId; 
            }
            set
            { 
                loginId = value; 
            }
        }
        //自动属性（包含1个字段 2个方法）
        /// <summary>
        /// 密码
        /// </summary>
        public string Password 
        { 
            get; 
            set; 
        }
        //***********构造函数******************* 
        public User()
        {

        }
        /// <summary>
        /// 创建一个用户
        /// </summary>
        /// <param name="loginId">账号</param>
        /// <param name="pwd">密码</param>
        public User(string loginId, string pwd)
        {
            this.LoginId = loginId;
            this.Password = pwd;
        }
        //***********方法*******************
        /// <summary>
        /// 在控制台中显示当前用户的账号和密码
        /// </summary>
        public void PrintUser()
        {
            Console.WriteLine("用户名：{0}，密码：{1}。", this.LoginId, Password);
        }
    }
}
