using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
//using static System.Threading.Tasks.Task;
using static System.IO.StreamWriter;
using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
// For series
using System.Windows.Forms.DataVisualization.Charting;
using ScottPlot;

namespace CryoManager.Backtesting {
    public partial class Histogram : Form {
        

        public Histogram() {
            InitializeComponent();
        }


        // Symbol to backtest
        static string symbol = "SOLUSDT";
        // Time interval to backtest
        KlineInterval candle_interval;
        DateTime start_date;
        DateTime end_date;
        TimeSpan myTimeSpan;
        int candle_limit = 1000;
        int total_binance_requests = 0;
        BinanceClient botKlineClient = new BinanceClient(); // For klines

        // Where data is stored
        botCoin mybotCoin = new botCoin(symbol);

        private async void button1_Click(object sender, EventArgs e) {
            
            List<OHLC> realPrices_list = new List<OHLC>();
            List<double> doubleList = new List<double>();
            int timeSpanMinutes = 1;
            // Manages getting data from Binance and sends a list with all candles to botCoin
            // Calculate stuff to get data from Binance
            candle_interval = KlineInterval.OneMinute;
            end_date = DateTime.Now.AddHours(-1);
            start_date = end_date.AddMinutes(-5000);
            // Calculate number of expected candles to know how many requests we are going to make as to not exceed limit
            myTimeSpan = end_date.Date.Subtract(start_date.Date);
            int num_candles = 5000;
            int candles_missing = num_candles;
            int req_limit = 1000;
            if (candles_missing < req_limit) {
                req_limit = candles_missing;
            }
            double num_requestsNeeded = (double)(num_candles / 1000d);
            // Get data from binance 
            //DateTime last_date;
            for (int i = 1; req_limit > 0 && total_binance_requests < 1000; i++) {
                var mykline2 = await botKlineClient.Spot.Market.GetKlinesAsync(symbol, candle_interval, start_date.AddMinutes((i - 1) * 1000 * timeSpanMinutes), start_date.AddMinutes((i - 1) * 1000 * timeSpanMinutes + req_limit * timeSpanMinutes), req_limit);
                total_binance_requests++;
                foreach (var candle in mykline2.Data) {
                    realPrices_list.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                                decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                                 candle.OpenTime, TimeSpan.FromMinutes(timeSpanMinutes)));
                    doubleList.Add((double)candle.Close);
                }
                debugControls.print($"Got 1m data {i}/{num_requestsNeeded}");
                candles_missing = candles_missing - req_limit;
                if (candles_missing < req_limit) {
                    req_limit = candles_missing;
                }
            }

            var plt = formsPlot1.Plot;


            //double[] values = ScottPlot.DataGen.RandomNormal(rand, pointCount: 1234, mean: 178.4, stdDev: 7.6);

            

            double[] values = doubleList.ToArray();

            // create a histogram
            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(values, min: 0, max: 300, binSize: 1);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            // display the histogram counts as a bar plot
            var bar = plt.AddBar(values: counts, positions: leftEdges);
            bar.BarWidth = 1;

            // customize the plot style
            plt.YAxis.Label("Count (#)");
            plt.XAxis.Label("Height (cm)");
            plt.SetAxisLimits(yMin: 0);

            formsPlot1.Refresh();
            












        }
    }
}
