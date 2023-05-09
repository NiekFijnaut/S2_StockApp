using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Business;
using Interface;


namespace StockAppForms
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();

        }
        
        private void btnLoginLog_Click(object sender, EventArgs e)
        {
            Account account = new Account(
                txtUserNameLog.Text, 
                txtPasswordLog.Text, 
                null, 
                null, 
                null,
                null);

            if (txtPasswordLog.Text == null || txtPasswordLog.Text == "" || txtUserNameLog.Text == null || txtUserNameLog.Text == "")
            {
                MessageBox.Show("Not all fields are filled in");
            }
            else
            {
                AccountContainer accountContainer = new AccountContainer();
                bool PasswordMatches = accountContainer.passwordMatches(account);


                if (PasswordMatches == true)
                {
                    MessageBox.Show("You are logged in");
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Password or Username is incorrect");
                }
                
            }
             
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateAccountLog_Click(object sender, EventArgs e)
        {
            AccountForm account = new AccountForm();
            account.Show();
        }
    }
}
