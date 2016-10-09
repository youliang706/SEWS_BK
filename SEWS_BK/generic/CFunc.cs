using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Com.Database;
using System.Data;

namespace SEWS_BK.generic
{
    public enum DateInterval
    {
        Second, Minute, Hour, Day, Week, Month, Quarter, Year
    }

    public sealed class CFunc
    {
        static CDatabase db = Program.db;

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 获取公网IP
        /// </summary>
        /// <returns></returns>
        public static string GetOuterIP()
        {
            string tempip = "127.0.0.1";
            try
            {
                WebRequest wr = WebRequest.Create("http://www.ip138.com/ips138.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string wburl = sr.ReadToEnd();

                if (wburl.IndexOf("无法找到该页") == -1)
                {
                    int start = wburl.IndexOf("您的IP地址是：[") + 1;
                    int end = wburl.IndexOf("]", start + 8);
                    tempip = wburl.Substring(start + 8, end - start - 8);
                    sr.Close();
                    s.Close();
                    return tempip;
                }

                wr = WebRequest.Create("http://www.net.cn/static/customercare/yourIP.asp");
                s = wr.GetResponse().GetResponseStream();
                sr = new StreamReader(s, Encoding.Default);
                wburl = sr.ReadToEnd();

                if (wburl.IndexOf("无法找到该页") == -1)
                {
                    int start = wburl.IndexOf("<h2>") + 4;
                    int end = wburl.IndexOf("</h2>", start);
                    tempip = wburl.Substring(start, end - start);
                    sr.Close();
                    s.Close();
                }
            }
            catch
            {
            }
            return tempip;
        }

        public static void SaveLog(string menuid, string menuname, string contect)
        {
            string outIP = GetOuterIP();

            string sql = "INSERT INTO TB_SYSTEM_LOG( "
                        + "    MAINID, OPERATEUSERCODE, OPERATEIP, OPERATETIME, OPERATEOBJECTID, OPERATEOBJECT, OPERATERESULT, OPERATECONTENT "
                        + ") VALUES ( "
                        + "      FN_GET_UUID(), '" + CVar.LoginID + "', '" + outIP + "', to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss'), '" + menuid + "', '" + menuname + "', '1', '" + contect + "' "
                        + ") ";
            db.Execute(sql);
        }

        /// <summary>
        /// 设置控件状态
        /// </summary>
        /// <param name="bln"></param>
        /// <param name="ctls"></param>
        public static void SetCtrlsSta(bool bln, params object[] ctls)
        {
            foreach (object ctl in ctls)
            {
                try
                {
                    if (ctl is TextBox)
                    {
                        (ctl as TextBox).Enabled = bln;
                        (ctl as TextBox).BackColor = bln ? Color.FromKnownColor(System.Drawing.KnownColor.Window) : Color.FromArgb(220, 220, 220);
                    }
                    else if (ctl is ComboBox)
                    {
                        (ctl as ComboBox).Enabled = bln;
                        (ctl as ComboBox).BackColor = bln ? Color.FromKnownColor(System.Drawing.KnownColor.Window) : Color.FromArgb(220, 220, 220);
                    }
                    else
                    {
                        (ctl as Control).Enabled = bln;
                        (ctl as Control).BackColor = bln ? Color.FromKnownColor(System.Drawing.KnownColor.Window) : Color.FromArgb(220, 220, 220);
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 判断文本框为空，提示"...不可为空"
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="tipText"></param>
        public static bool TxtCheck(TextBox txt, string tipText)
        {
            if (txt.Enabled && txt.Text.Trim() == "")
            {
                MessageBox.Show(tipText + "不可为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Focus();
                return false;
            }
            return true;
        }

        public static bool TxtCheck(DevExpress.XtraEditors.TextEdit txt, string tipText)
        {
            if (txt.Enabled && txt.Text.Trim() == "")
            {
                MessageBox.Show(tipText + "不可为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断组合框为空，提示"请选择..."
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="tipText"></param>
        public static bool CboCheck(ComboBox cbo, string tipText)
        {
            if (cbo.Enabled && cbo.Text.Trim() == "")
            {
                MessageBox.Show("请选择" + tipText + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo.Focus();
                return false;
            }
            return true;
        }

        public static bool CboCheck(DevExpress.XtraEditors.ComboBoxEdit cbo, string tipText)
        {
            if (cbo.Enabled && cbo.Text.Trim() == "")
            {
                MessageBox.Show("请选择" + tipText + "。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清除窗体控件内容
        /// </summary>
        /// <param name="ctls"></param>
        public static void ClearCtrls(params object[] ctls)
        {
            foreach (object ctl in ctls)
            {
                try
                {
                    if (ctl is TextBox)
                    {
                        (ctl as TextBox).Text = "";
                    }
                    else if (ctl is ComboBox)
                    {
                        (ctl as ComboBox).SelectedIndex = -1;
                    }
                    if (ctl is DateTimePicker)
                    {
                        (ctl as DateTimePicker).Value = DateTime.Now;
                    }
                    if (ctl is CheckBox)
                    {
                        (ctl as CheckBox).Checked = false;
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 取服务器的日期时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDate()
        {
            DataTable dt = db.GetRs("SELECT SYSDATE FROM DUAL");
            return DateTime.Parse(dt.Rows[0][0].ToString());
        }

        /// <summary>
        /// 根据一字段及内容查找另一字段内容
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="srcField"></param>
        /// <param name="destField"></param>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string IDValue(string tableName, string srcField, string destField, string value, string condition = "", string defValue = "")
        {
            string sql = "SELECT " + destField + " FROM " + tableName + " WHERE " + srcField + " = '" + value + "'";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][destField].ToString();
            }
            else
            {
                return defValue;
            }
        }

        public static string IDValue(string tableName, string srcField, string destField, int value, string condition = "", string defValue = "")
        {
            string sql = "SELECT " + destField + " FROM " + tableName + " WHERE " + srcField + " = " + value.ToString() + "";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][destField].ToString();
            }
            else
            {
                return defValue;
            }
        }

        public static string IDValue(string tableName, string srcField, string destField, DateTime value, string condition = "", string defValue = "")
        {
            string sql = "SELECT " + destField + " FROM " + tableName + " WHERE TRUNC(" + srcField + ") = TRUNC(" + value.ToString() + ")";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][destField].ToString();
            }
            else
            {
                return defValue;
            }
        }

        /// <summary>
        /// 检查记录是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static bool ChkExists(string tableName, string fieldName, string value, string condition = "")
        {
            string sql = "SELECT NVL(COUNT(" + fieldName + "),0) AS dest FROM " + tableName + " WHERE " + fieldName + " = '" + value.ToString() + "'";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ChkExists(string tableName, string fieldName, int value, string condition = "")
        {
            string sql = "SELECT NVL(COUNT(" + fieldName + "),0) AS dest FROM " + tableName + " WHERE " + fieldName + " = " + value.ToString() + "";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ChkExists(string tableName, string fieldName, DateTime value, string condition = "")
        {
            string sql = "SELECT NVL(COUNT(" + fieldName + "),0) AS dest FROM " + tableName + " WHERE TRUNC(" + fieldName + ") = TRUNC(" + value.ToString() + ")";
            if (!condition.Equals(""))
            {
                sql += " AND (" + condition + ")";
            }

            DataTable dt = db.GetRs(sql);

            if (int.Parse(dt.Rows[0][0].ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 设置文本最大输入字符数
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ctls"></param>
        public static void SetMaxLength(string tableName, params object[] ctls)
        {
            DataSet ds = db.GetDs(tableName);

            for (int i = 0; i < ctls.Count() - 1; i += 2)
            {
                try
                {
                    if (ctls[i] is TextBox)
                    {
                        (ctls[i] as TextBox).MaxLength = ds.Tables[0].Columns[(ctls[i + 1] as string)].MaxLength / 2;   //varchar2需要减半
                    }
                    else if (ctls[i] is DevExpress.XtraEditors.TextEdit)
                    {
                        (ctls[i] as DevExpress.XtraEditors.TextEdit).Properties.MaxLength = ds.Tables[0].Columns[(ctls[i + 1] as string)].MaxLength / 2;
                    }
                }
                catch
                { }
            }
        }

        public static string DBID()
        {
            try
            {
                string sql = "SELECT fn_get_uuid AS sysid FROM DUAL";
                DataTable dt = db.GetRs(sql);

                return dt.Rows[0]["sysid"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing functions DBID", ex);
            }
        }

        public static int DBID(string tag)
        {
            try
            {
                string sql = "SELECT fn_dbid('" + tag + "') AS sysid FROM DUAL";
                DataTable dt = db.GetRs(sql);

                return int.Parse(dt.Rows[0]["sysid"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing functions DBID", ex);
            }
        }

        /// <summary>
        /// 计算两个时间类型的差值
        /// </summary>
        /// <param name="Interval"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case DateInterval.Second:
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                case DateInterval.Minute:
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case DateInterval.Hour:
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case DateInterval.Day:
                    lngDateDiffValue = (long)TS.Days;
                    break;
                case DateInterval.Week:
                    lngDateDiffValue = (long)(TS.Days / 7);
                    break;
                case DateInterval.Month:
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case DateInterval.Quarter:
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case DateInterval.Year:
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }

        /// <summary>
        /// 计算时间
        /// </summary>
        /// <param name="Interval"></param>
        /// <param name="Number"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static DateTime DateAdd(DateInterval Interval, int Number, System.DateTime Date)
        {
            DateTime dteValue = Date;
            switch (Interval)
            {
                case DateInterval.Second:
                    dteValue = Date.AddSeconds(Number);
                    break;
                case DateInterval.Minute:
                    dteValue = Date.AddMinutes(Number);
                    break;
                case DateInterval.Hour:
                    dteValue = Date.AddHours(Number);
                    break;
                case DateInterval.Day:
                    dteValue = Date.AddDays(Number);
                    break;
                case DateInterval.Week:
                    dteValue = Date.AddDays(7 * Number);
                    break;
                case DateInterval.Month:
                    dteValue = Date.AddMonths(Number);
                    break;
                case DateInterval.Quarter:
                    dteValue = Date.AddMonths(4 * Number);
                    break;
                case DateInterval.Year:
                    dteValue = Date.AddYears(Number);
                    break;
            }
            return (dteValue);
        }

        public static string TransTime(DateTime itime)
        {
            return TransTime(itime, DateTime.Now);
        }

        public static string TransTime(DateTime itime, DateTime dte)
        {
            return dte.ToString("yyyy-MM-dd") + " " + itime.ToString("HH:mm:ss");
        }

        public static void ShowLoading()
        {
            WaitFormService.CreateWaitForm();
        }

        public static void ShowLoading(string text)
        {
            WaitFormService.CreateWaitForm(text);
        }

        public static void CloseLoading()
        {
            WaitFormService.CloseWaitForm();
        }

        /// <summary>
        /// 截取图像的矩形区域
        /// </summary>
        /// <param name="source">源图像</param>
        /// <param name="rect">截取的矩形区域</p
        public static Image AcquireRectangleImage(Image source, Rectangle rect)
        {
            if (source == null || rect.IsEmpty) return null;
            Bitmap bmSmall = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //Bitmap bmSmall = new Bitmap(rect.Width, rect.Height, source.PixelFormat);

            using (Graphics grSmall = Graphics.FromImage(bmSmall))
            {
                grSmall.DrawImage(source,
                                  new System.Drawing.Rectangle(0, 0, bmSmall.Width, bmSmall.Height),
                                  rect,
                                  GraphicsUnit.Pixel);
                grSmall.Dispose();
            }
            return bmSmall;
        }

        /// <summary>
        /// 图片转Base64字符串
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string ImgToBase64(Image img)
        {
            Bitmap bmp = new Bitmap(img);
            //读入MemoryStream对象
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            //转成字符串
            return Convert.ToBase64String(arr);
        }

        /// <summary>
        /// Base64字符串转图片
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public static Image Base64ToImg(string pic)
        {
            byte[] imageBytes = Convert.FromBase64String(pic);
            //读入MemoryStream对象
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            //转成图片
            return Image.FromStream(memoryStream);
        }

        /// <summary>
        /// 获取AB连线与正北方向的角度 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static double getAngle(MyLatLng A, MyLatLng B)
        {
            double dx = (B.m_RadLo - A.m_RadLo) * A.Ed;
            double dy = (B.m_RadLa - A.m_RadLa) * A.Ec;
            double angle = 0.0;
            angle = Math.Atan(Math.Abs(dx / dy)) * 180.0 / Math.PI;
            double dLo = B.m_Longitude - A.m_Longitude;
            double dLa = B.m_Latitude - A.m_Latitude;
            if (dLo > 0 && dLa <= 0)
            {
                angle = (90.0 - angle) + 90;
            }
            else if (dLo <= 0 && dLa < 0)
            {
                angle = angle + 180.0;
            }
            else if (dLo < 0 && dLa >= 0)
            {
                angle = (90.0 - angle) + 270;
            }
            return angle;
        }
    }

    public partial class NativeMethods
    {
        /// <summary>
        /// 启动控制台
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        /// <summary>
        /// 释放控制台
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
    }

    public class MyLatLng
    {
        internal const double Rc = 6378137;
        internal const double Rj = 6356725;
        internal double m_LoDeg, m_LoMin, m_LoSec;
        internal double m_LaDeg, m_LaMin, m_LaSec;
        internal double m_Longitude, m_Latitude;
        internal double m_RadLo, m_RadLa;
        internal double Ec;
        internal double Ed;
        public MyLatLng(double longitude, double latitude)
        {
            m_LoDeg = (int)longitude;
            m_LoMin = (int)((longitude - m_LoDeg) * 60);
            m_LoSec = (longitude - m_LoDeg - m_LoMin / 60.0) * 3600;

            m_LaDeg = (int)latitude;
            m_LaMin = (int)((latitude - m_LaDeg) * 60);
            m_LaSec = (latitude - m_LaDeg - m_LaMin / 60.0) * 3600;

            m_Longitude = longitude;
            m_Latitude = latitude;
            m_RadLo = longitude * Math.PI / 180.0;
            m_RadLa = latitude * Math.PI / 180.0;
            Ec = Rj + (Rc - Rj) * (90.0 - m_Latitude) / 90.0;
            Ed = Ec * Math.Cos(m_RadLa);
        }
    }
}
