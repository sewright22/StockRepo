using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFrontEnd.CustomException
{
    public class InvalidNasdaqStockLineException : Exception
    {
        public InvalidNasdaqStockLineException(string message) : base(message) { }
    }
}
