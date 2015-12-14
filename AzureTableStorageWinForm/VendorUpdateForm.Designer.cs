namespace AzureTableStorageWinForm
{
    partial class VendorUpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BaseLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.VendorGroupBox = new System.Windows.Forms.GroupBox();
            this.VendorListView = new System.Windows.Forms.ListView();
            this.ProductUpdateGroupBox = new System.Windows.Forms.GroupBox();
            this.ProductUpdatesListView = new System.Windows.Forms.ListView();
            this.StatusPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ShowAllUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.CheckUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.BaseLayoutPanel.SuspendLayout();
            this.VendorGroupBox.SuspendLayout();
            this.ProductUpdateGroupBox.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseLayoutPanel
            // 
            this.BaseLayoutPanel.ColumnCount = 2;
            this.BaseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.BaseLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.BaseLayoutPanel.Controls.Add(this.VendorGroupBox, 0, 0);
            this.BaseLayoutPanel.Controls.Add(this.ProductUpdateGroupBox, 1, 0);
            this.BaseLayoutPanel.Controls.Add(this.StatusPanel, 1, 1);
            this.BaseLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.BaseLayoutPanel.Name = "BaseLayoutPanel";
            this.BaseLayoutPanel.RowCount = 2;
            this.BaseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BaseLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BaseLayoutPanel.Size = new System.Drawing.Size(1184, 762);
            this.BaseLayoutPanel.TabIndex = 0;
            // 
            // VendorGroupBox
            // 
            this.VendorGroupBox.Controls.Add(this.VendorListView);
            this.VendorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VendorGroupBox.Location = new System.Drawing.Point(3, 3);
            this.VendorGroupBox.Name = "VendorGroupBox";
            this.VendorGroupBox.Size = new System.Drawing.Size(467, 716);
            this.VendorGroupBox.TabIndex = 5;
            this.VendorGroupBox.TabStop = false;
            this.VendorGroupBox.Text = "Vendors";
            // 
            // VendorListView
            // 
            this.VendorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VendorListView.FullRowSelect = true;
            this.VendorListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.VendorListView.HideSelection = false;
            this.VendorListView.Location = new System.Drawing.Point(3, 16);
            this.VendorListView.MultiSelect = false;
            this.VendorListView.Name = "VendorListView";
            this.VendorListView.Size = new System.Drawing.Size(461, 697);
            this.VendorListView.TabIndex = 5;
            this.VendorListView.UseCompatibleStateImageBehavior = false;
            this.VendorListView.View = System.Windows.Forms.View.Details;
            this.VendorListView.SelectedIndexChanged += new System.EventHandler(this.VendorListViewSelectionChanged);
            // 
            // ProductUpdateGroupBox
            // 
            this.ProductUpdateGroupBox.Controls.Add(this.ProductUpdatesListView);
            this.ProductUpdateGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductUpdateGroupBox.Location = new System.Drawing.Point(476, 3);
            this.ProductUpdateGroupBox.Name = "ProductUpdateGroupBox";
            this.ProductUpdateGroupBox.Size = new System.Drawing.Size(705, 716);
            this.ProductUpdateGroupBox.TabIndex = 6;
            this.ProductUpdateGroupBox.TabStop = false;
            this.ProductUpdateGroupBox.Text = "Product Updates";
            // 
            // ProductUpdatesListView
            // 
            this.ProductUpdatesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductUpdatesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ProductUpdatesListView.Location = new System.Drawing.Point(3, 16);
            this.ProductUpdatesListView.MultiSelect = false;
            this.ProductUpdatesListView.Name = "ProductUpdatesListView";
            this.ProductUpdatesListView.Size = new System.Drawing.Size(699, 697);
            this.ProductUpdatesListView.TabIndex = 2;
            this.ProductUpdatesListView.UseCompatibleStateImageBehavior = false;
            this.ProductUpdatesListView.View = System.Windows.Forms.View.Details;
            // 
            // StatusPanel
            // 
            this.StatusPanel.ColumnCount = 2;
            this.StatusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.StatusPanel.Controls.Add(this.ShowAllUpdatesCheckBox, 1, 0);
            this.StatusPanel.Controls.Add(this.StatusLabel, 0, 0);
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusPanel.Location = new System.Drawing.Point(476, 725);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.RowCount = 1;
            this.StatusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.StatusPanel.Size = new System.Drawing.Size(705, 34);
            this.StatusPanel.TabIndex = 7;
            // 
            // ShowAllUpdatesCheckBox
            // 
            this.ShowAllUpdatesCheckBox.AutoSize = true;
            this.ShowAllUpdatesCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowAllUpdatesCheckBox.Location = new System.Drawing.Point(533, 3);
            this.ShowAllUpdatesCheckBox.Name = "ShowAllUpdatesCheckBox";
            this.ShowAllUpdatesCheckBox.Size = new System.Drawing.Size(169, 28);
            this.ShowAllUpdatesCheckBox.TabIndex = 0;
            this.ShowAllUpdatesCheckBox.Text = "Show All Vendor Updates";
            this.ShowAllUpdatesCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.ShowAllVendorUpdates_CheckChanged);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 1;
            // 
            // CheckUpdateTimer
            // 
            this.CheckUpdateTimer.Interval = 1000;
            this.CheckUpdateTimer.Tick += new System.EventHandler(this.CheckUpdatesTimer_Tick);
            // 
            // VendorUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.BaseLayoutPanel);
            this.Name = "VendorUpdateForm";
            this.Text = "Product Update";
            this.Load += new System.EventHandler(this.VendorUpdateForm_FormLoad);
            this.BaseLayoutPanel.ResumeLayout(false);
            this.VendorGroupBox.ResumeLayout(false);
            this.ProductUpdateGroupBox.ResumeLayout(false);
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BaseLayoutPanel;
        private System.Windows.Forms.Timer CheckUpdateTimer;
        private System.Windows.Forms.GroupBox VendorGroupBox;
        private System.Windows.Forms.ListView VendorListView;
        private System.Windows.Forms.GroupBox ProductUpdateGroupBox;
        private System.Windows.Forms.ListView ProductUpdatesListView;
        private System.Windows.Forms.TableLayoutPanel StatusPanel;
        private System.Windows.Forms.CheckBox ShowAllUpdatesCheckBox;
        private System.Windows.Forms.Label StatusLabel;
    }
}

