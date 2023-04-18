using Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections;
using Data;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Drawing;

namespace StockAppForms
{
    public partial class DashboardForm : Form
    {
        // de constante van de api kunne in een aparte klasse misschien zelfs wel gewoon de hele connectie string dat is afhankelijk van extra bijgevoegde gegevens per functie
        private const string APIKEY = "ZN0C9Q4C0LG3REEE";

        private const string BaseUrl = "https://www.alphavantage.co/query";

        string ApiFunction = "TIME_SERIES_INTRADAY"; 
        public DashboardForm()
        {
           
            InitializeComponent();
            string[] itemsInterest = new string[] { "1min", "5min", "15min", "30min", "60min" };
            cbinterval.Items.AddRange(itemsInterest);
        }

        private async void btnAddStocks_Click(object sender, EventArgs e)
        {
            string Interval = cbinterval.Text;
            string symbol = txtSymbolAdd.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(symbol) )
            {
                MessageBox.Show("Please enter a stock symbol");
            }

            string apiurl = $"{BaseUrl}?function={ApiFunction}&symbol={symbol}&interval={Interval}&apikey={APIKEY}";
            
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiurl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(json);

                    string symbolName = data?["Meta Data"]?["2. Symbol"]?.ToString();
                    string lastRefreshed = data?["Meta Data"]?["3. Last Refreshed"]?.ToString();
                    string interval = data?["Meta Data"]?["4. Interval"]?.ToString();
                    string info = data?["Meta Data"]?["1. Information"]?.ToString();

                    if (!string.IsNullOrEmpty(symbolName))
                    {
                        labelSymbolName.Text = symbolName;
                    }

                    if (!string.IsNullOrEmpty(lastRefreshed))
                    {
                        labelLastRefreshed.Text = lastRefreshed;
                    }

                    if (!string.IsNullOrEmpty(interval))
                    {
                        labelInterval.Text = interval;
                    }

                    var timeSeries = data?["Time Series "+ "(" + Interval + ")"];
                    if (timeSeries != null)
                    {
                       
                        List<Stock> timeSeriesData = new List<Stock>();
                        foreach (JProperty property in timeSeries.Children<JProperty>())
                        {
                            DateTime date = DateTime.Parse(property.Name);
                            double open = double.Parse(property.Value["1. open"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double high = double.Parse(property.Value["2. high"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double low = double.Parse(property.Value["3. low"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            double close = double.Parse(property.Value["4. close"].ToString(), CultureInfo.GetCultureInfo("en-US"));
                            int volume = int.Parse(property.Value["5. volume"].ToString());

                            // hier wordt de klasse aangevuld met de gevraagde info
                            Stock stock = new Stock
                            (
                                date,
                                symbolName,
                                open,
                                high,
                                low,
                                close,
                                volume
                            );


                            StockContainer stockContainer = new StockContainer();
                            stockContainer.AddStock(stock);

                            timeSeriesData.Add(stock);
                            

                        }
                        /*dit kan later ook met regio vercshillen mocht daar tijd voor zijn
                        DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                        cellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

                        dataGridView1.DefaultCellStyle = cellStyle;*/

                        dataGridView1.DataSource = timeSeriesData;
                        dataGridView1.Columns["StockID"].Visible = false;

                       // StockContainer stockContainer = new StockContainer();
                        // stockContainer.AddStock(stock);


                    }
                    else
                    {
                        MessageBox.Show("Time series data not available.");
                    }
                }
                else
                {
                    MessageBox.Show($"API request failed with status code: {response.StatusCode}");
                }
            }
        }

        private void btnHistorie_Click(object sender, EventArgs e)
        {
            HistorieForm historie = new HistorieForm();
            historie.Show();
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            if (txtSymbolAdd.Text != "")
            {
                StockContainer stockContainer = new StockContainer();
                stockContainer.ViewStockBySymbol(txtSymbolAdd.Text);
            }
            else
            {
                MessageBox.Show("Ticker-Symbol is empty!");
            }
        }

        private void dgvAllStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                ulong StockID = Convert.ToUInt64(selectedRow.Cells["StockID"].Value);

                StockContainer stockContainer = new StockContainer();

                stockContainer.DeleteStock(StockID);

                dgvAllStock.Rows.Remove(selectedRow);
            }
           
            catch
        }
    }
}

