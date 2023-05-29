using DAL.Data.UnitOfWork;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JTO_WPF.Converters
{
    internal class RoleIDToBooleanTrainerConverter : IValueConverter
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is a collection
            if (value is int roleID)
                return (roleID == 2);

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}