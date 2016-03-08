namespace Client.ListForms
{
    partial class DetailListForm
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
            this.detailGridView = new System.Windows.Forms.DataGridView();
            this.detailListAnswerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailListAnswerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // paginator
            // 
            this.paginator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paginator.Location = new System.Drawing.Point(0, 228);
            this.paginator.Name = "paginator";
            this.paginator.Size = new System.Drawing.Size(760, 31);
            this.paginator.TabIndex = 0;
            // 
            // detailGridView
            // 
            this.detailGridView.AllowUserToAddRows = false;
            this.detailGridView.AllowUserToDeleteRows = false;
            this.detailGridView.AllowUserToOrderColumns = true;
            this.detailGridView.AutoGenerateColumns = false;
            this.detailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.nameDataGridViewTextBoxColumn,
            this.ColumnEdit,
            this.ColumnDelete});
            this.detailGridView.DataSource = this.detailListAnswerBindingSource;
            this.detailGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailGridView.Location = new System.Drawing.Point(0, 0);
            this.detailGridView.MultiSelect = false;
            this.detailGridView.Name = "detailGridView";
            this.detailGridView.ReadOnly = true;
            this.detailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.detailGridView.Size = new System.Drawing.Size(760, 228);
            this.detailGridView.TabIndex = 1;
            // 
            // detailListAnswerBindingSource
            // 
            this.detailListAnswerBindingSource.DataSource = typeof(Core.Models.Detail.DetailListAnswer);
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
            // 
            // Edit
            // 
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Image = global::Client.Properties.Resources.edit_icon;
            this.ColumnEdit.MinimumWidth = 20;
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            this.ColumnEdit.Width = 20;
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
            // DetailListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 259);
            this.Controls.Add(this.detailGridView);
            this.Controls.Add(this.paginator);
            this.Name = "DetailListForm";
            this.Text = "Список деталей";
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailListAnswerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Paginator paginator;
        private System.Windows.Forms.BindingSource detailListAnswerBindingSource;
        private System.Windows.Forms.DataGridView detailGridView;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}