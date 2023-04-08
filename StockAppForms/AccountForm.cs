using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Data;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StockAppForms
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            string[] itemsInterest = new string[] { "Energy (Energie)", "Materials (Materialen)", "Industrials (Industrie)", "Consumer Discretionary (Cyclische Consumptiegoederen)", "Consumer Staples (Defensieve Consumptiegoederen)", "Health Care (Gezondheidszorg)", "Financials (Financiële Dienstverlening)", "Information Technology (Technologie)", "Telecommunication Services (Communicatiediensten)", "Utilities (Nutsbedrijven)", "Real Estate (Vastgoed)" };
            cbInterestAcc.Items.AddRange(itemsInterest);

            string[] itemsRegion = new string[] { "Americas (North America, South America, Central America, Caribbean)", "Asia Pacific (Central & South Asia, Northeastern Asia, Southeastern Asia, Australia and Oceania)", "Europe (Northern Europe, Southern Europe, Eastern Europe, Western Europe)", "Middle East/Africa (Middle East, Northern Africa, Southern Africa)" };
            cbRegionAcc.Items.AddRange(itemsRegion);
        }

        private void Account_Load(object sender, EventArgs e)
        {
            

        }


        private void btnCreateAccountAcc_Click(object sender, EventArgs e)
        {

            string password = txtPasswordAcc.Text;

            SHA256 sha256 = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
            string hashedPassword = Convert.ToBase64String(hashedBytes);

            if (password == null || password == "" || txtEmailAcc.Text == null || txtEmailAcc.Text == "" || txtUserNameAcc.Text == null || txtUserNameAcc.Text == "" || cbInterestAcc.Text == null || cbInterestAcc.Text == "" || cbRegionAcc.Text == null || cbRegionAcc.Text == "")
            {
                MessageBox.Show("not all fields are filled in");
            }

            else if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters");
            }

            else if (!txtEmailAcc.Text.Contains("@"))
            {
                MessageBox.Show("Email must contain @");
            }
            
            else
            {
                DateTime selectedDate = dtpAgeAcc.Value;
                DateTime currentDate = DateTime.Now;
                int age = DateTime.Today.Year - selectedDate.Year;
                if (selectedDate.Month > currentDate.Month || (selectedDate.Month == currentDate.Month && selectedDate.Day > currentDate.Day))
                {
                    age--;
                }

                if (age < 18)
                {
                    MessageBox.Show("Age must be at least 18 years old");
                }

                else
                {
                    Account account = new Account(txtUserNameAcc.Text, hashedPassword, txtEmailAcc.Text, cbRegionAcc.Text, cbInterestAcc.Text, dtpAgeAcc.Value);
                   
                    try
                    {
                        AccountContainer accountContainer = new AccountContainer();
                        accountContainer.CreateAccount(account);

                        MessageBox.Show("Account has been created");
                        LoginForm login = new LoginForm();
                        login.Show();
                    }

                    catch (Exception exmsg)
                    {
                        MessageBox.Show(exmsg.Message);
                    }
                }
            }
        }

        private void btnLoginAcc_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }

    }
}
