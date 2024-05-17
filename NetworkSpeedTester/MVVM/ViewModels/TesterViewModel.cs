using NetworkSpeedTester.Core;
using NetworkSpeedTester.MVVM.Models;

namespace NetworkSpeedTester.MVVM.ViewModels
{
    class TesterViewModel : ObservableObject
    {
        private TesterModel _tester;

        public TesterViewModel()
        {
            _tester = new TesterModel();
            _ = _tester.getGeneralInfo();
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

    }
}
