using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using ScottPlot;
using Skender.Stock.Indicators;
using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Binance.Net.Objects.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;

namespace CryoManager {
    public class HistoricalCharts {
        // Shows the OHLC chart for the selected currency in USD
        public String timeframe; // "1 hour", "5 min", "1 week" 
        public String currency; // The coin to be represented 
        public DateTime startDate;
        public DateTime endDate;
        public Series historical_Series;


        // Fucntions
        public static void getHistoricalData(string coinPair, string interval, DateTime start, DateTime end) {


            
        }

        public static void updateCentralChart() {
            // Updates the central chart to display according to whatever is selected in the GUI


        }

        public static List<Tuple<double[], double[]>> computeAlligatorLines(OHLC[] candles) {
            // Receives candle data, creates alligator line (from the close)
            List<Tuple<double[], double[]>> allig_lines = new List<Tuple<double[], double[]>>();
            // Define jaws
            int jaws_average_period = 13;
            int jaws_offset = 8;
            // Define teeth
            int teeth_average_period = 8;
            int teeth_offset = 5;
            // Define Lips
            int lips_average_period = 5;
            int lips_offset = 3;
            // Transform candle data into quotes
            IEnumerable<Quote> quotes = parseCandlesToQuote(candles);
            //IEnumerable<Quote> quotes = GetHistoryFromFeed("MSFT");
            IEnumerable<AlligatorResult> allig_results = quotes.GetAlligator();
            // Transform results to x and y so a scatter plot can be added on the chart
            List<double> jaws_line_x = new List<double>();
            List<double> jaws_line_y = new List<double>();
            List<double> teeth_line_x = new List<double>();
            List<double> teeth_line_y = new List<double>();
            List<double> lips_line_x = new List<double>();
            List<double> lips_line_y = new List<double>();

            foreach (var point in allig_results) {
                // Assign jaw data
                jaws_line_x.Add(point.Date.ToOADate());
                if (point.Jaw == null) {
                    jaws_line_y.Add((double)allig_results.ElementAt(jaws_average_period + jaws_offset - 1).Jaw);
                } else {
                    jaws_line_y.Add((double)point.Jaw);
                }
                // Assign teeth data
                teeth_line_x.Add(point.Date.ToOADate());
                if (point.Jaw == null) {
                    teeth_line_y.Add((double)allig_results.ElementAt(teeth_average_period + teeth_offset - 1).Teeth);
                } else {
                    teeth_line_y.Add((double)point.Teeth);
                }
                // Assign lips data
                lips_line_x.Add(point.Date.ToOADate());
                if (point.Jaw == null) {
                    lips_line_y.Add((double)allig_results.ElementAt(lips_average_period + lips_offset - 1).Lips);
                } else {
                    lips_line_y.Add((double)point.Lips);
                }
            }
            // Add arrays to list
            // Jaws
            allig_lines.Add(new Tuple<double[], double[]>(jaws_line_x.ToArray(), jaws_line_y.ToArray()));
            // Teeth
            allig_lines.Add(new Tuple<double[], double[]>(teeth_line_x.ToArray(), teeth_line_y.ToArray()));
            // Lips
            allig_lines.Add(new Tuple<double[], double[]>(lips_line_x.ToArray(), lips_line_y.ToArray()));
            

            return allig_lines;
        }
        
        public static List<(double, double)> computeMovingAverage(OHLC[] candles) {
            List<(double, double)> movAvg = new List<(double, double)>();
            (double, double) newPoint;
            double averaged = 0;
            for (int i = 0; i < candles.Length; i++) {
                averaged = 0;
                for (int j = i; j > i - 25 && i > 25; j--) {
                    averaged += candles[j].Close;
                }
                if (averaged != 0)
                    averaged = averaged / 25;
                newPoint = (candles[i].DateTime.ToOADate(), averaged);
                //newPoint = (candles[i].DateTime.ToOADate(), averaged);
                movAvg.Add(newPoint);
            }
            return movAvg;
        }
        

        public static IEnumerable<Quote> parseCandlesToQuote(OHLC[] candles) {
            // Transforms the data from the OHLC to Quotes
            IEnumerable<Quote> quote_enum = new Quote[] { };
            
            foreach (var candle in candles) {
                Quote newQuote = new Quote();
                newQuote.Open = (decimal)candle.Open;
                newQuote.High = (decimal)candle.High;
                newQuote.Low = (decimal)candle.Low;
                newQuote.Close = (decimal)candle.Close;
                newQuote.Date = candle.DateTime;
                newQuote.Volume = 0;
                //quote_enum.Append(newQuote);
                quote_enum = quote_enum.Concat(new[] { newQuote });
            }
            return quote_enum;
        }

        public static void createBinanceClient() {

        }
        public static async Task<List<OHLC>> askBinanceForCandles(Form1 sender, BinanceClient client, String coinPair, KlineInterval interval, DateTime start, DateTime end, int limit, int candleTimespan) {
            // Calls binance and returns candle data in a list format
            sender.label_timeOfRequest.Text = $"Data requested at: {DateTime.Now.ToLongTimeString()}";
            var myKline = await client.Spot.Market.GetKlinesAsync(coinPair, interval, start, end, limit);
            // Add data to OHLC list and then to array
            List<OHLC> realPrices = new List<OHLC>();
            foreach (var candle in myKline.Data) {
                realPrices.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                            decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                             candle.OpenTime, TimeSpan.FromMinutes(candleTimespan)));
            }
            return realPrices;
        }

        public static Task<List<OHLC>> lastCandleClosed(Form1 sender, BinanceClient client, String coinPair, KlineInterval interval, DateTime start, DateTime end, int limit, int candleTimespan) {
            return askBinanceForCandles(sender, client, coinPair, interval, start, end, limit, candleTimespan);
        }










    }
}
