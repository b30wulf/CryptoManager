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

using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;



namespace CryoManager {
    public partial class Form2_charts : Form {
        // List with all plots
        List<FormsPlot> plots_list = new List<FormsPlot>();
        // Set timeframes of plots (not to be changed, but programmed for future)
        KlineInterval chartA_interval = KlineInterval.OneMinute;
        KlineInterval chartB_interval = KlineInterval.ThreeMinutes;
        KlineInterval chartC_interval = KlineInterval.FiveMinutes;
        KlineInterval chartD_interval = KlineInterval.FifteenMinutes;
        
        public Form2_charts() {
            InitializeComponent();
            // Add charts to list
            plots_list.Add(formsPlot_1m);
            plots_list.Add(formsPlot_3m);
            plots_list.Add(formsPlot_5m);
            plots_list.Add(formsPlot_15m);
            // Init charts
            init_charts();
        }
        
        public void init_charts() {
            // Set titles
            formsPlot_1m.Plot.Title(chartA_interval.ToString());
            formsPlot_3m.Plot.Title(chartB_interval.ToString());
            formsPlot_5m.Plot.Title(chartC_interval.ToString());
            formsPlot_15m.Plot.Title(chartD_interval.ToString());
            // Set cursor position labels
            foreach (var plt in plots_list) {
               
            }
        }
        public void updateCharts() {
            clearAllCharts();
            foreach (var plt in plots_list) {
                // Get data
                // Calculate alligator
                // Add to charts
            }
            refreshAllCharts();
        }
        public void clearAllCharts() {
            // Clear all previous data
            foreach (var plot in plots_list) {
                plot.Plot.Clear();
            }
        }
        public void refreshAllCharts() {
            // Refresh all previous data
            foreach (var plot in plots_list) {
                try {
                    plot.Refresh();
                } catch (Exception) {

                }
            }
        }
        private async void button_plot_Click(object sender, EventArgs e) {
            clearAllCharts();
            // Request data to binance grom the set time pickers and plot into charts
            if (dateTimePicker_date != null && dateTimePicker_time != null) {
                // Set the requested time (time of buy)
                DateTime req_dateTime = new DateTime(dateTimePicker_date.Value.Year, dateTimePicker_date.Value.Month, dateTimePicker_date.Value.Day,
                                                        dateTimePicker_time.Value.Hour, dateTimePicker_time.Value.Minute, dateTimePicker_time.Value.Second);
                // Init stuff the api request, based on timeframe
                int limit = 200;
                var kLineClient = new BinanceClient();
                // Draw candlesticks and alligator on all charts
                requestDataandDrawOnChartWithIndex(0, kLineClient, req_dateTime, limit, chartA_interval, 1); // 1 minute
                requestDataandDrawOnChartWithIndex(1, kLineClient, req_dateTime, limit, chartB_interval, 3); // 3 minute
                requestDataandDrawOnChartWithIndex(2, kLineClient, req_dateTime, limit, chartC_interval, 5); // 5 minute
                try {
                    requestDataandDrawOnChartWithIndex(3, kLineClient, req_dateTime, limit, chartD_interval, 15); // 15 minute
                } catch (Exception) {


                }
                
            }
        }
        private async void requestDataandDrawOnChartWithIndex (int index, BinanceClient client, DateTime requested_time, int limit, KlineInterval interval, int candleTimespan) {
            var plt = plots_list[index];
            DateTime start_date = requested_time.AddMinutes(-(limit*candleTimespan) / 2);
            DateTime end_date = requested_time.AddMinutes(limit* candleTimespan / 2);
            var mykline2 = await client.Spot.Market.GetKlinesAsync(textBox_reqSymbol.Text, interval, start_date, end_date, limit);
            List<OHLC> realPrices_list = new List<OHLC>();
            foreach (var candle in mykline2.Data) {
                realPrices_list.Add(new OHLC(decimal.ToDouble(candle.Open), decimal.ToDouble(candle.High),
                                            decimal.ToDouble(candle.Low), decimal.ToDouble(candle.Close),
                                             candle.OpenTime, TimeSpan.FromMinutes(candleTimespan)));
            }
            OHLC[] realPricesArray = realPrices_list.ToArray();
            plt.Plot.XAxis.DateTimeFormat(true);
            plt.Plot.YAxis.Ticks(true);
            plt.Plot.YAxis2.Ticks(false);
            plt.Plot.YAxis2.MinimumTickSpacing((double)candleTimespan);
            plt.Plot.AddCandlesticks(realPricesArray);
            // Spacing
            plt.Plot.XAxis.ManualTickSpacing(candleTimespan, ScottPlot.Ticks.DateTimeUnit.Minute);
            plt.Plot.XAxis.TickLabelStyle(rotation: 45);
            plt.Plot.XAxis.SetSizeLimit(min: 100);
            plt.Plot.YAxis.MinimumTickSpacing(.1);
            
            //plt.Plot.YAxis.ManualTickSpacing(.5);
            // Do the alligator
            List<Tuple<double[], double[]>> allig_lines = new List<Tuple<double[], double[]>>();
            if (realPricesArray.Count() >= 115) {
                // Not enough candles to make alligator, so request a previous time so there are enough periods TODO
                allig_lines = HistoricalCharts.computeAlligatorLines(realPricesArray);
                plt.Plot.AddScatterLines(allig_lines[0].Item1, allig_lines[0].Item2, Color.Blue, 1).YAxisIndex = 1;
                plt.Plot.AddScatterLines(allig_lines[1].Item1, allig_lines[1].Item2, Color.Red, 1).YAxisIndex = 1;
                plt.Plot.AddScatterLines(allig_lines[2].Item1, allig_lines[2].Item2, Color.Green, 1).YAxisIndex = 1;
            }
            
            // Add axisSpans for the higher timeframes, based on the 5 minute
            plt.Refresh();
            // show the candle of query
            plt.Plot.AddVerticalLine(requested_time.ToOADate());
            // For the 3, 5 and 15m charts, draw the range of the previous timeframe chart
            if (index == 1) {
                // For the 3 minute chart
                // show the range of the 3 minute chart
                plt.Plot.AddHorizontalSpan(requested_time.AddMinutes(-(limit * 1 / 2)).ToOADate(), requested_time.AddMinutes(+(limit * 1 / 2)).ToOADate(), Color.FromArgb(50, 175, 175, 175));
                plt.Refresh();
            }
            if (index == 2) {
                // For the 5 minute chart
                // show the range of the 3 minute chart
                plt.Plot.AddHorizontalSpan(requested_time.AddMinutes(-(limit * 3 / 2)).ToOADate(), requested_time.AddMinutes(+(limit * 3 / 2)).ToOADate(), Color.FromArgb(50, 175, 175, 175));
                plt.Plot.AddHorizontalSpan(requested_time.AddMinutes(-(limit * 1 / 2)).ToOADate(), requested_time.AddMinutes(+(limit * 1 / 2)).ToOADate(), Color.FromArgb(50, 175, 175, 175));
                plt.Refresh();
            }
            if (index == 3) {
                // For the 15 minute chart
                // show the range of the 5 minute chart
                plt.Plot.AddHorizontalSpan(requested_time.AddMinutes(-(limit * 5 / 2)).ToOADate(), requested_time.AddMinutes(+(limit * 5 / 2)).ToOADate(), Color.FromArgb(50, 175, 175, 175));
                plt.Plot.AddHorizontalSpan(requested_time.AddMinutes(-(limit * 3 / 2)).ToOADate(), requested_time.AddMinutes(+(limit * 3 / 2)).ToOADate(), Color.FromArgb(50, 175, 175, 175));
                plt.Plot.AddHorizontalSpan(requested_time.AddMinutes(-(limit * 1 / 2)).ToOADate(), requested_time.AddMinutes(+(limit * 1 / 2)).ToOADate(), Color.FromArgb(50, 175, 175, 175));
                plt.Refresh();
            }
            plt.Refresh();
        }
        private void saveChartsLayout() {
            var frm = Form.ActiveForm;
            using (var bmp = new Bitmap(frm.Width, frm.Height)) {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save($"{DateTime.Now.ToString("yyyy - M - dd--hh - mm - ss")}.png");
            }
        }
        private void button_saveScreenshot_Click(object sender, EventArgs e) {
            saveChartsLayout();
        }

        #region V & H Line Controls
        private void formsPlot_1m_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                double coordinateX = formsPlot_1m.GetMouseCoordinates().x;
                double coordinateY = formsPlot_1m.GetMouseCoordinates().y;
                updateChartsVHLine(coordinateX, coordinateY);
            }
        }

        private void formsPlot_3m_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                double coordinateX = formsPlot_3m.GetMouseCoordinates().x;
                double coordinateY = formsPlot_3m.GetMouseCoordinates().y;
                updateChartsVHLine(coordinateX, coordinateY);
            }
        }

        private void formsPlot_5m_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                double coordinateX = formsPlot_5m.GetMouseCoordinates().x;
                double coordinateY = formsPlot_5m.GetMouseCoordinates().y;
                updateChartsVHLine(coordinateX, coordinateY);
            }
        }

        private void formsPlot_15m_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                double coordinateX = formsPlot_15m.GetMouseCoordinates().x;
                double coordinateY = formsPlot_15m.GetMouseCoordinates().y;
                updateChartsVHLine(coordinateX, coordinateY);
            }
        }

        public void updateChartsVHLine(double coordinateX, double coordinateY) {
            foreach (var plt in plots_list) {
                // Vertical date line
                plt.Plot.Clear(typeof(ScottPlot.Plottable.VLine));
                var vline = plt.Plot.AddVerticalLine(coordinateX);
                //vline.Label = DateTime.FromOADate(coordinateX).ToString();
                Func<double, string> vFormatter = v => $"{DateTime.FromOADate(coordinateX).ToString()}";
                vline.PositionFormatter = vFormatter;
                vline.PositionLabel = true;
                vline.Color = Color.Red;
                vline.LineWidth = 0.5f;
                vline.PositionLabelBackground = vline.Color;
                // Horizontal price line
                plt.Plot.Clear(typeof(ScottPlot.Plottable.HLine));
                var hline = plt.Plot.AddHorizontalLine(coordinateY);
                hline.PositionLabel = true;
                hline.Color = Color.Red;
                hline.LineWidth = 1f;
                hline.PositionLabelBackground = hline.Color;
                plt.Refresh();
            }
        }
        #endregion

    }
}
