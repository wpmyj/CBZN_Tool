using System;
using System.Security.Principal;
using DB_ROM;
namespace Model
{
    [PrimaryKey(SetPrimaryKey = "Cid")]
    public class CardInfo
    {
        [IsAutoId(SetIsAutoId = true)]
        public Int64 Cid { get; set; }

        public string CardNumber { get; set; }

        public int CardType { get; set; }

        public DateTime CardTime { get; set; }

        public int CardDistance { get; set; }

        public int CardLock { get; set; }

        public int CardReportLoss { get; set; }

        public int ParkingRestrictions { get; set; }

        public int CardPartition { get; set; }

        public int Electricity { get; set; }

        public int Synchronous { get; set; }

        public int InOutState { get; set; }

        public int CardCount { get; set; }

    }
}