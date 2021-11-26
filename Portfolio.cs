using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoManager {
    public class Portfolio {
        // Aggregates everything related to the portfolio.
        // Transactions
        public List<Deposit> deposits_list = new List<Deposit>(); // Stores imported deposits data
        public List<Trade> unmodified_trades_list = new List<Trade>(); // Sotres imported trades
        public List<Trade> agg_trades_list = new List<Trade>(); // Contains all trades aggregating fractional trades

        public List<Transaction> all_transactions = new List<Transaction>(); // Contains all operations. Deposits + trades (aggregated??)

        // Currently owned
        public static List<CoinToken> owned_cointoken_list = new List<CoinToken>(); // Contains all coins owned
        public List<string> owned_coin_list = new List<string>();
        
        // Methods
        public void createListOfCoinTokesTraded(List<Transaction> trans_list) {
            // Sends each transaction to a type specific method to add into the list 
            // of all ever traded coins
            foreach (var trans in trans_list) {
                if (trans.GetType() == typeof(Deposit)) {
                    checkIfDepositCoinExistsInList((Deposit)trans);
                } else if (trans.GetType() == typeof(Trade)) {
                    debugControls.printTrade((Trade)trans);
                    checkIfTradeCoinExistsInList((Trade)trans);
                }
            }
        }
        public bool checkIfCoinTokenExists(string coinTokenAbbreviation) {
            // Checks if the coin is already owned. It not, it adds an object that represents it
            foreach (var coin in owned_cointoken_list) {
                if (coin.shortName == coinTokenAbbreviation) {
                    return true;
                }
            }
            return false;
        }
        public void checkIfDepositCoinExistsInList(Deposit depo) {
            // Checks if the coin exists in the list and adds it if it doesnt
            if (!checkIfCoinTokenExists(depo.depositCurrency))
                addCoinTokenToList(depo.depositCurrency);
            addSubtractCoinTokenQnty(depo.depositCurrency, depo.quantity);
            // Add the deposit to the history file of the coin
            addDepositToCoinTokenHistory(depo);
        }
        public void checkIfTradeCoinExistsInList(Trade trade) {
            // Diferenciate if buy or sell
            if (trade.operationType == "BUY") {
                // Coin1 was bought with coin2. Check if there already was coin1
                if (!checkIfCoinTokenExists(trade.coin1))
                    // Create coin if it doesnt exist
                    addCoinTokenToList(trade.coin1);
                // Coin1 exists. Add coin1 and subtract coin2
                addSubtractCoinTokenQnty(trade.coin1, trade.executed);
                addSubtractCoinTokenQnty(trade.coin2, -trade.amount);
            } else if (trade.operationType == "SELL") {
                if (!checkIfCoinTokenExists(trade.coin2))
                    // Create coin if it doesnt exist
                    addCoinTokenToList(trade.coin2);
                // Coin2 exists. Subtract coin1 and add coin2
                addSubtractCoinTokenQnty(trade.coin2, trade.amount);
                addSubtractCoinTokenQnty(trade.coin1, -trade.executed);
            }
            if (trade.feeCurrency == "USDT")
                addSubtractCoinTokenQnty("USDT", -trade.fee);
            addTradeToCoinTokenHistory(trade);
        }
        public void addCoinTokenToList(string tokenAbbre) {
            // Create an instance of coinToken to add into the list of owned coins
            CoinToken newCoin = new CoinToken();
            newCoin.shortName = tokenAbbre;
            newCoin.qntyOwned = 0;
            owned_cointoken_list.Add(newCoin);
        }
        public void addSubtractCoinTokenQnty(string tokenName, float qnty) {
            // Adds or subtracts qnty of the coin token
            // It the sign of qnty tells if +/- add/subtract
            // Go through the list of coins and find which coin to modify
            foreach (var coin in owned_cointoken_list) {
                if (coin.shortName == tokenName) {
                    if (coin.qntyOwned < (Math.Abs(qnty)-10) && qnty < 0) {
                        debugControls.print("ABOUT TO GO NEGATIVE");
                        debugControls.print($"Currently owned {coin.qntyOwned} {tokenName}");
                        debugControls.print($"Attempting to remove {qnty}");
                        debugControls.print($"Resulting in {coin.qntyOwned += qnty}");
                        // Something went wrong because we cant have negative qnty owned
                        debugControls.print($"Error counting coins with token {tokenName} trade with qnty {qnty}");
                    }                    
                    debugControls.print($"Modified {tokenName}: {coin.qntyOwned} + {qnty} = {coin.qntyOwned + qnty}");
                    coin.qntyOwned += qnty;
                }
            }
        }


        public void addDepositToCoinTokenHistory(Deposit depo) {
            // Find the cointoken of the transaction
            foreach (var coin in owned_cointoken_list) {
                if (coin.shortName == depo.depositCurrency) {
                    Trade newTrade = new Trade(); // Creates empty trade object with all set to 0
                    // Copy info of deposit into new trade object
                    newTrade.operationType = "Deposit";
                    newTrade.coin1 = depo.depositCurrency;
                    newTrade.amount = depo.quantity;
                    newTrade.executed = depo.quantity;
                    newTrade.date = depo.date;
                    coin.coinTrades.Add(newTrade);
                    debugControls.print($"Added a deposit on the history of {newTrade.coin1} of amount {newTrade.amount}");
                }
            }
        }
        public void addTradeToCoinTokenHistory(Trade trade) {
            // The trade will be added to both the buy and the sell coins
            foreach (var coin in owned_cointoken_list) {
                // Find the cointoken of coin1 and coin2
                if (coin.shortName == trade.coin1 || coin.shortName == trade.coin2) {
                    Trade newTrade = new Trade(); // Creates empty trade object with all set to 0
                    // Copy info of trade into new trade object
                    newTrade.operationType = trade.operationType;
                    newTrade.coin1 = trade.coin1;
                    newTrade.coin2 = trade.coin2;
                    newTrade.amount = trade.amount;
                    newTrade.price = trade.price;
                    newTrade.executed = trade.executed;
                    newTrade.date = trade.date;
                    coin.coinTrades.Add(newTrade);
                    debugControls.print($"Added a trade on the history of {coin.shortName} with date {trade.date}");
                    debugControls.print($"Total amount of {coin.shortName} = {coin.qntyOwned}");
                }
            }
        }
    }
}