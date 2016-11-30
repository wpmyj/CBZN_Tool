using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Data.Common;

namespace DB_ROM
{
    public class SqlHandler : IDbPort
    {
        private readonly string _connectionstr;

        public SqlHandler(string connectinostr)
        {
            this._connectionstr = connectinostr;
        }

        public string ConnectionStr
        {
            get
            {
                return _connectionstr;
            }
        }

        public DataTable DataAdapter(string cmdtext)
        {
            return DataAdapter(cmdtext, null);
        }

        public DataTable DataAdapter(string cmdtext, DbParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionstr))
            {
                SqlCommand comm = new SqlCommand(cmdtext, conn);
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dt);
                return dt;
            }
        }

        public int Del<T>()
        {
            return Del<T>(null);
        }

        public int Del<T>(long id)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return Del<T>(where);
        }

        public int Del<T>(string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" delete from {0} where 1=1 {1}", typeof(T).Name, where);
            return ExecuteNonQuery(sb.ToString());
        }

        public int ExecuteNonQuery(string cmdtext)
        {
            return ExecuteNonQuery(cmdtext, null);
        }

        public int ExecuteNonQuery(string cmdtext, DbParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstr))
            {
                SqlCommand comm = new SqlCommand(cmdtext, conn);
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }
                conn.Open();
                int count;
                try
                {
                    count = comm.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
                return count;
            }
        }

        public IDataReader ExecuteReader(string cmdtext)
        {
            SqlConnection conn = new SqlConnection(_connectionstr);
            SqlCommand comm = new SqlCommand(cmdtext, conn);
            conn.Open();
            return comm.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //public IDataReader ExecuteReader(string cmdtext, DbParameter[] parameter)
        //{
        //    throw new NotImplementedException();
        //}

        public object ExecuteScalar(string cmdtext)
        {
            return ExecuteScalar(cmdtext, null);
        }


        public object ExecuteScalar(string cmdtext, DbParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionstr))
            {
                SqlCommand comm = new SqlCommand(cmdtext, conn);
                if (parameters != null)
                    comm.Parameters.AddRange(parameters);
                conn.Open();
                object result;
                try
                {
                    result = comm.ExecuteScalar();
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }

        public T FirstDefault<T>()
        {
            return FirstDefault<T>(null);
        }

        public T FirstDefault<T>(long id)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return FirstDefault<T>(where);
        }

        public T FirstDefault<T>(string where)
        {
            PropertyInfo[] pinfos =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder(" select top 1 ");
            foreach (PropertyInfo item in pinfos)
            {
                sb.AppendFormat(" [{0}],", item.Name);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} where 1=1 {1} ", typeof(T).Name, where);
            SqlDataReader reader = ExecuteReader(sb.ToString()) as SqlDataReader;
            if (reader.HasRows)
            {
                T t = Activator.CreateInstance<T>();
                try
                {
                    while (reader.Read())
                    {
                        foreach (PropertyInfo item in pinfos)
                        {
                            item.SetValue(t, reader[item.Name], null);
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
                return t;
            }
            reader.Close();
            return default(T);
        }

        public int GetCount<T>()
        {
            return GetCount<T>(null, null);
        }

        public int GetCount<T>(long id)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return GetCount<T>(null, where);
        }

        public int GetCount<T>(string where)
        {
            return GetCount<T>(null, where);
        }

        public int GetCount<T>(string column, long id)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return GetCount<T>(column, where);
        }

        public int GetCount<T>(string column, string where)
        {
            if (string.IsNullOrEmpty(column))
                column = "*";
            string cmdtext = string.Format(" select count({0}) from {1} where 1=1 {2} ", column, typeof(T).Name, where);
            object result = ExecuteScalar(cmdtext);
            if (result != null && result != DBNull.Value)
                return Convert.ToInt32(result);
            return 0;
        }

        public int Insert<T>(T value)
        {
            StringBuilder sb = new StringBuilder(string.Format(" insert into {0} (", typeof(T).Name));
            StringBuilder sb2 = new StringBuilder(" values (");
            PropertyInfo[] pinfos =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            List<SqlParameter> parameters = new List<SqlParameter>();
            string primarykey = DbComm.GetPrimarykey<T>();
            bool isauto = false;
            foreach (PropertyInfo item in pinfos)
            {
                if (primarykey == item.Name)
                {
                    IsAutoId isautoid = Attribute.GetCustomAttribute(item, typeof(IsAutoId)) as IsAutoId;
                    if (isautoid != null)
                        isauto = isautoid.SetIsAutoId;
                    continue;
                }
                sb.AppendFormat(" [{0}],", item.Name);
                sb2.AppendFormat("@{0},", item.Name);
                parameters.Add(new SqlParameter(item.Name, item.GetValue(value, null)));
            }
            sb = sb.Replace(',', ')', sb.Length - 1, 1);
            sb2 = sb2.Replace(',', ')', sb2.Length - 1, 1);
            sb.Append(sb2);
            if (isauto)
            {
                sb.AppendFormat(" SELECT IDENT_CURRENT('{0}') ", typeof(T).Name);
                object obj = ExecuteScalar(sb.ToString(), parameters.ToArray());
                if (obj != null && obj != DBNull.Value)
                    return Convert.ToInt32(obj);
            }
            return ExecuteNonQuery(sb.ToString(), parameters.ToArray());
        }

        public int Insert<T>(List<T> values)
        {
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            StringBuilder columns = new StringBuilder(string.Format(" insert into {0} ( ", typeof(T).Name));
            string primarykey = DbComm.GetPrimarykey<T>();
            foreach (PropertyInfo item in pinfos)
            {
                if (primarykey == item.Name) continue;
                columns.AppendFormat("[{0}],", item.Name);
            }
            columns = columns.Replace(',', ')', columns.Length - 1, 1);
            columns.Append(" values (");
            int count = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (T item in values)
            {
                sb.Append(columns);
                count++;
                foreach (PropertyInfo properyinfo in pinfos)
                {
                    if (primarykey == properyinfo.Name) continue;
                    string name = properyinfo.Name + count;
                    sb.AppendFormat("@{0},", name);
                    parameters.Add(new SqlParameter(name, properyinfo.GetValue(item, null)));
                }
                sb = sb.Replace(',', ')', sb.Length - 1, 1);
                sb.Append(" ; ");
            }
            return ExecuteNonQuery(sb.ToString(), parameters.ToArray());
        }

        public DataTable Max<T>(string column)
        {
            return Max<T>(new[] { column }, null);
        }

        public DataTable Max<T>(string[] columns)
        {
            return Max<T>(columns, null);
        }

        public DataTable Max<T>(string column, string where)
        {
            return Max<T>(new[] { column }, where);
        }

        public DataTable Max<T>(string[] columns, string where)
        {
            StringBuilder sb = new StringBuilder(" select ");
            foreach (string str in columns)
            {
                sb.AppendFormat(" Max({0}),", str);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} where 1=1 {1}", typeof(T).Name, where);
            return DataAdapter(sb.ToString());
        }

        public DataTable Min<T>(string column)
        {
            return Min<T>(new[] { column }, null);
        }

        public DataTable Min<T>(string[] columns)
        {
            return Min<T>(columns, null);
        }

        public DataTable Min<T>(string column, string where)
        {
            return Min<T>(new[] { column }, where);
        }

        public DataTable Min<T>(string[] columns, string where)
        {
            StringBuilder sb = new StringBuilder(" select ");
            foreach (string str in columns)
            {
                sb.AppendFormat(" Min({0}),", str);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} where 1=1 {1}", typeof(T).Name, where);
            return DataAdapter(sb.ToString());
        }

        public DataTable Sum<T>(string column)
        {
            return Sum<T>(new[] { column }, null);
        }

        public DataTable Sum<T>(string[] columns)
        {
            return Sum<T>(columns, null);
        }

        public DataTable Sum<T>(string column, string where)
        {
            return Sum<T>(new[] { column }, where);
        }

        public DataTable Sum<T>(string[] columns, string where)
        {
            StringBuilder sb = new StringBuilder(" select ");
            foreach (string item in columns)
            {
                sb.AppendFormat(" sum({0}),", item);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} where 1=1 {1}", typeof(T).Name, where);
            return DataAdapter(sb.ToString());
        }

        public List<T> ToList<T>()
        {
            return ToList<T>(0, 0, null, null, false);
        }

        public List<T> ToList<T>(long id)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return ToList<T>(0, 0, where, null, false);
        }

        public List<T> ToList<T>(string where)
        {
            return ToList<T>(0, 0, where, null, false);
        }

        public List<T> ToList<T>(bool orderby)
        {
            return ToList<T>(0, 0, null, null, orderby);
        }

        public List<T> ToList<T>(long id, bool orderby)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return ToList<T>(0, 0, where, null, orderby);
        }

        public List<T> ToList<T>(string where, bool orderby)
        {
            return ToList<T>(0, 0, where, null, orderby);
        }

        public List<T> ToList<T>(string where, string orderbycolumn, bool orderby)
        {
            return ToList<T>(0, 0, where, orderbycolumn, orderby);
        }

        public List<T> ToList<T>(int page, int count)
        {
            return ToList<T>(page, count, null, null, false);
        }

        public List<T> ToList<T>(int page, int count, string where)
        {
            return ToList<T>(page, count, where, null, false);
        }

        public List<T> ToList<T>(int page, int count, string where, bool orderby)
        {
            return ToList<T>(page, count, where, null, orderby);
        }

        public List<T> ToList<T>(int page, int count, string where, string orderbycolumn, bool orderby)
        {
            string cmdtext = GetCmdtext<T>(page, count, where, orderbycolumn, orderby);
            SqlDataReader reader = ExecuteReader(cmdtext) as SqlDataReader;
            List<T> getlist = new List<T>();
            try
            {
                if (reader.HasRows)
                {
                    PropertyInfo[] pinfos =
                        typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                    while (reader.Read())
                    {
                        T t = Activator.CreateInstance<T>();

                        foreach (PropertyInfo item in pinfos)
                        {
                            item.SetValue(t, reader[item.Name], null);
                        }
                        getlist.Add(t);

                    }
                }
            }
            finally
            {
                reader.Close();
            }
            return getlist;
        }

        public List<T> Top<T>(int count)
        {
            return Top<T>(count, null, null, false);
        }

        public List<T> Top<T>(int count, bool orderby)
        {
            return Top<T>(count, null, null, orderby);
        }

        public List<T> Top<T>(int count, string where)
        {
            return Top<T>(count, where, null, false);
        }

        public List<T> Top<T>(int count, string where, bool orderby)
        {
            return Top<T>(count, where, null, orderby);
        }

        public List<T> Top<T>(int count, string where, string orderbycolumn, bool orderby)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select top {0} ", count);
            PropertyInfo[] pinfos =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (PropertyInfo info in pinfos)
            {
                sb.AppendFormat("[{0}],", info.Name);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} where 1=1 {1} ", typeof(T).Name, where);
            if (string.IsNullOrEmpty(orderbycolumn))
            {
                orderbycolumn = DbComm.GetPrimarykey<T>();
            }
            sb.AppendFormat(" order by {0} {1} ", orderbycolumn, orderby ? "asc" : "desc");
            SqlDataReader reader = ExecuteReader(sb.ToString()) as SqlDataReader;
            List<T> tlist = new List<T>();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T t = Activator.CreateInstance<T>();
                        foreach (PropertyInfo info in pinfos)
                        {
                            info.SetValue(t, reader[info.Name], null);
                        }
                        tlist.Add(t);
                    }
                }
            }
            finally
            {
                reader.Close();
            }
            return tlist;
        }

        public DataTable ToTable<T>()
        {
            return ToTable<T>(0, 0, null, null, false);
        }

        public DataTable ToTable<T>(long id)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return ToTable<T>(0, 0, where, null, false);
        }

        public DataTable ToTable<T>(string where)
        {
            return ToTable<T>(0, 0, where, null, false);
        }

        public DataTable ToTable<T>(bool ordery)
        {
            return ToTable<T>(0, 0, null, null, false);
        }

        public DataTable ToTable<T>(long id, bool orderby)
        {
            string where = DbComm.GetPrimaryKeywhere<T>(id);
            return ToTable<T>(0, 0, where, null, orderby);
        }

        public DataTable ToTable<T>(string where, bool orderby)
        {
            return ToTable<T>(0, 0, where, null, orderby);
        }

        public DataTable ToTable<T>(string where, string orderbycolumn, bool orderby)
        {
            return ToTable<T>(0, 0, where, orderbycolumn, orderby);
        }

        public DataTable ToTable<T>(int page, int count)
        {
            return ToTable<T>(page, count, null, null, false);
        }

        public DataTable ToTable<T>(int page, int count, string where)
        {
            return ToTable<T>(page, count, where, null, false);
        }

        public DataTable ToTable<T>(int page, int count, string where, bool orderby)
        {
            return ToTable<T>(page, count, where, null, false);
        }

        public DataTable ToTable<T>(int page, int count, string where, string orderbycolumn, bool orderby)
        {
            string cmdtext = GetCmdtext<T>(page, count, where, orderbycolumn, orderby);
            return DataAdapter(cmdtext);
        }

        public int Update<T>(T value)
        {
            return Update(value, null);
        }

        public int Update<T>(T value, string where)
        {
            PropertyInfo[] pinfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder(" Update " + typeof(T).Name + " set ");
            List<SqlParameter> parameters = new List<SqlParameter>();
            string primarykey = DbComm.GetPrimarykey<T>();
            foreach (PropertyInfo item in pinfos)
            {
                if (primarykey == item.Name)
                {
                    if (string.IsNullOrEmpty(where))
                    {
                        where = string.Format(" and {0}={1} ", primarykey, item.GetValue(value, null));
                    }
                    continue;
                }
                sb.AppendFormat("[{0}]=@{0},", item.Name);
                parameters.Add(new SqlParameter(item.Name, item.GetValue(value, null)));
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" where 1=1 {0} ", where);
            return ExecuteNonQuery(sb.ToString(), parameters.ToArray());
        }

        public int Update<T>(List<T> values)
        {
            PropertyInfo[] pinfos =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            string primarykey = DbComm.GetPrimarykey<T>();
            int count = 0;
            foreach (T titem in values)
            {
                object primarykeyvalue = null;
                count++;
                sb.AppendFormat(" Update {0} set ", typeof(T).Name);
                foreach (PropertyInfo info in pinfos)
                {
                    if (primarykey == info.Name)
                    {
                        primarykeyvalue = info.GetValue(titem, null);
                        continue;
                    }
                    string name = info.Name + count;
                    sb.AppendFormat("[{0}]=@{1},", info.Name, name);
                    parameters.Add(new SqlParameter(name, info.GetValue(titem, null)));
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.AppendFormat(" where {0}={1} ", primarykey, primarykeyvalue);
            }
            return ExecuteNonQuery(sb.ToString(), parameters.ToArray());
        }

        private string GetCmdtext<T>(int page, int count, string where, string orderbycolumn, bool orderby)
        {
            /*SELECT * FROM ARTICLE w1
    WHERE ID in
        (
            SELECT top 30 ID FROM
            (
                SELECT top 45030 ID, YEAR FROM ARTICLE ORDER BY YEAR DESC, ID DESC
            ) w ORDER BY w.YEAR ASC, w.ID ASC
        )
    ORDER BY w1.YEAR DESC, w1.ID DESC
             */
            StringBuilder sb = new StringBuilder(" select  ");
            PropertyInfo[] pinfos =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            foreach (PropertyInfo item in pinfos)
            {
                sb.AppendFormat(" [{0}],", item.Name);
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendFormat(" from {0} mi where ", typeof(T).Name);
            if (count > 0)
            {
                string primarykey = DbComm.GetPrimarykey<T>();
                sb.AppendFormat(" {0} in ( select  top {1} {0} from ( select top {2} {0} from {3} where 1=1 {4} order by {0} desc ) mi1 order by mi1.{0} asc ) ", primarykey, count, page + count, typeof(T).Name, where);
            }
            else
            {
                sb.AppendFormat(" 1=1 {0} ", where);
            }
            if (string.IsNullOrEmpty(orderbycolumn))
                orderbycolumn = DbComm.GetPrimarykey<T>();
            sb.AppendFormat(" order by mi.{0} ", orderbycolumn);
            sb.AppendFormat(" {0} ", @orderby ? "asc" : "desc");
            return sb.ToString();
        }
    }
}