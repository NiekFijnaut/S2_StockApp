namespace StockAppForm
{
    partial class Login
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
            this.txtUserNameLog = new System.Windows.Forms.TextBox();
            this.txtPasswordLog = new System.Windows.Forms.TextBox();
            this.btnLoginLog = new System.Windows.Forms.Button();
            this.btnCreateAccountLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtUserNameLog
            // 
            this.txtUserNameLog.Location = new System.Drawing.Point(220, 143);
            this.txtUserNameLog.Name = "txtUserNameLog";
            this.txtUserNameLog.Size = new System.Drawing.Size(233, 22);
            this.txtUserNameLog.TabIndex = 3;
            // 
            // txtPasswordLog
            // 
            this.txtPasswordLog.Location = new System.Drawing.Point(220, 226);
            this.txtPasswordLog.Name = "txtPasswordLog";
            this.txtPasswordLog.Size = new System.Drawing.Size(233, 22);
            this.txtPasswordLog.TabIndex = 4;
            // 
            // btnLoginLog
            // 
            this.btnLoginLog.Location = new System.Drawing.Point(221, 283);
            this.btnLoginLog.Name = "btnLoginLog";
            this.btnLoginLog.Size = new System.Drawing.Size(232, 46);
            this.btnLoginLog.TabIndex = 5;
            this.btnLoginLog.Text = "Login";
            this.btnLoginLog.UseVisualStyleBackColor = true;
            this.btnLoginLog.Click += new System.EventHandler(this.btnLoginLog_Click);
            // 
            // btnCreateAccountLog
            // 
            this.btnCreateAccountLog.Location = new System.Drawing.Point(220, 345);
            this.btnCreateAccountLog.Name = "btnCreateAccountLog";
            this.btnCreateAccountLog.Size = new System.Drawing.Size(233, 50);
            this.btnCreateAccountLog.TabIndex = 6;
            this.btnCreateAccountLog.Text = "Create Account";
            this.btnCreateAccountLog.UseVisualStyleBackColor = true;
            this.btnCreateAccountLog.Click += new System.EventHandler(this.btnCreateAccountLog_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 450);
            this.Controls.Add(this.btnCreateAccountLog);
            this.Controls.Add(this.btnLoginLog);
            this.Controls.Add(this.txtPasswordLog);
            this.Controls.Add(this.txtUserNameLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserNameLog;
        private System.Windows.Forms.TextBox txtPasswordLog;
        private System.Windows.Forms.Button btnLoginLog;
        private System.Windows.Forms.Button btnCreateAccountLog;
    }
}

