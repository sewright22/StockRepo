using DbAccess;
using StockFrontEnd.Factory;
using StockFrontEnd.Model;
using StockFrontEnd.ViewModel;
using StockImport;
using StockTrendPredictor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            //ImportNasdaqStocks();
            //ImportPricesForStocks();

            //RunPredictor(13, 3);
            //RunPredictor(35, 7);
            //RunPredictor(13, 3);
            //RunPredictor(35, 7);
            //RunPredictor(50, 13);
            //RunPredictor(50, 14);

            //var predictor = new BasicStochasticOscillatorPredictorAlgorithm(50, 14, 20, 80);
            //predictor.Run();

            //for (int low = 5; low <= 30; low = low + 5)
            //{
            //    for (int high = 95; high >= 40; high = high - 5)
            //    {
            //        var predictor = new BasicStochasticOscillatorPredictorAlgorithm(35, 7, low, high);
            //        predictor.Run();
            //    }
            //}

            //for (int low=5;low<=30;low=low+5)
            //{
            //    for (int high = 95; high >= 40; high = high - 5)
            //    {
            //        var predictor = new BasicStochasticOscillatorPredictorAlgorithm(50, 13, low, high);
            //        predictor.Run();
            //    }
            //}
        }

        //private void RunPredictor(int k, int d)
        //{
        //    for (int low = 5; low <= 30; low = low + 5)
        //    {
        //        for (int high = 95; high >= 40; high = high - 5)
        //        {
        //            var predictor = new BasicStochasticOscillatorPredictorAlgorithm(k, d, low, high);
        //            predictor.Run();
        //        }
        //    }
        //}

        //private void ImportPricesForStocks()
        //{
        //    foreach(var stock in _dbAccess.GetStocks())
        //    {
        //        try
        //        {
        //            var priceDownloader = new StockPriceDownloader(_dbAccess.GetMarket(stock.MarketID).Name, stock.Symbol, Properties.Resources.StockPriceBaseURL);
        //            priceDownloader.DownloadPrices();

        //            while (priceDownloader.EOF == false)
        //            {
        //                var stockPrice = StockPriceFactory.Build(priceDownloader.GetNextLine(), stock.ID);

        //                if (_dbAccess.StockPriceExists(stockPrice) == false)
        //                {
        //                    _dbAccess.AddStockPrice(stockPrice);
        //                }
        //            }
        //        }
        //        catch (Exception) { }
        //    }
        //}

        //private void ImportNasdaqStocks()
        //{
        //    FtpFileDownloader downloader = new FtpFileDownloader(Properties.Resources.NasdaqStockListURL);
        //    NasdaqSymbolParser parser = new NasdaqSymbolParser(downloader.Read());

        //    while (parser.EOF == false)
        //    {
        //        var stock = StockFactory.Build(parser.GetNextLine(), StockLineType.Nasdaq);

        //        if (_dbAccess.StockExists(stock) == false)
        //        {
        //            _dbAccess.AddStock(stock);
        //        }
        //    }
        //}
    }
}
