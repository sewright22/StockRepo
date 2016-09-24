using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StockTrendPredictor;

namespace StockFrontEnd.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SimulationRunnerViewModel : ViewModelBase
    {
        private string _buttonText;

        /// <summary>
        /// Initializes a new instance of the SimulationRunnerViewModel class.
        /// </summary>
        public SimulationRunnerViewModel()
        {
            _buttonText = "Run Simulation";
            RunSimulationCommand = new RelayCommand(RunSimulationButtonClicked);
        }

        private void RunSimulationButtonClicked()
        {
            var sim1 = new BasicStochasticOscillatorPredictorAlgorithmUsingCriteria(50, 14);
            var sim2 = new BasicStochasticOscillatorPredictorAlgorithmUsingCriteria(14, 4);

            sim1.Run();
            sim2.Run();
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

        public RelayCommand RunSimulationCommand { get; set; }
    }
}