namespace StockAppForms
{
    partial class HistorieForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbInterval = new System.Windows.Forms.ComboBox();
            this.cbSlice = new System.Windows.Forms.ComboBox();
            this.txtSymbolAdd = new System.Windows.Forms.TextBox();
            this.btnViewHistorie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(243, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(662, 412);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(663, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Symbol Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interval";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Slice";
            // 
            // cbInterval
            // 
            this.cbInterval.FormattingEnabled = true;
            this.cbInterval.Location = new System.Drawing.Point(18, 53);
            this.cbInterval.Name = "cbInterval";
            this.cbInterval.Size = new System.Drawing.Size(151, 28);
            this.cbInterval.TabIndex = 4;
            // 
            // cbSlice
            // 
            this.cbSlice.FormattingEnabled = true;
            this.cbSlice.Location = new System.Drawing.Point(336, 53);
            this.cbSlice.Name = "cbSlice";
            this.cbSlice.Size = new System.Drawing.Size(151, 28);
            this.cbSlice.TabIndex = 5;
            // 
            // txtSymbolAdd
            // 
            this.txtSymbolAdd.Location = new System.Drawing.Point(663, 54);
            this.txtSymbolAdd.Name = "txtSymbolAdd";
            this.txtSymbolAdd.Size = new System.Drawing.Size(125, 27);
            this.txtSymbolAdd.TabIndex = 6;
            // 
            // btnViewHistorie
            // 
            this.btnViewHistorie.Location = new System.Drawing.Point(18, 122);
            this.btnViewHistorie.Name = "btnViewHistorie";
            this.btnViewHistorie.Size = new System.Drawing.Size(151, 58);
            this.btnViewHistorie.TabIndex = 7;
            this.btnViewHistorie.Text = "View Historie";
            this.btnViewHistorie.UseVisualStyleBackColor = true;
            this.btnViewHistorie.Click += new System.EventHandler(this.btnViewHistorie_Click_1);
            // 
            // HistorieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 555);
            this.Controls.Add(this.btnViewHistorie);
            this.Controls.Add(this.txtSymbolAdd);
            this.Controls.Add(this.cbSlice);
            this.Controls.Add(this.cbInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "HistorieForm";
            this.Text = "HistroieFrom";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbInterval;
        private ComboBox cbSlice;
        private TextBox txtSymbolAdd;
        private Button btnViewHistorie;
    }
}