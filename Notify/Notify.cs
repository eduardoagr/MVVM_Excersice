using System.ComponentModel;

namespace MVVM_Example.Interfaces {

    public abstract class Notify: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}