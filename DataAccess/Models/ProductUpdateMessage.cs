using System.Collections.Generic;

namespace DataAccess.Models
{
    public class ProductUpdateMessage
    {
        public IEnumerable<Update> Updates { get; set; }
    }

    public class Update
    {
        public string VendorCode { get; set; }

        private string _productId;

        public string ProductId
        {
            get { return _productId; }
            set { _productId = "Product__" + value; }
        }
    }
}
