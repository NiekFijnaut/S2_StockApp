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
          /*if (txtPasswordLog.Text == null || txtUserNameLog.Text == null)
            {
                MessageBox.Show("Not all required fields are filled in");
            }
            if (txtUserNameLog.Text != ... && txtPasswordLog.Text != ...)
            {
                MessageBox.Show("password or username is incorrect");
            }*/
            if (txtPasswordLog.Text == null || txtPasswordLog.Text == "" || txtUserNameLog.Text == null || txtUserNameLog.Text == "")
            {
                MessageBox.Show("Not all fields are filled in");
            }
            else 
            {
                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();
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
