using System;
using System.Collections.Generic;

namespace MVVM_Example.Model {

    public class Minimum {
        private double _Value;

        public double Value {
            get { return Convert.ToInt32(_Value + "°C"); }
            set { _Value = value; }
        }
    }

    public class Maximum {
        private double _Value;

        public double Value {
            get { return Convert.ToInt32(_Value + "°C"); }
            set { _Value = value; }
        }
    }

    public class Temperature {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    
    }

    public class Day {
        public int Icon { get; set; }

        public string IconUrl {
            get {
                if (Icon < 10) { return "https://developer.accuweather.com/sites/default/files/0" + Icon + "-s.png"; }
                return "https://developer.accuweather.com/sites/default/files/" + Icon + "-s.png";
            }
        }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
    }

    public class DailyForecast {
        public DateTime Date { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public IList<string> Sources { get; set; }
    }

    public class AccuWeather {
        public IList<DailyForecast> DailyForecasts { get; set; }
    }
}
