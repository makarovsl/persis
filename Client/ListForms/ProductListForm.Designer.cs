namespace Client.ListForms
{
    partial class ProductListForm
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
            this.paginator = new Client.Controls.Paginator();
            this.productGridView = new System.Windows.Forms.DataGridView();
            this.productListAnswerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ColumnProduce = new System.Windows.Forms.DataGridViewImageColumn();

            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListAnswerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // paginator
            // 
            this.paginator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paginator.Location = new System.Drawing.Point(0, 203);
            this.paginator.Name = "paginator";
            this.paginator.Size = new System.Drawing.Size(748, 31);
            this.paginator.TabIndex = 0;
            // 
            // productGridView
            // 
            this.productGridView.AllowUserToAddRows = false;
            this.productGridView.AllowUserToDeleteRows = false;
            this.productGridView.AutoGenerateColumns = false;
            this.productGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ColumnName,
            this.ProductCount,
            ColumnProduce,
            this.ColumnEdit,
            this.ColumnDelete});
            this.productGridView.DataSource = this.productListAnswerBindingSource;
            this.productGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productGridView.Location = new System.Drawing.Point(0, 0);
            this.productGridView.MultiSelect = false;
            this.productGridView.Name = "productGridView";
            this.productGridView.ReadOnly = true;
            this.productGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productGridView.Size = new System.Drawing.Size(748, 203);
            this.productGridView.TabIndex = 1;
            // 
            // productListAnswerBindingSource
            // 
            this.productListAnswerBindingSource.DataSource = typeof(Core.Models.Product.ProductListAnswer);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.DataPropertyName = "Name";
            this.ColumnName.HeaderText = "Наименование";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ProductCount
            // 
            this.ProductCount.DataPropertyName = "Count";
            this.ProductCount.HeaderText = "Количество к производству";
            this.ProductCount.Name = "ProductCount";
            this.ProductCount.ReadOnly = true;
            //
            //Produce
            //
            ColumnProduce.HeaderText = "";
            ColumnProduce.Image = Properties.Resources.create_icon;
            ColumnProduce.Name = "ColumnProduce";
            ColumnProduce.ReadOnly = true;
            ColumnProduce.MinimumWidth = 20;
            ColumnProduce.Width = 20;


            // 
            // Edit
            // 
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Image = global::Client.Properties.Resources.edit_icon;
            this.ColumnEdit.MinimumWidth = 25;
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            this.ColumnEdit.Width = 25;
            // 
            // Delete
            // 
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Image = global::Client.Properties.Resources.delete_icon;
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            ColumnDelete.MinimumWidth = 20;
            ColumnDelete.Width = 20;
            // 
            // ProductListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 234);
            this.Controls.Add(this.productGridView);
            this.Controls.Add(this.paginator);
            this.Name = "ProductListForm";
            this.Text = "Изделия";
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productListAnswerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Paginator paginator;
        private System.Windows.Forms.DataGridView productGridView;
        private System.Windows.Forms.BindingSource productListAnswerBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnProduce;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}