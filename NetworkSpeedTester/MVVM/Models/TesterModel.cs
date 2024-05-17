using IPinfo;
using IPinfo.Models;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NetworkSpeedTester.MVVM.Models
{
    public class TesterModel : INotifyPropertyChanged
    {
        //private
        private IPinfoClient _ipInfoClient;

        //general
        private string _publicIP;
        private string _ipCityName;
        private string _ipCountryName;
        private string _ipLocation;
        private string _ipCompanyName;
        //current
        private long _currentSpeedDownload = 0;
        private long _currentSpeedUpload = 0;
        private long _currentPing = 0;
        //max
        private long _maxSpeedDownload = 0;
        private long _maxSpeedUpload = 0;
        private long _maxPing = 0;

        public string PublicIP
        {
            get => _publicIP;
            set
            {
                _publicIP = value;
                OnPropertyChanged();
            }
        }

        public string IPCityName
        {
            get => _ipCityName;
            set
            {
                _ipCityName = value;
                OnPropertyChanged();
            }
        }

        public string IPCountryName
        {
            get => _ipCountryName;
            set
            {
                _ipCountryName = value;
                OnPropertyChanged();
            }
        }

        public string IPLocation
        {
            get => _ipLocation;
            set
            {
                _ipLocation = value;
                OnPropertyChanged();
            }
        }

        public string IPCompanyASN
        {
            get => _ipCompanyName;
            set
            {
                _ipCompanyName = value;
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
        public TesterModel()
        {
            //you may use it:) it allows 50.000 requests per month
            string token = "e0025c4b88f57f";
            _ipInfoClient = new IPinfoClient.Builder().AccessToken(token).Build();
        }

        public async Task getGeneralInfo()
        {
            //1.get public ip
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

            //2.get info using IPinfo API
            IPResponse ipResponse = await _ipInfoClient.IPApi.GetDetailsAsync(publicIP);
            PublicIP = ipResponse.IP;
            IPCityName = ipResponse.City;
            IPCompanyASN = ipResponse.Org;
            IPCountryName = ipResponse.CountryName;
            IPLocation = ipResponse.Loc;
        }
    }
}
