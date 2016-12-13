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
        private int _selectedTab;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _selectedTab = 2;
            StockPriceHistoryRetriever = new StockPriceHistoryRetrieverViewModel();
            SimulationRunner = new SimulationRunnerViewModel();
            Suggestions = new StockSuggestionViewModel();
        }

        public int SelectedTab
        {
            get
            {
                return _selectedTab;
            }
            set
            {
                Set(ref _selectedTab, value);
            }
        }

        public StockPriceHistoryRetrieverViewModel StockPriceHistoryRetriever { get; set; }
        public SimulationRunnerViewModel SimulationRunner { get; set; }
        public StockSuggestionViewModel Suggestions { get; set; }
    }
}