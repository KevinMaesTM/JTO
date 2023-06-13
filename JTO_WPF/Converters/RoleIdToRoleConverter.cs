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
    internal class RoleIDToRoleConverter : IValueConverter
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int rID)
                return unit.RoleRepo.Retrieve(x => x.RoleID == rID).FirstOrDefault();

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
