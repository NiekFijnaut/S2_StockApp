namespace StockAppForms
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserNameAcc = new System.Windows.Forms.TextBox();
            this.txtPasswordAcc = new System.Windows.Forms.TextBox();
            this.txtEmailAcc = new System.Windows.Forms.TextBox();
            this.cbInterestAcc = new System.Windows.Forms.ComboBox();
            this.cbRegionAcc = new System.Windows.Forms.ComboBox();
            this.dtpAgeAcc = new System.Windows.Forms.DateTimePicker();
            this.btnCreateAccountAcc = new System.Windows.Forms.Button();
            this.btnLoginAcc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(316, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Interest";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Region";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(415, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Age";
            // 
            // txtUserNameAcc
            // 
            this.txtUserNameAcc.Location = new System.Drawing.Point(202, 137);
            this.txtUserNameAcc.Name = "txtUserNameAcc";
            this.txtUserNameAcc.Size = new System.Drawing.Size(185, 27);
            this.txtUserNameAcc.TabIndex = 7;
            // 
            // txtPasswordAcc
            // 
            this.txtPasswordAcc.Location = new System.Drawing.Point(202, 209);
            this.txtPasswordAcc.Name = "txtPasswordAcc";
            this.txtPasswordAcc.Size = new System.Drawing.Size(185, 27);
            this.txtPasswordAcc.TabIndex = 8;
            // 
            // txtEmailAcc
            // 
            this.txtEmailAcc.Location = new System.Drawing.Point(202, 278);
            this.txtEmailAcc.Name = "txtEmailAcc";
            this.txtEmailAcc.Size = new System.Drawing.Size(185, 27);
            this.txtEmailAcc.TabIndex = 9;
            // 
            // cbInterestAcc
            // 
            this.cbInterestAcc.FormattingEnabled = true;
            this.cbInterestAcc.Location = new System.Drawing.Point(415, 136);
            this.cbInterestAcc.Name = "cbInterestAcc";
            this.cbInterestAcc.Size = new System.Drawing.Size(185, 28);
            this.cbInterestAcc.TabIndex = 10;
            // 
            // cbRegionAcc
            // 
            this.cbRegionAcc.FormattingEnabled = true;
            this.cbRegionAcc.Location = new System.Drawing.Point(415, 208);
            this.cbRegionAcc.Name = "cbRegionAcc";
            this.cbRegionAcc.Size = new System.Drawing.Size(185, 28);
            this.cbRegionAcc.TabIndex = 11;
            // 
            // dtpAgeAcc
            // 
            this.dtpAgeAcc.Location = new System.Drawing.Point(415, 278);
            this.dtpAgeAcc.Name = "dtpAgeAcc";
            this.dtpAgeAcc.Size = new System.Drawing.Size(185, 27);
            this.dtpAgeAcc.TabIndex = 12;
            // 
            // btnCreateAccountAcc
            // 
            this.btnCreateAccountAcc.Location = new System.Drawing.Point(322, 328);
            this.btnCreateAccountAcc.Name = "btnCreateAccountAcc";
            this.btnCreateAccountAcc.Size = new System.Drawing.Size(168, 42);
            this.btnCreateAccountAcc.TabIndex = 13;
            this.btnCreateAccountAcc.Text = "Create Account";
            this.btnCreateAccountAcc.UseVisualStyleBackColor = true;
            this.btnCreateAccountAcc.Click += new System.EventHandler(this.btnCreateAccountAcc_Click);
            // 
            // btnLoginAcc
            // 
            this.btnLoginAcc.Location = new System.Drawing.Point(322, 376);
            this.btnLoginAcc.Name = "btnLoginAcc";
            this.btnLoginAcc.Size = new System.Drawing.Size(168, 42);
            this.btnLoginAcc.TabIndex = 14;
            this.btnLoginAcc.Text = "Login";
            this.btnLoginAcc.UseVisualStyleBackColor = true;
            this.btnLoginAcc.Click += new System.EventHandler(this.btnLoginAcc_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoginAcc);
            this.Controls.Add(this.btnCreateAccountAcc);
            this.Controls.Add(this.dtpAgeAcc);
            this.Controls.Add(this.cbRegionAcc);
            this.Controls.Add(this.cbInterestAcc);
            this.Controls.Add(this.txtEmailAcc);
            this.Controls.Add(this.txtPasswordAcc);
            this.Controls.Add(this.txtUserNameAcc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtUserNameAcc;
        private TextBox txtPasswordAcc;
        private TextBox txtEmailAcc;
        private ComboBox cbInterestAcc;
        private ComboBox cbRegionAcc;
        private DateTimePicker dtpAgeAcc;
        private Button btnCreateAccountAcc;
        private Button btnLoginAcc;
    }
}