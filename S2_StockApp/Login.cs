﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAppForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCreateAccountLog_Click(object sender, EventArgs e)
        {
            AccountForm account = new AccountForm();
            account.Show();
        }

        private void btnLoginLog_Click(object sender, EventArgs e)
        {
            
            
            
            
            
            
            Home home = new Home();
            home.Show();
        }
    }
}
