using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;

namespace StockAppForms
{
    public partial class HistorieForm : Form
    {
        private const string APIKEY = "ZN0C9Q4C0LG3REEE";

        private const string BaseUrl = "https://www.alphavantage.co/query";

        string ApiFunction = "TIME_SERIES_INTRADAY_EXTENDED";

        public HistorieForm()
        {
            InitializeComponent();
            string[] itemsInterest = new string[] { "1min", "5min", "15min", "30min", "60min" };
            cbInterval.Items.AddRange(itemsInterest);
            string[] itemsInterest2 = new string[] { "year1month1", "year1month2", "year1month3", "year1month4", "year1month5", "year1month6", "year1month7", "year1month8", "year1month9", "year1month10", "year1month11", "year1month12", "year2month1", "year2month2", "year2month3", "year2month4", "year2month5", "year2month6", "year2month7", "year2month8", "year2month9", "year2month10", "year2month11", "year2month12" };
            cbSlice.Items.AddRange(itemsInterest2);
        }

        private async void btnViewHistorie_Click_1(object sender, EventArgs e)
        {
            string Interval = cbInterval.Text;
            string symbol = txtSymbolAdd.Text.Trim().ToUpper();
            string slice = cbSlice.Text;

            string apiurl = $"{BaseUrl}?function={ApiFunction}&symbol={symbol}&interval={Interval}&slice={slice}&apikey={APIKEY}";
            Uri queryUri = new Uri(apiurl);

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DataTable dt = new DataTable();
            using (HttpClient client = new HttpClient())
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (Stream stream = await client.GetStreamAsync(queryUri))
                    {
                        await stream.CopyToAsync(memStream);
                    }

                    memStream.Position = 0;

                    using (StreamReader reader = new StreamReader(memStream))
                    {
                        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            foreach (string header in csv.HeaderRecord)
                            {
                                dt.Columns.Add(header);
                            }
                            while (csv.Read())
                            {
                                DataRow dr = dt.NewRow();
                                for (int i = 0; i < csv.Parser.Record.Length; i++)
                                {
                                    dr[i] = csv.Parser.Record[i];
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
            }

            dataGridView1.DataSource = dt;
        }
    }
}
