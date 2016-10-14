using System;

namespace SEWS_BK.realmonitor
{
    public class RealTrackPoint
    {
        /// <summary>
        /// 车辆经度
        /// </summary>
        private double longitude;

        /// <summary>
        /// 车辆经度
        /// </summary>
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        /// <summary>
        /// 车辆纬度
        /// </summary>
        private double latitude;

        /// <summary>
        /// 车辆纬度
        /// </summary>
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        /// <summary>
        /// GPS时间
        /// </summary>
        private DateTime itime;

        /// <summary>
        /// GPS时间
        /// </summary>
        public DateTime ITime
        {
            get { return itime; }
            set { itime = value; }
        }


        /// <summary>
        /// 速度
        /// </summary>
        private float speed;

        /// <summary>
        /// 速度
        /// </summary>
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// 方向
        /// </summary>
        private int directNum;

        /// <summary>
        /// 方向：0上行，1下行
        /// </summary>
        public int DirectNum
        {
            get { return directNum; }
            set { directNum = value; }
        }

        public String Direct
        {
            get { return directNum == 0 ? "上行" : directNum == 1 ? "下行" : "未知"; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private int statusExtra;

        /// <summary>
        /// 状态
        /// </summary>
        public int StatusExtra
        {
            get { return statusExtra; }
            set { statusExtra = value; }
        }

        public string StatusEx
        {
            get { return statusExtra == 2 ? "yes" : "no"; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private int statusnum;

        /// <summary>
        /// 状态
        /// </summary>
        public int StatusNum
        {
            get { return statusnum; }
            set { statusnum = value; }
        }

        public string Status
        {
            get { return statusnum == 1 ? "进站" : statusnum == 2 ? "出站" : "定时定距"; }
        }

        /// <summary>
        /// 角度
        /// </summary>
        private float course;

        /// <summary>
        /// 角度
        /// </summary>
        public float Course
        {
            get { return course; }
            set { course = value; }
        }

        /// <summary>
        /// 站点名称
        /// </summary>
        private string stationName;

        /// <summary>
        /// 站点名称
        /// </summary>
        public string StationName
        {
            get { return stationName; }
            set { stationName = value; }
        }
    }
}
