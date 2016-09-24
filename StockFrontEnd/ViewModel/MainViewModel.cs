using GalaSoft.MvvmLight;

namespace StockFrontEnd.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            StockPriceHistoryRetriever = new StockPriceHistoryRetrieverViewModel();
            SimulationRunner = new SimulationRunnerViewModel();
        }

        public StockPriceHistoryRetrieverViewModel StockPriceHistoryRetriever { get; set; }
        public SimulationRunnerViewModel SimulationRunner { get; set; }
    }
}