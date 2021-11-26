
namespace CryoManager {
    partial class Form2_charts {
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
            this.formsPlot_1m = new ScottPlot.FormsPlot();
            this.formsPlot_3m = new ScottPlot.FormsPlot();
            this.formsPlot_15m = new ScottPlot.FormsPlot();
            this.formsPlot_5m = new ScottPlot.FormsPlot();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.button_plot = new System.Windows.Forms.Button();
            this.dateTimePicker_date = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_time = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button_saveScreenshot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // formsPlot_1m
            // 
            this.formsPlot_1m.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot_1m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot_1m.Location = new System.Drawing.Point(0, 0);
            this.formsPlot_1m.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlot_1m.Name = "formsPlot_1m";
            this.formsPlot_1m.Size = new System.Drawing.Size(753, 585);
            this.formsPlot_1m.TabIndex = 0;
            this.formsPlot_1m.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formsPlot_1m_MouseDown);
            // 
            // formsPlot_3m
            // 
            this.formsPlot_3m.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot_3m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot_3m.Location = new System.Drawing.Point(0, 0);
            this.formsPlot_3m.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlot_3m.Name = "formsPlot_3m";
            this.formsPlot_3m.Size = new System.Drawing.Size(749, 585);
            this.formsPlot_3m.TabIndex = 1;
            this.formsPlot_3m.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formsPlot_3m_MouseDown);
            // 
            // formsPlot_15m
            // 
            this.formsPlot_15m.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot_15m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot_15m.Location = new System.Drawing.Point(0, 0);
            this.formsPlot_15m.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlot_15m.Name = "formsPlot_15m";
            this.formsPlot_15m.Size = new System.Drawing.Size(749, 630);
            this.formsPlot_15m.TabIndex = 3;
            this.formsPlot_15m.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formsPlot_15m_MouseDown);
            // 
            // formsPlot_5m
            // 
            this.formsPlot_5m.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot_5m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot_5m.Location = new System.Drawing.Point(0, 0);
            this.formsPlot_5m.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.formsPlot_5m.Name = "formsPlot_5m";
            this.formsPlot_5m.Size = new System.Drawing.Size(753, 630);
            this.formsPlot_5m.TabIndex = 2;
            this.formsPlot_5m.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formsPlot_5m_MouseDown);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1510, 73);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // button_plot
            // 
            this.button_plot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_plot.Location = new System.Drawing.Point(1439, 12);
            this.button_plot.Name = "button_plot";
            this.button_plot.Size = new System.Drawing.Size(59, 53);
            this.button_plot.TabIndex = 6;
            this.button_plot.Text = "Plot";
            this.button_plot.UseVisualStyleBackColor = true;
            this.button_plot.Click += new System.EventHandler(this.button_plot_Click);
            // 
            // dateTimePicker_date
            // 
            this.dateTimePicker_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_date.Location = new System.Drawing.Point(1140, 12);
            this.dateTimePicker_date.Name = "dateTimePicker_date";
            this.dateTimePicker_date.Size = new System.Drawing.Size(281, 22);
            this.dateTimePicker_date.TabIndex = 7;
            // 
            // dateTimePicker_time
            // 
            this.dateTimePicker_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_time.Location = new System.Drawing.Point(1264, 43);
            this.dateTimePicker_time.Name = "dateTimePicker_time";
            this.dateTimePicker_time.Size = new System.Drawing.Size(157, 22);
            this.dateTimePicker_time.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.splitContainer1.Location = new System.Drawing.Point(0, 79);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1510, 1223);
            this.splitContainer1.SplitterDistance = 755;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.formsPlot_1m);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.formsPlot_5m);
            this.splitContainer2.Size = new System.Drawing.Size(755, 1223);
            this.splitContainer2.SplitterDistance = 587;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.formsPlot_3m);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.formsPlot_15m);
            this.splitContainer3.Size = new System.Drawing.Size(751, 1223);
            this.splitContainer3.SplitterDistance = 587;
            this.splitContainer3.TabIndex = 0;
            // 
            // button_saveScreenshot
            // 
            this.button_saveScreenshot.Location = new System.Drawing.Point(12, 12);
            this.button_saveScreenshot.Name = "button_saveScreenshot";
            this.button_saveScreenshot.Size = new System.Drawing.Size(103, 53);
            this.button_saveScreenshot.TabIndex = 10;
            this.button_saveScreenshot.Text = "Save screenshot";
            this.button_saveScreenshot.UseVisualStyleBackColor = true;
            this.button_saveScreenshot.Click += new System.EventHandler(this.button_saveScreenshot_Click);
            // 
            // Form2_charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1510, 1314);
            this.Controls.Add(this.button_saveScreenshot);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.dateTimePicker_time);
            this.Controls.Add(this.dateTimePicker_date);
            this.Controls.Add(this.button_plot);
            this.Controls.Add(this.splitter1);
            this.Name = "Form2_charts";
            this.Text = "Form2_charts";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ScottPlot.FormsPlot formsPlot_3m;
        private ScottPlot.FormsPlot formsPlot_15m;
        private ScottPlot.FormsPlot formsPlot_5m;
        public ScottPlot.FormsPlot formsPlot_1m;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button_plot;
        private System.Windows.Forms.DateTimePicker dateTimePicker_date;
        private System.Windows.Forms.DateTimePicker dateTimePicker_time;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button_saveScreenshot;
    }
}