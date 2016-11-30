using System;
using System.Collections.Generic;
using System.Text;
using DB_ROM;

namespace Model
{
    [PrimaryKey(SetPrimaryKey = "Bid")]
    public class BundledInfo
    {
        [IsAutoId(SetIsAutoId = true)]
        public Int64 Bid { get; set; }

        public Int64 Cid { get; set; }

        public string HostCardNumber { get; set; }

        public Int64 Vid { get; set; }

        public string ViceCardNumber { get; set; }
    }
}
