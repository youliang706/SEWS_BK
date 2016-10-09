using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Drawing;

namespace SEWS_BK.generic
{
    public sealed class CFtp
    {
        public static readonly CFtp Instance = new CFtp();

        string localPath = ConfigurationManager.AppSettings["localaddress"];
        string ftpUrl = ConfigurationManager.AppSettings["ftpaddress"];
        string ftpUser = ConfigurationManager.AppSettings["ftpuser"];
        bool usePassive = ConfigurationManager.AppSettings["usepassive"].ToLower() == "true" ? true : false;

        /// <summary>
        /// 获取Ftp文件流
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public Stream GetFtpStream(string fileName)
        {
            try
            {
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(fileName));
                reqFtp.Credentials = new NetworkCredential(ftpUser, "123");
                reqFtp.UseBinary = true;
                reqFtp.UsePassive = usePassive;
                FtpWebResponse respFtp = (FtpWebResponse)reqFtp.GetResponse();
                Stream stream = respFtp.GetResponseStream();
                return stream;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //从ftp服务器上下载文件的功能
        public void DownloadFile(string filePath, string fileName)
        {
            try
            {
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(fileName));
                reqFtp.Credentials = new NetworkCredential(ftpUser, "123");
                reqFtp.UseBinary = true;
                reqFtp.UsePassive = usePassive;
                FtpWebResponse respFtp = (FtpWebResponse)reqFtp.GetResponse();
                Stream stream = respFtp.GetResponseStream();

                FileStream outputStream = new FileStream(filePath, FileMode.Create);
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = stream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = stream.Read(buffer, 0, bufferSize);
                }
                stream.Close();
                outputStream.Close();
                respFtp.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Image GetFtpImage(string imgName)
        {
            if (ftpUrl == "")
            {
                Image img = Image.FromFile(imgName);
                return img;
            }
            else
            {
                string imgpath = imgName.ToLower().Replace(localPath.ToLower(), ftpUrl).Replace("\\", "/");

                Image img = Image.FromStream(GetFtpStream(imgpath));
                return img;
            }
        }

        public void DownloadImage(string filePath, string imgName)
        {
            if (ftpUrl == "")
            {
                string filepath = Path.Combine(filePath, Path.GetFileName(imgName));

                File.Copy(imgName, filepath);
            }
            else
            {
                string imgpath = imgName.ToLower().Replace(localPath.ToLower(), ftpUrl).Replace("\\", "/");
                string filepath = Path.Combine(filePath, Path.GetFileName(imgName));

                DownloadFile(filepath, imgpath);
            }
        }
    }
}
