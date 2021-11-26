using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoManager {
    public class CoinToken {
        // This class defines what is a coin, its full and abbreviated name. Live price and a historical daily price with USDT
        public String fullName; // Full name of coin ej: 'bitcoin'
        public String shortName; // Short name of coin ej: BTC
        public float livePriceUSDT; // Live price in USDT

        // Also keeps the relation of this coin with the portfolio: Amount of owned coins. Trades taken with it
        public float qntyOwned; // Quantity of coins owned
        public List<Trade> coinTrades = new List<Trade>(); // Contains the trades and deposits regarding this coin
        
        // To calculate profits of trades. Also have a List of just the price and qnty of coins that are owned
        public List<List<float>> coinsBoughtAtPrice = new List<List<float>>(); // List of (price, quantity) ordered by date            
        
        // Methods
        public void createHistoryOfTransactionsForCoin(CoinToken coin) {

        }
    
    
    
    
    }
}
