using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace ListViewIssuesXF4
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(targetType == typeof(Color));

            if (value is string s && !String.IsNullOrEmpty(s))
            {
                if (parameter != null && Double.TryParse(parameter.ToString(), out double opacity))
                {
                    string color = String.Empty;

                    int currentOpacity = 255;
                    switch (s.Length)
                    {
                        case 6:
                            color = s;
                            break;
                        case 7:
                            color = s.Substring(1);
                            break;
                        case 8:
                            currentOpacity = Int32.Parse(s.Substring(0, 2), NumberStyles.HexNumber);
                            color = s.Substring(2);
                            break;
                        case 9:
                            currentOpacity = Int32.Parse(s.Substring(1, 2), NumberStyles.HexNumber);
                            color = s.Substring(3);
                            break;
                        default:
                            throw new ArgumentException(paramName: "value", message: "Invalid value");
                    }

                    string hex = ((int)Math.Round(currentOpacity * opacity)).ToString("X2");
                    return Color.FromHex($"#{hex}{color}");
                }

                return Color.FromHex(s);
            }

            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
