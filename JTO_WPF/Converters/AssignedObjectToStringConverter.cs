using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using JTO_MODELS;

namespace JTO_WPF.Converters
{
    internal class AssignedObjectToStringConverter : IValueConverter
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string assignedObject)
            {
                if (assignedObject == "GroupTour")
                    return "Groepsreizen";
                else
                    return "Training";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}