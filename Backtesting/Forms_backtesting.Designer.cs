
namespace CryoManager.Backtesting {
    partial class Forms_backtesting {
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
            this.formsPlot_timeline15m = new ScottPlot.FormsPlot();
            this.formsPlot_openTrades = new ScottPlot.FormsPlot();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_1m = new System.Windows.Forms.Button();
            this.button_3m = new System.Windows.Forms.Button();
            this.button_5m = new System.Windows.Forms.Button();
            this.button_15m = new System.Windows.Forms.Button();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_readLog = new System.Windows.Forms.Button();
            this.checkBox_candles_1m = new System.Windows.Forms.CheckBox();
            this.checkBox_allig_1m = new System.Windows.Forms.CheckBox();
            this.checkBox_allig_3m = new System.Windows.Forms.CheckBox();
            this.checkBox_candles_3m = new System.Windows.Forms.CheckBox();
            this.checkBox_allig_5m = new System.Windows.Forms.CheckBox();
            this.checkBox_candles_5m = new System.Windows.Forms.CheckBox();
            this.checkBox_allig_15m = new System.Windows.Forms.CheckBox();
            this.checkBox_candles_15m = new System.Windows.Forms.CheckBox();
            this.checkBox_trades_1m = new System.Windows.Forms.CheckBox();
            this.checkBox_trades_3m = new System.Windows.Forms.CheckBox();
            this.checkBox_trades_5m = new System.Windows.Forms.CheckBox();
            this.checkBox_trades_15m = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_resultsFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_bt_symbol = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formsPlot_timeline15m
            // 
            this.formsPlot_timeline15m.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot_timeline15m.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot_timeline15m.Location = new System.Drawing.Point(4, 4);
            this.formsPlot_timeline15m.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlot_timeline15m.Name = "formsPlot_timeline15m";
            this.formsPlot_timeline15m.Size = new System.Drawing.Size(1603, 531);
            this.formsPlot_timeline15m.TabIndex = 0;
            this.formsPlot_timeline15m.AxesChanged += new System.EventHandler(this.formsPlot_timeline15m_AxesChanged);
            // 
            // formsPlot_openTrades
            // 
            this.formsPlot_openTrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot_openTrades.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot_openTrades.Location = new System.Drawing.Point(4, 4);
            this.formsPlot_openTrades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlot_openTrades.Name = "formsPlot_openTrades";
            this.formsPlot_openTrades.Size = new System.Drawing.Size(1603, 530);
            this.formsPlot_openTrades.TabIndex = 1;
            this.formsPlot_openTrades.AxesChanged += new System.EventHandler(this.formsPlot_openTrades_AxesChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 170);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.formsPlot_timeline15m);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.formsPlot_openTrades);
            this.splitContainer1.Size = new System.Drawing.Size(1613, 1085);
            this.splitContainer1.SplitterDistance = 541;
            this.splitContainer1.TabIndex = 2;
            // 
            // button_1m
            // 
            this.button_1m.Location = new System.Drawing.Point(19, 26);
            this.button_1m.Name = "button_1m";
            this.button_1m.Size = new System.Drawing.Size(111, 53);
            this.button_1m.TabIndex = 3;
            this.button_1m.Text = "Get 1m";
            this.button_1m.UseVisualStyleBackColor = true;
            this.button_1m.Click += new System.EventHandler(this.button_1m_Click);
            // 
            // button_3m
            // 
            this.button_3m.Location = new System.Drawing.Point(136, 26);
            this.button_3m.Name = "button_3m";
            this.button_3m.Size = new System.Drawing.Size(111, 53);
            this.button_3m.TabIndex = 4;
            this.button_3m.Text = "Get 3m";
            this.button_3m.UseVisualStyleBackColor = true;
            this.button_3m.Click += new System.EventHandler(this.button_3m_Click);
            // 
            // button_5m
            // 
            this.button_5m.Location = new System.Drawing.Point(253, 26);
            this.button_5m.Name = "button_5m";
            this.button_5m.Size = new System.Drawing.Size(111, 53);
            this.button_5m.TabIndex = 5;
            this.button_5m.Text = "Get 5m";
            this.button_5m.UseVisualStyleBackColor = true;
            this.button_5m.Click += new System.EventHandler(this.button_5m_Click);
            // 
            // button_15m
            // 
            this.button_15m.Location = new System.Drawing.Point(370, 26);
            this.button_15m.Name = "button_15m";
            this.button_15m.Size = new System.Drawing.Size(111, 53);
            this.button_15m.TabIndex = 6;
            this.button_15m.Text = "Get 15m";
            this.button_15m.UseVisualStyleBackColor = true;
            this.button_15m.Click += new System.EventHandler(this.button_15m_Click);
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(498, 53);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(247, 22);
            this.dateTimePicker_start.TabIndex = 7;
            this.dateTimePicker_start.Value = new System.DateTime(2021, 11, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Start:";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(498, 108);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(246, 22);
            this.dateTimePicker_end.TabIndex = 10;
            this.dateTimePicker_end.Value = new System.DateTime(2021, 12, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "End:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(750, 108);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 21);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Now";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button_readLog
            // 
            this.button_readLog.Location = new System.Drawing.Point(1141, 18);
            this.button_readLog.Name = "button_readLog";
            this.button_readLog.Size = new System.Drawing.Size(88, 47);
            this.button_readLog.TabIndex = 13;
            this.button_readLog.Text = "Read log";
            this.button_readLog.UseVisualStyleBackColor = true;
            this.button_readLog.Click += new System.EventHandler(this.button_readLog_Click);
            // 
            // checkBox_candles_1m
            // 
            this.checkBox_candles_1m.AutoSize = true;
            this.checkBox_candles_1m.Location = new System.Drawing.Point(19, 85);
            this.checkBox_candles_1m.Name = "checkBox_candles_1m";
            this.checkBox_candles_1m.Size = new System.Drawing.Size(81, 21);
            this.checkBox_candles_1m.TabIndex = 14;
            this.checkBox_candles_1m.Text = "Candles";
            this.checkBox_candles_1m.UseVisualStyleBackColor = true;
            this.checkBox_candles_1m.CheckedChanged += new System.EventHandler(this.checkBox_candles_1m_CheckedChanged);
            // 
            // checkBox_allig_1m
            // 
            this.checkBox_allig_1m.AutoSize = true;
            this.checkBox_allig_1m.Location = new System.Drawing.Point(19, 112);
            this.checkBox_allig_1m.Name = "checkBox_allig_1m";
            this.checkBox_allig_1m.Size = new System.Drawing.Size(56, 21);
            this.checkBox_allig_1m.TabIndex = 15;
            this.checkBox_allig_1m.Text = "Allig";
            this.checkBox_allig_1m.UseVisualStyleBackColor = true;
            this.checkBox_allig_1m.CheckedChanged += new System.EventHandler(this.checkBox_allig_1m_CheckedChanged);
            // 
            // checkBox_allig_3m
            // 
            this.checkBox_allig_3m.AutoSize = true;
            this.checkBox_allig_3m.Location = new System.Drawing.Point(136, 112);
            this.checkBox_allig_3m.Name = "checkBox_allig_3m";
            this.checkBox_allig_3m.Size = new System.Drawing.Size(56, 21);
            this.checkBox_allig_3m.TabIndex = 17;
            this.checkBox_allig_3m.Text = "Allig";
            this.checkBox_allig_3m.UseVisualStyleBackColor = true;
            this.checkBox_allig_3m.CheckedChanged += new System.EventHandler(this.checkBox_allig_3m_CheckedChanged);
            // 
            // checkBox_candles_3m
            // 
            this.checkBox_candles_3m.AutoSize = true;
            this.checkBox_candles_3m.Location = new System.Drawing.Point(136, 85);
            this.checkBox_candles_3m.Name = "checkBox_candles_3m";
            this.checkBox_candles_3m.Size = new System.Drawing.Size(81, 21);
            this.checkBox_candles_3m.TabIndex = 16;
            this.checkBox_candles_3m.Text = "Candles";
            this.checkBox_candles_3m.UseVisualStyleBackColor = true;
            this.checkBox_candles_3m.CheckedChanged += new System.EventHandler(this.checkBox_candles_3m_CheckedChanged);
            // 
            // checkBox_allig_5m
            // 
            this.checkBox_allig_5m.AutoSize = true;
            this.checkBox_allig_5m.Location = new System.Drawing.Point(253, 112);
            this.checkBox_allig_5m.Name = "checkBox_allig_5m";
            this.checkBox_allig_5m.Size = new System.Drawing.Size(56, 21);
            this.checkBox_allig_5m.TabIndex = 19;
            this.checkBox_allig_5m.Text = "Allig";
            this.checkBox_allig_5m.UseVisualStyleBackColor = true;
            this.checkBox_allig_5m.CheckedChanged += new System.EventHandler(this.checkBox_allig_5m_CheckedChanged);
            // 
            // checkBox_candles_5m
            // 
            this.checkBox_candles_5m.AutoSize = true;
            this.checkBox_candles_5m.Location = new System.Drawing.Point(253, 85);
            this.checkBox_candles_5m.Name = "checkBox_candles_5m";
            this.checkBox_candles_5m.Size = new System.Drawing.Size(81, 21);
            this.checkBox_candles_5m.TabIndex = 18;
            this.checkBox_candles_5m.Text = "Candles";
            this.checkBox_candles_5m.UseVisualStyleBackColor = true;
            this.checkBox_candles_5m.CheckedChanged += new System.EventHandler(this.checkBox_candles_5m_CheckedChanged);
            // 
            // checkBox_allig_15m
            // 
            this.checkBox_allig_15m.AutoSize = true;
            this.checkBox_allig_15m.Location = new System.Drawing.Point(370, 112);
            this.checkBox_allig_15m.Name = "checkBox_allig_15m";
            this.checkBox_allig_15m.Size = new System.Drawing.Size(56, 21);
            this.checkBox_allig_15m.TabIndex = 21;
            this.checkBox_allig_15m.Text = "Allig";
            this.checkBox_allig_15m.UseVisualStyleBackColor = true;
            this.checkBox_allig_15m.CheckedChanged += new System.EventHandler(this.checkBox_allig_15m_CheckedChanged);
            // 
            // checkBox_candles_15m
            // 
            this.checkBox_candles_15m.AutoSize = true;
            this.checkBox_candles_15m.Location = new System.Drawing.Point(370, 85);
            this.checkBox_candles_15m.Name = "checkBox_candles_15m";
            this.checkBox_candles_15m.Size = new System.Drawing.Size(81, 21);
            this.checkBox_candles_15m.TabIndex = 20;
            this.checkBox_candles_15m.Text = "Candles";
            this.checkBox_candles_15m.UseVisualStyleBackColor = true;
            this.checkBox_candles_15m.CheckedChanged += new System.EventHandler(this.checkBox_candles_15m_CheckedChanged);
            // 
            // checkBox_trades_1m
            // 
            this.checkBox_trades_1m.AutoSize = true;
            this.checkBox_trades_1m.Location = new System.Drawing.Point(19, 139);
            this.checkBox_trades_1m.Name = "checkBox_trades_1m";
            this.checkBox_trades_1m.Size = new System.Drawing.Size(75, 21);
            this.checkBox_trades_1m.TabIndex = 22;
            this.checkBox_trades_1m.Text = "Trades";
            this.checkBox_trades_1m.UseVisualStyleBackColor = true;
            // 
            // checkBox_trades_3m
            // 
            this.checkBox_trades_3m.AutoSize = true;
            this.checkBox_trades_3m.Location = new System.Drawing.Point(136, 139);
            this.checkBox_trades_3m.Name = "checkBox_trades_3m";
            this.checkBox_trades_3m.Size = new System.Drawing.Size(75, 21);
            this.checkBox_trades_3m.TabIndex = 23;
            this.checkBox_trades_3m.Text = "Trades";
            this.checkBox_trades_3m.UseVisualStyleBackColor = true;
            // 
            // checkBox_trades_5m
            // 
            this.checkBox_trades_5m.AutoSize = true;
            this.checkBox_trades_5m.Location = new System.Drawing.Point(253, 139);
            this.checkBox_trades_5m.Name = "checkBox_trades_5m";
            this.checkBox_trades_5m.Size = new System.Drawing.Size(75, 21);
            this.checkBox_trades_5m.TabIndex = 24;
            this.checkBox_trades_5m.Text = "Trades";
            this.checkBox_trades_5m.UseVisualStyleBackColor = true;
            // 
            // checkBox_trades_15m
            // 
            this.checkBox_trades_15m.AutoSize = true;
            this.checkBox_trades_15m.Location = new System.Drawing.Point(370, 139);
            this.checkBox_trades_15m.Name = "checkBox_trades_15m";
            this.checkBox_trades_15m.Size = new System.Drawing.Size(75, 21);
            this.checkBox_trades_15m.TabIndex = 25;
            this.checkBox_trades_15m.Text = "Trades";
            this.checkBox_trades_15m.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_resultsFrom
            // 
            this.dateTimePicker_resultsFrom.Location = new System.Drawing.Point(818, 53);
            this.dateTimePicker_resultsFrom.Name = "dateTimePicker_resultsFrom";
            this.dateTimePicker_resultsFrom.Size = new System.Drawing.Size(247, 22);
            this.dateTimePicker_resultsFrom.TabIndex = 26;
            this.dateTimePicker_resultsFrom.Value = new System.DateTime(2021, 11, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(815, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Calculate returns from:";
            // 
            // textBox_bt_symbol
            // 
            this.textBox_bt_symbol.Location = new System.Drawing.Point(577, 18);
            this.textBox_bt_symbol.Name = "textBox_bt_symbol";
            this.textBox_bt_symbol.Size = new System.Drawing.Size(100, 22);
            this.textBox_bt_symbol.TabIndex = 28;
            this.textBox_bt_symbol.Text = "SOLUSDT";
            // 
            // Forms_backtesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 1267);
            this.Controls.Add(this.textBox_bt_symbol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_resultsFrom);
            this.Controls.Add(this.checkBox_trades_15m);
            this.Controls.Add(this.checkBox_trades_5m);
            this.Controls.Add(this.checkBox_trades_3m);
            this.Controls.Add(this.checkBox_trades_1m);
            this.Controls.Add(this.checkBox_allig_15m);
            this.Controls.Add(this.checkBox_candles_15m);
            this.Controls.Add(this.checkBox_allig_5m);
            this.Controls.Add(this.checkBox_candles_5m);
            this.Controls.Add(this.checkBox_allig_3m);
            this.Controls.Add(this.checkBox_candles_3m);
            this.Controls.Add(this.checkBox_allig_1m);
            this.Controls.Add(this.checkBox_candles_1m);
            this.Controls.Add(this.button_readLog);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.button_15m);
            this.Controls.Add(this.button_5m);
            this.Controls.Add(this.button_3m);
            this.Controls.Add(this.button_1m);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Forms_backtesting";
            this.Text = "Forms_backtesting";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot_timeline15m;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_1m;
        private System.Windows.Forms.Button button_3m;
        private System.Windows.Forms.Button button_5m;
        private System.Windows.Forms.Button button_15m;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        public ScottPlot.FormsPlot formsPlot_openTrades;
        private System.Windows.Forms.Button button_readLog;
        private System.Windows.Forms.CheckBox checkBox_candles_1m;
        private System.Windows.Forms.CheckBox checkBox_allig_1m;
        private System.Windows.Forms.CheckBox checkBox_allig_3m;
        private System.Windows.Forms.CheckBox checkBox_candles_3m;
        private System.Windows.Forms.CheckBox checkBox_allig_5m;
        private System.Windows.Forms.CheckBox checkBox_candles_5m;
        private System.Windows.Forms.CheckBox checkBox_allig_15m;
        private System.Windows.Forms.CheckBox checkBox_candles_15m;
        private System.Windows.Forms.CheckBox checkBox_trades_1m;
        private System.Windows.Forms.CheckBox checkBox_trades_3m;
        private System.Windows.Forms.CheckBox checkBox_trades_5m;
        private System.Windows.Forms.CheckBox checkBox_trades_15m;
        private System.Windows.Forms.DateTimePicker dateTimePicker_resultsFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_bt_symbol;
    }
}