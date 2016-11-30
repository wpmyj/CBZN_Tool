using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DB_ROM
{
    public interface IDbPort
    {
        string ConnectionStr { get; }

        DataTable DataAdapter(string cmdtext);

        DataTable DataAdapter(string cmdtext, DbParameter[] parameter);

        int Del<T>();

        int Del<T>(long id);

        int Del<T>(string where);

        int ExecuteNonQuery(string cmdtext);

        IDataReader ExecuteReader(string cmdtext);

        //IDataReader ExecuteReader(string cmdtext, DbParameter[] parameter);

        object ExecuteScalar(string cmdtext);

        object ExecuteScalar(string cmdtext, DbParameter[] parameter);

        T FirstDefault<T>();

        T FirstDefault<T>(long id);

        T FirstDefault<T>(string where);

        int GetCount<T>();

        int GetCount<T>(long id);

        int GetCount<T>(string where);

        int GetCount<T>(string column, long id);

        int GetCount<T>(string column, string where);

        int Insert<T>(T value);

        int Insert<T>(List<T> values);

        DataTable Max<T>(string column);

        DataTable Max<T>(string[] columns);

        DataTable Max<T>(string column, string where);

        DataTable Max<T>(string[] columns, string where);

        DataTable Min<T>(string column);

        DataTable Min<T>(string[] columns);

        DataTable Min<T>(string column, string where);

        DataTable Min<T>(string[] columns, string where);

        DataTable Sum<T>(string column);

        DataTable Sum<T>(string[] columns);

        DataTable Sum<T>(string column, string where);

        DataTable Sum<T>(string[] columns, string where);

        List<T> ToList<T>();

        List<T> ToList<T>(long id);

        List<T> ToList<T>(string where);

        List<T> ToList<T>(bool orderby);

        List<T> ToList<T>(long id, bool orderby);

        List<T> ToList<T>(string where, bool orderby);

        List<T> ToList<T>(string where, string orderbycolumn, bool orderby);

        List<T> ToList<T>(int page, int count);

        List<T> ToList<T>(int page, int count, string where);

        List<T> ToList<T>(int page, int count, string where, bool orderby);

        List<T> ToList<T>(int page, int count, string where, string orderbycolumn, bool orderby);

        List<T> Top<T>(int count);

        List<T> Top<T>(int count, bool orderby);

        List<T> Top<T>(int count, string where);

        List<T> Top<T>(int count, string where, bool orderby);

        List<T> Top<T>(int count, string where, string orderbycolumn, bool orderby);

        DataTable ToTable<T>();

        DataTable ToTable<T>(long id);

        DataTable ToTable<T>(string where);

        DataTable ToTable<T>(bool orderby);

        DataTable ToTable<T>(long id, bool orderby);

        DataTable ToTable<T>(string where, bool orderby);

        DataTable ToTable<T>(string where, string orderbycolumn, bool orderby);

        DataTable ToTable<T>(int page, int count);

        DataTable ToTable<T>(int page, int count, string where);

        DataTable ToTable<T>(int page, int count, string where, bool orderby);

        DataTable ToTable<T>(int page, int count, string where, string orderbycolumn, bool orderby);

        int Update<T>(T value);

        int Update<T>(T value, string where);

        int Update<T>(List<T> value);
    }
}