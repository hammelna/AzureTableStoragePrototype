using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using DataAccess.Entities;
using System.Threading.Tasks;

namespace AzureTableStorageWinForm
{
    public partial class VendorUpdateForm : Form
    {
        private Controller _controller = Controller.GetInstance();

        private Model _model = Model.GetInstance();

        public VendorUpdateForm()
        {
            InitializeComponent();
        }

        private async void VendorUpdateForm_FormLoad(object sender, EventArgs e)
        {
            ShowAllUpdatesCheckBox.Enabled = false;

            try
            {
                Trace.WriteLine("Awaiting Vendor Load");

                await _controller.InitializeModel();

                Trace.WriteLine("Vendors Loaded");

                bindVendorsListView();

                ShowAllUpdatesCheckBox.Enabled = true;

                this.CheckUpdateTimer.Enabled = true;

                this.CheckUpdateTimer.Start();
            }
            catch(Microsoft.WindowsAzure.Storage.StorageException storageEx)
            {
                Trace.WriteLine(string.Format("Storage Exception: {0}, StackTrace: {1}", storageEx.Message, storageEx.StackTrace));

                StatusLabel.Text = "Could not connect to Storage";
            }
        }

        private void bindVendorsListView()
        {
            try
            {
                this.VendorListView.Clear();

                _model.Vendors.ForEach(v => addVendorListItem(VendorListView, v));

                this.VendorListView.Columns.Add("Name", 100);
                this.VendorListView.Columns.Add("Code", 50);
                this.VendorListView.Columns.Add("Description", 250);
            }
            catch(Exception ex)
            {
                Trace.WriteLine(string.Format("Exception: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }

        private void addVendorListItem(ListView list, VendorEntity vendor)
        {
            ListViewItem item = new ListViewItem(vendor.Name);
            item.SubItems.Add(vendor.Code);
            item.SubItems.Add(vendor.Description);
            item.Tag = vendor;
            list.Items.Add(item);
            
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void VendorListViewSelectionChanged(object sender, EventArgs e)
        {
            if(this.VendorListView.SelectedItems != null && this.VendorListView.SelectedItems.Count > 0)
            {
                var selectedItem = this.VendorListView.SelectedItems.Cast<ListViewItem>().ToList().First();

                _model.SelectedVendor = (VendorEntity)selectedItem.Tag;

                bindProductUpdatesListView(_model.SelectedVendor.Code);
            }
        }

        private void bindProductUpdatesListView(string vendorCode)
        {
            try
            {
                this.ProductUpdatesListView.Clear();

                if(_model.ShowAllUpdates)
                {
                    _model.AllUpdates.ForEach(u => addProductUpdateListItem(this.ProductUpdatesListView, u));
                }
                else
                {
                    List<ProductUpdateEntity> updates = null;

                    if (_model.ProductUpdates.TryGetValue(vendorCode, out updates))
                    {
                        updates.ForEach(u => addProductUpdateListItem(this.ProductUpdatesListView, u));
                    }
                }
                
                this.ProductUpdatesListView.Columns.Add("Vendor", 75);
                this.ProductUpdatesListView.Columns.Add("Product Name", 150);
                this.ProductUpdatesListView.Columns.Add("Product Description", 175);
                this.ProductUpdatesListView.Columns.Add("Price", 70);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Exception: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
            }
        }

        private void addProductUpdateListItem(ListView list, ProductUpdateEntity productUpdate)
        {
            ListViewItem item = new ListViewItem(productUpdate.PartitionKey);
            item.SubItems.Add(productUpdate.Name);
            item.SubItems.Add(productUpdate.Description);
            item.SubItems.Add(productUpdate.Price.ToString());
            item.Tag = productUpdate;
            list.Items.Add(item);

            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        
        /// <summary>
        /// Checks the message Queue every second to see if new product updates have arrived
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CheckUpdatesTimer_Tick(object sender, EventArgs e)
        {
            await _controller.CheckQueue();

            if (_model.UpdateRequired)
            {
                string vendorCode = _model.SelectedVendor != null && !_model.ShowAllUpdates ? _model.SelectedVendor.Code : "";

                bindProductUpdatesListView(vendorCode);

                _model.UpdateRequired = false;

                Trace.WriteLine("Cleared UpdateRequired Flag");
            }            
        }

        /// <summary>
        /// Check Box Allows for switching between seeing product updates for all vendors and product updates for the selected vendor only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowAllVendorUpdates_CheckChanged(object sender, EventArgs e)
        {
            _model.ShowAllUpdates = this.ShowAllUpdatesCheckBox.Checked;

            if(_model.ShowAllUpdates)
            {
                this.VendorListView.Enabled = false;
                this.VendorListView.SelectedItems.Clear();
                bindProductUpdatesListView("");
            }
            else
            {
                this.VendorListView.Enabled = true;

                //if selectedVendor is null, get first vendor in the list
                _model.SelectedVendor = _model.SelectedVendor ?? _model.Vendors.First();

                bindProductUpdatesListView(_model.SelectedVendor.Code);

                //set the selected index in the list view
                var item = this.VendorListView.Items.Cast<ListViewItem>()
                    .SingleOrDefault(l => _model.SelectedVendor != null && (l.Tag as VendorEntity).Code == _model.SelectedVendor.Code);

                if (item != null)
                {
                    var index = this.VendorListView.Items.IndexOf(item);
                    this.VendorListView.Items[index].Selected = true;
                }
            }
        }
    }
}
