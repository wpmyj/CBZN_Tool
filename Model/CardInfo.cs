using System;
using System.Security.Principal;
using  DB_ROM;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "ID")]
    public class CardInfo
    {
        public Int64 ID { get; set; }

        public string Number { get; set; }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public int Value3 { get; set; }

        public int Value4 { get; set; }

        public int Value5 { get; set; }

        public int Value6 { get; set; }

        public int Value7 { get; set; }

    }
}