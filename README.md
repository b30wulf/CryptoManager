# CryptoManager (WIP)
CryptoManager is a tool to visualize and keep track of my cryptocurrency trading and activity as well as a framework for algorithmic trading, strategy backtesting and bot deployment. This code is all work in progress and non definitive, therefore early optimization is avoided.

# Trading History
CryptoManager imports and reads all trades, transactions and deposits from .csv files provided by Binance to track each trade and each coin independently. Trading profit is calculated with the FIFO directive in order to calculate the taxable profits.

# Backtesting
CryptoManager connects to Binance throught their REST API to request candle data (OHLC values) for the specified time period. Received kline data is processed and fed into a trading bot object that will follow a specific trading strategy. The resulting trades are displayed alongside with the price history of the specified time period as well as resulting profit from the trading activity which is displayed, for now, via console. 

# Algorithmic Trading
The same bot class objects used for backtesting are used for live trading. Connecting to Binance websocket, live price data is fed to the bot which waits for the buy/sell conditions to be met. Trades are stored in a text file for future analysis.  
