using DBConnector.IF;
using System.Data.SQLite;

namespace DBConnector.SQLite
{
    public class Connector : IDBConnector<SQLiteDataReader>
    {
        protected SQLiteConnection? _connection;
        protected SQLiteTransaction? _transaction;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Connector()
        {
            Connect();
        }

        public void BeginTransaction()
        {
            _transaction = _connection?.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        /// <summary>
        /// Setup connection to data base.
        /// </summary>
        public void Connect()
        {
            string connectionString = SetupConnectionString();

            _connection = new SQLiteConnection(connectionString);
            _connection.Open();
        }

        /// <summary>
        /// Close connection of data base.
        /// </summary>
        public void Disconnect()
        {
            _connection?.Close();
        }

        /// <summary>
        /// Dispoase of the object.
        /// </summary>
        public void Dispose()
        {
            Disconnect();

            _transaction?.Dispose();
            _connection?.Dispose();

            _connection = null;
            _transaction = null;
        }

        /// <summary>
        /// Execute INSERT, UPDATE, and DELETE query.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <returns>The number of records handled by the query.</returns>
        public int ExecuteNonQuery(string query)
        {
            var parameter = new Dictionary<string, object>();
            int count = ExecuteNonQuery(query, parameter);

            return count;
        }

		/// <summary>
		/// Execute INSERT, UPDATE, and DELETE query.
		/// </summary>
		/// <param name="query">SQL query.</param>
        /// <param name="parameters">SQL query parameters.</param>
		/// <returns>The number of records handled by the query.</returns>
		public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (var cmd = new SQLiteCommand())
            {
                cmd.Connection = _connection;
                cmd.Transaction = _transaction;
                foreach (var parameter in parameters)
                {
                    if (0 < query.IndexOf(parameter.Key))
                    {
                        var sqliteParameter = new SQLiteParameter(parameter.Key, parameter.Value);
                        cmd.Parameters.Add(sqliteParameter);
                    }
                }
				cmd.CommandText = query;
				int count = cmd.ExecuteNonQuery();
				return count;
			}
        }

        /// <summary>
        /// Execute SELECT query.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <returns>Object to read record from.</returns>
        public SQLiteDataReader ExecuteQuery(string query)
        {
            var parameters = new Dictionary<string, object>();
            var reader = ExecuteQuery(query, parameters);
            return reader;
        }

		/// <summary>
		/// Execute SELECT query.
		/// </summary>
		/// <param name="query">SQL query.</param>
		/// <returns>Object to read record from.</returns>
		public SQLiteDataReader ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            using (var cmd = new SQLiteCommand())
            {
                cmd.Connection = _connection;
                cmd.Transaction = _transaction;
                foreach (var parameter in parameters)
                {
                    if (0 < query.IndexOf(parameter.Key))
                    {
                        var sqliteParameter = new SQLiteParameter(parameter.Key, parameter.Value);
                        cmd.Parameters.Add(sqliteParameter);
                    }
                }
                cmd.CommandText = query;
                SQLiteDataReader reader = cmd.ExecuteReader();

                return reader;
            }
        }

        /// <summary>
        /// Rollback transaction.
        /// </summary>
        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        /// <summary>
        /// Setup connectino string.
        /// </summary>
        /// <returns>String to be used when connecting </returns>
        public string SetupConnectionString()
        {
            Configuration config = Configuration.Load();
            string path = config.Path;
            string connectionString = $"Data source={path}";
            return connectionString;
        }
    }
}