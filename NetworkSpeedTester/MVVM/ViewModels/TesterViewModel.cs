using NetworkSpeedTester.Core;
using NetworkSpeedTester.MVVM.Models;
using System.Windows;

namespace NetworkSpeedTester.MVVM.ViewModels
{
    class TesterViewModel : ObservableObject
    {
        private TesterModel _tester;

        public RelayCommand StartTestCommand { get; set; }

        public TesterViewModel()
        {
            _tester = new TesterModel();
            _ = _tester.getGeneralInfo();

            StartTestCommand = new RelayCommand(StartTest);
        }

        public TesterModel Tester
        {
            get { return _tester; }
            set
            {
                _tester = value;
                OnPropertyChanged();
            }
        }

        /********************
        |  Implementation  |
        ********************/
        void StartTest(object parameter)
        {
            _ = _tester.startTest();
        }
    }
}
