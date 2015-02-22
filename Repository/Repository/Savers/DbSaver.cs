using System;
using System.Data.Common;
using System.Reflection;

namespace Repository.Savers
{
    /// <summary>
    /// Class that allows you to save events to database.
    /// </summary>
    public class DbSaver: ISaver
    {
        #region Fields
        private string _connString;

        private string _providerName;

        private string _tableName;

        private DbProviderFactory _dbFactory;
        #endregion

        #region CTORS
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="connString">Connection string for databse</param>
        /// <param name="providerName">Name of the provider of the database.</param>
        /// <param name="tableName">
        ///     Name of the table, which you want to save events to.
        ///     Column names must match names of the public fields and public properties of events.
        /// </param>
        public DbSaver(string connString, string providerName, string tableName)
        {
            _connString = connString;
            _providerName = providerName;
            _dbFactory = DbProviderFactories.GetFactory(_providerName);
            _tableName = tableName;
        }
        #endregion

        #region PrivateMethods
        private DbParameter CreateParam(DbCommand cmd, string name, object value)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            return param;
        }

        private void ConstructInsertionCommand(Event e, DbCommand cmd)
        {
            string sql = string.Format("INSERT INTO {0} ", _tableName);
            string columnsNames = "(";
            string columnsValues = "(";
            FieldInfo[] fields = e.GetType().GetFields();
            for (int i = 0; i < fields.Length; ++i)
            {
                columnsNames += fields[i].Name;
                columnsValues += "@" + fields[i].Name;
                if (i != fields.Length - 1)
                {
                    columnsNames += ",";
                    columnsValues += ",";
                }
                cmd.Parameters.Add(CreateParam(cmd, string.Format("@{0}", fields[i].Name), fields[i].GetValue(e).ToString()));
            }
            PropertyInfo[] props = e.GetType().GetProperties();
            for (int i = 0; i < props.Length; ++i)
            {
                columnsNames += props[i].Name;
                columnsValues += "@" + props[i].Name;
                if (i != props.Length - 1)
                {
                    columnsNames += ",";
                    columnsValues += ",";
                }
                cmd.Parameters.Add(CreateParam(cmd, string.Format("@{0}", props[i].Name), props[i].GetValue(e).ToString()));
            }
            columnsNames += ")";
            columnsValues += ")";
            sql += columnsNames + " Values " + columnsValues;
            cmd.CommandText = sql;
        }

        private void ConstructUpdateCommand(Event e, DbCommand cmd)
        {
            string sql = string.Format("UPDATE {0} SET ", _tableName);
            FieldInfo[] fields = e.GetType().GetFields();
            for (int i = 0; i < fields.Length; ++i)
            {
                sql += fields[i].Name + "=@" + fields[i].Name;
                if (i != fields.Length - 1)
                {
                    sql += ",";
                }
                cmd.Parameters.Add(CreateParam(cmd, string.Format("@{0}", fields[i].Name), fields[i].GetValue(e).ToString()));
            }
            PropertyInfo[] props = e.GetType().GetProperties();
            for (int i = 0; i < props.Length; ++i)
            {
                sql += props[i].Name + "=@" + props[i].Name;
                if (i != props.Length - 1)
                {
                    sql += ",";
                }
                cmd.Parameters.Add(CreateParam(cmd, string.Format("@{0}", props[i].Name), props[i].GetValue(e).ToString()));
            }
            sql += string.Format(" WHERE ID = {0}", e.ID);
            cmd.CommandText = sql;
        }

        private bool Exists(int id, DbConnection cn)
        {
            string sql = string.Format("if exists (select ID from {0} where ID = {1}) select 1 else select 0 return", _tableName, id);
            using(DbCommand cmd = cn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (((int)cmd.ExecuteScalar()) == 1) return true;
            }
            return false;
        }
        #endregion

        public void SaveEvents(bool overwrite, params Event[] events)
        {
            if (events == null) throw new ArgumentNullException("events", "Events that you try to save is NULL");
            using(DbConnection cn = _dbFactory.CreateConnection())
            {
                cn.ConnectionString = _connString;
                cn.Open();
                foreach(Event e in events)
                {
                    using (DbCommand cmd = cn.CreateCommand())
                    {
                        e.Status = EventStatus.Saved;
                        if (Exists(e.ID,cn))
                        {
                            if (overwrite)
                            {
                                ConstructUpdateCommand(e, cmd);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            ConstructInsertionCommand(e, cmd);
                            cmd.ExecuteNonQuery();
                        }
                    }
                 }
            }
        }
    }
}
