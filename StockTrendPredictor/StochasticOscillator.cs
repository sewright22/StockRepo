using StockDbWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrendPredictor
{
    public class StochasticOscillator
    {
        private int _dVal;
        private int _kVal;
        private List<KPercentPoint> _lst_KVals;
        private List<StockPrice> _lst_pricePoints;
        private decimal _percentD;
        private decimal _percentKSmooth;
        private StockPrice _periodLowVal;
        private StockPrice _periodHighVal;
        private decimal _percentK;

        public StochasticOscillator(int kNum, int dNum)
        {
            _lst_pricePoints = new List<StockPrice>();
            _lst_KVals = new List<KPercentPoint>();
            _kVal = kNum;
            _dVal = dNum;
        }

        public decimal DPercent
        {
            get
            {
                return _percentD;
            }
        }

        public decimal KPercent
        {
            get
            {
                return _percentKSmooth;
            }
        }

        public void AddPricePoint(StockPrice point)
        {
            _lst_pricePoints.Insert(0, point);
            DetermineHigh();
            DetermineLow();
            CalculatePercentK();
            CalculateMovingAverageK();
            CalculateMovingAverageD();
        }

        private void DetermineLow()
        {
            _periodLowVal = null;
            if (_lst_pricePoints.Count >= 14)
            {
                for (int i = 0; i < 14; i++)
                {
                    var currentPoint = _lst_pricePoints[i];

                    if (_periodLowVal == null)
                    {
                        _periodLowVal = currentPoint;
                    }
                    else
                    {
                        if (currentPoint.Close < _periodLowVal.Close)
                        {
                            _periodLowVal = currentPoint;
                        }
                    }
                }
            }
        }

        private void DetermineHigh()
        {
            _periodHighVal = null;
            if (_lst_pricePoints.Count >= 14)
            {
                for (int i = 0; i < 14; i++)
                {
                    var currentPoint = _lst_pricePoints[i];

                    if (_periodHighVal == null)
                    {
                        _periodHighVal = currentPoint;
                    }
                    else
                    {
                        if (currentPoint.Close > _periodHighVal.Close)
                        {
                            _periodHighVal = currentPoint;
                        }
                    }
                }
            }
        }

        private void CalculateMovingAverageK()
        {
            int count = 1;
            decimal sum = 0;

            if (_lst_KVals.Count >= _kVal)
            {
                foreach (var item in _lst_KVals)
                {
                    if (count <= _kVal)
                    {
                        sum += item.Value;
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            _percentKSmooth = sum / _kVal;
        }

        private void CalculateMovingAverageD()
        {
            int count = 1;
            decimal sum = 0;

            if (_lst_KVals.Count >= _dVal)
            {
                foreach (var item in _lst_KVals)
                {
                    if (count <= _dVal)
                    {
                        sum += item.Value;
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            _percentD = sum / _dVal;
        }

        public void CalculatePercentK()
        {
            if (_lst_pricePoints.Count >= 14)
            {
                _percentK = ((_lst_pricePoints[0].Close - _periodLowVal.Close) / (_periodHighVal.Close - _periodLowVal.Close)) * 100;
                _lst_KVals.Insert(0, new KPercentPoint() { Date = DateTime.Now, Value = _percentK });
            }
            else
            {
                _percentK = -1;
            }
        }

        public void Clear()
        {
            _lst_pricePoints.Clear();
            _lst_KVals.Clear();
            _percentD = 0;
            _percentK = 0;
        }
    }
}
