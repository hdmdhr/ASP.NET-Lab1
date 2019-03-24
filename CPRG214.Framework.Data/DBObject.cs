using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG214.Framework.Data
{
    /// <summary>
    /// A Singleton class provides a query and a non-query methods for database CRUD functionality.
    /// </summary>
    public class DBObject
    {
        // properties
        DbProviderFactory Factory { get; set; }

        // implement singleton design pattern 
        // 1.private static instance of class itself 
        private static readonly DBObject _instance = new DBObject();

        // 2.private constructor 
        private DBObject()
        {
        }

        // 3.public static member returns the private static instance
        /// <summary>
        /// Property get the only instance of the class.
        /// </summary>
        public static DBObject Instance { get => _instance; }

        // rest of the code is regular class members (non-static)

        public string ConnectionString { get; set; }

        // Methods

        public void SetProvider(string provider)
        {
            Factory = DbProviderFactories.GetFactory(provider);
        }

        public IDataParameter CreateParameter()
        {
            return Factory.CreateParameter();  // DbParameter implemented (is a) IDataParameter
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        public void NonQuery(string sql, CommandType cmdType, IDataParameter[] parameters)
        {
            if (Factory == null)
                throw new Exception("Provider name has not been set.");

            try
            {
                using (var conn = Factory.CreateConnection())
                {
                    conn.ConnectionString = ConnectionString;  // set connection string for SqlConnection obj
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdType;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Data error occurred. Contact app support.",ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader Query(string sql, CommandType cmdType, IDataParameter[] parameters)
        {
            if (Factory == null)
                throw new Exception("Provider name has not been set.");

            try
            {
                var conn = Factory.CreateConnection();
                conn.ConnectionString = ConnectionString;
                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = cmdType;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Data error occurred. Contact app support.", ex);
            }
        }
    }
}
