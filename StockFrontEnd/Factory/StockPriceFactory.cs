using DbAccess;
using StockDbWriter;
using StockFrontEnd.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFrontEnd.Factory
{
    public class StockPriceFactory
    {
        public static StockPrice Build(string line, int stockID)
        {
            var splitLine = line.Split(',');

            try
            {
                return new StockPrice()
                {
                    Date = Convert.ToDateTime(splitLine[0]),
                    Open = Convert.ToDecimal(splitLine[1]),
                    High = Convert.ToDecimal(splitLine[2]),
                    Low = Convert.ToDecimal(splitLine[3]),
                    Close = Convert.ToDecimal(splitLine[4]),
                    Volume = Convert.ToInt32(splitLine[5]),
                    StockID = stockID
                };
            }
            catch(Exception)
            {
                throw new InvalidPriceLineException(string.Format("INVALID LINE: {0}", line));
            }
        }
    }
}
