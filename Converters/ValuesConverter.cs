﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MVVM_Example.Converters {
    public class ValuesConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {

            if (value != null) {

                var valueToString = value.ToString();
                return valueToString +""+"°C";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
