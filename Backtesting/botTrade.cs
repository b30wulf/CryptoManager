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
    public class botTrade {
        // Holds data of a trade performed by the bot
        public string symbolPair;
        public DateTime openTime;
        public DateTime closeTime;
        public double boughtAt;
        public double soldAt;
        public int interval;


        public botTrade() { }










    }
}
