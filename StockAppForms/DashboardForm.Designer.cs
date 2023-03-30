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
            this.AccountStocks = new System.Windows.Forms.ListBox();
            this.txtSymbolAdd = new System.Windows.Forms.TextBox();
            this.txtSymbolRemove = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddStocks
            // 
            this.btnAddStocks.Location = new System.Drawing.Point(194, 90);
            this.btnAddStocks.Name = "btnAddStocks";
            this.btnAddStocks.Size = new System.Drawing.Size(141, 57);
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
            // AccountStocks
            // 
            this.AccountStocks.FormattingEnabled = true;
            this.AccountStocks.ItemHeight = 20;
            this.AccountStocks.Location = new System.Drawing.Point(194, 159);
            this.AccountStocks.Name = "AccountStocks";
            this.AccountStocks.Size = new System.Drawing.Size(389, 104);
            this.AccountStocks.TabIndex = 4;
            // 
            // txtSymbolAdd
            // 
            this.txtSymbolAdd.Location = new System.Drawing.Point(196, 57);
            this.txtSymbolAdd.Name = "txtSymbolAdd";
            this.txtSymbolAdd.Size = new System.Drawing.Size(139, 27);
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
            this.label1.Location = new System.Drawing.Point(196, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter Symbol";
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
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 341);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSymbolRemove);
            this.Controls.Add(this.txtSymbolAdd);
            this.Controls.Add(this.AccountStocks);
            this.Controls.Add(this.btnRemoveStocks);
            this.Controls.Add(this.btnAddStocks);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnAddStocks;
        private Button btnRemoveStocks;
        private ListBox AccountStocks;
        private TextBox txtSymbolAdd;
        private TextBox txtSymbolRemove;
        private Label label1;
        private Label label2;
    }
}