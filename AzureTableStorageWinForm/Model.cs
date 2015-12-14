using System.Collections.Generic;
using DataAccess.Entities;

namespace AzureTableStorageWinForm
{
    public class Model
    {
        private static Model _instance;
        private Model()
        {
            Vendors = new List<VendorEntity>();

            ProductUpdates = new Dictionary<string, List<ProductUpdateEntity>>();

            AllUpdates = new List<ProductUpdateEntity>();

            ShowAllUpdates = false;

            UpdateRequired = false;
        }

        public static Model GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Model();
            }

            return _instance;
        }

        public List<VendorEntity> Vendors { get; set; }

        public Dictionary<string, List<ProductUpdateEntity>> ProductUpdates { get; set; }

        public VendorEntity SelectedVendor { get; set; }

        public bool UpdateRequired { get; set; }

        public List<ProductUpdateEntity> AllUpdates { get; set; }

        public bool ShowAllUpdates { get; set; }
    }
}
