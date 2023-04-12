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
                if (string.IsNullOrEmpty(exmsg.Message))
                {
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();
                }
            }
            catch (Exception exmsg)
            {
                if (!string.IsNullOrEmpty(exmsg.Message))
                {
                    if (exmsg.Message == "Username has already been chosen")
                    {
                        MessageBox.Show(exmsg.Message);
                    }
                    else if (exmsg.Message == "Password doesnt match with the Username")
                    {
                        MessageBox.Show(exmsg.Message);
                    }
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
