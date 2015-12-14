using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using DataAccess.Entities;

namespace DataAccess
{
    public class ProductUpdateRepository
    {
        private CloudTable _productUpdateTable;

        public ProductUpdateRepository()
        {
            _productUpdateTable = Database.GetInstance().GetTable("VendorData");
        }

        public IEnumerable<ProductUpdateEntity> FetchProductUpdatesByVendor(string vendorCode)
        {
            TableQuery<ProductUpdateEntity> query = new TableQuery<ProductUpdateEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, vendorCode)).Take(50);
            
            var results = _productUpdateTable.ExecuteQuery(query);

            return results;
        }

        /// <summary>
        /// Get the product update by the passed in partition key(vendorCode) and row key(productId)
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductUpdateEntity> FetchProductUpdatesByVendorAndId(string vendorCode, string productId)
        {
            TableOperation querySingle = TableOperation.Retrieve<ProductUpdateEntity>(vendorCode, productId);

            var result = await _productUpdateTable.ExecuteAsync(querySingle);

            return result.ResultOrDefault<ProductUpdateEntity>();
        }

        public async Task<IEnumerable<ProductUpdateEntity>> FetchProductUpdatesByVendorAsync(string vendorCode)
        {
            TableQuery<ProductUpdateEntity> query = new TableQuery<ProductUpdateEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, vendorCode)).Take(50);

            TableContinuationToken continuationToken = null;

            TableQuerySegment<ProductUpdateEntity> result = await _productUpdateTable.ExecuteQuerySegmentedAsync(query, continuationToken);

            return result.Results;
        }
    }
}
