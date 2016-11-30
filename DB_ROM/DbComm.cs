using System;
using System.Collections.Generic;
using System.Text;

namespace DB_ROM
{
    public class DbComm
    {
        public static string GetPrimaryKeywhere<T>(long id)
        {
            string primarykey = GetPrimarykey<T>();
            return string.Format(" and {0} = {1} ", primarykey, id);
        }

        public static string GetPrimarykey<T>()
        {
            T t = Activator.CreateInstance<T>();
            PrimaryKey pk = Attribute.GetCustomAttribute(t.GetType(), typeof(PrimaryKey)) as PrimaryKey;
            if (pk == null) throw new Exception(string.Format("实体类{0}没有主键类型，无法完成操作。", typeof(T).Name));
            return pk.SetPrimaryKey;
        }
    }
}
