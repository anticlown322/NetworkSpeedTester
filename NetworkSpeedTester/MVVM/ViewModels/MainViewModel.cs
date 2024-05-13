﻿using NetworkSpeedTester.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetworkSpeedTester.MVVM.ViewModels
{
    class MainViewModel : ObservableObject
    {
        //left menu commands
        public RelayCommand TesterViewCommand { get; set; }
        public RelayCommand HelpViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand AboutViewCommand { get; set; }

        //top menu commands
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }


        //other commands
        public RelayCommand DragWindowCommand { get; set; }

        //view models
        public TesterViewModel TesterVM { get; set; }
        public HelpViewModel HelpVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public AboutViewModel AboutVM { get; set; }

        //entities
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        /********************
         |  Implementation  |
         ********************/
        public MainViewModel()
        {
            //viewModels init
            TesterVM = new TesterViewModel();
            HelpVM = new HelpViewModel();
            SettingsVM = new SettingsViewModel();
            AboutVM = new AboutViewModel();

            CurrentView = TesterVM; //testerView = homepage

            //commands init
            //left menu
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

            //top menu
            MinimizeWindowCommand = new RelayCommand(MinimizeWindow);
            CloseWindowCommand = new RelayCommand(CloseWindow);
            //other
            DragWindowCommand = new RelayCommand(DragWindow);
        }

        void MinimizeWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        void CloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        void DragWindow(object parameter)
        {
            if (parameter is Border border)
            {
               
            }
        }
    }
}
