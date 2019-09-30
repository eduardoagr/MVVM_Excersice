﻿using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace MVVM_Example {
    public class LocationManager {

        public static async Task<Geoposition> GetGeopositionAsync() {

            var status = await Geolocator.RequestAccessAsync();

            if (status == GeolocationAccessStatus.Denied) {

                throw new Exception();
            }

            var locator = new Geolocator { DesiredAccuracy = PositionAccuracy.High };

            var position = await locator.GetGeopositionAsync();

            return position;
        }
    }
}
