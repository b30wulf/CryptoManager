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
    public class backtestingDirector { 
        // Deprectaded
        /*
        BinanceClient botKlineClient = new BinanceClient(); // For klines
        List<OHLC> realPrices_list = new List<OHLC>();
        // Symbol to backtest
        string symbol = "SOLUSDT";
        // Time interval to backtest
        KlineInterval candle_interval = KlineInterval.OneMinute;
        DateTime start_date;
        DateTime end_date;
        int candle_limit = 1000;

        // Where data is stored



        public backtestingDirector() {
            requestAllData();
            // Calculate dates based on candle interval
            end_date = 
            start_date = end_date.AddMinutes(-1*candle_limit);
        }


        public async void requestAllData() {
            // Requests data from Binance
            var mykline2 = await botKlineClient.Spot.Market.GetKlinesAsync(symbol, candle_interval, start_date, end_date);
            
            foreach (var candle in mykline2.Data) {
                realPrices_list.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                            decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                             candle.OpenTime, TimeSpan.FromMinutes(1)));
            }
            debugControls.print("Got data");
        }

        public void sendDataToBotCoin() {
            
        }
        */
    }
}
