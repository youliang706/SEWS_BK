using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Web;
using Com.Database;
using Com.Register;
using System.Text;
using SEWS_BK.generic;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace SEWS_BK
{
    //定义委托
    public delegate void DataChangedEvevt(int editType, object id);

    static class Program
    {

        //全局数据库处理对象
        public static CDatabase db = new CDatabase();

        //注册表处理
        public static CReg reg = new CReg();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //判断只能运行一个实例 
            bool createNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew);

            if (!createNew)
            {
                MessageBox.Show("程序实例已经运行");
                return;
            }

            string sConn = ConfigurationManager.ConnectionStrings["dbconfig"].ConnectionString;
            if (!db.CreateConn(sConn))
            {
                MessageBox.Show("数据库连接不成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (!VerifyVer())
            //{
            //    Process myProcess = new Process();
            //    try
            //    {
            //        myProcess.StartInfo.UseShellExecute = false;
            //        myProcess.StartInfo.FileName = Application.StartupPath + "\\LiveUpdate.exe";
            //        myProcess.StartInfo.CreateNoWindow = true;
            //        myProcess.Start();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    Application.Exit();
            //    return;
            //}

            Application.Run(new frmMain());
        }

        static bool VerifyVer()
        {
            bool bln = false;

            try
            {
                if (File.Exists(Application.StartupPath + @"\update.xml"))
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(Application.StartupPath + @"\update.xml");

                    XmlNode x = xml.SelectSingleNode("//updatelist/version");
                    string ver = x.InnerText;

                    string sql = "SELECT objectVersion FROM TB_ObjVer WHERE LOWER(objectName) = 'update.xml'";
                    DataTable dt = db.GetRs(sql);

                    if (dt.Rows.Count != 0)
                    {
                        if (String.Compare(ver, dt.Rows[0][0].ToString(), true) == 0)
                        {
                            bln = true;
                        }
                    }
                    else
                    {
                        bln = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bln;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
                sb.AppendLine("【异常方法】：" + ex.TargetSite);

            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}
