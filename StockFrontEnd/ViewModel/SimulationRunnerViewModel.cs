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
            //for(int i=10;i<=20;i++)
            {
                //for (int j = 45; j <= 55; j++)
                {
                    var sim1 = new BasicStochasticOscillatorPredictorAlgorithmUsingCriteria(50,14,14);
                    var sim2 = new BasicStochasticOscillatorPredictorAlgorithmUsingCriteria(55, 18, 14);
                    //var sim3 = new BasicStochasticOscillatorPredictorAlgorithmUsingCriteria(55, 18, 21);
                    //var sim2 = new BasicStochasticOscillatorPredictorAlgorithmUsingFlipCriteria(50, 15);
                    sim1.Run();
                    sim2.Run();
                    //sim3.Run();
                    //sim2.Run();
                }
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

        public RelayCommand RunSimulationCommand { get; set; }
    }
}