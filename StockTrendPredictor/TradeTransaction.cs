using StockDbWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrendPredictor
{
    public class TradeTransaction
    {
        public StockPrice BuyStockPrice { get; set; }
        public StockPrice SellStockPrice { get; set; }
        public StockPrice HighSinceBuy { get; set; }
        public StockPrice LowSinceBuy { get; set; }
    }
}
