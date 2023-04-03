using Business;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                double stock100DayTotal = 0;
                double stock50DayTotal = 0;
                double stock20DayTotal = 0;
                int dayCounter = 0;
                string printOutSpacer = "  ";

                string Symbol = txtSymbolAdd.Text;

                string APIKEY = "ZN0C9Q4C0LG3REEE";

                string queryURL = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={Symbol}&apikey={APIKEY}&datatype=csv";

                WebClient webClient = new WebClient();

                string dateTime = Symbol + "-" + DateTime.Now.ToString("MM-dd-yyyy");

                string directoryPath = (@"C:\Users\" + Environment.UserName + @"\Desktop\");
                string fileName = (dateTime + ".csv");

                if (!File.Exists(directoryPath + fileName))
                {
                    string data = webClient.DownloadString(queryURL);
                    Directory.CreateDirectory(directoryPath + fileName);
                        
                    string fullPath = Path.Combine(directoryPath, fileName);
                    using (StreamWriter writer = new StreamWriter(fullPath))
                    {
                        File.WriteAllText(directoryPath + fileName, data);
                    }
                }

                using (StreamReader reader = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Desktop\" + dateTime + ".csv"))
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                      
                    List<Stock> stockList = new List<Stock>();

                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {

                    Stock stock = new Stock
                    (
                        csv.GetField<double>("adjusted_close"),
                        DateTime.Parse(csv.GetField<string>("timestamp")).ToString("MM-dd-yyyy"),
                        Symbol,
                        csv.GetField<double>("open"),
                        csv.GetField<double>("high"),
                        csv.GetField<double>("low"),
                        csv.GetField<double>("close"),
                        csv.GetField<double>("dividend_amount"),
                        csv.GetField<int>("volume")
                    );

                        stock100DayTotal += stock.AdjustedClose;
                        dayCounter++;

                        if (dayCounter == 20)
                        {
                            stock20DayTotal = stock100DayTotal;
                        }

                        if (dayCounter == 50)
                        {
                            stock50DayTotal = stock100DayTotal;
                        }

                        stockList.Add(stock);
                    }

                    foreach (var item in stockList)
                    {
                        Console.WriteLine(
                            $"{item.Symbol}{printOutSpacer}" +
                            $"Open: ${item.Open.ToString("0.00")}{printOutSpacer}" +
                            $"High: $ {item.High.ToString("0.00")}{printOutSpacer}" +
                            $"Low: ${item.Low.ToString("0.00")}{printOutSpacer}" +
                            $"Close: ${item.Close.ToString("0.00")}{printOutSpacer}" +
                            $"Adjusted Close: ${item.AdjustedClose.ToString("0.00")}{printOutSpacer}" +
                            $"Volume: {item.Volume}{printOutSpacer}" +
                            $"DividendAmount: ${item.DividendAmount.ToString("0.00")}{printOutSpacer}" +
                            $"{item.Date}");

                        Thread.Sleep(100);
                    }

                    Console.WriteLine($"{Symbol} 100 Day Moving Average: ${(stock100DayTotal / 100).ToString("0.00")}");
                    Console.WriteLine($"{Symbol} 50 Day Moving Average: ${(stock50DayTotal / 50).ToString("0.00")}");
                    Console.WriteLine($"{Symbol} 20 Day Moving Average: ${(stock20DayTotal / 20).ToString("0.00")}");
                }

                Console.Read();

            }

        }
    }
}

