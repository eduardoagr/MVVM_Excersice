using MVVM_Example.Interfaces;
using System.Collections.Generic;

namespace MVVM_Example.Model {

    public class Main : Notify {
        private double _temp;
        public double temp {
            get { return _temp; }
            set {
                if (value != _temp) {
                    _temp = value;
                    onPropertyChanged("temp");
                }
            }
        }

        private double _temp_min;
        public double temp_min {
            get { return _temp_min; }
            set {
                if (value != _temp_min) {
                    _temp_min = value;
                    onPropertyChanged("temp_min");
                }
            }
        }

        private double _temp_max;
        public double temp_max {
            get { return _temp_max; }
            set {
                if (value != _temp_max) {
                    _temp_max = value;
                    onPropertyChanged("temp_max");
                }
            }
        }

    }

    public class Weather : Notify {
        private string _main;
        public string main {
            get { return _main; }
            set {
                if (value != _main) {
                    _main = value;
                    onPropertyChanged("main");
                }
            }
        }

        private string _description;
        public string description {
            get { return _description; }
            set {
                if (value != _description) {
                    _description = value;
                    onPropertyChanged("description");
                }
            }
        }

        private string _icon;
        public string icon {
            get { return _icon; }
            set {
                if (value != _icon) {
                    _icon = value;
                    onPropertyChanged("icon");
                }
            }
        }

    }


    public class Day : Notify {
        private Main _main;
        public Main main {
            get { return _main; }
            set {
                if (value != _main) {
                    _main = value;
                    onPropertyChanged("main");
                }
            }
        }

        private List<Weather> _weather;
        public List<Weather> weather {
            get { return _weather; }
            set {
                if (value != _weather) {
                    _weather = value;
                    onPropertyChanged("weather");
                }
            }
        }

        private string _dt_txt;
        public string dt_txt {
            get { return _dt_txt; }
            set {
                if (value != _dt_txt) {
                    _dt_txt = value;
                    onPropertyChanged("dt_txt");
                }
            }
        }


    }

    public class RootObject : Notify {
        private List<Day> _list;
        public List<Day> list {
            get { return _list; }
            set {
                if (value != _list) {
                    _list = value;
                    onPropertyChanged("list");
                }
            }
        }

    }
}