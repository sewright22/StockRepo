using DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrendPredictor
{
    public class BasicStochasticOscillatorPredictorAlgorithmUsingCriteria : ISimulation
    {
        private int _dVal;
        private int _kVal;
        private StockDbAccess _repo;

        public BasicStochasticOscillatorPredictorAlgorithmUsingCriteria(int kVal, int dVal)
        {
            _repo = new StockDbAccess();
            _kVal = kVal;
            _dVal = dVal;
        }

        public void Run()
        {
            int runID5 = _repo.StartRun(string.Format("Stochastic Oscillator Flip - K={0} D={1} Lower Limit 5 Sell at 10% profit", _kVal, _dVal));
            int runID10 = _repo.StartRun(string.Format("Stochastic Oscillator Flip - K={0} D={1} Lower Limit 10 Sell at 10% profit", _kVal, _dVal));
            int runID15 = _repo.StartRun(string.Format("Stochastic Oscillator Flip - K={0} D={1} Lower Limit 15 Sell at 10% profit", _kVal, _dVal));
            int runID20 = _repo.StartRun(string.Format("Stochastic Oscillator Flip - K={0} D={1} Lower Limit 20 Sell at 10% profit", _kVal, _dVal));

            var stockList = _repo.GetStocks();

            foreach(var stock in stockList)
            {
                var stochasticOscillator = new StochasticOscillator(_kVal, _dVal);
                var priceHistory = _repo.GetStockPrices(stock.ID);
                var transaction = new TradeTransaction();
                IBuySellCriteria crit5 = new BasicThresholdBuySellCriteria(runID5, 5, stochasticOscillator);
                IBuySellCriteria crit10 = new BasicThresholdBuySellCriteria(runID10, 10, stochasticOscillator);
                IBuySellCriteria crit15 = new BasicThresholdBuySellCriteria(runID15, 15, stochasticOscillator);
                IBuySellCriteria crit20 = new BasicThresholdBuySellCriteria(runID20, 20, stochasticOscillator);

                foreach (var price in priceHistory)
                {
                    stochasticOscillator.AddPricePoint(price);
                    crit5.Buy();
                    crit10.Buy();
                    crit15.Buy();
                    crit20.Buy();
                    crit5.Sell();
                    crit10.Sell();
                    crit15.Sell();
                    crit20.Sell();
                }

                crit5.LogOpenTransaction();
                crit10.LogOpenTransaction();
                crit15.LogOpenTransaction();
            }
        }
    }
}
