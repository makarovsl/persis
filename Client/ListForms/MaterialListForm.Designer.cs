namespace Client.ListForms
{
    partial class MaterialListForm
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
            this.materialGridView = new System.Windows.Forms.DataGridView();
            this.materialListAnswerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paginator = new Client.Controls.Paginator();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.materialGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialListAnswerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // materialGridView
            // 
            this.materialGridView.AllowUserToAddRows = false;
            this.materialGridView.AllowUserToDeleteRows = false;
            this.materialGridView.AllowUserToOrderColumns = true;
            this.materialGridView.AutoGenerateColumns = false;
            this.materialGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.ColumnEdit,
            this.ColumnDelete});
            this.materialGridView.DataSource = this.materialListAnswerBindingSource;
            this.materialGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialGridView.Location = new System.Drawing.Point(0, 0);
            this.materialGridView.MultiSelect = false;
            this.materialGridView.Name = "materialGridView";
            this.materialGridView.ReadOnly = true;
            this.materialGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.materialGridView.Size = new System.Drawing.Size(700, 314);
            this.materialGridView.TabIndex = 1;
            // 
            // materialListAnswerBindingSource
            // 
            this.materialListAnswerBindingSource.DataSource = typeof(Core.Models.Material.MaterialListAnswer);
            // 
            // paginator
            // 
            this.paginator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paginator.Location = new System.Drawing.Point(0, 283);
            this.paginator.Name = "paginator";
            this.paginator.Size = new System.Drawing.Size(700, 31);
            this.paginator.TabIndex = 2;
            this.paginator.PageChange += new System.EventHandler(this.RebindGrid);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
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
            // MaterialListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 314);
            this.Controls.Add(this.paginator);
            this.Controls.Add(this.materialGridView);
            this.Name = "MaterialListForm";
            this.Text = "Список материалов";
            ((System.ComponentModel.ISupportInitialize)(this.materialGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialListAnswerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource materialListAnswerBindingSource;
        private System.Windows.Forms.DataGridView materialGridView;
        private Controls.Paginator paginator;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}