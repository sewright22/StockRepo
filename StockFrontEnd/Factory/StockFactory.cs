using StockDbWriter;
using StockFrontEnd.CustomException;
using StockFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFrontEnd.Factory
{
    public class StockFactory
    {
        public static Stock Build(string line, StockLineType type)
        {
            var retVal = new Stock();

            switch (type)
            {
                case StockLineType.Nasdaq:
                    retVal = BuildFromNasdaqLine(line);
                    break;
                case StockLineType.Other:
                    retVal = BuildFromOtherLine(line);
                    break;
            }

            return retVal;
        }

        private static Stock BuildFromNasdaqLine(string line)
        {
            var splitLine = line.Split('|');

            try
            {
                return new Stock()
                {
                    MarketID = 1,
                    Symbol = splitLine[0],
                    Name = splitLine[1],
                    Category = splitLine[2],
                    TestIssue = splitLine[3],
                    RoundLotSize = Convert.ToInt32(splitLine[5]),
                    ETF = splitLine[6]
                };
            }
            catch(Exception)
            {
                throw new InvalidNasdaqStockLineException(string.Format("INVALID LINE: {0}", line));
            }
            
        }

        private static Stock BuildFromOtherLine(string line)
        {
            throw new NotImplementedException();
        }
    }
}
