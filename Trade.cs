using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoManager {
    public class Trade : Transaction {
        // A trade is an exchange of one coin for another. Trades are the bulk of the transactions done.
        public DateTime date; // Date of the trade
        public string coinPair; // Coin pair used (bought / bought with)
        public string coin1; // From the coinPair (bought coin1 / sold coin1)
        public string coin2; // From the coinpair (bought with coin2 / sold for coin2)
        public string operationType; // If the operation was "BUY" or "SELL"
        public float price; // Price of coin1 payed with coin2
        public float executed; // Amount of coin1 bought / sold
        public float amount; // Amount of coin2 used / received
        public float fee; // Fee amount
        public string feeCurrency; // Fee currency 
        public float feeUSD; // Fee amount converted to USD at price of the day (approx).
        // public String tradeType; // funding or trading. Not used for now
        // Methods
        public Trade() {
            // Empty construcctor. Set all values to 0
            date = DateTime.MinValue; ;
            coinPair = "";
            coin1 = "";
            coin2 = "";
            operationType = "";
            price = 0;
            executed = 0;
            amount = 0;
            fee = 0;
            feeCurrency = "";
            feeUSD = 0;
        }
        public Trade(Trade a, Trade b) {
            // Constructor. Merges trade a and trade b into 1 single trade by averaging price and adding quantities
            date = a.date;
            coinPair = a.coinPair;
            coin1 = a.coin1;
            coin2 = a.coin2;
            operationType = a.operationType;
            executed = a.executed + b.executed;
            amount = a.amount + b.amount;
            price = amount / executed;
            fee = a.fee + b.fee;
            feeCurrency = a.feeCurrency;
            feeUSD = a.feeUSD + b.feeUSD;
        }
        public static void aggregatePartialTrades(List<Trade> unmodified_trades, List<Trade> agg_trades) {
            // Aggregates partial trades into one
            // Go throu the unmodified trades and aggregate the partial trades that happened at the same time and save on aggregated list
            for (int i = 0; i <= unmodified_trades.Count() - 1; i++) {
                // Create a list that will store the trades to be aggregated into one, and save trade i (worse case no other trade gets aggregated)
                List<Trade> tradesToAggegate_temp = new List<Trade>();
                tradesToAggegate_temp.Add(unmodified_trades[i]);
                // Better use while loop?
                int j = i + 1;
                while (j < unmodified_trades.Count() &&
                            unmodified_trades[i].date == unmodified_trades[j].date &&
                            unmodified_trades[i].coinPair == unmodified_trades[j].coinPair &&
                            unmodified_trades[i].operationType == unmodified_trades[j].operationType) {
                    // Trade j shares metadata with trade i, so put them on a list to be aggregated when one is found to not share metadata
                    tradesToAggegate_temp.Add(unmodified_trades[j]);
                    j++;
                }
                // By this point trade j does not share metadata with trade i.
                // Aggregate the temp list into one trade
                Trade aggregatedTrade = new Trade(); // Initialize trade instance that will contain the aggregated data
                foreach (var trade in tradesToAggegate_temp) {
                    // Common values 
                    aggregatedTrade.date = trade.date;
                    aggregatedTrade.coinPair = trade.coinPair;
                    aggregatedTrade.coin1 = trade.coin1;
                    aggregatedTrade.coin2 = trade.coin2;
                    aggregatedTrade.operationType = trade.operationType;
                    aggregatedTrade.feeCurrency = trade.feeCurrency;
                    aggregatedTrade.feeUSD = trade.feeUSD;
                    // Values to aggregate
                    aggregatedTrade.executed += trade.executed;
                    aggregatedTrade.amount += trade.amount;
                    aggregatedTrade.fee += trade.fee; ;
                }
                aggregatedTrade.price = aggregatedTrade.amount / aggregatedTrade.executed;
                // Save aggregated trade into the myPortfolio aggregated trades list
                agg_trades.Add(aggregatedTrade);
                // Move i to j - 1 to from the last trade that didnt match previous i
                i = j - 1;
            }
        }
        public static DateTime tradeTimeConverter(string dateString) {
            // Converts binance date data into DateTime object
            int year = Int32.Parse(dateString.Split(' ')[0].Split('/')[2]);
            int month = Int32.Parse(dateString.Split(' ')[0].Split('/')[1]);
            int day = Int32.Parse(dateString.Split(' ')[0].Split('/')[0]);
            int hour = Int32.Parse(dateString.Split(' ')[1].Split(':')[0]);
            int minute = Int32.Parse(dateString.Split(' ')[1].Split(':')[1]);
            DateTime tradeTime = new DateTime(year, month, day, hour, minute, 0);
            return tradeTime;
        }
        public static void getCoinPairNames(Trade trade) {
            // Split coinpair between the two symbols
            // Check agains list of possible coins
            foreach (string coin in binanceTokens.coinNames) {
                if (trade.coinPair.StartsWith(coin)) {
                    trade.coin1 = coin;
                    trade.coin2 = trade.coinPair.Replace(trade.coin1, "");
                }
            }
        }
        public static string getCoinName (string amountToken) {
            // Check the currency of the string
            foreach(string coin in binanceTokens.coinNames) {
                if (amountToken.EndsWith(coin)) {
                    return coin;
                }
            }
            // If nothing appeared then return an error
            return "Error, no coin found";
        }
        public static float calcProfitFromBUYSELL(CoinToken coin1, Trade trade, float price, float saleQnty) {
            // Calculates the profit from selling owned coins using FIFO directive
            float sellProfit = 0;
            float costOfBuyingCoins = 0;
            // Build the tuple and remove coins as the list is being generated.
            if (trade.operationType == "BUY") {
                List<float> newEntry = new List<float>();
                newEntry.Add(price);
                newEntry.Add(saleQnty);
                coin1.coinsBoughtAtPrice.Add(newEntry);
                return sellProfit;
            } else if (trade.operationType == "SELL") {
                // Start by the top of the list and remove coins
                float removed = 0;
                float pendingToRemove = saleQnty;
                int i = 0;
                while (removed < pendingToRemove && coin1.coinsBoughtAtPrice.Count>0) {
                    // Remove coins from first entry
                    if (coin1.coinsBoughtAtPrice[i][1] >= pendingToRemove) {
                        // Subtract qnty of coins
                        coin1.coinsBoughtAtPrice[i][1] -= pendingToRemove;
                        // Calculate profit
                        costOfBuyingCoins = pendingToRemove * coin1.coinsBoughtAtPrice[i][0];
                        pendingToRemove = 0;
                        if (coin1.coinsBoughtAtPrice[i][1] == 0)
                            coin1.coinsBoughtAtPrice.RemoveAt(i);
                    } else if (coin1.coinsBoughtAtPrice[i][1] < pendingToRemove) {
                        // remove coins and continue removing other entries
                        pendingToRemove -= coin1.coinsBoughtAtPrice[i][1];
                        removed = coin1.coinsBoughtAtPrice[i][1];
                        costOfBuyingCoins += coin1.coinsBoughtAtPrice[i][1] * coin1.coinsBoughtAtPrice[i][0];
                        coin1.coinsBoughtAtPrice.RemoveAt(i);
                    }
                }
            }
            coin1.coinsBoughtAtPrice.Clear();
            sellProfit = (price * saleQnty) - costOfBuyingCoins;
            debugControls.print("sellprofit = " + sellProfit);
            // Removes owned coins tuples form the first bought to the latests bought
            return sellProfit;
        }
    }


    public class Deposit : Transaction {
        public DateTime date;
        public string depositCurrency;
        public float quantity;
        public String IDCode;
        // Methods
        public static DateTime depositTimeConverter(string dateString) {
            // Converts binance date data into DateTime object
            int year = Int32.Parse(dateString.Split(' ')[0].Split('/')[2 ]);
            int month = Int32.Parse(dateString.Split(' ')[0].Split('/')[1]);
            int day = Int32.Parse(dateString.Split(' ')[0].Split('/')[0]);
            int hour = Int32.Parse(dateString.Split(' ')[1].Split(':')[0]);
            int minute = Int32.Parse(dateString.Split(' ')[1].Split(':')[1]);
            DateTime tradeTime = new DateTime(year, month, day, hour, minute, 0);
            return tradeTime;
        }
    }


    public class Transaction {
        // Methods
        public static void parseTransactions(ref Portfolio myPortfo, ref List<Transaction> trans_list, List<Deposit> depo_list, List<Trade> trade_list) {
            // Deposits and Trades are ordered by date into the same list. 
            // Compare elements and select by date order to merge the lists into one. 
            // At the end, update the portfolio holdings << make into new fuction
            int depoQnty = depo_list.Count();
            debugControls.print($"{depoQnty} deposits found.");
            int d = 0;
            int tradeQnty = trade_list.Count();
            debugControls.print($"{tradeQnty} trades found.");
            int t = 0;
            // Loop while there are still trades or deposits to be added
            // d will reach depoQnty -1;
            // t will reach tradeQnry -1;
            do {
                // if there are no trades left, add deposit
                if (t > tradeQnty -1) {
                    debugControls.print($"Adding a deposit: {depo_list[d].date}, {depo_list[d].quantity}, {depo_list[d].depositCurrency}");
                    trans_list.Add(depo_list[d]);
                    //if (d < depoQnty - 1)
                    d++;
                }
                // if there are no deposits left, add trade
                else if (d > depoQnty - 1) {
                    debugControls.print($"Adding a trade: {trade_list[t].date}, {trade_list[t].coinPair}, Amount: {trade_list[t].amount}");
                    trans_list.Add(trade_list[t]);
                    //if (t < tradeQnty - 1)
                        t++;
                }
                // If there are trades and deposits left, compare dates
                else {
                    if (depo_list[d].date < trade_list[t].date) {
                        debugControls.print($"Adding a deposit: {depo_list[d].date}, {depo_list[d].quantity}, {depo_list[d].depositCurrency}");
                        trans_list.Add(depo_list[d]);
                        //if (d < depoQnty - 1)
                            d++;
                    } else if (depo_list[d].date > trade_list[t].date) {
                        debugControls.print($"Adding a trade: {trade_list[t].date}, {trade_list[t].coinPair}, Amount: {trade_list[t].amount}");
                        trans_list.Add(trade_list[t]);
                        //if (t < tradeQnty - 1)
                            t++;
                    }
                }
            } while (d < depoQnty  || t < tradeQnty );
            debugControls.print($"Finished adding trades and deposits. Total {trans_list.Count} transactions");
            
        }
        /*
        public static void countCoins(ref Portfolio myPortfo) {
            // Reads the contents of trans_list and adds/removes coins being holded
            foreach (var transaction in myPortfo.all_transactions) {
                if (transaction.GetType() == typeof(Deposit)) {
                    // Element is a Deposit. Add the deposited currency to the Owned cointoken list
                    myPortfo.checkIfDepositCoinExistsInList((Deposit)transaction);
                } else if (transaction.GetType() == typeof(Trade)) {
                    // Element is a Trade
                    myPortfo.checkIfTradeCoinExistsInList((Trade)transaction);
                }
            }
        }
        */
    }

    
}
