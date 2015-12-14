using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DataAccess
{
    public class Database
    {
        private CloudTableClient _tableClient;
        private static Database _instance;

        private Database()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TableStorage"].ConnectionString;

            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

            _tableClient = account.CreateCloudTableClient();
        }

        /// <summary>
        /// Get a single database instance connected to table storage
        /// </summary>
        /// <returns></returns>
        public static Database GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Database();
            }

            return _instance;
        }

        /// <summary>
        /// Get a reference to the table defined by the passed in table name
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public CloudTable GetTable(string tableName)
        {
            var table = _tableClient.GetTableReference(tableName);

            return table;
        }
    }
}
