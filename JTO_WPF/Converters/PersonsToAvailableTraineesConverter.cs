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
using JTO_MODELS;

namespace JTO_WPF.Converters
{
    internal class PersonsToAvailableTraineesConverter
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is a collection
            if (value is IEnumerable collection)
            {
                // Get the first element from the collection
                var elements = collection.Cast<Person>();

                foreach (var element in elements)
                {
                    return unit.PersonRepo.Retrieve();
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}