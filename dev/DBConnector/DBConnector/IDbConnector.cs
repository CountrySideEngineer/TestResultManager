using System;
using System.Collections.Generic;
using System.Text;

namespace DBConnector.IF
{
    internal interface IDbConnector<Reader> : IDisposable
    {
        Reader ExecuteQuery(string query);
        Reader ExecuteQuery(string query, Dictionary<string, object> parameters);

        int ExecuteNonQuery(string query);
        int ExecuteNonQuery(string query, Dictionary<string, object> parameters);

        void Connect();
        void DisConnect();

        string SetupConnectionString();

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
