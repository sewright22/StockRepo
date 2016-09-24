using DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrendPredictor
{
    public class BasicThresholdBuySellCriteria : IBuySellCriteria
    {
        private bool bought;
        private int _lowerThreshold;
        private StochasticOscillator _stochasticOscillator;
        private TradeTransaction _tradeTransaction;
        private StockDbAccess _repo;
        private int _runId;

        public BasicThresholdBuySellCriteria(int runID, int low, StochasticOscillator osc)
        {
            _repo = new StockDbAccess();
            _lowerThreshold = low;
            _stochasticOscillator = osc;
            _runId = runID;
        }

        public void Buy()
        {
            if (_stochasticOscillator.KPercent > 0 &&
                _stochasticOscillator.DPercent > 0)
            {
                if (!bought)
                {
                    if (_stochasticOscillator.KPercent < _lowerThreshold &&
                       _stochasticOscillator.DPercent < _lowerThreshold &&
                       _stochasticOscillator.KPercent >= _stochasticOscillator.DPercent)
                    {
                        bought = true;
                        _tradeTransaction = new TradeTransaction()
                        {
                            BuyStockPrice = _stochasticOscillator.LatestPrice,
                            HighSinceBuy = _stochasticOscillator.LatestPrice,
                            LowSinceBuy = _stochasticOscillator.LatestPrice
                        };
                    }
                }
            }
        }

        public void Sell()
        {
            if (bought)
            {
                var price = _stochasticOscillator.LatestPrice;

                if (((price.Close - _tradeTransaction.BuyStockPrice.Close) / _tradeTransaction.BuyStockPrice.Close) > Convert.ToDecimal(0.1))
                {
                    bought = false;
                    _tradeTransaction.SellStockPrice = price;
                    _repo.AddCompletedTransaction(new StockDbWriter.CompletedTransaction()
                    {
                        RunID = _runId,
                        BuyStockPriceID = _tradeTransaction.BuyStockPrice.ID,
                        SellStockPriceID = _tradeTransaction.SellStockPrice.ID,
                        LowStockPriceSinceBuyID = _tradeTransaction.LowSinceBuy.ID,
                        HighStockPriceSinceBuyID = _tradeTransaction.HighSinceBuy.ID
                    });
                    _tradeTransaction = new TradeTransaction();
                }
                else
                {
                    if (_stochasticOscillator.LatestPrice.Close < _tradeTransaction.LowSinceBuy.Close)
                    {
                        _tradeTransaction.LowSinceBuy = price;
                    }
                    else if (price.Close > _tradeTransaction.HighSinceBuy.Close)
                    {
                        _tradeTransaction.HighSinceBuy = price;
                    }
                }
            }
        }

        public void LogOpenTransaction()
        {
            if (_tradeTransaction != null && _tradeTransaction.BuyStockPrice != null)
            {
                _repo.AddCompletedTransaction(new StockDbWriter.CompletedTransaction()
                {
                    RunID = _runId,
                    BuyStockPriceID = _tradeTransaction.BuyStockPrice.ID,
                    SellStockPriceID = _tradeTransaction.HighSinceBuy.ID,
                    LowStockPriceSinceBuyID = _tradeTransaction.LowSinceBuy.ID,
                    HighStockPriceSinceBuyID = _tradeTransaction.HighSinceBuy.ID
                });
            }
        }
    }
}
