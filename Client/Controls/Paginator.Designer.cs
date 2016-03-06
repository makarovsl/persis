namespace Client.Controls
{
    partial class Paginator
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
            this.label1 = new System.Windows.Forms.Label();
            this.pageUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPageCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pageSizeUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pageUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Страница";
            // 
            // pageUpDown
            // 
            this.pageUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageUpDown.Location = new System.Drawing.Point(92, 2);
            this.pageUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageUpDown.Name = "pageUpDown";
            this.pageUpDown.Size = new System.Drawing.Size(49, 26);
            this.pageUpDown.TabIndex = 1;
            this.pageUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(147, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "из";
            // 
            // labelPageCount
            // 
            this.labelPageCount.AutoSize = true;
            this.labelPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPageCount.Location = new System.Drawing.Point(179, 6);
            this.labelPageCount.Name = "labelPageCount";
            this.labelPageCount.Size = new System.Drawing.Size(99, 20);
            this.labelPageCount.TabIndex = 3;
            this.labelPageCount.Text = "1231231231";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(318, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Элементов на странице";
            // 
            // pageSizeUpDown
            // 
            this.pageSizeUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageSizeUpDown.Location = new System.Drawing.Point(517, 1);
            this.pageSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageSizeUpDown.Name = "pageSizeUpDown";
            this.pageSizeUpDown.Size = new System.Drawing.Size(49, 26);
            this.pageSizeUpDown.TabIndex = 5;
            this.pageSizeUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Paginator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageSizeUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPageCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pageUpDown);
            this.Controls.Add(this.label1);
            this.Name = "Paginator";
            this.Size = new System.Drawing.Size(581, 31);
            this.Load += new System.EventHandler(this.Paginator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pageUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown pageUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPageCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown pageSizeUpDown;
    }
}
