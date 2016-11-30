using System;
using System.Collections.Generic;
using System.Text;
using DB_ROM;

namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class UserInfo
    {
        [IsAutoId(SetIsAutoId = true)]
        public Int64 ID { get; set; }

        public string UserName { get; set; }

        public int UserNumber { get; set; }

        public string Description { get; set; }

        public DateTime RecordTime { get; set; }

    }
}
