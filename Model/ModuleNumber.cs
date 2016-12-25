using System;
using System.Collections.Generic;
using System.Text;
using DB_ROM;

namespace Model
{
    [PrimaryKey(SetPrimaryKey = "Mid")]
    public class ModuleNumber
    {
        [IsAutoId(SetIsAutoId = true)]
        public Int64 Mid { get; set; }

        public int Number { get; set; }
    }
}
