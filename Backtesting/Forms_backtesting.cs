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
    public partial class Forms_backtesting : Form {
        // Directs the backtesting stuff. (replaces old backtestDirector)
        BinanceClient botKlineClient = new BinanceClient(); // For klines
        // Define plots so that they can be toggled
        ScottPlot.Plottable.FinancePlot candles_1m, candles_3m, candles_5m, candles_15m;
        // Alligator plottables
        ScottPlot.Plottable.ScatterPlot allig_1m_jaw, allig_1m_teeth, allig_1m_lips; 
        ScottPlot.Plottable.ScatterPlot allig_3m_jaw, allig_3m_teeth, allig_3m_lips;
        ScottPlot.Plottable.ScatterPlot allig_5m_jaw, allig_5m_teeth, allig_5m_lips;
        ScottPlot.Plottable.ScatterPlot allig_15m_jaw, allig_15m_teeth, allig_15m_lips;
        // Moving avergae plotables
        ScottPlot.Plottable.ScatterPlot movAvg_15m;
        

        // Symbol to backtest
        static string symbol = "SOLUSDT";
        // Time interval to backtest
        KlineInterval candle_interval;
        DateTime start_date;
        DateTime end_date;
        TimeSpan myTimeSpan;
        int candle_limit = 1000;
        int total_binance_requests = 0;

        // Where data is stored
        botCoin mybotCoin = new botCoin(symbol);

        

        public Forms_backtesting() {
            InitializeComponent();
            formsPlot_timeline15m.Plot.XAxis.DateTimeFormat(true);
            //formsPlot_timeline15m.Configuration.LockVerticalAxis = true;
            formsPlot_openTrades.Plot.XAxis.DateTimeFormat(true);
            //formsPlot_openTrades.Configuration.LockVerticalAxis = true;
        }

        
        #region Binance
        public async void requestAllData() {
            // Requests data from Binance
            //var mykline2 = await botKlineClient.Spot.Market.GetKlinesAsync(symbol, candle_interval, start_date, end_date);
            /*
            foreach (var candle in mykline2.Data) {
                realPrices_list.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                            decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                             candle.OpenTime, TimeSpan.FromMinutes(1)));
            }
            debugControls.print("Got data");
            */
        }
        #endregion

        #region GUI buttons
        // Get data buttons
        private async void button_1m_Click(object sender, EventArgs e) {
            if (button_1m.BackColor == Color.Brown) {
                mybotCoin.bt_candles_list_1m.Clear();
                mybotCoin.bt_trades_1m.Clear();
                mybotCoin.bt_allig_lines_1m.Clear();
            }
            button_1m.BackColor = Color.Brown;
            List<OHLC> realPrices_list = new List<OHLC>();
            int timeSpanMinutes = 1;
            // Manages getting data from Binance and sends a list with all candles to botCoin
            // Calculate stuff to get data from Binance
            candle_interval = KlineInterval.OneMinute;
            end_date = dateTimePicker_end.Value;
            start_date = dateTimePicker_start.Value;
            // Calculate number of expected candles to know how many requests we are going to make as to not exceed limit
            myTimeSpan = end_date.Date.Subtract(start_date.Date);
            int num_candles = (int)(myTimeSpan.TotalMinutes / timeSpanMinutes);
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
                }
                debugControls.print($"Got 1m data {i}/{num_requestsNeeded}");
                candles_missing = candles_missing - req_limit;
                if (candles_missing < req_limit) {
                    req_limit = candles_missing;
                }
            }
            // Send data to botCoin
            mybotCoin.receiveCandleDataAndCalculateAlligator(realPrices_list, timeSpanMinutes);
            // Calculate stuff
            mybotCoin.analyzePricesAndDetermineBuys(mybotCoin.bt_candles_list_1m, mybotCoin.bt_allig_lines_1m, mybotCoin.bt_trades_1m);
            // Add to chart
            drawOnOpenTradesChart(mybotCoin.bt_trades_1m);
            // Calculate return
            mybotCoin.calculateReturns(mybotCoin.bt_trades_1m, mybotCoin.bt_candles_list_1m, dateTimePicker_resultsFrom.Value);
            if (true) {
                candles_1m = formsPlot_timeline15m.Plot.AddCandlesticks(mybotCoin.bt_candles_list_1m.ToArray());
                allig_1m_jaw = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_1m[0].Item1, mybotCoin.bt_allig_lines_1m[0].Item2, Color.Blue, 1);       // Jaws
                allig_1m_teeth = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_1m[1].Item1, mybotCoin.bt_allig_lines_1m[1].Item2, Color.Red, 1);      // Teeth
                allig_1m_lips = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_1m[2].Item1, mybotCoin.bt_allig_lines_1m[2].Item2, Color.Green, 1);     // Lips
                checkBox_candles_1m.Checked = true;
                checkBox_allig_1m.Checked = true;
                formsPlot_timeline15m.Plot.AxisAutoY();
                formsPlot_timeline15m.Refresh();
            }
            debugControls.print("Finished 1m loop");
        }
        private async void button_3m_Click(object sender, EventArgs e) {
            if (button_3m.BackColor == Color.Green) {
                mybotCoin.bt_candles_list_3m.Clear();
                mybotCoin.bt_trades_3m.Clear();
                mybotCoin.bt_allig_lines_3m.Clear();
            }
            button_3m.BackColor = Color.Green;
            List<OHLC> realPrices_list = new List<OHLC>();
            int timeSpanMinutes = 60;
            // Manages getting data from Binance and sends a list with all candles to botCoin
            // Calculate stuff to get data from Binance
            candle_interval = KlineInterval.OneHour;
            end_date = dateTimePicker_end.Value;
            start_date = dateTimePicker_start.Value;
            // Calculate number of expected candles to know how many requests we are going to make as to not exceed limit
            myTimeSpan = end_date.Date.Subtract(start_date.Date);
            int num_candles = (int)(myTimeSpan.TotalMinutes / timeSpanMinutes);
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
                }
                debugControls.print($"Got 3m data {i}/{num_requestsNeeded}");
                candles_missing = candles_missing - req_limit;
                if (candles_missing < req_limit) {
                    req_limit = candles_missing;
                }
            }
            // Send data to botCoin
            mybotCoin.receiveCandleDataAndCalculateAlligator(realPrices_list, timeSpanMinutes);
            // Calculate stuff
            mybotCoin.analyzePricesAndDetermineBuys(mybotCoin.bt_candles_list_3m, mybotCoin.bt_allig_lines_3m, mybotCoin.bt_trades_3m);
            // Add to chart
            drawOnOpenTradesChart(mybotCoin.bt_trades_3m);
            // Calculate return
            mybotCoin.calculateReturns(mybotCoin.bt_trades_3m, mybotCoin.bt_candles_list_3m, dateTimePicker_resultsFrom.Value);
            // Add candles to chart above (removable)
            if (true) {
                candles_3m = formsPlot_timeline15m.Plot.AddCandlesticks(mybotCoin.bt_candles_list_3m.ToArray());
                allig_3m_jaw = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_3m[0].Item1, mybotCoin.bt_allig_lines_3m[0].Item2, Color.Blue, 1);       // Jaws
                allig_3m_teeth = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_3m[1].Item1, mybotCoin.bt_allig_lines_3m[1].Item2, Color.Red, 1);      // Teeth
                allig_3m_lips = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_3m[2].Item1, mybotCoin.bt_allig_lines_3m[2].Item2, Color.Green, 1);     // Lips
                checkBox_candles_3m.Checked = true;
                checkBox_allig_3m.Checked = true;
                formsPlot_timeline15m.Plot.AxisAutoY();
                formsPlot_timeline15m.Refresh();
            }
            debugControls.print("Finished 3m loop");
        }
        private async void button_5m_Click(object sender, EventArgs e) {
            if (button_5m.BackColor == Color.Blue) {
                mybotCoin.bt_candles_list_5m.Clear();
                mybotCoin.bt_trades_5m.Clear();
                mybotCoin.bt_allig_lines_5m.Clear();
            }
            button_5m.BackColor = Color.Blue;
            List<OHLC> realPrices_list = new List<OHLC>();
            int timeSpanMinutes = 5;
            // Manages getting data from Binance and sends a list with all candles to botCoin
            // Calculate stuff to get data from Binance
            candle_interval = KlineInterval.FiveMinutes;
            end_date = dateTimePicker_end.Value;
            start_date = dateTimePicker_start.Value;
            // Calculate number of expected candles to know how many requests we are going to make as to not exceed limit
            myTimeSpan = end_date.Date.Subtract(start_date.Date);
            int num_candles = (int)(myTimeSpan.TotalMinutes / timeSpanMinutes);
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
                }
                debugControls.print($"Got 5m data {i}/{num_requestsNeeded}");
                candles_missing = candles_missing - req_limit;
                if (candles_missing < req_limit) {
                    req_limit = candles_missing;
                }
            }
            // Send data to botCoin
            mybotCoin.receiveCandleDataAndCalculateAlligator(realPrices_list, timeSpanMinutes);
            // Calculate stuff
            mybotCoin.analyzePricesAndDetermineBuys(mybotCoin.bt_candles_list_5m, mybotCoin.bt_allig_lines_5m, mybotCoin.bt_trades_5m);
            // Add to chart
            drawOnOpenTradesChart(mybotCoin.bt_trades_5m);
            // Calculate return
            mybotCoin.calculateReturns(mybotCoin.bt_trades_5m, mybotCoin.bt_candles_list_5m, dateTimePicker_resultsFrom.Value);
            // Add candles to chart above (removable)
            if (true) {
                candles_5m = formsPlot_timeline15m.Plot.AddCandlesticks(mybotCoin.bt_candles_list_5m.ToArray());
                allig_5m_jaw = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_5m[0].Item1, mybotCoin.bt_allig_lines_5m[0].Item2, Color.Blue, 1);       // Jaws
                allig_5m_teeth = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_5m[1].Item1, mybotCoin.bt_allig_lines_5m[1].Item2, Color.Red, 1);      // Teeth
                allig_5m_lips = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_5m[2].Item1, mybotCoin.bt_allig_lines_5m[2].Item2, Color.Green, 1);     // Lips
                checkBox_candles_5m.Checked = true;
                checkBox_allig_5m.Checked = true;
                formsPlot_timeline15m.Plot.AxisAutoY();
                formsPlot_timeline15m.Refresh();
            }
            debugControls.print("Finished 5m loop");
        }
        private async void button_15m_Click(object sender, EventArgs e) {
            symbol = textBox_bt_symbol.Text;
            // Clear all data if button is pressed again
            if (button_15m.BackColor == Color.Red) {
                mybotCoin.bt_candles_list_15m.Clear();
                mybotCoin.bt_trades_15m.Clear();
                mybotCoin.bt_allig_lines_15m.Clear();
            }
            button_15m.BackColor = Color.Red;
            List<OHLC> realPrices_list = new List<OHLC>();
            int timeSpanMinutes = 15;
            // Manages getting data from Binance and sends a list with all candles to botCoin
            // Calculate stuff to get data from Binance
            candle_interval = KlineInterval.FifteenMinutes;
            end_date = dateTimePicker_end.Value;
            start_date = dateTimePicker_start.Value;
            // Calculate number of expected candles to know how many requests we are going to make as to not exceed limit
            myTimeSpan = end_date.Date.Subtract(start_date.Date);
            int num_candles = (int)(myTimeSpan.TotalMinutes / timeSpanMinutes);
            int candles_missing = num_candles;
            int req_limit = 1000;
            if (candles_missing < req_limit) {
                req_limit = candles_missing;
            }
            double num_requestsNeeded = (double)(num_candles / 1000d);
            // Get data from binance 
            //DateTime last_date;
            for (int i = 1; req_limit > 0 && total_binance_requests < 1000; i++) {
                var mykline2 = await botKlineClient.Spot.Market.GetKlinesAsync(symbol, candle_interval, start_date.AddMinutes((i - 1) * 1000 * 15), start_date.AddMinutes((i - 1) * 1000 * timeSpanMinutes + req_limit * timeSpanMinutes), req_limit);
                total_binance_requests++;
                foreach (var candle in mykline2.Data) {
                    realPrices_list.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                                decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                                 candle.OpenTime, TimeSpan.FromMinutes(timeSpanMinutes)));
                }
                debugControls.print($"Got 15m data {i}/{num_requestsNeeded}");
                candles_missing = candles_missing - req_limit;
                if (candles_missing < req_limit) {
                    req_limit = candles_missing;
                }
            }
            // Send data to botCoin
            mybotCoin.receiveCandleDataAndCalculateAlligator(realPrices_list, timeSpanMinutes);
            // Calculate stuff
            mybotCoin.analyzePricesAndDetermineBuys(mybotCoin.bt_candles_list_15m, mybotCoin.bt_allig_lines_15m, mybotCoin.bt_trades_15m);
            
            // Add candles to chart above (removable)
            if (true) {
                candles_15m = formsPlot_timeline15m.Plot.AddCandlesticks(mybotCoin.bt_candles_list_15m.ToArray());
                candles_15m.ColorUp = Color.DarkGreen;
                candles_15m.ColorDown = Color.DarkRed;
                allig_15m_jaw = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_15m[0].Item1, mybotCoin.bt_allig_lines_15m[0].Item2, Color.Blue, 1);       // Jaws
                allig_15m_teeth = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_15m[1].Item1, mybotCoin.bt_allig_lines_15m[1].Item2, Color.Red, 1);      // Teeth
                allig_15m_lips = formsPlot_timeline15m.Plot.AddScatterLines(mybotCoin.bt_allig_lines_15m[2].Item1, mybotCoin.bt_allig_lines_15m[2].Item2, Color.Green, 1);     // Lips
                // Moving average
                // Make array of mov average
                double[] movAvg_x = new double[mybotCoin.bt_movingAvg_25_close_15m.Count()];
                double[] movAvg_y = new double[mybotCoin.bt_movingAvg_25_close_15m.Count()];
                for (int i = 0; i < mybotCoin.bt_movingAvg_25_close_15m.Count(); i++) {
                    movAvg_x[i] = mybotCoin.bt_movingAvg_25_close_15m[i].Item1;
                    movAvg_y[i] = mybotCoin.bt_movingAvg_25_close_15m[i].Item2;
                }
                movAvg_15m = formsPlot_timeline15m.Plot.AddScatterLines(movAvg_x, movAvg_y, Color.Gold);
                checkBox_candles_15m.Checked = true;
                checkBox_allig_15m.Checked = true;
                formsPlot_timeline15m.Plot.AxisAutoY();
                formsPlot_timeline15m.Refresh();
            }
            // Add to chart
            drawOnOpenTradesChart(mybotCoin.bt_trades_15m);
            mybotCoin.calculateReturns(mybotCoin.bt_trades_15m, mybotCoin.bt_candles_list_15m, dateTimePicker_resultsFrom.Value);
            debugControls.print("Finished 15m loop");
        }

        #region Checkboxes states
        // 1m
        private void checkBox_candles_1m_CheckedChanged(object sender, EventArgs e) {
            candles_1m.IsVisible = checkBox_candles_1m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        private void checkBox_allig_1m_CheckedChanged(object sender, EventArgs e) {
            allig_1m_jaw.IsVisible = checkBox_allig_1m.Checked;
            allig_1m_teeth.IsVisible = checkBox_allig_1m.Checked;
            allig_1m_lips.IsVisible = checkBox_allig_1m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        // 3m
        private void checkBox_candles_3m_CheckedChanged(object sender, EventArgs e) {
            candles_3m.IsVisible = checkBox_candles_3m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        private void checkBox_allig_3m_CheckedChanged(object sender, EventArgs e) {
            allig_3m_jaw.IsVisible = checkBox_allig_3m.Checked;
            allig_3m_teeth.IsVisible = checkBox_allig_3m.Checked;
            allig_3m_lips.IsVisible = checkBox_allig_3m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        // 5m
        private void checkBox_candles_5m_CheckedChanged(object sender, EventArgs e) {
            candles_5m.IsVisible = checkBox_candles_5m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        private void checkBox_allig_5m_CheckedChanged(object sender, EventArgs e) {
            allig_5m_jaw.IsVisible = checkBox_allig_5m.Checked;
            allig_5m_teeth.IsVisible = checkBox_allig_5m.Checked;
            allig_5m_lips.IsVisible = checkBox_allig_5m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        // 15m
        private void checkBox_candles_15m_CheckedChanged(object sender, EventArgs e) {
            candles_15m.IsVisible = checkBox_candles_15m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        private void checkBox_allig_15m_CheckedChanged(object sender, EventArgs e) {
            allig_15m_jaw.IsVisible = checkBox_allig_15m.Checked;
            allig_15m_teeth.IsVisible = checkBox_allig_15m.Checked;
            allig_15m_lips.IsVisible = checkBox_allig_15m.Checked;
            formsPlot_timeline15m.Refresh();
        }
        #endregion

        #endregion


        public void drawOnOpenTradesChart(List<botTrade> trades) {
            // Select color
            Color myColor = Color.Green;
            switch (trades[0].interval) {
                case 1:
                    myColor = Color.Brown;
                    break;
                case 60:
                    myColor = Color.Green;
                    break;
                case 5:
                    myColor = Color.Blue;
                    break;
                case 15:
                    myColor = Color.Red;
                    break;
            }
            formsPlot_openTrades.Plot.AxisAuto();
            foreach (var trade in trades) {
                double[] xData = new double[2] { trade.openTime.ToOADate(), trade.closeTime.ToOADate() };
                //double[] yData = new double[2] { trade.interval, trade.interval };
                double[] yData = new double[2] { trade.boughtAt, trade.soldAt };
                formsPlot_openTrades.Plot.AddScatter( xData , yData, myColor);
                if (myColor == Color.Red) {
                    // TEMP: Add trades to price chart too
                    formsPlot_timeline15m.Plot.AddScatter(xData, yData, Color.Blue, 1);
                }
            }
            formsPlot_openTrades.Plot.AxisAuto();
            formsPlot_openTrades.Refresh();
        }
        private void formsPlot_openTrades_AxesChanged(object sender, EventArgs e) {
            formsPlot_timeline15m.Plot.YAxis.LockLimits(true);
            formsPlot_timeline15m.Plot.MatchAxis(formsPlot_openTrades.Plot);
            formsPlot_timeline15m.Render(skipIfCurrentlyRendering: true);
            formsPlot_timeline15m.Plot.YAxis.LockLimits(false);
        }
        private void formsPlot_timeline15m_AxesChanged(object sender, EventArgs e) {
            formsPlot_openTrades.Plot.YAxis.LockLimits(true);
            formsPlot_openTrades.Plot.MatchAxis(formsPlot_timeline15m.Plot);
            formsPlot_openTrades.Render(skipIfCurrentlyRendering: true);
            formsPlot_openTrades.Plot.YAxis.LockLimits(false);
        }

        private void button_readLog_Click(object sender, EventArgs e) {
            string bottradescsv = @"C:\\Users\\capit\\Desktop\\logs\\botlogs.csv";
            List<botTrade> listofTradesbyBot = new List<botTrade>();
            // Reads trade from csv file and stores them into a list od trades to be plotted
            using (TextFieldParser csvParser = new TextFieldParser(bottradescsv)) {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                //csvParser.ReadLine(); // Skip the row with the column names
                int numberOfParsedTrades = 0;
                botTrade newBotTrade = new botTrade();
                while (!csvParser.EndOfData) {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    // 0 = Date
                    // 1 = Buy/sell
                    // 2 = Coin
                    // 3 = "Time" 
                    // 4 = Datetime
                    // 5 = "Price"
                    // 6 = price
                    // Make new trade object and assign the data
                    if (fields[1].ToString() == "BUY") {
                        newBotTrade = new botTrade();
                        //newBotTrade.openTime = Trade.tradeTimeConverter(fields[3]);
                        newBotTrade.openTime = Convert.ToDateTime(fields[4]);
                        newBotTrade.boughtAt = double.Parse(fields[6], System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    } else if (fields[1].ToString() == "SELL") {
                        newBotTrade.closeTime = Convert.ToDateTime(fields[4]);
                        //newBotTrade.closeTime = Trade.tradeTimeConverter(fields[3]);
                        newBotTrade.soldAt = double.Parse(fields[6], System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                        listofTradesbyBot.Add(newBotTrade);
                    }
                }
                // Plot the trades in the graph
                foreach (var trade in listofTradesbyBot) {
                    double[] xData = new double[2] { trade.openTime.ToOADate(), trade.closeTime.ToOADate() };
                    //double[] yData = new double[2] { trade.interval, trade.interval };
                    double[] yData = new double[2] { trade.boughtAt, trade.soldAt };
                    formsPlot_openTrades.Plot.AddScatter(xData, yData, Color.Gold, 2);
                    formsPlot_timeline15m.Plot.AddScatter(xData, yData, Color.Gold, 2);
                }
                formsPlot_openTrades.Plot.AxisAuto();
                formsPlot_openTrades.Refresh();

            }
        }
    }
}
