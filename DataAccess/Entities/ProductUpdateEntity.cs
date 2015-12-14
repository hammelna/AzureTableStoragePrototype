using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace DataAccess.Entities
{
    public class ProductUpdateEntity : TableEntity
    {
        public ProductUpdateEntity() { }

        public ProductUpdateEntity(string vendorCode, Guid productId, string description, string name, double price, DateTime timestamp)
        {
            this.PartitionKey = vendorCode;
            this.RowKey = "Product__" + productId;
            this.Description = description;
            this.Name = name;
            this.VendorCode = vendorCode;
            this.ProductId = productId;
            this.Price = price;
        }

        public string VendorCode { get; set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
