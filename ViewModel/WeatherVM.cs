using MVVM_Example.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM_Example.ViewModel {
    public class WeatherVM: INotifyPropertyChanged {

        public RootObject rootObject { get; set; }

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


        private async void GetLocation() {
            cityData = await MapLocator.GetCityData();
        }

        public WeatherVM() {
            rootObject = new RootObject();
            GetLocation();
        }

        private async void GetWeatherData(){
            var splitedData = cityData.Split(",");
            var city = splitedData[0];
            var conutryCode = splitedData[1];

            var data = await WeatherAPI.GetWeatherDataAsync(city, conutryCode);
            if (data != null) {
                for (int i = 0; i < data.list.Count; i++) {
                    rootObject.list[i].dt_txt = data.list[i].dt_txt;
                    rootObject.list[i].main.temp_max = data.list[i].main.temp_max;
                    rootObject.list[i].main.temp_min = data.list[i].main.temp_min;
                    rootObject.list[i].weather[i].icon
                }
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
