using MVVM_Example.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM_Example.ViewModel {
    public class WeatherVM: INotifyPropertyChanged {

        public AccuWeather AccuWeather { get; set; }

        private string _cityData;
        public string CityData {
            get { return _cityData; }
            set {
                if (value != _cityData) {
                    _cityData = value;
                    OnPropertyChanged("cityData");
                    GetWeatherData();
                }
            }
        }

        private DailyForecast _currentDay;
        public DailyForecast CurrentDay {
            get { return _currentDay; }
            set {
                if (value != _currentDay) {
                    _currentDay = value;
                    OnPropertyChanged("currentDay");
                }
            }
        }

        private bool _ring;
        public bool Ring {
            get { return _ring; }
            set {
                if (value != _ring) {
                    _ring = value;
                    OnPropertyChanged("ring");
                }
            }
        }



        public ObservableCollection<DailyForecast> DailyForecasts { get; set; }


        public WeatherVM() {
            GetCuurentLocation();
            DailyForecasts = new ObservableCollection<DailyForecast>();
            Ring = true;
        }

        private async void GetCuurentLocation() {
               CityData = await BingLocator.GetCityData();
        }

        public async void GetWeatherData() {
        
            var geoposition = await LocationManager.GetGeopositionAsync();
            var currentLocationKey = await WeatherAPI.GetCityDstaAsync(geoposition.Coordinate.Point.Position.Latitude, geoposition.Coordinate.Point.Position.Longitude);
            var weatherData = await WeatherAPI.GetWeatherAsync(currentLocationKey.Key);
            if (weatherData != null) {

                foreach (var item in weatherData.DailyForecasts) {
                    DailyForecasts.Add(item);
                }
            }
            Ring = false;
            CurrentDay = DailyForecasts[0];

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
