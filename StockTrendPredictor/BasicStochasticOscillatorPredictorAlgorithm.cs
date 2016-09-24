using DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrendPredictor
{
    public class BasicStochasticOscillatorPredictorAlgorithm : ISimulation
    {
        private int _dVal;
        private int _kVal;
        private int _lowerThreshold;
        private StockDbAccess _repo;
        private int _upperThreshold;

        public BasicStochasticOscillatorPredictorAlgorithm(int kVal, int dVal, int lowerThreshold, int upperThreshold)
        {
            _repo = new StockDbAccess();
            _lowerThreshold = lowerThreshold;
            _upperThreshold = upperThreshold;
            _kVal = kVal;
            _dVal = dVal;
        }

        public void Run()
        {
            _repo.StartRun(string.Format("Stochastic Oscillator - K={0} D={1} Lower {2} Upper {3}", _kVal, _dVal, _lowerThreshold, _upperThreshold));

            var stockList = _repo.GetStocks();

            foreach(var stock in stockList)
            {
                var stochasticOscillator = new StochasticOscillator(_kVal, _dVal);
                var priceHistory = _repo.GetStockPrices(stock.ID);
                var bought = false;
                var transaction = new TradeTransaction();

                foreach (var price in priceHistory)
                {
                    stochasticOscillator.AddPricePoint(price);
                    if (stochasticOscillator.KPercent > 0 &&
                        stochasticOscillator.DPercent > 0)
                    {
                        if (!bought)
                        {
                            if (stochasticOscillator.KPercent < _lowerThreshold &&
                               stochasticOscillator.DPercent < _lowerThreshold &&
                               stochasticOscillator.DPercent >= stochasticOscillator.KPercent)
                            {
                                bought = true;
                                transaction = new TradeTransaction() { BuyStockPrice = price,
                                                                       HighSinceBuy = price,
                                                                       LowSinceBuy = price};
                                //_repo.BuyStock(stock.ID, price.Close, price.Date);
                            }
                        }
                        else
                        {
                            if (((price.Close - transaction.BuyStockPrice.Close) / transaction.BuyStockPrice.Close) > Convert.ToDecimal(0.1))
                            {
                                bought = false;
                                //_repo.SellStock(stock.ID, price.Close, price.Date);
                                transaction.SellStockPrice = price;
                                _repo.AddCompletedTransaction(new StockDbWriter.CompletedTransaction()
                                {
                                    BuyStockPriceID = transaction.BuyStockPrice.ID,
                                    SellStockPriceID = transaction.SellStockPrice.ID,
                                    LowStockPriceSinceBuyID = transaction.LowSinceBuy.ID,
                                    HighStockPriceSinceBuyID = transaction.HighSinceBuy.ID
                                });
                                transaction = new TradeTransaction();
                            }
                            else
                            {
                                if(price.Close < transaction.LowSinceBuy.Close)
                                {
                                    transaction.LowSinceBuy = price;
                                }
                                else if(price.Close > transaction.HighSinceBuy.Close)
                                {
                                    transaction.HighSinceBuy = price;
                                }
                            }
                        }
                    }
                }

                if(transaction.BuyStockPrice != null)
                {
                    _repo.AddCompletedTransaction(new StockDbWriter.CompletedTransaction()
                    {
                        BuyStockPriceID = transaction.BuyStockPrice.ID,
                        SellStockPriceID = transaction.HighSinceBuy.ID,
                        LowStockPriceSinceBuyID = transaction.LowSinceBuy.ID,
                        HighStockPriceSinceBuyID = transaction.HighSinceBuy.ID
                    });
                }
            }
        }
    }
}
