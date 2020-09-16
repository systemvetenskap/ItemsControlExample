using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ExempelMVVM
{
    class PegPositionToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pegPosition = (PegPosition)value;
            switch (pegPosition)
            {
                case PegPosition.CorrectColorWrongPosition:
                    return new SolidColorBrush(Colors.Yellow);
                case PegPosition.CorrectColorAndPosition:
                    return new SolidColorBrush(Colors.Black);
                case PegPosition.TotalyWrong:
                    return new SolidColorBrush(Colors.White);
                default:
                    break;
            }
            return new SolidColorBrush(Colors.White); // Grundfärg

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
