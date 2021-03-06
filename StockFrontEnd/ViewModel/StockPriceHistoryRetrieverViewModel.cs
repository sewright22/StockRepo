﻿using DbAccess;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StockFrontEnd.Factory;
using StockImport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockFrontEnd.ViewModel
{
    public class StockPriceHistoryRetrieverViewModel : ViewModelBase
    {
        //StockDbAccess _dbAccess;
        private string _labelText;
        private string _buttonText;
        private string _dots;
        private BackgroundWorker _bw;
        private bool _isLoading;

        public StockPriceHistoryRetrieverViewModel()
        {
            _buttonText = "Import Prices";
            //_dbAccess = new StockDbAccess();
            ImportPriceCommand = new RelayCommand(ImportPricesButtonClicked);
            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.DoWork += Loading;
            _bw.ProgressChanged += UpdateLabel;
        }

        private async void ImportPricesButtonClicked()
        {
            _isLoading = true;
            _bw.RunWorkerAsync();

            await Task.Run(() => ImportPrices());

            LabelText = "Done!";
            
            _isLoading = false;
        }

        private void ImportPrices()
        {
            var _dbAccess = new StockDbAccess();

            foreach (var stock in _dbAccess.GetStocks())
            {
                try
                {
                    var priceDownloader = new StockPriceDownloader(_dbAccess.GetMarket(stock.MarketID).Name, stock.Symbol, Properties.Resources.StockPriceBaseURL2);
                    priceDownloader.DownloadPrices();

                    while (priceDownloader.EOF == false)
                    {
                        var stockPrice = StockPriceFactory.Build(priceDownloader.GetNextLine(), stock.ID);

                        //if (_dbAccess.StockPriceExists(stockPrice) == false)
                        
                         var retVal = _dbAccess.AddStockPrice(stock.Symbol, stockPrice.OpenPrice, stockPrice.Low, stockPrice.High, stockPrice.ClosePrice, stockPrice.Volume, stockPrice.Date);

                        if (retVal >= 0)
                        {
                            var item = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    var m = e;
                }
            }
        }

        private void ImportStockSymbols()
        {
            var _dbAccess = new StockDbAccess();
            var file = new FtpFileDownloader();

            var lines = file.Download("ftp://ftp.nasdaqtrader.com/SymbolDirectory/otherlisted.txt").Split(new string[] { Environment.NewLine, '\n'.ToString() }, StringSplitOptions.None);
            lines = lines.Where(w => w != lines[0]).ToArray();
            foreach (var line in lines)
            {
                var stockPrice = StockFactory.Build(line, Model.StockLineType.Other);

                _dbAccess.AddStock(stockPrice);
            }
        }

        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {
                Set(ref _labelText, value);
            }
        }

        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                Set(ref _buttonText, value);
            }
        }

        public RelayCommand ImportPriceCommand { get; set; }

        private void UpdateLabel(object sender, ProgressChangedEventArgs e)
        {
            _dots = _dots + ".";
            LabelText = string.Format("Downloading{0}", _dots);
            if (_dots == "...")
            {
                _dots = "";
            }
        }

        private void Loading(object sender, DoWorkEventArgs e)
        {
            while (_isLoading)
            {
                _bw.ReportProgress(0);
                Thread.Sleep(1000);
            }
        }
    }
}
