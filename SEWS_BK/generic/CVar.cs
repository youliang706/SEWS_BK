using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWS_BK.generic
{
    internal class CVar
    {
        private static string _loginid = "";
        private static string _loginpwd = "";
        private static string _username = "";

        static CVar()
        {
            //登录名
            _loginid = "";
            //登录密码
            _loginpwd = "";
            //用户名
            _username = "";
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public static string LoginID
        {
            get { return _loginid; }
            set { _loginid = value; }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public static string LoginPwd
        {
            get { return _loginpwd; }
            set { _loginpwd = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        

    }
}
