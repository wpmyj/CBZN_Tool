using System;
using DB_ROM;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "Did")]
    public class DeviceInfo
    {
        [IsAutoId(SetIsAutoId = true)]
        public Int64 Did { get; set; }

        public int HostNumber { get; set; }

        /// <summary>
        /// 进出口
        /// </summary>
        public int IOMouth { get; set; }

        public int BrakeNumber { get; set; }

        public int OpenModel { get; set; }

        public int Partition { get; set; }

        /// <summary>
        /// 防潜回
        /// </summary>
        public int SAPBF { get; set; }

        public int Detection { get; set; }

        public int CardReadDistance { get; set; }

        public int ReadCardDelay { get; set; }

        public int CameraDetection { get; set; }

        public int WirelessNumber { get; set; }

        public int FrequencyOffset { get; set; }

        public int Language { get; set; }
    }
}