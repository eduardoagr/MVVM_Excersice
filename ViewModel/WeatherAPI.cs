using MVVM_Example.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVVM_Example.ViewModel {
    public class WeatherAPI {

        const string API_KEY = "8iJsDPBYitjlAyu3IPiVpNbCNBOKI8mO";
        const string URL = "http://dataservice.accuweather.com/locations/v1/cities/geoposition/search?apikey={0}&q={1}%2C{2}";
        const string FORECAST_URL = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&metric=true";

        public static async Task<City> GetCityDstaAsync(double lat, double lon) {

            var apiData = string.Format(URL, API_KEY, lat, lon);

            using (HttpClient client = new HttpClient()) {

                var request = await client.GetAsync(apiData);
                var response = await request.Content.ReadAsStringAsync();

                City result = JsonConvert.DeserializeObject<City>(response);

                return new City();
            }
        }

        public static async Task<AccuWeather> GetWeatherAsync(string LocationKey) {

            var apiData = string.Format(FORECAST_URL, LocationKey, API_KEY);

            using (HttpClient client = new HttpClient()) {

                var request = await client.GetAsync(apiData);
                var responce = await request.Content.ReadAsStringAsync();

                AccuWeather result = JsonConvert.DeserializeObject<AccuWeather>(responce);

                return result;
            }
        }
    }
}
