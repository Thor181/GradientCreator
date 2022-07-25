﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GradientCreator.Service
{

    [ValueConversion(typeof(double), typeof(Point))]
    public class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(double))
                throw new ArgumentException("Тип должен быть double");
            double val = Math.Round((double)value,2);
            if (val <= 1)
            {
                return new Point(val == 1 ? 1 : val % 1, 0);
            }
            else if (val is > 1 and <= 2)
            {
                return new Point(1, val == 2 ? 1 : val % 1);
            }
            else if (val is > 2 and <= 3)
            {
                return new Point(1 - (val == 3 ? 1 : val % 1), 1);
            }
            else if (val is > 3 and <= 4)
            {
                return new Point(0, 1 - (val == 4 ? 1 : val % 1));
            }
            return new Point(0, 0);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
