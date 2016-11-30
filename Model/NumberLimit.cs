using System;
using System.Collections.Generic;
using System.Text;
using DB_ROM;

namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class NumberLimit
    {
        [IsAutoId(SetIsAutoId = true)]

        public Int64 ID { get; set; }

        public int LimitNumber { get; set; }
    }
}
