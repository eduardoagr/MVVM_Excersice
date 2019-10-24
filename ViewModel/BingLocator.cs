using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace MVVM_Example.ViewModel {
    public class BingLocator {

        const string KEY = "UNtijPSBDvr0h0U68vUX~khL3P_FpMNw2Ik_CpvHUUQ~Aszrntk4oWtZE6ZxGzDK34kutoDZy_-rBh4x2hAd2oKnL7rTF6bckQ06wjDIO9hu";

        public static async Task<string> GetCityData() {

            var citydata = await LocationManager.GetGeopositionAsync();

            BasicGeoposition geoposition = new BasicGeoposition() {
                Latitude = citydata.Coordinate.Point.Position.Latitude, Longitude = citydata.Coordinate.Point.Position.Longitude
            };
            Geopoint geopoint = new Geopoint(geoposition);

            MapService.ServiceToken = KEY;

            MapLocationFinderResult finderResult = await MapLocationFinder.FindLocationsAtAsync(geopoint);

            if (finderResult.Status != MapLocationFinderStatus.Success) {
                return null;
            }

            return finderResult.Locations[0].Address.Town;
        }
    }
}
