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
            if (Db != null) return;
            string connectionstring = string.Format(ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString, path);
            Db = new Sqlite(connectionstring);
            if (!File.Exists(path))
            {
                CreateDb(path);
            }
        }

        private static void CreateDb(string path)
        {
            SQLiteConnection.CreateFile(path);
            StringBuilder sb = new StringBuilder();
            sb.Append(@" Create Table UserInfo ( ID integer primary key AUTOINCREMENT ,UserName text , UserNumber int ,Description text, RecordTime datetime );");

            sb.Append(@" Create Table NumberLimit ( ID integer primary key autoincrement, LimitNumber int ) ;");
            sb.Append(@" Insert Into NumberLimit (LimitNumber) values(9887); ");

            sb.Append(
                @" Create Table CardInfo(Cid integer primary key autoincrement,CardNumber NvarChar(10) ,CardType Int ,CardTime DateTime, CardDistance Int ,CardLock Int, CardReportLoss Int,Synchronous Int, CardPartition Int, ParkingRestrictions Int ,InOutState Int, Electricity Int, CardCount Int ,ViceCardCount Int); ");

            sb.Append(@" Create Table BundledInfo(Bid integer primary key autoincrement,Cid integer, HostCardNumber NvarChar(10),Vid integer,ViceCardNumber NvarChar(10) );");

            sb.Append(
                @" Create Table DeviceInfo(Did integer primary key autoincrement,HostNumber int ,IOMouth int, BrakeNumber int ,OpenModel int,Partition int,SAPBF int,Detection int,CardReadDistance int,ReadCardDelay int,CameraDetection int,WirelessNumber int,FrequencyOffset int ,Language int , FuzzyQuery int ); ");

            sb.Append(@" Create Table ModuleNumber (Mid integer Primary key AUTOINCREMENT, Number Int) ");

            Db.ExecuteNonQuery(sb.ToString());
        }

    }
}
