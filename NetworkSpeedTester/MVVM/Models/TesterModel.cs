using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NetworkSpeedTester.MVVM.Models
{
    public class TesterModel : INotifyPropertyChanged
    {
        //general
        private NetworkInterface[] _networkInterfaces;
        private string _publicIP;
        private long _totalBytesReceived = 0;
        private long _totalBytesSent = 0;
        //current
        private long _currentSpeedDownload = 0;
        private long _currentSpeedUpload = 0;
        private long _currentPing = 0;
        //max
        private long _maxSpeedDownload = 0;
        private long _maxSpeedUpload = 0;
        private long _maxPing = 0;

        private NetworkInterface SelectedNetworkInterface = null;
        public string PublicIP
        {
            get => _publicIP;
            set
            {
                _publicIP = value;
                OnPropertyChanged();
            }
        }

        //for interface
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        /********************
        |  Implementation  |
        ********************/
        public async Task getPublicIP()
        {
            var publicIP = "0.0.0.0";
            try
            {
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(10);
                publicIP = await client.GetStringAsync("https://ipecho.net/plain");
            }
            catch 
            {
                //
            }
            PublicIP = publicIP;
        }
    }
}
