using MVVM_Example.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVVM_Example.ViewModel {
    public class WeatherAPI {

        const string KEY = "d3b450256f7cf6125f8f26eef24a5966";
        const string URL = "https://api.openweathermap.org/data/2.5/forecast?q={0},{1}&appid={2}&units=metric";


        public static async Task<RootObject> GetWeatherDataAsync(string city, string countryCode) {

            var result = new RootObject();

            var apiURL = string.Format(URL, city, countryCode, KEY);

            using (var client = new HttpClient()) {

                var request = await client.GetAsync(apiURL);
                var response = await request.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<RootObject>(response);

                return result;
            }
        }
    }
}
