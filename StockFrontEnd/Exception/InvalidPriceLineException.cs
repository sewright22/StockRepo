using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFrontEnd.CustomException
{
    public class InvalidPriceLineException : Exception
    {
        public InvalidPriceLineException(string message) : base(message) { }
    }
}
