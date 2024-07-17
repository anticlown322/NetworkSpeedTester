using NetworkSpeedTester.Core;
using System.Diagnostics;

namespace NetworkSpeedTester.MVVM.ViewModels
{
    class AboutViewModel : ObservableObject
    {
        public RelayCommand GithubPageCommand { get; set; }
        public RelayCommand GithubProfileCommand { get; set; }
        public RelayCommand LinkedinCommand { get; set; }
        public AboutViewModel()
        {
            GithubPageCommand = new RelayCommand(FollowGithubPageLink);
            GithubProfileCommand = new RelayCommand(FollowGithubProfileLink);
            LinkedinCommand = new RelayCommand(FollowLinkedinLink);
        }

        /********************
        |  Implementation  |
        ********************/

        void FollowGithubPageLink(object parameter)
        {
            Process.Start(new ProcessStartInfo("https://github.com/anticlown322/NetworkSpeedTester") { UseShellExecute = true });
        }

        void FollowGithubProfileLink(object parameter)
        {
            Process.Start(new ProcessStartInfo("https://github.com/anticlown322") { UseShellExecute = true });
        }

        void FollowLinkedinLink(object parameter)
        {
            Process.Start(new ProcessStartInfo("https://www.linkedin.com/in/andrey-karas/") { UseShellExecute = true });
        }
    }
}
