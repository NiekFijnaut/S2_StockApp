namespace StockAppForms
{
    partial class DashboardForm
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
            this.btnAddStocks = new System.Windows.Forms.Button();
            this.btnRemoveStocks = new System.Windows.Forms.Button();
            this.txtSymbolAdd = new System.Windows.Forms.TextBox();
            this.txtSymbolRemove = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbinterval = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSymbolName = new System.Windows.Forms.Label();
            this.labelLastRefreshed = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddStocks
            // 
            this.btnAddStocks.Location = new System.Drawing.Point(40, 214);
            this.btnAddStocks.Name = "btnAddStocks";
            this.btnAddStocks.Size = new System.Drawing.Size(151, 57);
            this.btnAddStocks.TabIndex = 2;
            this.btnAddStocks.Text = "Add Stock";
            this.btnAddStocks.UseVisualStyleBackColor = true;
            this.btnAddStocks.Click += new System.EventHandler(this.btnAddStocks_Click);
            // 
            // btnRemoveStocks
            // 
            this.btnRemoveStocks.Location = new System.Drawing.Point(442, 90);
            this.btnRemoveStocks.Name = "btnRemoveStocks";
            this.btnRemoveStocks.Size = new System.Drawing.Size(141, 57);
            this.btnRemoveStocks.TabIndex = 3;
            this.btnRemoveStocks.Text = "Remove Stock";
            this.btnRemoveStocks.UseVisualStyleBackColor = true;
            // 
            // txtSymbolAdd
            // 
            this.txtSymbolAdd.Location = new System.Drawing.Point(40, 79);
            this.txtSymbolAdd.Name = "txtSymbolAdd";
            this.txtSymbolAdd.Size = new System.Drawing.Size(151, 27);
            this.txtSymbolAdd.TabIndex = 5;
            // 
            // txtSymbolRemove
            // 
            this.txtSymbolRemove.Location = new System.Drawing.Point(442, 57);
            this.txtSymbolRemove.Name = "txtSymbolRemove";
            this.txtSymbolRemove.Size = new System.Drawing.Size(139, 27);
            this.txtSymbolRemove.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Add Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Enter Symbol";
            // 
            // cbinterval
            // 
            this.cbinterval.FormattingEnabled = true;
            this.cbinterval.Location = new System.Drawing.Point(40, 149);
            this.cbinterval.Name = "cbinterval";
            this.cbinterval.Size = new System.Drawing.Size(151, 28);
            this.cbinterval.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ticker-Symbol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "interval";
            // 
            // labelSymbolName
            // 
            this.labelSymbolName.AutoSize = true;
            this.labelSymbolName.Location = new System.Drawing.Point(40, 318);
            this.labelSymbolName.Name = "labelSymbolName";
            this.labelSymbolName.Size = new System.Drawing.Size(50, 20);
            this.labelSymbolName.TabIndex = 12;
            this.labelSymbolName.Text = "label5";
            // 
            // labelLastRefreshed
            // 
            this.labelLastRefreshed.AutoSize = true;
            this.labelLastRefreshed.Location = new System.Drawing.Point(207, 318);
            this.labelLastRefreshed.Name = "labelLastRefreshed";
            this.labelLastRefreshed.Size = new System.Drawing.Size(50, 20);
            this.labelLastRefreshed.TabIndex = 13;
            this.labelLastRefreshed.Text = "label6";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(391, 318);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(50, 20);
            this.labelInterval.TabIndex = 14;
            this.labelInterval.Text = "label7";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 378);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1030, 478);
            this.dataGridView1.TabIndex = 16;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 887);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelLastRefreshed);
            this.Controls.Add(this.labelSymbolName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbinterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSymbolRemove);
            this.Controls.Add(this.txtSymbolAdd);
            this.Controls.Add(this.btnRemoveStocks);
            this.Controls.Add(this.btnAddStocks);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnAddStocks;
        private Button btnRemoveStocks;
        private TextBox txtSymbolAdd;
        private TextBox txtSymbolRemove;
        private Label label1;
        private Label label2;
        private ComboBox cbinterval;
        private Label label3;
        private Label label4;
        private Label labelSymbolName;
        private Label labelLastRefreshed;
        private Label labelInterval;
        private DataGridView dataGridView1;
    }
}