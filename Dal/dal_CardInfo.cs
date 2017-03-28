using System;
using System.Collections.Generic;
using System.Text;
using DB_ROM;
using Model;
using System.Reflection;

namespace Dal
{
    public class dal_CardInfo
    {
        public static List<CardInfo> SelectBound(Int64 id)
        {
            string cmdtext = string.Format(" SELECT Cid,CardNumber,CardType,CardTime,CardDistance,CardLock,CardReportLoss,CardPartition,ParkingRestrictions,Electricity,Synchronous,InOutState,CardCount,ViceCardCount FROM CardInfo where cid in ( select vid from BundledInfo where Cid={0})  ", id);
            System.Data.SQLite.SQLiteDataReader dr = null;
            List<CardInfo> cardinfos = new List<CardInfo>();
            try
            {
                dr = DbHelper.Db.ExecuteReader(cmdtext) as System.Data.SQLite.SQLiteDataReader;
                if (dr.HasRows)
                {
                    PropertyInfo[] pis = typeof(CardInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    while (dr.Read())
                    {
                        CardInfo info = new CardInfo();
                        foreach (PropertyInfo item in pis)
                        {
                            item.SetValue(info, dr[item.Name], null);
                        }
                        cardinfos.Add(info);
                    }
                }
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
            return cardinfos;
        }
    }
}