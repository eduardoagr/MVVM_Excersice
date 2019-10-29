using MVVM_Example.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM_Example.ViewModel {
    public class WeatherVM: INotifyPropertyChanged {

        public AccuWeather accuWeather { get; set; }

        private string _cityData;
        public string cityData {
            get { return _cityData; }
            set {
                if (value != _cityData) {
                    _cityData = value;
                    onPropertyChanged("cityData");
                    GetWeatherData();
                }
            }
        }

        private DailyForecast _currentDay;
        public DailyForecast currentDay {
            get { return _currentDay; }
            set {
                if (value != _currentDay) {
                    _currentDay = value;
                    onPropertyChanged("currentDay");
                }
            }
        }

        private bool _ring;
        public bool ring {
            get { return _ring; }
            set {
                if (value != _ring) {
                    _ring = value;
                    onPropertyChanged("ring");
                }
            }
        }



        public ObservableCollection<DailyForecast> dailyForecasts { get; set; }


        public WeatherVM() {
            GetCuurentLocation();
            dailyForecasts = new ObservableCollection<DailyForecast>();
            ring = true;
        }

        private async void GetCuurentLocation() {
               cityData = await BingLocator.GetCityData();
        }

        public async void GetWeatherData() {
        
            var geoposition = await LocationManager.GetGeopositionAsync();
            var currentLocationKey = await WeatherAPI.GetCityDstaAsync(geoposition.Coordinate.Point.Position.Latitude, geoposition.Coordinate.Point.Position.Longitude);
            var weatherData = await WeatherAPI.GetWeatherAsync(currentLocationKey.Key);
            if (weatherData != null) {

                foreach (var item in weatherData.DailyForecasts) {
                    dailyForecasts.Add(item);
                }
            }
            ring = false;
            currentDay = dailyForecasts[0];

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
