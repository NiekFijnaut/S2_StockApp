using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace StockAppForms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private async void btnAddStocks_Click(object sender, EventArgs e)
        {
            {

                string Ticker = txtSymbolAdd.Text;
                string APIKEY = "ZN0C9Q4C0LG3REEE";

                string QUERY_URL = "https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords="+ Ticker + "&apikey=" + APIKEY;
                Uri queryUri = new Uri(QUERY_URL);


                using (HttpClient client = new HttpClient())
                {
                    string json_str = await client.GetStringAsync(queryUri);
                    JsonDocument json_doc = JsonDocument.Parse(json_str);

                    JsonElement best_matches = json_doc.RootElement.GetProperty("bestMatches");
                    JsonElement latest_data = best_matches[0];
                    string open_price = latest_data.GetProperty("1. open").GetString();
                    string high_price = latest_data.GetProperty("2. high").GetString();
                    string low_price = latest_data.GetProperty("3. low").GetString();
                    string close_price = latest_data.GetProperty("4. close").GetString();
                    string volume = latest_data.GetProperty("6. volume").GetString();

                    string message = $"Open price: {open_price}\n" +
                                     $"High price: {high_price}\n" +
                                     $"Low price: {low_price}\n" +
                                     $"Close price: {close_price}\n" +
                                     $"Volume: {volume}";

                    MessageBox.Show(message, "Stock Information", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }

            }

        }
    }
}

