using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_MODELS;
using JTO_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public void CreateDestination()
        {
            try
            {
                unit.DestinationRepo.Create(Destination);
                unit.Save();

                DVM.SnackbarContent = $"Bestemming '{Destination.Name}' aangemaakt.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
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
                            CreateDestination();
                        else
                            UpdateDestination();

                        ShowDestinations();
                        break;
                    }
                    else
                        MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case "Cancel": ShowDestinations(); break;
                default: break;
            }
        }

        public void ShowDestinations()
        {
            var dVM = new DestinationViewModel(DVM);
            var dV = new DestinationView();
            dV.DataContext = dVM;
            DVM.Content = dV;
        }

        public void UpdateDestination()
        {
            try
            {
                unit.DestinationRepo.Update(Destination);
                unit.Save();

                DVM.SnackbarContent = $"Bestemming '{Destination.Name}' aangepast.";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
            else if (!Destination.Number.Any(char.IsDigit))
                result += "Huisnummer moet minstens één nummer (0-9) bevatten!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.Zip))
                result += "Postcode is een verplicht veld!" + Environment.NewLine;
            else if (!Destination.Zip.Any(char.IsDigit))
                result += "Postcode moet minstens één nummer (0-9) bevatten!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.City))
                result += "Stad is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(Destination.Country))
                result += "Land is een verplicht veld!" + Environment.NewLine;

            return result;
        }
    }
}