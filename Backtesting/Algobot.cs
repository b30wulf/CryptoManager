using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net.Enums;

namespace CryoManager {
    public class Algobot {
        // Defines the properties of the trading bot
        // Name and strategy
        public String name;            // Name of the bot
        public String strategyText;    // Strategy info

        // Timeframes
        public KlineInterval timeInterval;  // Timeframe to monitor
        public String timeFrame;            // Timeframe in text form

        // Symbols that will be monitored
        public String coinPair;
        List<string> symbolsToTrade = new List<string> { "SOLUSDT", "MANAUSDT" };

        // State of the bot adn trading info
        public bool openTrade = false;     // True if a trade is currently open
        public Trade current_trade;    // Information on the current trade 
        public double boughtPriceCoinUSDT = 0;
        public double unrealizedProfitUSDT = 0;
        public double boughtAmountUSDT = 0;
        public double account_worth = 100;

        // History data to keep
        public List<Trade> list_of_trades = new List<Trade>(); // Historical list of all trades executed
        
        
        public Algobot() {
            
            coinPair = "SOLUSDT";
            name = "Bot A";
            strategyText = "First trading bot test using the alligator strategy as described in https://www.youtube.com/watch?v=eJyz7CRWWW0 \r\n" +
                "Behaviour: \r\n" + "BUY SIGNAL: \r\n" + " Lips(green line) is below teeth (red) \r\n" + "A candle closed above the teeth(red)" +
                "SELL(EXIT) SIGNAL \r\n" + "A candle hits the lips(green)\r\n OR\r\n  Loss of 2 % of account" + 
                $"Symbol: {coinPair}";
            timeFrame = "1m";
            timeInterval = KlineInterval.OneMinute;

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

        

       



    }
}
