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

namespace CryoManager {
    public class Algobot {
        // Defines the properties of the trading bot
        // Name and strategy
        //public String name;            // Name of the bot
        //public String strategyText;    // Strategy info
        BinanceClient botKlineClient = new BinanceClient(); // For klines
        BinanceSocketClient socketClient3 = new BinanceSocketClient(); // for price updates

        // Timeframes
        public KlineInterval timeInterval;  // Timeframe to monitor
        public String timeFrame;            // Timeframe in text form
        public int candleTimespan;          // Timeframe in int form

        // Symbols that will be monitored
        public String coinPair;
        List<string> symbolsToTrade = new List<string> { "SOLUSDT"};

        // State of the bot adn trading info
        public bool openTrade = false;     // True if a trade is currently open
        public Trade current_trade;    // Information on the current trade 
        public double boughtPriceCoinUSDT = 0;
        public double unrealizedProfitUSDT = 0;
        public double boughtAmountUSDT = 0;
        public double account_worth = 100;
        DateTime startTradingTime = DateTime.Now.AddMinutes(-60); // Trading start time in Binance timeframe (1h behind)
        public int candleLimit = 600;
        public bool start_trading = false;

        // CoinData
        public List<botCoin> botCoin_list = new List<botCoin>();
        // History data to keep
        public List<Trade> list_of_trades = new List<Trade>(); // Historical list of all trades executed
        
        
        public Algobot() {
            // Initialize bot
            timeFrame = "5m";
            timeInterval = KlineInterval.FiveMinutes;
            candleTimespan = 5;
            // Initialize botCoin objects based on list of coins to trade
            foreach (var coinPairStr in symbolsToTrade) {
                botCoin newCoin = new botCoin(coinPairStr);
                botCoin_list.Add(newCoin);
            }

            // Get past candle data for each coin
            foreach (var myBotCoin in botCoin_list) {
                // Get candlesticks and calculate candles when data is received. Since its an async method, alligCalc called from within
                requestHistoryCandlesFromBinance(myBotCoin);
                // Calculate alligator (done in previous line)
            }
            // Start monitoring candles for all coins
            monitorCandles();
            // Start monitoring price updates for all coins
            monitorPricesAndDirectTrading();
            start_trading = true;
        }



        public async void monitorPricesAndDirectTrading() {
            debugControls.print("Start monitor prices");
            // Subscribe to price update data (can subscribe to a bunch of symbols)
            await socketClient3.Spot.SubscribeToSymbolMiniTickerUpdatesAsync(symbolsToTrade, data => {
                //debugControls.print($"Received {data.Data.Symbol} update: Last price = {data.Data.LastPrice}");
                foreach (var botCoin in botCoin_list) {
                    if (botCoin.coinPair == data.Data.Symbol) {
                        botCoin.currPrice = (double)data.Data.LastPrice;
                        // Check if buy or sell
                        if (start_trading && botCoin.waitForNewCandle == false) {
                            if (botCoin.openTrade) {
                                // A trade is open, see if sell
                                // Calculate current win/loss
                                botCoin.unrealizedProfitUSDT = ((botCoin.currPrice / botCoin.boughtPriceUSDT) * botCoin.boughtAmountUSDT) - botCoin.boughtAmountUSDT;
                                if (botCoin.checkSellConditions(account_worth * 0.03)) {
                                    botCoin.executeSell();
                                    account_worth += botCoin.unrealizedProfitUSDT;
                                    //debugControls.print($"Account worth after sell: {account_worth}");
                                    //debugControls.print($"");
                                }
                            } else {
                                // A trade is not open, see if buy
                                if (botCoin.checkBuyConditions()) {
                                    botCoin.executeBuy(account_worth/2);
                                }
                            }
                        }
                    }
                }
            });
        }

        public async void monitorCandles() {
            debugControls.print("Start monitor candles");
            // Subscribe to candle data (can subscribe to a bunch of symbols)
            var socketClient3 = new BinanceSocketClient();
            await socketClient3.Spot.SubscribeToKlineUpdatesAsync(symbolsToTrade, timeInterval, candleData => {
                // Updates are received every few seconds regardless of the interval requested
                // Each update is for a specific coin
                // This method is only used to update candles when a candle closes and a new candle opens
                // Find out if data received is from a new candle or the previous candle
                // and when its new, send to be added to each list 

                // Check what coin is the update for 
                foreach (var botCoin in botCoin_list) {
                    if (botCoin.coinPair == candleData.Data.Symbol) {
                        // Find out if this update is for a new candle or for a previous candle
                        if (botCoin.firstCandleUpdateEverReceived) {
                            botCoin.currentCandleCloseTime = candleData.Data.Data.CloseTime;
                            botCoin.firstCandleUpdateEverReceived = false;
                        }
                        if (botCoin.currentCandleCloseTime != candleData.Data.Data.CloseTime) {
                            //debugControls.print("Last candle closed, new candle received");
                            //debugControls.print($"{botCoin.coinPair}: Last candle close is at {(botCoin.candles_list.Last().DateTime.AddMinutes(4).AddSeconds(59))}");
                            //debugControls.print($"{botCoin.coinPair}: This candle close is at {candleData.Data.Data.CloseTime}");
                            botCoin.currentCandleCloseTime = candleData.Data.Data.CloseTime;
                            // This is a new candle
                            botCoin.newCandleReceived = true;
                            // add latest candle to the list
                            
                            addLatestCandleToListandRedoAlligator(botCoin);
                        } else {
                            // This is an update of the previous candle. Keep data to store when this candle is finalized
                            OHLC currCandle = new OHLC((double)candleData.Data.Data.Open, (double)candleData.Data.Data.High,
                                                            (double)candleData.Data.Data.Low, (double)candleData.Data.Data.Close,
                                                            candleData.Data.Data.OpenTime, TimeSpan.FromMinutes(candleTimespan));
                            botCoin.currentCandle = currCandle;
                            botCoin.newCandleReceived = false;
                            //debugControls.print($"Latest received candle data: {candleData.Data.Symbol}. Open: {(double)candleData.Data.Data.Open} " +
                            //                                                            $"Close: {(double)candleData.Data.Data.Close}");
                            //debugControls.print($"{botCoin.coinPair}:   Last element in list is: Open: {botCoin.candles_list.Last().Open}, OpenTime: {botCoin.candles_list.Last().DateTime}  ");
                            //debugControls.print($"{botCoin.coinPair}:   CurrentCandle is Open: {botCoin.currentCandle.Open}, OpenTime: {botCoin.currentCandle.DateTime}");
                        }
                    }
                }

            });
        }
        public void addLatestCandleToListandRedoAlligator(botCoin coin) {
            if (coin.firstIncompleteCandle) {
                // This is the first and only time this happens
                coin.firstIncompleteCandle = false;
                // Last candle was incomplete. Replace now with the completed version
                coin.candles_list.RemoveAt(coin.candles_list.Count() - 1);
                debugControls.print("First ever complete candle received");
            }
            //debugControls.print("Adding last complete candle to list");
            //debugControls.print($"Last complete candle: Open: {coin.currentCandle.Open}, High: {coin.currentCandle.High}, " +
            //                                        $"Low: {coin.currentCandle.Low}, Close: {coin.currentCandle.Close}");
            coin.candles_list.Add(coin.currentCandle);
            // Remove first candle so that list doesnt get huge
            coin.candles_list.RemoveAt(0);
            calculateAlligatorLines(coin);
            coin.waitForNewCandle = false;
            // Redraw charts here
        }

        // Functions
        public static bool buyConditions_all() {
            // Returns true if all buy conditions are true
            bool conditionsMet = false;
            return conditionsMet;
        }
        public static bool sellConditions_all() {
            // Returns true if all sell conditions are true
            bool conditionsMet = false;
            return conditionsMet;
        }
        public static void update_list_of_trades() {
            // Adds the current trade to the list of trades.
            // Executes when a trade is open or closed
        }
        public async void requestHistoryCandlesFromBinance(botCoin coin) {
            debugControls.print($"Requesting data for  {coin.coinPair}");
            DateTime startDate = startTradingTime.AddMinutes(-(candleLimit * candleTimespan));
            DateTime endDate = startTradingTime;
            var botReceivedkLine = await botKlineClient.Spot.Market.GetKlinesAsync(coin.coinPair, timeInterval, startDate, endDate, candleLimit);
            // Put received candle info in a list
            List<OHLC> realPrices_list = new List<OHLC>();
            foreach (var candle in botReceivedkLine.Data) {
                realPrices_list.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                             decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                             candle.OpenTime, TimeSpan.FromMinutes(candleTimespan)));
            }
            // Put that candle list into the botCoin candle list
            coin.candles_list = realPrices_list;
            // Calculate alligator
            calculateAlligatorLines(coin);
        }
        public void calculateAlligatorLines(botCoin botCoin) {
            //debugControls.print($"Calculating alligator for {botCoin.coinPair}");
            // Uses the OHLC list in the object to calculate the alligator lines
            OHLC[] realPricesArray = botCoin.candles_list.ToArray();
            botCoin.allig_lines = HistoricalCharts.computeAlligatorLines(realPricesArray);
            //debugControls.print($"{botCoin.coinPair} last alligator values: " +
            //                                            $" Lips(green):    {botCoin.allig_lines[2].Item2.Last()}," +
            //                                            $" Teeth(red):     {botCoin.allig_lines[1].Item2.Last()}" +
            //                                            $" Jaw(blue):      {botCoin.allig_lines[0].Item2.Last()}");
        }
       



    }
}
