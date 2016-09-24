using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockImport
{
    public class StockPriceDownloader
    {
        private string _market;
        private string _symbol;
        private string _url;
        private string[] _lines;
        private int _curIndex;

        public bool EOF { get; private set; }

        public StockPriceDownloader(string market, string stockSymbol, string url)
        {
            _curIndex = 1;
            _market = market;
            _symbol = stockSymbol;
            _url = url;
        }

        public void DownloadPrices()
        {
            var downloader = new HttpFileDownloader();
            var priceFile = downloader.Download(string.Format(_url, _market, _symbol));
            _lines = priceFile.Split(new string[] { Environment.NewLine, '\n'.ToString() }, StringSplitOptions.None);
        }

        public string GetNextLine()
        {
            string retVal = "";

            if (_curIndex < _lines.Length)
            {
                retVal = _lines[_curIndex];
                _curIndex++;
            }

            if (_curIndex == _lines.Length -1)
            {
                EOF = true;
            }

            return retVal;
        }
    }
}
