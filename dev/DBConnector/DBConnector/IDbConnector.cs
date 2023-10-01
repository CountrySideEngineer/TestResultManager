namespace DBConnector.IF
{
    public interface IDBConnector<Reader> : IDisposable
    {
        Reader ExecuteQuery(string query);
        Reader ExecuteQuery(string query, Dictionary<string, object> parameters);

        int ExecuteNonQuery(string query);
        int ExecuteNonQuery(string query, Dictionary<string, object> parameters);

        void Connect();
        void Disconnect();

        string SetupConnectionString();

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}