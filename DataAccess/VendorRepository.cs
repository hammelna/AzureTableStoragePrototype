using DataAccess.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VendorRepository
    {
        private const string PARTITION_KEY = "Vendor";
        private CloudTable _vendorTable;

        public VendorRepository()
        {
            _vendorTable = Database.GetInstance().GetTable("VendorData");
        }

        public IEnumerable<VendorEntity> FetchAllVendors()
        {
            TableQuery<VendorEntity> query = new TableQuery<VendorEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, PARTITION_KEY));

            var results = _vendorTable.ExecuteQuery(query);

            return results;
        }

        public async Task<VendorEntity> FetchVendorByNameAsync(string name)
        {
            TableOperation querySingle = TableOperation.Retrieve<VendorEntity>(PARTITION_KEY, name);

            var result = await _vendorTable.ExecuteAsync(querySingle);

            return result.ResultOrDefault<VendorEntity>();
        }

        /// <summary>
        /// Get all Vendors by the partition key (Vendor) 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VendorEntity>> FetchAllVendorsAsync()
        {
            TableQuery<VendorEntity> query = new TableQuery<VendorEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, PARTITION_KEY)).Take(50);

            TableContinuationToken continuationToken = null;

            TableQuerySegment<VendorEntity> result = await _vendorTable.ExecuteQuerySegmentedAsync(query, continuationToken);

            return result.Results;
        }
    }
}
