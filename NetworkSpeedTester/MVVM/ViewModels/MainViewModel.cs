using NetworkSpeedTester.Core;

namespace NetworkSpeedTester.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand TesterViewCommand { get; set; } 
        public RelayCommand HelpViewCommand { get; set; } 
        public RelayCommand SettingsViewCommand { get; set; } 
        public RelayCommand AboutViewCommand { get; set; } 

        public TesterViewModel TesterVM { get; set; }
        public HelpViewModel HelpVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public AboutViewModel AboutVM { get; set; }
        
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();  
            }
        }

        public MainViewModel() 
        {
            TesterVM = new TesterViewModel();
            HelpVM = new HelpViewModel();
            SettingsVM = new SettingsViewModel();
            AboutVM = new AboutViewModel();

            CurrentView = TesterVM;

            TesterViewCommand = new RelayCommand(obj =>
            {
                CurrentView = TesterVM;
            });

            HelpViewCommand = new RelayCommand(obj =>
            {
                CurrentView = HelpVM;
            });

            SettingsViewCommand = new RelayCommand(obj =>
            {
                CurrentView = SettingsVM;
            });

            AboutViewCommand = new RelayCommand(obj =>
            {
                CurrentView = AboutVM;
            });
        }
    }
}
