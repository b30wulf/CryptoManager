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



namespace CryoManager {
    public partial class Form1 : Form {
        
        //string myDepoFilepath = "C:\\Files JuanVi\\2. Proyectos\\CryoManagerV2\\Documents\\All_deposits_history.csv";
        string myDepoFilepath = "C:\\Files JuanVi\\2. Proyectos\\CryoManagerV2\\Documents\\All_deposits_history - Copy.csv";
        //string myTradesFilepath = "C:\\Files JuanVi\\2. Proyectos\\CryoManagerV2\\Documents\\all_trades.csv";             // Short version
        string myTradesFilepath = "C:\\Files JuanVi\\2. Proyectos\\CryoManagerV2\\Documents\\all_trades - Copy.csv";    //All trades
        //event priceUpdateReceived = new event();

        public Portfolio myPortfolio = new Portfolio(); // The main portfolio object where everything will be stored into
        public Form1() {
            InitializeComponent();
            BinanceClient.SetDefaultOptions(new BinanceClientOptions() {
                ApiCredentials = new ApiCredentials("APIKEY", "APISECRET"),
                LogLevel = LogLevel.Debug,
                LogWriters = new List<ILogger> { new ConsoleLogger() }
            });
            BinanceSocketClient.SetDefaultOptions(new BinanceSocketClientOptions() {
                ApiCredentials = new ApiCredentials("APIKEY", "APISECRET"),
                LogLevel = LogLevel.Debug,
                LogWriters = new List<ILogger> { new ConsoleLogger() }
            });
            #region Chart ComboBoxes
            // Populate the comboboxes with the symbols in the list in alphabetical order
            List<string> ordered_coins = new List<string>(binanceTokens.coinNames.OrderBy(name => name).ToList());
            foreach (var coinName in ordered_coins) {
                comboBox1.Items.Add(coinName);
                comboBox2.Items.Add(coinName);
            }
            // Select USDT for the second comboBox as default
            comboBox2.SelectedIndex = comboBox2.FindString("USDT");

            // Populate comboBox3 with timeframe data
            comboBox3.Items.Add("1m");
            comboBox3.Items.Add("5m");
            comboBox3.Items.Add("30m");
            comboBox3.Items.Add("1h");
            comboBox3.Items.Add("4h");
            comboBox3.Items.Add("1d");
            #endregion

            #region Binance old commented code
            /*
            using (var client = new BinanceClient()) {
                // Spot.Market | Spot market info endpoints
                client.Spot.Market.GetBookPriceAsync("BTCUSDT");
                // Spot.Order | Spot order info endpoints
                client.Spot.Order.GetOrdersAsync("BTCUSDT");
                // Spot.System | Spot system endpoints
                client.Spot.System.GetExchangeInfoAsync();
                // Spot.UserStream | Spot user stream endpoints. Should be used to subscribe to a user stream with the socket client
                client.Spot.UserStream.StartUserStreamAsync();
                // Spot.Futures | Transfer to/from spot from/to the futures account + cross-collateral endpoints
                client.Spot.Futures.TransferFuturesAccountAsync("ASSET", 1, FuturesTransferType.FromSpotToUsdtFutures);

                // FuturesCoin | Coin-M general endpoints
                client.FuturesCoin.GetPositionInformationAsync();
                // FuturesCoin.Market | Coin-M futures market endpoints
                client.FuturesCoin.Market.GetBookPricesAsync("BTCUSD");
                // FuturesCoin.Order | Coin-M futures order endpoints
                client.FuturesCoin.Order.GetUserTradesAsync();
                // FuturesCoin.Account | Coin-M account info
                client.FuturesCoin.Account.GetAccountInfoAsync();
                // FuturesCoin.System | Coin-M system endpoints
                client.FuturesCoin.System.GetExchangeInfoAsync();
                // FuturesCoin.UserStream | Coin-M user stream endpoints. Should be used to subscribe to a user stream with the socket client
                client.FuturesCoin.UserStream.StartUserStreamAsync();

                // FuturesUsdt | USDT-M general endpoints
                client.FuturesUsdt.GetPositionInformationAsync();
                // FuturesUsdt.Market | USDT-M futures market endpoints
                client.FuturesUsdt.Market.GetBookPricesAsync("BTCUSDT");
                // FuturesUsdt.Order | USDT-M futures order endpoints
                client.FuturesUsdt.Order.GetUserTradesAsync("BTCUSDT");
                // FuturesUsdt.Account | USDT-M account info
                client.FuturesUsdt.Account.GetAccountInfoAsync();
                // FuturesUsdt.System | USDT-M system endpoints
                client.FuturesUsdt.System.GetExchangeInfoAsync();
                // FuturesUsdt.UserStream | USDT-M user stream endpoints. Should be used to subscribe to a user stream with the socket client
                client.FuturesUsdt.UserStream.StartUserStreamAsync();

                // General | General/account endpoints
                client.General.GetAccountInfoAsync();

                // Lending | Lending endpoints
                client.Lending.GetFlexibleProductListAsync();

                // Margin | Margin general/account info
                client.Margin.GetMarginAccountInfoAsync();
                // Margin.Market | Margin market endpoints
                client.Margin.Market.GetMarginPairsAsync();
                // Margin.Order | Margin order endpoints
                client.Margin.Order.GetMarginAccountOrdersAsync("BTCUSDT");
                // Margin.UserStream | Margin user stream endpoints. Should be used to subscribe to a user stream with the socket client
                client.Margin.UserStream.StartUserStreamAsync();
                // Margin.IsolatedUserStream | Isolated margin user stream endpoints. Should be used to subscribe to a user stream with the socket client
                client.Margin.IsolatedUserStream.StartIsolatedMarginUserStreamAsync("BTCUSDT");

                // Mining | Mining endpoints
                client.Mining.GetMiningCoinListAsync();

                // SubAccount | Sub account management
                //client.SubAccount.TransferSubAccountAsync("fromEmail", "toEmail", "asset", 1);

                // Brokerage | Brokerage management
                client.Brokerage.CreateSubAccountAsync();

                // WithdrawDeposit | Withdraw and deposit endpoints
                client.WithdrawDeposit.GetWithdrawalHistoryAsync();
            }

            var socketClient = new BinanceSocketClient();
            // Spot | Spot market and user subscription methods
            socketClient.Spot.SubscribeToAllBookTickerUpdatesAsync(data => {
                // Handle data
            });

            // FuturesCoin | Coin-M futures market and user subscription methods
            socketClient.FuturesCoin.SubscribeToAllBookTickerUpdatesAsync(data => {
                // Handle data
            });

            // FuturesUsdt | USDT-M futures market and user subscription methods
            socketClient.FuturesUsdt.SubscribeToAllBookTickerUpdatesAsync(data => {
                // Handle data
            });
            // Unsubscribe
            socketClient.UnsubscribeAllAsync();
            Console.ReadLine();
            */
            #endregion

            timer1.Start();
        }

        #region GUI Buttons

        #region ToolStipMenu Buttons
        private void importDepositsToolStripMenuItem_Click(object sender, EventArgs e) {
            // Read the file and imports all deposits
            // Asumes the deposits are ordered by time
            // Doesnt delete previous deposits, therefore this is only to be clicked once. 
            // Saves all data on deposits_list inside Portfolio
            using (TextFieldParser csvParser = new TextFieldParser(myDepoFilepath)) {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                while (!csvParser.EndOfData) {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    // 0 = Date
                    // 1 = Currency
                    // 2 = Quantity
                    // 3 = -
                    // 4 = -
                    // 5 = -
                    // 6 = - 
                    // 7 = IDCode
                    // Make new deposit object and assign the data
                    Deposit newDeposit = new Deposit();
                    newDeposit.date = Deposit.depositTimeConverter(fields[0]);
                    newDeposit.depositCurrency = fields[1].ToString();
                    newDeposit.quantity = float.Parse(fields[2], NumberStyles.AllowDecimalPoint);
                    newDeposit.IDCode = fields[7];
                    // Add new deposit to list of trades
                    myPortfolio.deposits_list.Add(newDeposit);
                }
            }
        }
        private void importTradesToolStripMenuItem_Click(object sender, EventArgs e) {
            // Imports trades from data from CSV
            // Asumes trades are ordered by date
            // Doesnt delete previous trades, so import only once. 
            // Saves all data on unmodified_trades_list
            using (TextFieldParser csvParser = new TextFieldParser(myTradesFilepath)) {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                // Skip the row with the column names
                csvParser.ReadLine();
                int numberOfParsedTrades = 0;
                while (!csvParser.EndOfData) {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    // 0 = Date
                    // 1 = Pair
                    // 2 = BUY / SELL
                    // 3 = price
                    // 4 = executed + coinname
                    // 5 = amount + coinname
                    // 6 = fee + coinname 
                    // Make new trade object and assign the data
                    Trade newTrade = new Trade();
                    newTrade.date = Trade.tradeTimeConverter(fields[0]);
                    newTrade.coinPair = fields[1];
                    Trade.getCoinPairNames(newTrade); // Separates coinPair into coin1 and coin2.
                    newTrade.operationType = fields[2];
                    newTrade.price = float.Parse(fields[3], System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    newTrade.executed = float.Parse(fields[4].Substring(0, fields[4].Length - newTrade.coin1.Length),
                        System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands); // Gets the executed amount. Have to remove the coin1 information
                    newTrade.amount = float.Parse(fields[5].Substring(0, fields[5].Length - newTrade.coin2.Length),
                        System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands); //  Gets the traded amount. Have to remove the coin1 information
                    // For the fee, find out which currency its on
                    string tradeFee = fields[6];
                    newTrade.feeCurrency = Trade.getCoinName(tradeFee);
                    newTrade.fee = float.Parse(fields[6].Substring(0, fields[6].Length - newTrade.feeCurrency.Length));
                    // TODO: Find out the price of that currency in USD by that day. And add this to the object. For now its 0
                    newTrade.feeUSD = 0;
                    // Add new trade to list of trades
                    myPortfolio.unmodified_trades_list.Add(newTrade);
                    numberOfParsedTrades++;
                    debugControls.print($"Parsed a {newTrade.coinPair} on {newTrade.date}");
                    debugControls.print($"Total: {numberOfParsedTrades} parsed trades");
                }
                // Now all trades are added to the unmodified list.

                // Aggregate partial trades into one and store values in agg_trades_list
                Trade.aggregatePartialTrades(myPortfolio.unmodified_trades_list, myPortfolio.agg_trades_list);
                // Now all trades are saved into myportfolio and partial trades have been aggregated 
            }
        }
        private void parseTransactionsToolStripMenuItem_Click(object sender, EventArgs e) {
            // Combine all deposits and trades into the same list
            Transaction.parseTransactions(ref myPortfolio, ref myPortfolio.all_transactions, myPortfolio.deposits_list, myPortfolio.agg_trades_list);
            // Make list of coins that have been traded
            myPortfolio.createListOfCoinTokesTraded(myPortfolio.all_transactions);



            updateDataGridView_ownedCoins();
        }

        #endregion

        private async void button_get_btc_price_Click(object sender, EventArgs e) {
            // Forces the central chart to look for data and update
            String symbolQuery; // String containing the pair that will be queried
            // Check if the dropdowns have selected string
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null) {
                symbolQuery = string.Concat(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            } else
                symbolQuery = "BTCUSD";
            label_chartLog.Text = $"Querring Binance for {symbolQuery}";
            KlineInterval interval = KlineInterval.FiveMinutes;
            double candleTimespan = 5;
            if (comboBox3.SelectedItem != null) {
                switch (comboBox3.SelectedItem) {
                    case "1m":
                        interval = KlineInterval.OneMinute;
                        candleTimespan = 1;
                        break;
                    case "5m":
                        interval = KlineInterval.FiveMinutes;
                        candleTimespan = 5;
                        break;
                    case "30m":
                        interval = KlineInterval.ThirtyMinutes;
                        candleTimespan = 30;
                        break;
                    case "1h":
                        interval = KlineInterval.OneHour;
                        candleTimespan = 60;
                        break;
                    case "4h":
                        interval = KlineInterval.FourHour;
                        candleTimespan = 60 * 4;
                        break;
                    case "1d":
                        interval = KlineInterval.OneDay;
                        candleTimespan = 60 * 24;
                        break;
                    default:
                        break;
                }
            } else {
                interval = KlineInterval.FiveMinutes;
                candleTimespan = 5;
            }
            int req_limit = 500;

            DateTime date_now = DateTime.Now;
            DateTime date_1h = date_now.AddMinutes(-(candleTimespan) * req_limit);

            BinanceClient.SetDefaultOptions(new BinanceClientOptions() {
                LogLevel = LogLevel.Error,
            });

            var kLineClient = new BinanceClient();
            var myKline = await kLineClient.Spot.Market.GetKlinesAsync(symbolQuery, interval, date_1h, date_now, req_limit);
            // Add data to OHLC list and then to array
            List<OHLC> realPrices = new List<OHLC>();
            foreach (var candle in myKline.Data) {
                realPrices.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                            decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                             candle.OpenTime, TimeSpan.FromMinutes(candleTimespan)));
            }
            OHLC[] realPricesArray = realPrices.ToArray();
            // Set up chart and add stuff to it
            formsPlotPrice.Plot.Title(symbolQuery + "   " + comboBox3.SelectedItem.ToString());
            formsPlotPrice.Plot.XAxis.DateTimeFormat(true);
            formsPlotPrice.Plot.YAxis.Ticks(false);
            formsPlotPrice.Plot.YAxis2.Ticks(true);
            formsPlotPrice.Plot.YAxis2.Label("Price EUR");
            formsPlotPrice.Plot.Clear();
            formsPlotPrice.Plot.AddCandlesticks(realPricesArray).YAxisIndex = 1;
            formsPlotPrice.Plot.AddScatter(new double[] { realPrices[0].DateTime.ToOADate() }, new double[] { 62750 }, Color.Green, 2);

            List<Tuple<double[], double[]>> allig_lines = new List<Tuple<double[], double[]>>();
            allig_lines = HistoricalCharts.computeAlligatorLines(realPricesArray);

            // Add alligator lines to plot
            // Jaws
            formsPlotPrice.Plot.AddScatterLines(allig_lines[0].Item1, allig_lines[0].Item2, Color.Blue, 1).YAxisIndex = 1;
            // Teeth
            formsPlotPrice.Plot.AddScatterLines(allig_lines[1].Item1, allig_lines[1].Item2, Color.Red, 1).YAxisIndex = 1;
            // Lips
            formsPlotPrice.Plot.AddScatterLines(allig_lines[2].Item1, allig_lines[2].Item2, Color.Green, 1).YAxisIndex = 1;
            
            formsPlotPrice.Refresh();



            label_chartLog.Text = $"{symbolQuery} - {comboBox3.SelectedItem.ToString()}";

            using (var client = new BinanceClient()) {
                /*
                List<Binance.Net.Objects.Spot.MarketData.BinanceBookPrice> stuff = 
                    new List<Binance.Net.Objects.Spot.MarketData.BinanceBookPrice>();
                stuff = client.Spot.Market.GetBookPriceAsync("BTCUSDT");
               */

            }
            #region old code

            /*
            var socketClient = new BinanceSocketClient();
            // Spot | Spot market and user subscription methods
            socketClient.Spot.SubscribeToAllBookTickerUpdatesAsync(data => {
                // Handle data
                Console.WriteLine(data.Data.Symbol);
                Console.WriteLine("Bid: " + data.Data.BestBidPrice);
                Console.WriteLine("Ask: " + data.Data.BestAskPrice);
            }).Wait();
            */

            /*
            var socketClient2 = new BinanceSocketClient();
            socketClient2.Spot.SubscribeToSymbolTickerUpdatesAsync("BTCUSDT", data => {
                Console.WriteLine(data.Data.Symbol);
                Console.WriteLine("Bid: " + data.Data.BidPrice);
                Console.WriteLine("Ask: " + data.Data.AskPrice);
            }).Wait();
            */

            #endregion

            var socketClient3 = new BinanceSocketClient();
            await socketClient3.Spot.SubscribeToSymbolMiniTickerUpdatesAsync("BTCUSDT", data => {
                //Console.WriteLine(data.Data.Symbol + "miniUpdate");
                //Console.WriteLine("Bid: " + data.Data.LastPrice);
            });

        }

        #endregion
        
        #region DATA GRID VIEW CONTROLS
        // Owned coins
        public void updateDataGridView_ownedCoins() {
            // Creates the table that shows the owned coins
            foreach (var coin in Portfolio.owned_cointoken_list) {
                int newRowID = dataGridView_ownedCoins.Rows.Add();
                DataGridViewRow newRow = dataGridView_ownedCoins.Rows[newRowID];
                newRow.Cells["ColumnCoin"].Value = coin.shortName;
                newRow.Cells["ColumnQnty"].Value = coin.qntyOwned;
            }
        }
        private void dataGridView_ownedCoins_SelectionChanged(object sender, EventArgs e) {
            if (dataGridView_ownedCoins.SelectedCells[0].Value != null) {
                // A click has changed the selection of the data grid view. Update the secondary data grid view to show the trades of the selected coin
                dataGridView_coinTradesUpdateWhenSelectedCoinChange(sender, e);
                // Change the selection of the first dropdown to the selected 
                comboBox1.SelectedIndex = comboBox1.FindString(dataGridView_ownedCoins.SelectedCells[0].Value.ToString());
            }
        }
        // Coin trades view
        private void dataGridView_coinTradesUpdateWhenSelectedCoinChange(object sender, EventArgs e) {
            float labelProfit = 0;
            // Delete previous data
            dataGridView_coinTrades.Rows.Clear();
            // Add data of selected coin
            // Get name of currently selected coin
            DataGridView mySender = (DataGridView)sender;
            if (mySender.CurrentCell.Value != null) {
                string selectedCoin = mySender.CurrentCell.Value.ToString();
                // Find the coin in the list of coins
                foreach (var coin in Portfolio.owned_cointoken_list) {
                    if (coin.shortName == selectedCoin) {
                        foreach (var trade in coin.coinTrades) {
                            int newRowID = dataGridView_coinTrades.Rows.Add();
                            DataGridViewRow newRow = dataGridView_coinTrades.Rows[newRowID];
                            newRow.Cells["ColumnDate"].Value = trade.date;
                            newRow.Cells["ColumnAction"].Value = trade.operationType;
                            newRow.Cells["ColumnPair"].Value = trade.coin1 + trade.coin2;
                            newRow.Cells["ColumnSide"].Value = trade.operationType;
                            newRow.Cells["ColumnPrice"].Value = trade.price;
                            dataGridView_coinTrades.Columns["ColumnExecuted"].HeaderText = "Executed (" + trade.coin1 + ")";
                            newRow.Cells["ColumnExecuted"].Value = trade.executed;
                            newRow.Cells["ColumnUSDValue"].Value = trade.amount;
                            // To know the profit value some calculations have to be done (TODO)
                            float profit = Trade.calcProfitFromBUYSELL(coin, trade, trade.price, trade.executed);
                            labelProfit += profit;
                            label_totalProfitAmount.Text = (labelProfit).ToString();
                            newRow.Cells["ColumnProfit"].Value = profit;
                            newRow.Cells["ColumnProfitPercentage"].Value = "00";
                            newRow.Cells["ColumnUSDFee"].Value = trade.feeUSD;
                        }
                    }
                }
            }
        }

        #endregion

        #region Labels
        private void timer1_Tick_1(object sender, EventArgs e) {
            label_currTime.Text = DateTime.Now.ToLongTimeString();
        }


        #endregion





        private async void button_startBot_Click(object sender, EventArgs e) {
            // Start form with extra plots
            Form2_charts forms2Charts = new Form2_charts();
            forms2Charts.Visible = true;

            // Set sounds
            System.Media.SoundPlayer player_sell = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Error.wav");
            System.Media.SoundPlayer player_buy = new System.Media.SoundPlayer(@"C:\Windows\Media\tada.wav");
                
            // Launches the trading bot
            debugControls.clearLog();
            //debugControls.newLogFile();
            debugControls.print("Instancing trading bot...");
            Algobot myBot = new Algobot();
            debugControls.print("Name: " + myBot.name);
            debugControls.print("Strategy: \r\n" + myBot.strategyText);
            debugControls.print("Timeframe: " + myBot.timeFrame + "\r\n");
            debugControls.print($"Fetching {myBot.coinPair} - {myBot.timeFrame} data from Binance...");
            // Define stuff to get from binance
            KlineInterval interval = myBot.timeInterval;
            int candleTimespan = 1; // Candle timespan in minutes
            int req_limit = 200; // Limit to the last X candles
            DateTime date_now = DateTime.Now.AddHours(-1);
            DateTime date_1hback = date_now.AddMinutes(-(candleTimespan * req_limit));
            BinanceClient.SetDefaultOptions(new BinanceClientOptions() { LogLevel = LogLevel.Error});
            var kLineClient = new BinanceClient();
            //var myKline = await kLineClient.Spot.Market.GetKlinesAsync(myBot.coinPair, interval, date_1h, date_now, req_limit);
            var candleData = await HistoricalCharts.askBinanceForCandles(this, kLineClient, myBot.coinPair, interval, date_1hback, date_now, req_limit, candleTimespan);
            // Remove last candle that is incomplete
            candleData.Remove(candleData.Last());
            // Define things regarding the plot
            int maxPlottedCandles = req_limit; // Maximum amount of candles that can be plotted at the same time
            if (req_limit > maxPlottedCandles) {
                maxPlottedCandles = req_limit;
                debugControls.print($"MaxPlottedCandles changed to req_limit = {req_limit}");
            }
            OHLC[] realPricesArray = candleData.ToArray();
            // Set up chart and add stuff to it
            formsPlotPrice.Plot.Title(myBot.coinPair + "   " + myBot.timeFrame);
            formsPlotPrice.Plot.XAxis.DateTimeFormat(true);
            formsPlotPrice.Plot.YAxis.Ticks(false);
            formsPlotPrice.Plot.YAxis2.Ticks(true);
            formsPlotPrice.Plot.YAxis2.Label("Price USDT");
            formsPlotPrice.Plot.Clear();
            formsPlotPrice.Plot.AddCandlesticks(realPricesArray).YAxisIndex = 1;
            // Alligator indicator
            List<Tuple<double[], double[]>> allig_lines = new List<Tuple<double[], double[]>>();
            allig_lines = HistoricalCharts.computeAlligatorLines(realPricesArray);
            // Add alligator lines to plot
            formsPlotPrice.Plot.AddScatterLines(allig_lines[0].Item1, allig_lines[0].Item2, Color.Blue, 1).YAxisIndex = 1;// Jaws
            formsPlotPrice.Plot.AddScatterLines(allig_lines[1].Item1, allig_lines[1].Item2, Color.Red, 1).YAxisIndex = 1;// Teeth
            formsPlotPrice.Plot.AddScatterLines(allig_lines[2].Item1, allig_lines[2].Item2, Color.Green, 1).YAxisIndex = 1;// Lips
            // Update chart when everything else is done
            formsPlotPrice.Refresh();
            debugControls.print("System setup finished.");
            debugControls.print($"Connecting socket to Binance to receive {myBot.coinPair} data...");
            var socketClient3 = new BinanceSocketClient();
            
            //double latestQuote = 1;
            double currQuote = 0;
            bool freshCandle = false;
            bool waitForNextCandle = true;
            bool firstCandle = true;
            bool checkifbuy = false;

            DateTime currentCandle_CloseTime = DateTime.Now.AddHours(-1); // Init to NOW so that it updates as soon as first data is received
            //OHLC previousCandle_data;
            OHLC lastCandle = null;
            List<Tuple<double[], double[]>> allig_lines2 = new List<Tuple<double[], double[]>>();
            await socketClient3.Spot.SubscribeToKlineUpdatesAsync(myBot.coinPair, interval, candle_data => {
                // Updates are received every few seconds regardless of the interval requested
                // This method is only used to update candles when a candle closes and a new candle opens
                // Find out if data received is from a new candle or the previous candle
                if (currentCandle_CloseTime != candle_data.Data.Data.CloseTime) { 
                    // I got a new candle bc the CloseTime dont match any more
                    // Update the closetime 
                    currentCandle_CloseTime = candle_data.Data.Data.CloseTime;
                    freshCandle = true; // Refresh state to know when a new candle is about to close
                    waitForNextCandle = false; // Candle just changed, so dont wait longer
                } else {
                    freshCandle = false; // I got the same candle as before
                    // Overrite data to be used when a fresh candle is received
                    lastCandle = new OHLC((double)candle_data.Data.Data.Open,   (double)candle_data.Data.Data.High,
                                          (double)candle_data.Data.Data.Low,    (double)candle_data.Data.Data.Close,
                                                  candle_data.Data.Data.OpenTime, candleData.Last().TimeSpan);
                    waitForNextCandle = true;
                }
                //debugControls.print("Received kline update");
                if (waitForNextCandle == false) { 
                    waitForNextCandle = true;
                    // Insert last candle into candleData and then redo realPricesArray
                    if (firstCandle == true) {
                        firstCandle = false;
                    } else {
                        candleData.Add(lastCandle); // Add last candle to list with all candles
                        debugControls.print($"Last candle open: {lastCandle.Open} close: {lastCandle.Close}, update...");
                    }
                    if (candleData.Count() > maxPlottedCandles) {
                        debugControls.print($"Removing last candle: {candleData[0].DateTime}");
                        candleData.RemoveAt(0); // Remove first element of the list
                    }
                    realPricesArray = candleData.ToArray(); // Convert list into array (needed for alligator calculationn)
                    formsPlotPrice.Plot.Clear(); // Remove the candles and alligator from the plot to be refreshed
                    formsPlotPrice.Plot.AddCandlesticks(realPricesArray).YAxisIndex = 1; // Add updated candles to the plot
                    // Calculate the alligator
                    allig_lines2 = HistoricalCharts.computeAlligatorLines(realPricesArray);
                    // Add updated alligator lines to plot
                    formsPlotPrice.Plot.AddScatterLines(allig_lines2[0].Item1, allig_lines2[0].Item2, Color.Blue, 1).YAxisIndex = 1; // Jaws
                    formsPlotPrice.Plot.AddScatterLines(allig_lines2[1].Item1, allig_lines2[1].Item2, Color.Red, 1).YAxisIndex = 1; // Teeth
                    formsPlotPrice.Plot.AddScatterLines(allig_lines2[2].Item1, allig_lines2[2].Item2, Color.Green, 1).YAxisIndex = 1; // Lips
                    // Update axis so that last candle is always in view
                    formsPlotPrice.Plot.AxisAuto();
                    // Update chart when everything else is done
                    try {
                        formsPlotPrice.Refresh();
                    } catch (Exception) {
                        debugControls.print("Unable to update chart because object is in use");
                    }
                    // Update extra charts
                    //Form2_charts.updateCharts();                    
                    checkifbuy = true;
                }
            });
            DateTime myMinute = DateTime.Now;
            await socketClient3.Spot.SubscribeToSymbolMiniTickerUpdatesAsync(myBot.coinPair, data => {
                // Receives price update from Binance every few seconds. This method runs when data is received. 
                // Get the received price and use it to check if program should buy or sell
                // Print price every minute
                if (DateTime.Now.Minute != myMinute.Minute) {
                    debugControls.print($"Latest price: {currQuote}");
                    myMinute = DateTime.Now;
                }
                currQuote = (double)data.Data.LastPrice;
                //debugControls.print($"Latest price: {currQuote}");
                // Check price with bot logic
                if (myBot.openTrade && allig_lines2.Count() > 1) {
                    // Trade is open
                    // Calculate current win/loss
                    myBot.unrealizedProfitUSDT = ((currQuote / myBot.boughtPriceCoinUSDT) * myBot.boughtAmountUSDT) - myBot.boughtAmountUSDT;
                    debugControls.print($"Bought: {myBot.boughtPriceCoinUSDT}, Current: {currQuote} -> Unrealized profits: {myBot.unrealizedProfitUSDT} or {(myBot.unrealizedProfitUSDT/myBot.boughtAmountUSDT)*100}%");
                    bool sellCondition1 = false;
                    bool sellCondition2 = false;
                    //Check for SELL signal
                    // 1. Price is below teeth (red)
                    if (currQuote < allig_lines2[1].Item2.Last()) {
                        sellCondition1 = true;
                    }
                    // 2. Max loss is reached
                    if (myBot.unrealizedProfitUSDT < -(myBot.account_worth) * 0.03) {
                        sellCondition2 = true;
                    }
                    if (sellCondition1 || sellCondition2) {
                        // Close trade
                        myBot.openTrade = false;
                        myBot.account_worth += myBot.unrealizedProfitUSDT;
                        if (sellCondition1) {
                            debugControls.print($"Trade closed under condition 1. Bought at {myBot.boughtPriceCoinUSDT} Sold at {currQuote}. Profit {myBot.unrealizedProfitUSDT}. Account worth: {myBot.account_worth}");
                            debugControls.print("");
                        } else {
                            debugControls.print($"Trade closed under condition 2. Bought at {myBot.boughtPriceCoinUSDT} Sold at {currQuote}. Profit {myBot.unrealizedProfitUSDT}. Account worth: {myBot.account_worth}");
                            debugControls.print("");
                        }
                        // Save snapshot of the plot
                        formsPlotPrice.Plot.SaveFig($"{DateTime.Now.ToString("yyyy-M-dd--hh-mm-ss")} sell at {currQuote}.png");
                        waitForNextCandle = true;
                        if (checkBox_sound.Checked)
                            player_sell.Play();
                    }
                    //else if (allig_lines2.Count() > 1 && waitForNextCandle == true){
                } else if (allig_lines2.Count() > 1 && checkifbuy == true){
                    checkifbuy = false;
                    // No trade open. Check for BUY signal
                    // 1. Lips (green) below teeth (red)
                    // 1.1 Last candle closed above teeth (red)
                    bool buyConditions = false;
                    if (allig_lines2[2].Item2.Last() < allig_lines2[1].Item2.Last() && candleData.Last().Close > allig_lines2[1].Item2.Last()) {
                        buyConditions = true;
                        debugControls.print($"Buy conditions are met:");
                        debugControls.print($"      Lips: {allig_lines2[2].Item2.Last()} < Teeth: {allig_lines2[1].Item2.Last()}");
                        debugControls.print($"      Last close: {candleData.Last().Close} > Teeth: {allig_lines2[1].Item2.Last()}");
                        debugControls.print($"      ");
                        debugControls.print($"      ");
                    }
                    if (buyConditions) {
                        // Send buy order
                        myBot.boughtAmountUSDT = myBot.account_worth;
                        myBot.boughtPriceCoinUSDT = currQuote;
                        myBot.openTrade = true;
                        debugControls.print($"Bought {myBot.boughtAmountUSDT} USDT worth of coin at {myBot.boughtPriceCoinUSDT}");
                        // Save snapshot of the plot
                        formsPlotPrice.Plot.SaveFig($"{DateTime.Now.ToString("yyyy-M-dd--hh-mm-ss")} buy at {myBot.boughtPriceCoinUSDT}.png");
                        if (checkBox_sound.Checked)
                            player_buy.Play();
                    }
                }
            });
            



            debugControls.print("End of fucntion");



            //debugControls.print("Start trading at " + DateTime.Now.ToString());




        }

        private void button_clearChart_Click(object sender, EventArgs e) {
            formsPlotPrice.Plot.Clear();
            formsPlotPrice.Refresh();
        }

        private void button_openCharts_Click(object sender, EventArgs e) {
            // Start form with extra plots
            Form2_charts forms2Charts = new Form2_charts();
            forms2Charts.Visible = true;
        }
    }







}






public class binanceTokens {
    // The abbreviated names of the coins used. Must enlarge the list manually
    public static List<String> coinNames = new List<string>()
    {"BTC","USDT","GRT","THETA","DCR","PPT","XMR","XLM","CRV","EUR", "DOGE", "XRP", "BNB", "ETH", "BUSD", "ADA", "BTT", "DENT",
    "WIN", "GRT", "NPXS", "DODO", "SOL", "XEM", "1INCH", "UNI", "TRX", "MATIC", "LINK", "SC", "VET", "CAKE", "ONE", "CHF",
    "MANA", "MKR", "SHIB", "BAT"};
}

public class debugControls {
    static bool outputText = true; 

    public static async void print(String str) {
        // Create output string
        string outputLogLine = $"{DateTime.Now.ToString()}   {str}";
        // Write into console
        //Console.WriteLine(DateTime.Now.ToString() + "   " + str);
        Console.WriteLine(outputLogLine);
        // Save into file
        string outputFolder = @"C:\\Users\\capit\\Desktop\\Botlog\\";
        string todayDate = DateTime.Now.ToString("yyyy-M-dd");
        string textfileName = $"{todayDate} botlog.txt";
        //string textfileName = textfileName1;
        //string textfileName =  "Hola.txt";
        string fullPath = outputFolder + textfileName;
        // This text is added only once to the file.
        if (!File.Exists(fullPath)) {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(fullPath)) {
            }
        }
        // This text is always added, making the file longer over time
        using (StreamWriter sw = File.AppendText(fullPath)) {
            sw.WriteLine(outputLogLine);
        }
    }
    public static void printTrade(CryoManager.Trade trade) {
        if (outputText == true) {
            Console.WriteLine("");
            Console.WriteLine($"vv TRADE INFORMATION: vv");
            Console.WriteLine($"-- Date: {trade.date}");
            Console.WriteLine($"-- CoinPair: {trade.coinPair}");
            Console.WriteLine($"-- Coin1: {trade.coin1}");
            Console.WriteLine($"-- Coin2: {trade.coin2}");
            Console.WriteLine($"-- Operation type: {trade.operationType}");
            Console.WriteLine($"-- Price: {trade.price}");
            Console.WriteLine($"-- Executed: {trade.executed}");
            Console.WriteLine($"-- Amount: {trade.amount}");
            Console.WriteLine($"-- Fee: {trade.fee}");
            Console.WriteLine($"-- Fee currency: {trade.feeCurrency}");
            Console.WriteLine($"-- Fee USD: {trade.feeUSD}");
            Console.WriteLine("");
        }
    }

    public static void clearLog() {
        Console.Clear();
    }

    public static void newLogFile() {

    }
}
