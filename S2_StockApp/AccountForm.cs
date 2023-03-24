using System;
using System.Windows.Forms;
using Business;

namespace StockAppForm
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

        private void btnLoginAcc_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void btnCreateAccountAcc_Click(object sender, EventArgs e)
        {
            if (txtPasswordAcc.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters");            }
            else
            {
                DateTime selectedDate = dateTimePicker1.Value;
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
                    Account account = new Account(txtUserNameAcc.Text, txtEmailAcc.Text, cbRegionAcc.Text, cbInterestAcc.Text, dateTimePicker1);
                    MessageBox.Show("Account has been created");
                    Login login = new Login();
                    login.Show();
                }
            }
        }
    }
}
