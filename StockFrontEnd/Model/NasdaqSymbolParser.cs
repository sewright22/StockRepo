using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFrontEnd.Model
{
    public class NasdaqSymbolParser
    {
        private string[] _lines;
        private int _curIndex;

        public bool EOF { get; internal set; }

        public NasdaqSymbolParser(string text)
        {
            EOF = false;
            _curIndex = 1;
            _lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public string GetNextLine()
        {
            string retVal = "";

            if(_curIndex < _lines.Length)
            {
                retVal = _lines[_curIndex];
                _curIndex++;
            }

            if(_curIndex == _lines.Length-2)
            {
                EOF = true;
            }

            if (retVal.Contains("Creation"))
                {
                EOF = true;
            }

            return retVal;
        }
    }
}
