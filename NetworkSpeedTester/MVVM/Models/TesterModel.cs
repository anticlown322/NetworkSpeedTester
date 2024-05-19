using IPinfo;
using IPinfo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkSpeedTester.MVVM.Models
{
    public class TesterModel : INotifyPropertyChanged
    {
        //private
        private IPinfoClient _ipInfoClient; //for collecting general info values

        private const int MByte_VALUE = 1024 * 1024;
        private const int MBit_VALUE = 1024 * 1024 / 8;

        //list with servers for more accurate test results
        //all files are 100 MB
        readonly List<string> fileLinks = new List<string> {
            /* Germany */
            "https://ash-speed.hetzner.com/100MB.bin", // ?
            "https://fsn1-speed.hetzner.com/100MB.bin", // ?
            "https://nbg1-speed.hetzner.com/100MB.bin", // Nuremberg
            "https://hil-speed.hetzner.com/100MB.bin", // ?
            "https://hel1-speed.hetzner.com/100MB.bin", // ?
            "http://speedtest.fra1.de.leaseweb.net/100mb.bin", // Frankfurt 
            /* Netherlands */
             "http://speedtest.ams1.nl.leaseweb.net/100mb.bin", // Amsterdam 
            "http://speedtest.ams2.nl.leaseweb.net/100mb.bin", // Amsterdam 
            /*France*/
            "http://www.ovh.net/files/100Mb.dat", // Paris
            /* UK */
            "http://speedtest.lon1.uk.leaseweb.net/100mb.bin", // London
            "http://speedtest.lon12.uk.leaseweb.net/100mb.bin", // London
            /* US */
            "http://speedtest.lax11.us.leaseweb.net/100mb.bin", // Los Angeles
            "http://speedtest.wdc2.us.leaseweb.net/100mb.bin", // Washington
            "http://speedtest.sfo12.us.leaseweb.net/100mb.bin", // San Francisco
            "http://speedtest.sea11.us.leaseweb.net/100mb.bin", // Seattle 
            "http://speedtest.mia11.us.leaseweb.net/100mb.bin", // Miami
            "http://speedtest.phx1.us.leaseweb.net/100mb.bin", // Phoenix
            "http://speedtest.dal13.us.leaseweb.net/100mb.bin", // Dallas
            "http://speedtest.nyc1.us.leaseweb.net/100mb.bin", // New York
            "http://speedtest.chi11.us.leaseweb.net/100mb.bin", // Chicago
            /* Canada */
            "http://speedtest.mtl2.ca.leaseweb.net/100mb.bin", // Montreal
            "http://proof.ovh.ca/files/100Mb.dat", // ?
            /* APAC */
            "https://singapore.downloadtestfile.com/100MB.bin", // Singapore
            "http://speedtest.sin1.sg.leaseweb.net/100mb.bin", // Singapore
            "http://www.speedtest.com.sg/test_random_100mb.zip", // Singapore
            "http://speedtest.syd12.au.leaseweb.net/100mb.bin", // Sydney
            "http://speedtest-syd.apac-tools.ovh/files/100Mb.dat", // Sydney
            "http://speedtest.hkg12.hk.leaseweb.net/100mb.bin", // Hong Kong
            "http://speedtest.tyo11.jp.leaseweb.net/100mb.bin", // Tokyo
            /* Belarus ^_^ */
            "http://lg.hosterby.com/100MB.test", // Minsk
            /* Unknown */
            "http://speedtest.tele2.net/100MB.zip", //?
            "https://speedtest.rastrnet.ru/100MB.zip", //?
            "https://downloadtestfile.com/germany/100MB.bin", // ?
            "http://ipv4.download.thinkbroadband.com/100MB.zip", // ?
            "http://212.183.159.230/100MB.zip", //?
            "https://proof.ovh.net/files/100Mb.dat" //?
        };

        //general info values
        private string _publicIP;
        private string _ipCityName;
        private string _ipCountryName;
        private string _ipLocation;
        private string _ipCompanyName;

        #region Propeties for general info values
        public string PublicIP
        {
            get => _publicIP;
            set
            {
                _publicIP = value;
                OnPropertyChanged();
            }
        }
        public string IpCityName
        {
            get => _ipCityName;
            set
            {
                _ipCityName = value;
                OnPropertyChanged();
            }
        }
        public string IpCountryName
        {
            get => _ipCountryName;
            set
            {
                _ipCountryName = value;
                OnPropertyChanged();
            }
        }
        public string IpLocation
        {
            get => _ipLocation;
            set
            {
                _ipLocation = value;
                OnPropertyChanged();
            }
        }
        public string IpCompanyName
        {
            get => _ipCompanyName;
            set
            {
                _ipCompanyName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //current test values
        private double _currentSpeedDownload;
        private double _currentSpeedUpload;
        private long _currentPing;
        private double _currentPercentage;

        #region Propeties for current test values
        public double CurrentSpeedDownload
        {
            get => _currentSpeedDownload;
            set
            {
                _currentSpeedDownload = value;
                OnPropertyChanged();
            }
        }
        public double CurrentSpeedUpload
        {
            get => _currentSpeedUpload;
            set
            {
                _currentSpeedUpload = value;
                OnPropertyChanged();
            }
        }
        public long CurrentPing
        {
            get => _currentPing;
            set
            {
                _currentPing = value;
                OnPropertyChanged();
            }
        }
        public double CurrentPercentage
        {
            get => _currentPercentage;
            set
            {
                _currentPercentage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //average test result values
        private double _averSpeedDownload;
        private double _averSpeedUpload;
        private double _averPing;

        #region Propeties for average test result values
        public double AverSpeedDownload
        {
            get => _averSpeedDownload;
            set
            {
                _averSpeedDownload = value;
                OnPropertyChanged();
            }
        }
        public double AverSpeedUpload
        {
            get => _averSpeedUpload;
            set
            {
                _averSpeedUpload = value;
                OnPropertyChanged();
            }
        }
        public double AverPing
        {
            get => _averPing;
            set
            {
                _averPing = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //max test result values
        private double _maxSpeedDownload;
        private double _maxSpeedUpload;
        private long _maxPing;

        #region Propeties for max test result values
        public double MaxSpeedDownload
        {
            get => _maxSpeedDownload;
            set
            {
                _maxSpeedDownload = value;
                OnPropertyChanged();
            }
        }
        public double MaxSpeedUpload
        {
            get => _maxSpeedUpload;
            set
            {
                _maxSpeedUpload = value;
                OnPropertyChanged();
            }
        }
        public long MaxPing
        {
            get => _maxPing;
            set
            {
                _maxPing = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //for interface INotifyPropertyChanged
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
            string token = "e0025c4b88f57f"; //you may use it:) it allows 50.000 requests per month
            _ipInfoClient = new IPinfoClient.Builder().AccessToken(token).Build();

            initializeTesterValues();
        }

        private void initializeTesterValues()
        {
            initializeGeneralInfoValues();
            initializeTestsValues();
        }

        /* General Info */
        private void initializeGeneralInfoValues()
        {
            PublicIP = "Unknown";
            IpCityName = "Not found";
            IpCompanyName = "Unknown";
            IpCountryName = "Not found";
            IpLocation = "Not found";
        }

        public async Task getGeneralInfo()
        {
            //0. init info values
            initializeGeneralInfoValues();

            //1.get public ip
            var publicIP = "0.0.0.0";
            try
            {
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(10);
                publicIP = await client.GetStringAsync("https://ipecho.net/plain");
            }
            catch
            { }

            //2.get info using IPinfo API
            IPResponse ipResponse = await _ipInfoClient.IPApi.GetDetailsAsync(publicIP);
            PublicIP = ipResponse.IP;
            IpCityName = ipResponse.City;
            IpCompanyName = ipResponse.Org;
            IpCountryName = ipResponse.CountryName;
            IpLocation = ipResponse.Loc;
        }

        /* Tests */
        public async Task startTest()
        {
            //0. init test values with zeros
            initializeTestsValues();

            //1. Ping all servers in parallel and get the best server
            Random random = new Random();
            string fileUrl = //fileLinks[random.Next(0, fileLinks.Count)];
            await GetBestServerByPingAsync();

            //2. start tests
            CurrentPercentage = 0;
            processPingTest(new Uri(fileUrl).Host);
            CurrentPercentage = 0;
            await processDownloadTest(fileUrl);
            CurrentPercentage = 0;
            await processUploadTest(fileUrl);
        }
        private void initializeTestsValues()
        {
            CurrentSpeedDownload = 0;
            CurrentSpeedUpload = 0;
            CurrentPing = 0;

            AverSpeedDownload = 0;
            AverSpeedUpload = 0;
            AverPing = 0;

            MaxSpeedDownload = 0;
            MaxSpeedUpload = 0;
            MaxPing = 0;
        }

        private void processPingTest(string serverAddress)
        {
            List<long> pingResults = new List<long>();
            const int numberOfPings = 20;

            try
            {
                for (int i = 0; i < numberOfPings; i++)
                {
                    Ping ping = new Ping();
                    PingReply reply = ping.Send(serverAddress);

                    if (reply.Status == IPStatus.Success)
                    {
                        long res = reply.RoundtripTime;

                        pingResults.Add(res);
                        CurrentPing = res;
                        if (res > MaxPing)
                            MaxPing = res;
                    }
                    else
                    {
                        //incorr ping
                        pingResults.Add(-1);
                    }

                    CurrentPercentage += 5;
                }
            }
            catch
            {
                //MessageBox.Show($"Error pinging server: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //sum all correct pings and calc average
            AverPing = pingResults.Where(x => x > -1).Sum(x => x) / numberOfPings;
        }

        private async Task processDownloadTest(string fileUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                const int FILE_SIZE = 100 * MByte_VALUE;
                string tempFilePath = Path.Combine(Path.GetTempPath(), "100mb.bin");

                Stopwatch stopwatch = new Stopwatch();

                webClient.DownloadProgressChanged += (sender, e) =>
                {
                    if (e.BytesReceived == FILE_SIZE)
                    {
                        stopwatch.Stop();
                        CurrentPercentage = 100;
                    }
                    else
                    {
                        CurrentPercentage = Math.Round(((double)e.BytesReceived / FILE_SIZE) * 100, 3);
                        CurrentSpeedDownload = Math.Round(e.BytesReceived / (stopwatch.Elapsed.TotalSeconds * MBit_VALUE), 3);
                        if (CurrentSpeedDownload > MaxSpeedDownload)
                            MaxSpeedDownload = CurrentSpeedDownload;
                    }
                };

                stopwatch.Start();
                await webClient.DownloadFileTaskAsync(new Uri(fileUrl), tempFilePath);
                AverSpeedDownload = Math.Round(FILE_SIZE / (stopwatch.Elapsed.TotalSeconds * MBit_VALUE), 3);

                try
                {
                    File.Delete(tempFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting temporary file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task processUploadTest(string fileUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), "100mb.bin");

                //create random 100 MB file
                const int FILE_SIZE = 100 * MByte_VALUE;
                byte[] data = new byte[FILE_SIZE];
                Random rng = new Random();
                rng.NextBytes(data);
                File.WriteAllBytes(tempFilePath, data);

                //start test
                Stopwatch stopwatch = new Stopwatch();

                webClient.UploadProgressChanged += (sender, e) =>
                {
                    //TO-DO: Check why if(e.BytesSent == FILE_SIZE) doesn't work

                    CurrentPercentage = Math.Round(((double)e.BytesSent / FILE_SIZE) * 100, 3);
                    if (CurrentPercentage == 100)
                    {
                        stopwatch.Stop();
                    }
                    else
                    {

                        CurrentSpeedUpload = Math.Round(e.BytesSent / (stopwatch.Elapsed.TotalSeconds * MBit_VALUE), 3);
                        if (CurrentSpeedUpload > MaxSpeedUpload)
                            MaxSpeedUpload = CurrentSpeedUpload;
                    }
                };

                stopwatch.Start();
                await webClient.UploadFileTaskAsync(new Uri(fileUrl), tempFilePath);
                AverSpeedUpload = Math.Round(FILE_SIZE / (stopwatch.Elapsed.TotalSeconds * MBit_VALUE), 3);

                try
                {
                    File.Delete(tempFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting temporary file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /* Utility funcs */
        private async Task<string> GetBestServerByPingAsync()
        {
            // Ping all servers in parallel
            var pingTasks = fileLinks.Select(async link =>
            {
                long pingTime = await MeasurePingTimeAsync(new Uri(link).Host);
                return new { FileLink = link, PingTime = pingTime };
            });
            var pingResults = await Task.WhenAll(pingTasks);

            // Select the server with the lowest ping time
            var bestFileLink = pingResults.OrderBy(result => result.PingTime).FirstOrDefault();

            return bestFileLink?.FileLink ?? fileLinks[0];
        }

        private async Task<long> MeasurePingTimeAsync(string serverHostname)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(serverHostname);

                if (reply.Status == IPStatus.Success)
                {
                    return reply.RoundtripTime;
                }
            }
            catch
            {
                //MessageBox.Show($"Error pinging server: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Return a high value if the ping fails
            return long.MaxValue;
        }
    }
}
