using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEWS_BK.generic;

namespace SEWS_BK.realmonitor
{
    class CHeartBeatInfo
    {
        public CHeartBeatInfo(string busnumber)
        {
            busNumber = busnumber;
        }

        private string busNumber;
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string BusNumber
        {
            get { return busNumber; }
            set { busNumber = value; }
        }

        private double lng;
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng
        {
            get { return lng; }
            set { lng = value; }
        }

        private double lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        private double angle;
        /// <summary>
        /// 角度
        /// </summary>
        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        private double speed;
        /// <summary>
        /// 速度
        /// </summary>
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private DateTime gpsTime;
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime GpsTime
        {
            get { return gpsTime; }
            set { gpsTime = value; }
        }

        private bool isSelected;
        /// <summary>
        /// 是否选择
        /// </summary>
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public bool IsOnline
        {
            get
            {
                return CFunc.DateDiff(DateInterval.Minute, gpsTime, DateTime.Now) < 2 ? true : false;
            }
        }

        /// <summary>
        /// 是否界面可见（判定条件为 选择 + 时间在两分钟内）
        /// </summary>
        public bool IsVisible
        {
            get 
            {
                return IsSelected && IsOnline ? true : false;
            }
        }
    }
}
