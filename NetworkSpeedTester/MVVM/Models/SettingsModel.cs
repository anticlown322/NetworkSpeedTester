using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NetworkSpeedTester.MVVM.Models
{
    public class SettingsModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
