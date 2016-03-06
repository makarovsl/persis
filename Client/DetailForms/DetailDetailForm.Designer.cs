namespace Client.DetailForms
{
    partial class DetailDetailForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.detailNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.materialGridView = new System.Windows.Forms.DataGridView();
            this.materialOfDetailItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simpleListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MaterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.materialCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialOfDetailItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleListItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 32);
            this.panel1.TabIndex = 5;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(331, 5);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(412, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.detailNameTB);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 38);
            this.panel2.TabIndex = 10;
            // 
            // detailNameTB
            // 
            this.detailNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailNameTB.Location = new System.Drawing.Point(167, 6);
            this.detailNameTB.Name = "detailNameTB";
            this.detailNameTB.Size = new System.Drawing.Size(319, 26);
            this.detailNameTB.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Наименование";
            // 
            // materialGridView
            // 
            this.materialGridView.AutoGenerateColumns = false;
            this.materialGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialId,
            this.MaterialName,
            this.materialCountDataGridViewTextBoxColumn,
            this.Delete});
            this.materialGridView.DataSource = this.materialOfDetailItemBindingSource;
            this.materialGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialGridView.Location = new System.Drawing.Point(0, 38);
            this.materialGridView.Name = "materialGridView";
            this.materialGridView.Size = new System.Drawing.Size(499, 222);
            this.materialGridView.TabIndex = 11;
            this.materialGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.materialGridView_CellBeginEdit);
            this.materialGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialGridView_CellContentClick);
            // 
            // materialOfDetailItemBindingSource
            // 
            this.materialOfDetailItemBindingSource.DataSource = typeof(Core.Models.Material.MaterialOfDetailItem);
            // 
            // simpleListItemBindingSource
            // 
            this.simpleListItemBindingSource.DataSource = typeof(Core.Models.SimpleListItem);
            // 
            // MaterialId
            // 
            this.MaterialId.DataPropertyName = "MaterialId";
            this.MaterialId.HeaderText = "MaterialId";
            this.MaterialId.Name = "MaterialId";
            this.MaterialId.Visible = false;
            // 
            // MaterialName
            // 
            this.MaterialName.DataPropertyName = "MaterialId";
            this.MaterialName.DataSource = this.simpleListItemBindingSource;
            this.MaterialName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MaterialName.HeaderText = "Материал";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaterialName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // materialCountDataGridViewTextBoxColumn
            // 
            this.materialCountDataGridViewTextBoxColumn.DataPropertyName = "MaterialCount";
            this.materialCountDataGridViewTextBoxColumn.HeaderText = "Количество материалов";
            this.materialCountDataGridViewTextBoxColumn.Name = "materialCountDataGridViewTextBoxColumn";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::Client.Properties.Resources.delete_icon;
            this.Delete.Name = "Delete";
            // 
            // DetailDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 292);
            this.Controls.Add(this.materialGridView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DetailDetailForm";
            this.Text = "DetailDetailFom";
            this.Load += new System.EventHandler(this.RebindData);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialOfDetailItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleListItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView materialGridView;
        private System.Windows.Forms.BindingSource materialOfDetailItemBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox detailNameTB;
        private System.Windows.Forms.BindingSource simpleListItemBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialId;
    }
}