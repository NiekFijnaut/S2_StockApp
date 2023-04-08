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
using Interface;
using Business;
using Data;

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


            if (txtPasswordLog.Text == null || txtPasswordLog.Text == "" || txtUserNameLog.Text == null || txtUserNameLog.Text == "")
            {
                MessageBox.Show("Not all fields are filled in");
            }

            
            try
            {

                AccountDTO account = AccountDAL.VerifyPassword();

                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();

            }
            catch (Exception exmsg)
            {
                MessageBox.Show(exmsg.Message);
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
