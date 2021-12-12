
namespace CryoManager {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_get_btc_price = new System.Windows.Forms.Button();
            this.label_show_btc_price = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDepositsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backtestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_ownedCoins = new System.Windows.Forms.DataGridView();
            this.ColumnCoin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQnty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_coinTrades = new System.Windows.Forms.DataGridView();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExecuted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUSDValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProfitPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUSDFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_totalProfit = new System.Windows.Forms.Label();
            this.label_totalProfitAmount = new System.Windows.Forms.Label();
            this.formsPlotPrice = new ScottPlot.FormsPlot();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label_chartLog = new System.Windows.Forms.Label();
            this.button_startBot = new System.Windows.Forms.Button();
            this.button_stopBot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_currTime = new System.Windows.Forms.Label();
            this.label_timeLeftoforNewCandle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_timeOfRequest = new System.Windows.Forms.Label();
            this.checkBox_sound = new System.Windows.Forms.CheckBox();
            this.button_clearChart = new System.Windows.Forms.Button();
            this.button_openCharts = new System.Windows.Forms.Button();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ownedCoins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_coinTrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // button_get_btc_price
            // 
            this.button_get_btc_price.Location = new System.Drawing.Point(320, 55);
            this.button_get_btc_price.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_get_btc_price.Name = "button_get_btc_price";
            this.button_get_btc_price.Size = new System.Drawing.Size(103, 53);
            this.button_get_btc_price.TabIndex = 0;
            this.button_get_btc_price.Text = "get price chart";
            this.button_get_btc_price.UseVisualStyleBackColor = true;
            this.button_get_btc_price.Click += new System.EventHandler(this.button_get_btc_price_Click);
            // 
            // label_show_btc_price
            // 
            this.label_show_btc_price.AutoSize = true;
            this.label_show_btc_price.Location = new System.Drawing.Point(460, 74);
            this.label_show_btc_price.Name = "label_show_btc_price";
            this.label_show_btc_price.Size = new System.Drawing.Size(106, 17);
            this.label_show_btc_price.TabIndex = 2;
            this.label_show_btc_price.Text = "show_btc_price";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.importToolStripMenuItem,
            this.backtestToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2459, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTradesToolStripMenuItem,
            this.importDepositsToolStripMenuItem,
            this.parseTransactionsToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // importTradesToolStripMenuItem
            // 
            this.importTradesToolStripMenuItem.Name = "importTradesToolStripMenuItem";
            this.importTradesToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.importTradesToolStripMenuItem.Text = "Import trades";
            this.importTradesToolStripMenuItem.Click += new System.EventHandler(this.importTradesToolStripMenuItem_Click);
            // 
            // importDepositsToolStripMenuItem
            // 
            this.importDepositsToolStripMenuItem.Name = "importDepositsToolStripMenuItem";
            this.importDepositsToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.importDepositsToolStripMenuItem.Text = "Import deposits";
            this.importDepositsToolStripMenuItem.Click += new System.EventHandler(this.importDepositsToolStripMenuItem_Click);
            // 
            // parseTransactionsToolStripMenuItem
            // 
            this.parseTransactionsToolStripMenuItem.Name = "parseTransactionsToolStripMenuItem";
            this.parseTransactionsToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.parseTransactionsToolStripMenuItem.Text = "Parse transactions";
            this.parseTransactionsToolStripMenuItem.Click += new System.EventHandler(this.parseTransactionsToolStripMenuItem_Click);
            // 
            // backtestToolStripMenuItem
            // 
            this.backtestToolStripMenuItem.Name = "backtestToolStripMenuItem";
            this.backtestToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.backtestToolStripMenuItem.Text = "Backtest";
            this.backtestToolStripMenuItem.Click += new System.EventHandler(this.backtestToolStripMenuItem_Click);
            // 
            // dataGridView_ownedCoins
            // 
            this.dataGridView_ownedCoins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView_ownedCoins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ownedCoins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCoin,
            this.ColumnQnty});
            this.dataGridView_ownedCoins.Location = new System.Drawing.Point(12, 146);
            this.dataGridView_ownedCoins.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_ownedCoins.Name = "dataGridView_ownedCoins";
            this.dataGridView_ownedCoins.RowHeadersVisible = false;
            this.dataGridView_ownedCoins.RowHeadersWidth = 51;
            this.dataGridView_ownedCoins.RowTemplate.Height = 24;
            this.dataGridView_ownedCoins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ownedCoins.Size = new System.Drawing.Size(251, 1102);
            this.dataGridView_ownedCoins.TabIndex = 5;
            this.dataGridView_ownedCoins.SelectionChanged += new System.EventHandler(this.dataGridView_ownedCoins_SelectionChanged);
            // 
            // ColumnCoin
            // 
            this.ColumnCoin.HeaderText = "Coin";
            this.ColumnCoin.MinimumWidth = 6;
            this.ColumnCoin.Name = "ColumnCoin";
            this.ColumnCoin.ReadOnly = true;
            this.ColumnCoin.Width = 125;
            // 
            // ColumnQnty
            // 
            this.ColumnQnty.HeaderText = "Qnty";
            this.ColumnQnty.MinimumWidth = 6;
            this.ColumnQnty.Name = "ColumnQnty";
            this.ColumnQnty.ReadOnly = true;
            this.ColumnQnty.Width = 125;
            // 
            // dataGridView_coinTrades
            // 
            this.dataGridView_coinTrades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_coinTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_coinTrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDate,
            this.ColumnAction,
            this.ColumnPair,
            this.ColumnSide,
            this.ColumnPrice,
            this.ColumnExecuted,
            this.ColumnUSDValue,
            this.ColumnProfit,
            this.ColumnProfitPercentage,
            this.ColumnUSDFee});
            this.dataGridView_coinTrades.Location = new System.Drawing.Point(269, 962);
            this.dataGridView_coinTrades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_coinTrades.Name = "dataGridView_coinTrades";
            this.dataGridView_coinTrades.RowHeadersVisible = false;
            this.dataGridView_coinTrades.RowHeadersWidth = 51;
            this.dataGridView_coinTrades.RowTemplate.Height = 24;
            this.dataGridView_coinTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_coinTrades.Size = new System.Drawing.Size(1533, 286);
            this.dataGridView_coinTrades.TabIndex = 6;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.MinimumWidth = 6;
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Width = 125;
            // 
            // ColumnAction
            // 
            this.ColumnAction.HeaderText = "Action";
            this.ColumnAction.MinimumWidth = 6;
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.ReadOnly = true;
            this.ColumnAction.Width = 125;
            // 
            // ColumnPair
            // 
            this.ColumnPair.HeaderText = "Pair";
            this.ColumnPair.MinimumWidth = 6;
            this.ColumnPair.Name = "ColumnPair";
            this.ColumnPair.ReadOnly = true;
            this.ColumnPair.Width = 125;
            // 
            // ColumnSide
            // 
            this.ColumnSide.HeaderText = "Side";
            this.ColumnSide.MinimumWidth = 6;
            this.ColumnSide.Name = "ColumnSide";
            this.ColumnSide.ReadOnly = true;
            this.ColumnSide.Width = 125;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "Price";
            this.ColumnPrice.MinimumWidth = 6;
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.Width = 125;
            // 
            // ColumnExecuted
            // 
            this.ColumnExecuted.HeaderText = "Executed";
            this.ColumnExecuted.MinimumWidth = 6;
            this.ColumnExecuted.Name = "ColumnExecuted";
            this.ColumnExecuted.ReadOnly = true;
            this.ColumnExecuted.Width = 125;
            // 
            // ColumnUSDValue
            // 
            this.ColumnUSDValue.HeaderText = "Value $";
            this.ColumnUSDValue.MinimumWidth = 6;
            this.ColumnUSDValue.Name = "ColumnUSDValue";
            this.ColumnUSDValue.ReadOnly = true;
            this.ColumnUSDValue.Width = 125;
            // 
            // ColumnProfit
            // 
            this.ColumnProfit.HeaderText = "Profit $";
            this.ColumnProfit.MinimumWidth = 6;
            this.ColumnProfit.Name = "ColumnProfit";
            this.ColumnProfit.Width = 125;
            // 
            // ColumnProfitPercentage
            // 
            this.ColumnProfitPercentage.HeaderText = "Profit %";
            this.ColumnProfitPercentage.MinimumWidth = 6;
            this.ColumnProfitPercentage.Name = "ColumnProfitPercentage";
            this.ColumnProfitPercentage.Width = 125;
            // 
            // ColumnUSDFee
            // 
            this.ColumnUSDFee.HeaderText = "Fee $";
            this.ColumnUSDFee.MinimumWidth = 6;
            this.ColumnUSDFee.Name = "ColumnUSDFee";
            this.ColumnUSDFee.Width = 125;
            // 
            // chart2
            // 
            this.chart2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(1823, 469);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(589, 395);
            this.chart2.TabIndex = 7;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            this.chart3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart3.Legends.Add(legend2);
            this.chart3.Location = new System.Drawing.Point(1823, 884);
            this.chart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart3.Name = "chart3";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart3.Series.Add(series2);
            this.chart3.Size = new System.Drawing.Size(589, 318);
            this.chart3.TabIndex = 8;
            this.chart3.Text = "chart3";
            // 
            // label_totalProfit
            // 
            this.label_totalProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_totalProfit.AutoSize = true;
            this.label_totalProfit.Location = new System.Drawing.Point(1796, 1222);
            this.label_totalProfit.Name = "label_totalProfit";
            this.label_totalProfit.Size = new System.Drawing.Size(80, 17);
            this.label_totalProfit.TabIndex = 9;
            this.label_totalProfit.Text = "Total profit:";
            // 
            // label_totalProfitAmount
            // 
            this.label_totalProfitAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_totalProfitAmount.AutoSize = true;
            this.label_totalProfitAmount.Location = new System.Drawing.Point(1897, 1222);
            this.label_totalProfitAmount.Name = "label_totalProfitAmount";
            this.label_totalProfitAmount.Size = new System.Drawing.Size(28, 17);
            this.label_totalProfitAmount.TabIndex = 10;
            this.label_totalProfitAmount.Text = "0.0";
            // 
            // formsPlotPrice
            // 
            this.formsPlotPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlotPrice.BackColor = System.Drawing.Color.Transparent;
            this.formsPlotPrice.Location = new System.Drawing.Point(269, 114);
            this.formsPlotPrice.Margin = new System.Windows.Forms.Padding(5);
            this.formsPlotPrice.Name = "formsPlotPrice";
            this.formsPlotPrice.Size = new System.Drawing.Size(1547, 841);
            this.formsPlotPrice.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(320, 114);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(447, 114);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 15;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(573, 114);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 16;
            // 
            // label_chartLog
            // 
            this.label_chartLog.AutoSize = true;
            this.label_chartLog.Location = new System.Drawing.Point(1600, 122);
            this.label_chartLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_chartLog.Name = "label_chartLog";
            this.label_chartLog.Size = new System.Drawing.Size(58, 17);
            this.label_chartLog.TabIndex = 17;
            this.label_chartLog.Text = "No data";
            this.label_chartLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_startBot
            // 
            this.button_startBot.Location = new System.Drawing.Point(755, 63);
            this.button_startBot.Margin = new System.Windows.Forms.Padding(4);
            this.button_startBot.Name = "button_startBot";
            this.button_startBot.Size = new System.Drawing.Size(100, 28);
            this.button_startBot.TabIndex = 18;
            this.button_startBot.Text = "Start bot";
            this.button_startBot.UseVisualStyleBackColor = true;
            this.button_startBot.Click += new System.EventHandler(this.button_startBot_Click);
            // 
            // button_stopBot
            // 
            this.button_stopBot.Location = new System.Drawing.Point(863, 63);
            this.button_stopBot.Margin = new System.Windows.Forms.Padding(4);
            this.button_stopBot.Name = "button_stopBot";
            this.button_stopBot.Size = new System.Drawing.Size(100, 28);
            this.button_stopBot.TabIndex = 19;
            this.button_stopBot.Text = "Stop bot";
            this.button_stopBot.UseVisualStyleBackColor = true;
            this.button_stopBot.Click += new System.EventHandler(this.button_stopBot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(755, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "label_botState";
            // 
            // label_currTime
            // 
            this.label_currTime.AutoSize = true;
            this.label_currTime.Location = new System.Drawing.Point(1214, 32);
            this.label_currTime.Name = "label_currTime";
            this.label_currTime.Size = new System.Drawing.Size(46, 17);
            this.label_currTime.TabIndex = 21;
            this.label_currTime.Text = "label2";
            // 
            // label_timeLeftoforNewCandle
            // 
            this.label_timeLeftoforNewCandle.AutoSize = true;
            this.label_timeLeftoforNewCandle.Location = new System.Drawing.Point(1214, 74);
            this.label_timeLeftoforNewCandle.Name = "label_timeLeftoforNewCandle";
            this.label_timeLeftoforNewCandle.Size = new System.Drawing.Size(46, 17);
            this.label_timeLeftoforNewCandle.TabIndex = 22;
            this.label_timeLeftoforNewCandle.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // label_timeOfRequest
            // 
            this.label_timeOfRequest.AutoSize = true;
            this.label_timeOfRequest.Location = new System.Drawing.Point(1214, 55);
            this.label_timeOfRequest.Name = "label_timeOfRequest";
            this.label_timeOfRequest.Size = new System.Drawing.Size(46, 17);
            this.label_timeOfRequest.TabIndex = 23;
            this.label_timeOfRequest.Text = "label2";
            // 
            // checkBox_sound
            // 
            this.checkBox_sound.AutoSize = true;
            this.checkBox_sound.Location = new System.Drawing.Point(956, 32);
            this.checkBox_sound.Name = "checkBox_sound";
            this.checkBox_sound.Size = new System.Drawing.Size(71, 21);
            this.checkBox_sound.TabIndex = 24;
            this.checkBox_sound.Text = "Sound";
            this.checkBox_sound.UseVisualStyleBackColor = true;
            // 
            // button_clearChart
            // 
            this.button_clearChart.Location = new System.Drawing.Point(112, 32);
            this.button_clearChart.Name = "button_clearChart";
            this.button_clearChart.Size = new System.Drawing.Size(75, 23);
            this.button_clearChart.TabIndex = 25;
            this.button_clearChart.Text = "clear chart";
            this.button_clearChart.UseVisualStyleBackColor = true;
            this.button_clearChart.Click += new System.EventHandler(this.button_clearChart_Click);
            // 
            // button_openCharts
            // 
            this.button_openCharts.Location = new System.Drawing.Point(131, 85);
            this.button_openCharts.Name = "button_openCharts";
            this.button_openCharts.Size = new System.Drawing.Size(141, 53);
            this.button_openCharts.TabIndex = 26;
            this.button_openCharts.Text = "Open charts";
            this.button_openCharts.UseVisualStyleBackColor = true;
            this.button_openCharts.Click += new System.EventHandler(this.button_openCharts_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2459, 1260);
            this.Controls.Add(this.button_openCharts);
            this.Controls.Add(this.button_clearChart);
            this.Controls.Add(this.checkBox_sound);
            this.Controls.Add(this.label_timeOfRequest);
            this.Controls.Add(this.label_timeLeftoforNewCandle);
            this.Controls.Add(this.label_currTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_stopBot);
            this.Controls.Add(this.button_startBot);
            this.Controls.Add(this.label_chartLog);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.formsPlotPrice);
            this.Controls.Add(this.label_totalProfitAmount);
            this.Controls.Add(this.label_totalProfit);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.dataGridView_coinTrades);
            this.Controls.Add(this.dataGridView_ownedCoins);
            this.Controls.Add(this.label_show_btc_price);
            this.Controls.Add(this.button_get_btc_price);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ownedCoins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_coinTrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_get_btc_price;
        private System.Windows.Forms.Label label_show_btc_price;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDepositsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_ownedCoins;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCoin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQnty;
        private System.Windows.Forms.DataGridView dataGridView_coinTrades;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Label label_totalProfit;
        private System.Windows.Forms.Label label_totalProfitAmount;
        private System.Windows.Forms.ToolStripMenuItem parseTransactionsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPair;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExecuted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUSDValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProfitPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUSDFee;
        private ScottPlot.FormsPlot formsPlotPrice;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label_chartLog;
        private System.Windows.Forms.Button button_startBot;
        private System.Windows.Forms.Button button_stopBot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_currTime;
        private System.Windows.Forms.Label label_timeLeftoforNewCandle;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label_timeOfRequest;
        private System.Windows.Forms.CheckBox checkBox_sound;
        private System.Windows.Forms.Button button_clearChart;
        private System.Windows.Forms.Button button_openCharts;
        private System.Windows.Forms.ToolStripMenuItem backtestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
    }
}

