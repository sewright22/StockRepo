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

        public Market GetMarket(string marketName)
        {
            return (from m in _stockDb.Markets
                    where m.Name.ToUpper() == marketName.ToUpper()
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

        public void AddStockPrice(string stockName, decimal open, decimal low, decimal high, decimal close, int volume, DateTime date)
        {
            AddStockPrice(GetStock(stockName).ID, open, low, high, close, volume, date);
        }

        public void AddStockPrice(int stockId, decimal open, decimal low, decimal high, decimal close, int volume, DateTime date)
        {
            var stockPrice = new StockPrice() { StockID = stockId, Open = open, Low = low, High = high, Close = close, Volume = volume, Date = date };
            _stockDb.StockPrices.InsertOnSubmit(stockPrice);
            _stockDb.SubmitChanges();
        }

        public void BuyStock(int stockID, decimal price)
        {
            _stockDb.BuyStock((int)stockID, (decimal)price);
        }

        public void SellStock(int stockID, decimal price)
        {
            _stockDb.SellStock((int)stockID, (decimal)price);
        }
    }
}
