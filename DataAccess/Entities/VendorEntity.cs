using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace DataAccess.Entities
{
    public class VendorEntity : TableEntity
    {
        public VendorEntity() { }

        public VendorEntity(string code, string name, string description, DateTime timestamp)
        {
            this.PartitionKey = "Vendor";
            this.RowKey = code;
            this.Code = code;
            this.Name = name;
            this.Description = description;
        }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
    }
}
