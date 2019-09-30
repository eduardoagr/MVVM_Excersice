using MVVM_Example.Interfaces;
using MVVM_Example.Model;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MVVM_Example.ViewModel {
    public class WeatherVM: INotifyPropertyChanged {

        public RootObject rootObject { get; set; }

        private string _cityData;

        public string cityData {
            get { return _cityData; }
            set {
                _cityData = value;
                GetData();
            }
        }

        private async void GetData() {
            cityData = await MapLocator.GetCityData();
        }

        public WeatherVM() {
            rootObject = new RootObject();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
