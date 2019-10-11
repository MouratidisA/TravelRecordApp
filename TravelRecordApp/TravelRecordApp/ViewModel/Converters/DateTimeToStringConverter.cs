using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel.Converters
{
    class DateTimeToStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeAgo = string.Empty;

            DateTimeOffset datetime = (DateTimeOffset) value;
            DateTimeOffset rigthNow = DateTimeOffset.Now;

            var difference = rigthNow - datetime;

            if (difference.TotalDays > 1)
            {
                return $"{datetime:d}";
            }
            else
            {
                if (difference.TotalSeconds < 60)
                {
                    return $"{difference.TotalSeconds:0} seconds ago";
                }

                if (difference.TotalMinutes < 60)
                {
                    return $"{difference.TotalSeconds:0} minutes ago";
                }

                if (difference.TotalHours < 24)
                {
                    return $"{difference.TotalSeconds:0} hours ago";
                }

                return "yesterday";
            }

            return timeAgo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
