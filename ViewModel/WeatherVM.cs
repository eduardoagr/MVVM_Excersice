using MVVM_Example.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

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


        public ObservableCollection<DailyForecast> dailyForecasts { get; set; }


        public WeatherVM() {
            GetCuurentLocation();
            dailyForecasts = new ObservableCollection<DailyForecast>();
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

            currentDay = dailyForecasts[0];
            Debug.WriteLine(dailyForecasts[0].Day.Icon);

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
