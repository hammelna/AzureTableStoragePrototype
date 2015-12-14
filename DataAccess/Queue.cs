using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using DataAccess.Models;
using System.Diagnostics;

namespace DataAccess
{
    public class Queue
    {
        private static Queue _instance;

        private CloudQueueClient _queueClient;

        private CloudQueue _queue;

        public Queue()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TableStorage"].ConnectionString;

            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

            _queueClient = account.CreateCloudQueueClient();

            _queue = _queueClient.GetQueueReference("productupdates");
        }

        public  static Queue GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Queue();
            }

            return _instance;
        }

        /// <summary>
        /// Async method to check the queue, will return a parsed product update message
        /// </summary>
        /// <returns></returns>
        public async Task<ProductUpdateMessage> CheckQueueAsync()
        {
            Trace.WriteLine(string.Format("Checking Queue"));
            ProductUpdateMessage productMessage = null;

            CloudQueueMessage message = await _queue.GetMessageAsync();
            
            if(message!= null)
            {
                productMessage = JsonConvert.DeserializeObject<ProductUpdateMessage>(message.AsString);

                await _queue.DeleteMessageAsync(message);
            }

            return productMessage;
        }

        public CloudQueueMessage CheckQueue()
        {
            CloudQueueMessage message = _queue.GetMessage();

            _queue.DeleteMessage(message);

            return message;
        }
    }
}
