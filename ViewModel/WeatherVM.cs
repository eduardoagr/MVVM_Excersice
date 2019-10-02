using MVVM_Example.Model;
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
                }
            }
        }


        private async void GetData() {
            cityData = await MapLocator.GetCityData();
        }

        public WeatherVM() {
            rootObject = new RootObject();
            GetData();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
