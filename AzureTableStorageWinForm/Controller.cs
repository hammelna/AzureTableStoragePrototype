using DataAccess.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace AzureTableStorageWinForm
{
    public class Controller
    {
        private static Controller _instance;

        private Model _model = Model.GetInstance();

        private DataAccess.Queue _queue = DataAccess.Queue.GetInstance();
        
        private DataAccess.VendorRepository _vendorRepo = new DataAccess.VendorRepository();

        private DataAccess.ProductUpdateRepository _productUpdateRepo = new DataAccess.ProductUpdateRepository();

        private Controller() { }

        public static Controller GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Controller();
            }

            return _instance;
        }

        public async Task InitializeModel()
        {
            var vendors = await _vendorRepo.FetchAllVendorsAsync();

            _model.Vendors = vendors.ToList();

            await CheckQueue();
        }

        public async Task CheckQueue()
        {
            var message = await _queue.CheckQueueAsync();

            if (message != null)
            {
                await ProcessQueueMessage(message);
            }
        }

        private async Task ProcessQueueMessage(ProductUpdateMessage message)
        {
            foreach(var update in message.Updates)
            {
                var productUpdate = await _productUpdateRepo.FetchProductUpdatesByVendorAndId(update.VendorCode, update.ProductId);

                if (productUpdate != null)
                {
                    if(_model.ProductUpdates.ContainsKey(productUpdate.VendorCode))
                    {
                        Trace.WriteLine(string.Format("Product Update Added, Vendor: {0}, Product Name: {1}", productUpdate.VendorCode, productUpdate.Name));

                        _model.ProductUpdates[productUpdate.VendorCode].QueuedAdd(productUpdate, 50);

                    }
                    else
                    {
                        Trace.WriteLine(string.Format("Product Update and Vendor Code Added, Vendor: {0}, Product Name: {1}", productUpdate.VendorCode, productUpdate.Name));

                        _model.ProductUpdates.Add(productUpdate.VendorCode, new List<ProductUpdateEntity>() { productUpdate });
                    }

                    _model.AllUpdates.QueuedAdd(productUpdate, 50);

                    if ((_model.SelectedVendor != null && productUpdate.VendorCode == _model.SelectedVendor.Code) || _model.ShowAllUpdates)
                    {
                        _model.UpdateRequired = true;

                        Trace.WriteLine("Update Required");
                    }
                }
            }
        }
    }
}
