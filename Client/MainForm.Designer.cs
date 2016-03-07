using Client.ListForms;

namespace Client
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialListButtomMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addMaterialButtomMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.деталиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addDetailButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 24);
            this.mainMenu.TabIndex = 1;
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалыToolStripMenuItem,
            this.деталиToolStripMenuItem,
            this.изделияToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // материалыToolStripMenuItem
            // 
            this.материалыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialListButtomMenu,
            this.addMaterialButtomMenu});
            this.материалыToolStripMenuItem.Name = "материалыToolStripMenuItem";
            this.материалыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.материалыToolStripMenuItem.Text = "Материалы";
            // 
            // materialListButtomMenu
            // 
            this.materialListButtomMenu.Name = "materialListButtomMenu";
            this.materialListButtomMenu.Size = new System.Drawing.Size(184, 22);
            this.materialListButtomMenu.Text = "Список материалов";
            this.materialListButtomMenu.Click += new System.EventHandler(this.OpenMdiChildForm);
            // 
            // addMaterialButtomMenu
            // 
            this.addMaterialButtomMenu.Name = "addMaterialButtomMenu";
            this.addMaterialButtomMenu.Size = new System.Drawing.Size(184, 22);
            this.addMaterialButtomMenu.Text = "Добавить материал";
            this.addMaterialButtomMenu.Click += new System.EventHandler(this.OpenMdiChildForm);
            // 
            // деталиToolStripMenuItem
            // 
            this.деталиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailButtonMenu,
            this.addDetailButtonMenu});
            this.деталиToolStripMenuItem.Name = "деталиToolStripMenuItem";
            this.деталиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.деталиToolStripMenuItem.Text = "Детали";
            // 
            // detailButtonMenu
            // 
            this.detailButtonMenu.Name = "detailButtonMenu";
            this.detailButtonMenu.Size = new System.Drawing.Size(165, 22);
            this.detailButtonMenu.Text = "Список деталей";
            this.detailButtonMenu.Click += new System.EventHandler(this.OpenMdiChildForm);
            // 
            // addDetailButtonMenu
            // 
            this.addDetailButtonMenu.Name = "addDetailButtonMenu";
            this.addDetailButtonMenu.Size = new System.Drawing.Size(165, 22);
            this.addDetailButtonMenu.Text = "Добавить деталь";
            this.addDetailButtonMenu.Click += new System.EventHandler(this.OpenMdiChildForm);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productButtonMenu,
            this.addProductButtonMenu});
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.изделияToolStripMenuItem.Text = "Изделия";
            // 
            // productButtonMenu
            // 
            this.productButtonMenu.Name = "productButtonMenu";
            this.productButtonMenu.Size = new System.Drawing.Size(173, 22);
            this.productButtonMenu.Text = "Список изделий";
            this.productButtonMenu.Click += new System.EventHandler(this.OpenMdiChildForm);
            // 
            // addProductButtonMenu
            // 
            this.addProductButtonMenu.Name = "addProductButtonMenu";
            this.addProductButtonMenu.Size = new System.Drawing.Size(173, 22);
            this.addProductButtonMenu.Text = "Добавить изделие";
            this.addProductButtonMenu.Click += new System.EventHandler(this.OpenMdiChildForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "PerSis";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem материалыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialListButtomMenu;
        private System.Windows.Forms.ToolStripMenuItem addMaterialButtomMenu;
        private System.Windows.Forms.ToolStripMenuItem деталиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailButtonMenu;
        private System.Windows.Forms.ToolStripMenuItem addDetailButtonMenu;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productButtonMenu;
        private System.Windows.Forms.ToolStripMenuItem addProductButtonMenu;
    }
}