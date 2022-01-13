using System;
using Npgsql;

namespace Usergemschallengerepository
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = "denu3og6hclbt2";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private NpgsqlConnection connection = null;
        public NpgsqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = "Server=ec2-34-242-89-204.eu-west-1.compute.amazonaws.com;Port=5432;User Id=fvbxvayklqaxsq;Password=129772dbd1b56aef4404f11b963ceba65d4a50d40586b99724483b3787638854;Database=dckgmo1bnogtma;";
                connection = new NpgsqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}