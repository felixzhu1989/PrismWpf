using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PrismWpf.WeMail.Common.Converters
{
    public class MenuIconConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value!=null)
            {
               var result = value.ToString();
                switch (result)
                {
                    case "Contact":
                        return "AccountBoxOutline";
                    case "Schedule":
                        return "ClockOutline";
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
