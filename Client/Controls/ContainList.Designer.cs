namespace Client.Controls
{
    partial class ContainList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.selectGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.simpleListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.containObjectItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleListItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containObjectItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.button1);
            this.buttonPanel.Controls.Add(this.buttonAdd);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(584, 28);
            this.buttonPanel.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAdd.Image = global::Client.Properties.Resources.add_icon;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(0, 0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(86, 28);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.AddNewItem);
            // 
            // selectGridView
            // 
            this.selectGridView.AllowUserToAddRows = false;
            this.selectGridView.AllowUserToDeleteRows = false;
            this.selectGridView.AutoGenerateColumns = false;
            this.selectGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Count});
            this.selectGridView.DataSource = this.containObjectItemBindingSource;
            this.selectGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectGridView.Location = new System.Drawing.Point(0, 28);
            this.selectGridView.MultiSelect = false;
            this.selectGridView.Name = "selectGridView";
            this.selectGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.selectGridView.Size = new System.Drawing.Size(584, 233);
            this.selectGridView.TabIndex = 1;
            this.selectGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.CellBeginEdit);
            this.selectGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectGridView_CellEndEdit);
            this.selectGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.EditingControlShowing);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.DataPropertyName = "Id";
            this.Id.DataSource = this.simpleListItemBindingSource;
            this.Id.DisplayMember = "Name";
            this.Id.HeaderText = "Наименование";
            this.Id.Name = "Id";
            this.Id.ValueMember = "Id";
            // 
            // simpleListItemBindingSource
            // 
            this.simpleListItemBindingSource.DataSource = typeof(Core.Models.SimpleListItem);
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // containObjectItemBindingSource
            // 
            this.containObjectItemBindingSource.DataSource = typeof(Core.Models.ContainObjectItem);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Image = global::Client.Properties.Resources.delete_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(86, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Удалить";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeleteItem);
            // 
            // ContainList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectGridView);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ContainList";
            this.Size = new System.Drawing.Size(584, 261);
            this.Load += new System.EventHandler(this.InitGrid);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleListItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containObjectItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.DataGridView selectGridView;
        private System.Windows.Forms.BindingSource containObjectItemBindingSource;
        private System.Windows.Forms.BindingSource simpleListItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewComboBoxColumn Id;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button button1;
    }
}
