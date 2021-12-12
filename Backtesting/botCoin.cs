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
using CryoManager.Backtesting;

namespace CryoManager {
    // Objects of the coins that the bot is trading
    public class botCoin {
        public string coinPair;
        public List<OHLC> candles_list = new List<OHLC>();
        public List<Tuple<double[], double[]>> allig_lines = new List<Tuple<double[], double[]>>(); // Each allig line has x and y data as arrays, and have 3 lines
        public OHLC currentCandle = new OHLC(0,0,0,0,DateTime.Now, TimeSpan.FromMinutes(5));
        // Stuff for candle logic
        public bool firstIncompleteCandle = true;
        public bool newCandleReceived = false;
        public DateTime currentCandleCloseTime = DateTime.Now.AddHours(-1);
        public bool firstCandleUpdateEverReceived = true;
        // Stuff for latest price logic
        public double currPrice = 0;
        public bool waitForNewCandle = true;
        // State of trading
        public bool openTrade = false; // True when a trade is open
        public double boughtPriceUSDT = 0; // Holds the price at which it was bought
        public double unrealizedProfitUSDT = 0;
        public double boughtAmountUSDT = 0;
        Backtesting.botTrade currTrade = new Backtesting.botTrade();

        // Backtesting stuff
        public List<OHLC> bt_candles_list_1m = new List<OHLC>();
        public List<OHLC> bt_candles_list_3m = new List<OHLC>();
        public List<OHLC> bt_candles_list_5m = new List<OHLC>();
        public List<OHLC> bt_candles_list_15m = new List<OHLC>();
        // Indicators
        public List<Tuple<double[], double[]>> bt_allig_lines_1m = new List<Tuple<double[], double[]>>(); // Each allig line has x and y data as arrays, and have 3 lines
        public List<Tuple<double[], double[]>> bt_allig_lines_3m = new List<Tuple<double[], double[]>>();
        public List<Tuple<double[], double[]>> bt_allig_lines_5m = new List<Tuple<double[], double[]>>();
        public List<Tuple<double[], double[]>> bt_allig_lines_15m = new List<Tuple<double[], double[]>>();
        public List<(double, double)> bt_movingAvg_25_close_15m = new List<(double, double)>();
        public List<botTrade> bt_trades_1m = new List<botTrade>();
        public List<botTrade> bt_trades_3m = new List<botTrade>();
        public List<botTrade> bt_trades_5m = new List<botTrade>();
        public List<botTrade> bt_trades_15m = new List<botTrade>();


        public botCoin(string pair) {
            coinPair = pair;
            debugControls.print($"Init {coinPair} botCoin");
        }
        #region Backtesting functions
        // Receive data from backtesting 
        public void receiveCandleDataAndCalculateAlligator(List<OHLC> candleList, int interval) {
            OHLC[] realPricesArray;
            switch (interval) {
                case 1:
                    bt_candles_list_1m = candleList;
                    realPricesArray = candleList.ToArray();
                    bt_allig_lines_1m = HistoricalCharts.computeAlligatorLines(realPricesArray);
                    break;
                case 60:
                    bt_candles_list_3m = candleList;
                    realPricesArray = candleList.ToArray();
                    bt_allig_lines_3m = HistoricalCharts.computeAlligatorLines(realPricesArray);
                    break;
                case 5:
                    bt_candles_list_5m = candleList;
                    realPricesArray = candleList.ToArray();
                    bt_allig_lines_5m = HistoricalCharts.computeAlligatorLines(realPricesArray);
                    break;
                case 15:
                    bt_candles_list_15m = candleList;
                    realPricesArray = candleList.ToArray();
                    bt_allig_lines_15m = HistoricalCharts.computeAlligatorLines(realPricesArray);
                    bt_movingAvg_25_close_15m = HistoricalCharts.computeMovingAverage(realPricesArray);
                    break;
            }
        }
        public void analyzePricesAndDetermineBuys(List<OHLC> candles, List<Tuple<double[], double[]>> alligatorLines, List<botTrade> trades) {
            // Goes through the candles and alligators and determines when it buys and when it sells
            botTrade newTradeToHold = new botTrade();
            bool tradeOpen = false;
            bool saveTrade = false;
            bool waitForNextCandle = false;
            double movingAvg = 0;
            // Skip the first 20 candles bc alligators are not made
            for (int i = 26; i < candles.Count()-1; i++) {
                // Calculate moving average
                for (int j = i; j > i - 25; j--) {
                    movingAvg += candles[j].Close;
                }
                movingAvg = movingAvg / 25;
                waitForNextCandle = false;
                // Check for buys
                //if (candles[i].Close > (alligatorLines[1].Item2[i]*1.001) && alligatorLines[2].Item2[i] < alligatorLines[1].Item2[i] && tradeOpen == false) {
                if (tradeOpen == false && bt_buyConditions(candles[i], alligatorLines[0].Item2[i], alligatorLines[1].Item2[i], alligatorLines[2].Item2[i], movingAvg)) {
                    // Buy
                    newTradeToHold = new botTrade();
                    tradeOpen = true;
                    waitForNextCandle = true;
                    newTradeToHold.openTime = candles[i + 1].DateTime;
                    newTradeToHold.boughtAt = candles[i + 1].Open;
                }
                // Check for sells
                // Original if statement was:
                //if (tradeOpen == true && (candles[i].Close < alligatorLines[1].Item2[i])) {
                if (waitForNextCandle == false && tradeOpen == true && (candles[i].Close < alligatorLines[1].Item2[i] || candles[i].Low < alligatorLines[1].Item2[i])) {
                    newTradeToHold.closeTime = candles[i].DateTime;
                    newTradeToHold.soldAt = alligatorLines[1].Item2[i];
                    newTradeToHold.interval = (int)candles[i].TimeSpan.TotalMinutes;
                    tradeOpen = false;
                    saveTrade = true;
                }
                // Save trade to lsit
                if (saveTrade) {
                    saveTrade = false;
                    trades.Add(newTradeToHold);
                }
            }
            debugControls.print("");
        }
        public bool bt_buyConditions(OHLC candle, double allig_jaw, double allig_teeth, double allig_lip, double movAvg) {
            if (candle.Close > movAvg) {
                if (candle.Close > allig_teeth * 1.001 && allig_lip < allig_teeth) {
                    return true;
                }
                if (candle.Close > allig_lip && allig_lip > allig_teeth && allig_teeth > allig_jaw) {
                    return true;
                }
            }
            
            return false;
        }
        public void calculateReturns(List<botTrade> trades, List<OHLC> candles, DateTime startDate) {
            double budget = 100;
            double total_win = 0;
            double total_loss = 0;
            int winningTrades = 0;
            int loosingTrades = 0;
            int unkowntrades = 0;
            double maxDrawdown = 0;
            double priceAtStartOfPeriod = 0;
            DateTime maxDrawdownDate = DateTime.Now;
            // Find the price at the beggining of the period
            int i = 0;
            for (i = 0; i < candles.Count && candles[i].DateTime < startDate; i++) {
                priceAtStartOfPeriod = candles[i].Close;
            }
            foreach (var trade in trades) {
                if (trade.openTime > startDate) {
                    budget = (budget / trade.boughtAt) * trade.soldAt;
                    if (trade.boughtAt >= trade.soldAt) {
                        // Loosing trade
                        loosingTrades++;
                        total_loss -= (trade.soldAt / trade.boughtAt) * 100;
                        if (-(trade.soldAt / trade.boughtAt) * 100 < maxDrawdown) {
                            maxDrawdown = -(trade.soldAt / trade.boughtAt) * 100;
                            maxDrawdownDate = trade.openTime;
                        }
                    } else if (trade.boughtAt < trade.soldAt) {
                        // Winning trade
                        winningTrades++;
                        total_win += (trade.soldAt / trade.boughtAt) * 100;
                    } else {
                        unkowntrades++;
                    }
                } 
            }

            debugControls.print($"Total returns for the {trades[0].interval}m timeframe {((budget/100)-1)*100}%");
            debugControls.print($"Total period return  {((candles.Last().Close/ priceAtStartOfPeriod)-1)*100}%");
            debugControls.print($"Total number of trades: {loosingTrades + winningTrades}");
            debugControls.print($"Winning trades: {winningTrades}");
            debugControls.print($"Loosing trades: {loosingTrades}");
            debugControls.print($"Accuracy: {((double)winningTrades / (double)(trades.Count))}");
            debugControls.print($"Price at start of period: {priceAtStartOfPeriod}. Price at end {candles.Last().Close}");
            debugControls.print($"Max drawdown: {maxDrawdown}% opened at {maxDrawdownDate}");
            debugControls.print($"Average win: {total_win / winningTrades}");
            debugControls.print($"Averalge loss: {total_loss / loosingTrades}");
            debugControls.print($"Unkown trades: {unkowntrades}");
            
        }










        #endregion

        #region Live trading functions
        // Selling functions
        public bool checkSellConditions(double limitSell) {
            //Check for SELL signal
            // 1. Price is below teeth (red)
            if (currPrice < allig_lines[1].Item2.Last()) {
                //debugControls.print($"Trade closed under condition 1");
                //debugControls.print($"      {currPrice} < {allig_lines[1].Item2.Last()}");
                //debugControls.print($"      Bought {coinPair} at {boughtPriceUSDT} Sold at {currPrice}. Profit {unrealizedProfitUSDT}");
                return true;
            }
            if (unrealizedProfitUSDT < -limitSell) {
                //debugControls.print($"Trade closed under condition 2");
                //debugControls.print($"      {unrealizedProfitUSDT} < {-limitSell}");
                //debugControls.print($"      Bought {coinPair} at {boughtPriceUSDT} Sold at {currPrice}. Profit {unrealizedProfitUSDT}");
                return true;
            }
            return false;
        }
        public void executeSell() {
            openTrade = false;
            waitForNewCandle = true;
            // Save into currTrade for later display
            currTrade.closeTime = DateTime.Now.AddHours(-1);
            currTrade.soldAt = currPrice;
            debugControls.printbotTrade(currTrade);
            debugControls.print($"#SELL#{coinPair}#{DateTime.Now.AddHours(-1)}#Price#{currPrice}");
        }
        // Buying functions
        public bool checkBuyConditions() {
            if (allig_lines[2].Item2.Last() < allig_lines[1].Item2.Last() && candles_list.Last().Close > allig_lines[1].Item2.Last()) {
                //debugControls.print($"Buy conditions for {coinPair} are met:");
                //debugControls.print($"      Lips: {allig_lines[2].Item2.Last()} < Teeth: {allig_lines[1].Item2.Last()}");
                //debugControls.print($"      Last close: {candles_list.Last().Close} > Teeth: {allig_lines[1].Item2.Last()}");

                return true;
            }
            return false;
        }
        public void executeBuy(double displ_amount) {
            boughtAmountUSDT = displ_amount;
            boughtPriceUSDT = currPrice;
            openTrade = true;
            //debugControls.print($"Bought {boughtAmountUSDT} USDT worth of {coinPair} at {boughtPriceUSDT}");
            //debugControls.print($"      ");
            // Save into currTrade for later display
            currTrade.symbolPair = coinPair;
            currTrade.openTime = DateTime.Now.AddHours(-1);
            currTrade.boughtAt = boughtAmountUSDT;
            debugControls.print($"#BUY#{coinPair}#{DateTime.Now.AddHours(-1)}#Price#{boughtPriceUSDT}");
        }
        #endregion



    }
}
