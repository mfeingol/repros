using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace ListViewIssuesXF4
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(targetType == typeof(bool) || targetType == typeof(bool?));

            bool eval = false;
            bool negate = parameter != null && parameter.ToString().StartsWith("!");

            if (value is bool b)
                eval = b;
            else if (value is string s)
                eval = !String.IsNullOrEmpty(s);
            else if (value is TimeSpan t)
                eval = t != TimeSpan.Zero;
            else if (value is IEnumerable e)
                eval = e.GetEnumerator().MoveNext();
            else if (value is int i)
                eval = i != 0;
            else if (value is double d)
                eval = d != 0;
            else if (value == null && targetType == typeof(bool?))
                return null;

            else if (value is Enum)
            {
                if (parameter == null)
                    return false;

                string param = parameter.ToString();
                if (negate)
                    param = param.Substring(1);

                eval = value.ToString() == param;
            }
            else
                eval = value != null;

            // Negate
            if (parameter != null && parameter.ToString() == "!")
                eval = !eval;

            return eval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
