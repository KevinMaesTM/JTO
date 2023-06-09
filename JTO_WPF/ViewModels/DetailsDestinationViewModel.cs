using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_MODELS;
using JTO_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_WPF.ViewModels
{
    internal class DetailsDestinationViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public string City { get; set; }
        public string Country { get; set; }
        public Destination Destination { get; set; }
        public DashboardViewModel DVM { get; set; }
        public string HouseNumber { get; set; }
        public string Name { get; set; }
        public string OutputResult { get; set; }
        public string Streetname { get; set; }
        public string Zipcode { get; set; }

        public DetailsDestinationViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            this.Destination = new Destination();
        }

        public DetailsDestinationViewModel(DashboardViewModel dvm, Destination destination)
        {
            DVM = dvm;
            this.Destination = destination;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            string errors = "";
            switch (parameter.ToString())
            {
                case "SaveDestination":
                    errors = ValidateInput();
                    if (string.IsNullOrEmpty(errors))
                    {
                        if (Destination.DestinationID == 0)
                        {
                            unit.DestinationRepo.Create(Destination);
                            unit.Save();
                        }
                        else
                        {
                            unit.DestinationRepo.Update(Destination);
                            unit.Save();
                        }
                        var dVM = new DestinationViewModel(DVM);
                        var dV = new DestinationView();
                        dV.DataContext = dVM;
                        DVM.Content = dV;
                    }
                    else
                        OutputResult = errors;
                    break;

                case "Cancel":
                    var dVM2 = new DestinationViewModel(DVM);
                    var dV2 = new DestinationView();
                    dV2.DataContext = dVM2;
                    DVM.Content = dV2;
                    break;
            }
        }

        public string ValidateInput()
        {
            string result = "";
            if (string.IsNullOrEmpty(Destination.Name))
                result += "Naam van de bestemming is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.Street))
                result += "Straatnaam is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.Number))
                result += "Huisnummer is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.Zip))
                result += "Postcode is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.City))
                result += "Stad is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.Country))
                result += "Land is een verplicht veld!" + Environment.NewLine;

            return result;
        }
    }
}