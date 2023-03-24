namespace StockAppForm
{
    partial class AccountForm
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
            this.btnCreateAccountAcc = new System.Windows.Forms.Button();
            this.btnLoginAcc = new System.Windows.Forms.Button();
            this.txtPasswordAcc = new System.Windows.Forms.TextBox();
            this.txtUserNameAcc = new System.Windows.Forms.TextBox();
            this.Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtEmailAcc = new System.Windows.Forms.TextBox();
            this.cbRegionAcc = new System.Windows.Forms.ComboBox();
            this.cbInterestAcc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCreateAccountAcc
            // 
            this.btnCreateAccountAcc.Location = new System.Drawing.Point(310, 323);
            this.btnCreateAccountAcc.Name = "btnCreateAccountAcc";
            this.btnCreateAccountAcc.Size = new System.Drawing.Size(233, 50);
            this.btnCreateAccountAcc.TabIndex = 13;
            this.btnCreateAccountAcc.Text = "Create Account";
            this.btnCreateAccountAcc.UseVisualStyleBackColor = true;
            this.btnCreateAccountAcc.Click += new System.EventHandler(this.btnCreateAccountAcc_Click);
            // 
            // btnLoginAcc
            // 
            this.btnLoginAcc.Location = new System.Drawing.Point(311, 379);
            this.btnLoginAcc.Name = "btnLoginAcc";
            this.btnLoginAcc.Size = new System.Drawing.Size(232, 46);
            this.btnLoginAcc.TabIndex = 12;
            this.btnLoginAcc.Text = "Login";
            this.btnLoginAcc.UseVisualStyleBackColor = true;
            this.btnLoginAcc.Click += new System.EventHandler(this.btnLoginAcc_Click);
            // 
            // txtPasswordAcc
            // 
            this.txtPasswordAcc.Location = new System.Drawing.Point(154, 207);
            this.txtPasswordAcc.Name = "txtPasswordAcc";
            this.txtPasswordAcc.Size = new System.Drawing.Size(233, 22);
            this.txtPasswordAcc.TabIndex = 11;
            // 
            // txtUserNameAcc
            // 
            this.txtUserNameAcc.Location = new System.Drawing.Point(154, 139);
            this.txtUserNameAcc.Name = "txtUserNameAcc";
            this.txtUserNameAcc.Size = new System.Drawing.Size(233, 22);
            this.txtUserNameAcc.TabIndex = 10;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(151, 188);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(67, 16);
            this.Label.TabIndex = 9;
            this.Label.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Region";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Interest";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Age";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(446, 270);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // txtEmailAcc
            // 
            this.txtEmailAcc.Location = new System.Drawing.Point(157, 270);
            this.txtEmailAcc.Name = "txtEmailAcc";
            this.txtEmailAcc.Size = new System.Drawing.Size(233, 22);
            this.txtEmailAcc.TabIndex = 19;
            // 
            // cbRegionAcc
            // 
            this.cbRegionAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegionAcc.FormattingEnabled = true;
            this.cbRegionAcc.Location = new System.Drawing.Point(446, 139);
            this.cbRegionAcc.Name = "cbRegionAcc";
            this.cbRegionAcc.Size = new System.Drawing.Size(233, 24);
            this.cbRegionAcc.TabIndex = 20;
            // 
            // cbInterestAcc
            // 
            this.cbInterestAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterestAcc.FormattingEnabled = true;
            this.cbInterestAcc.Items.AddRange(new object[] {
            "Energy (Energie)",
            "Materials (Materialen)",
            "Industrials (Industrie)",
            "Consumer Discretionary (Cyclische Consumptiegoederen)",
            "Consumer Staples (Defensieve Consumptiegoederen)",
            "Health Care (Gezondheidszorg)",
            "Financials (Financiële Dienstverlening)",
            "Information Technology (Technologie)",
            "Telecommunication Services (Communicatiediensten)",
            "Utilities (Nutsbedrijven)",
            "Real Estate (Vastgoed)"});
            this.cbInterestAcc.Location = new System.Drawing.Point(446, 207);
            this.cbInterestAcc.Name = "cbInterestAcc";
            this.cbInterestAcc.Size = new System.Drawing.Size(233, 24);
            this.cbInterestAcc.TabIndex = 21;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbInterestAcc);
            this.Controls.Add(this.cbRegionAcc);
            this.Controls.Add(this.txtEmailAcc);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateAccountAcc);
            this.Controls.Add(this.btnLoginAcc);
            this.Controls.Add(this.txtPasswordAcc);
            this.Controls.Add(this.txtUserNameAcc);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account";
            this.Load += new System.EventHandler(this.Account_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateAccountAcc;
        private System.Windows.Forms.Button btnLoginAcc;
        private System.Windows.Forms.TextBox txtPasswordAcc;
        private System.Windows.Forms.TextBox txtUserNameAcc;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtEmailAcc;
        private System.Windows.Forms.ComboBox cbRegionAcc;
        private System.Windows.Forms.ComboBox cbInterestAcc;
    }
}