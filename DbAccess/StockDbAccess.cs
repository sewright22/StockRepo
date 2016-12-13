using DbAccess;
using StockDbWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess
{
    public class StockDbAccess
    {
        private StockDbDataContext _stockDb;

        public StockDbAccess()
        {
            _stockDb = new StockDbDataContext();
        }

        public IEnumerable<Stock> GetStocks()
        {
            var value = from s in _stockDb.Stocks
                        select s;

            return value;
        }

        public int StartRun(string runInfo)
        {
            _stockDb.StockSimulationRuns.InsertOnSubmit(new StockSimulationRun() { RunTime = DateTime.Now, RunInfo = runInfo });
            _stockDb.SubmitChanges();
            return GetLatestRunId();
        }

        public int GetLatestRunId()
        {
            return (from r in _stockDb.StockSimulationRuns
                          select r).OrderByDescending(t => t.ID).FirstOrDefault().ID;
        }

        public IEnumerable<StockPrice> GetStockPrices(int stockID)
        {
            var results = (from p in _stockDb.StockPrices
                          where p.StockID == stockID
                          select p).OrderBy(p => p.Date);

            return results;
        }

        public Market GetMarket(string marketName)
        {
            return (from m in _stockDb.Markets
                    where m.Name.ToUpper() == marketName.ToUpper()
                    select m).FirstOrDefault();
        }

        public Market GetMarket(int marketID)
        {
            return (from m in _stockDb.Markets
                    where m.ID == marketID
                    select m).FirstOrDefault();
        }

        public Stock GetStock(string stockName)
        {
            return (from s in _stockDb.Stocks
                    where s.Name.ToUpper() == stockName.ToUpper()
                    select s).FirstOrDefault();
        }

        public void AddMarket(string marketName)
        {
            var market = new Market() { Name = marketName };
            _stockDb.Markets.InsertOnSubmit(market);
            _stockDb.SubmitChanges();
        }

        public void AddStock(Stock stock)
        {
            _stockDb.Stocks.InsertOnSubmit(stock);
            _stockDb.SubmitChanges();
        }

        public bool StockExists(Stock stock)
        {
            bool retVal = false;
            var results = from s in _stockDb.Stocks
                          where s.Symbol == stock.Symbol
                          select s;

            if(results.ToList().Count == 0)
            {
                retVal = false;
            }
            else
            {
                retVal = true;
            }

            return retVal;
        }

        public bool StockPriceExists(StockPrice stockPrice)
        {
            bool retVal = false;
            var results = from s in _stockDb.StockPrices
                          where s.Date.Date == stockPrice.Date.Date
                          where s.StockID == stockPrice.StockID
                          select s;

            if (results.ToList().Count == 0)
            {
                retVal = false;
            }
            else
            {
                retVal = true;
            }

            return retVal;
        }

        public void AddStock(int marketID, string symbol)
        {
            AddStock(marketID, symbol, "");
        }

        public void AddStock(string marketName, string symbol)
        {
            AddStock(marketName, symbol, "");
        }

        public void AddStock(string marketName, string symbol, string stockName)
        {
            AddStock(GetMarket(marketName).ID, symbol, stockName);
        }

        public void AddStock(int marketID, string symbol, string stockName)
        {
            var stock = new Stock() { MarketID = marketID, Symbol = symbol, Name = stockName };
            _stockDb.Stocks.InsertOnSubmit(stock);
            _stockDb.SubmitChanges();
        }

        public void AddCompletedTransaction (CompletedTransaction transaction)
        {
            _stockDb.CompletedTransactions.InsertOnSubmit(transaction);
            _stockDb.SubmitChanges();
        }

        public void AddStockPrice(StockPrice stockPrice)
        {
            //_stockDb.InsertStockPrice(stockPrice);
        }

        public int AddStockPrice(string stockName, decimal open, decimal low, decimal high, decimal close, int volume, DateTime date)
        {
            return _stockDb.InsertStockPrice(stockName, open, low, high, close, volume, date);
        }

        public void AddStockPrice(int stockId, decimal open, decimal low, decimal high, decimal close, int volume, DateTime date)
        {
            //var stockPrice = new StockPrice() { StockID = stockId, OpenPrice = open, Low = low, High = high, ClosePrice = close, Volume = volume, Date = date };
            //_stockDb.InsertStockPrice();
        }

        public void BuyStock(int stockID, decimal price, DateTime date)
        {
            _stockDb.BuyStock((int)stockID, (decimal)price, date);
        }

        public void SellStock(int stockID, decimal price, DateTime date)
        {
            _stockDb.SellStock((int)stockID, (decimal)price, date);
        }
    }
}
