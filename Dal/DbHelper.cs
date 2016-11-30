using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.SQLite;
using DB_ROM;


namespace Dal
{
    public class DbHelper
    {
        public static IDbPort Db;

        public static void LoadDb(string path)
        {
            if (Db == null)
            {
                string connectionstring = string.Format(ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString, path);
                Db = new Sqlite(connectionstring);
                if (!File.Exists(path))
                {
                    CreateDb(path);
                }
            }
        }

        private static void CreateDb(string path)
        {
            SQLiteConnection.CreateFile(path);
            StringBuilder sb = new StringBuilder();
            sb.Append(@" Create Table UserInfo ( ID integer primary key AUTOINCREMENT ,UserName text , UserNumber int ,Description text, RecordTime datetime );");
            sb.Append(@" Create Table NumberLimit ( ID integer primary key autoincrement, LimitNumber int ) ;");
            sb.Append(@" Insert Into NumberLimit (LimitNumber) values(9887) ");
            sb.Append(
                @" Create Table CardInfo(ID integer primary key autoincrement,Number NvarChar(10) ,Value1 Int ,Value2 Int, Value3 Int ,Value4 Int, Value5 Int, Value6 Int, Value7 Int");
            Db.ExecuteNonQuery(sb.ToString());
        }

    }
}
