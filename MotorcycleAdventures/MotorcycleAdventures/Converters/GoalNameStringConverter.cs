using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MotorcycleAdventures.Core.Models;
using Xamarin.Forms;

namespace MotorcycleAdventures.Converters
{
    public class GoalNameStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string goalDisplayName = "";

            if (value is Goal goal)
            {
                goalDisplayName = goal.Name + " " + goal.AchieveByDate.ToString("MMM dd, yyyy");
            }

            return goalDisplayName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }

    }
}
