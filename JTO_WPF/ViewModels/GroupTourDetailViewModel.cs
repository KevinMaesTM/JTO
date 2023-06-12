using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_WPF.Views;
using System.Windows;

namespace JTO_WPF.ViewModels
{
    internal class GroupTourDetailViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public IEnumerable<AgeCategory> AgeCategories { get; set; }
        public IEnumerable<Destination> Destinations { get; set; }
        public DashboardViewModel DVM { get; set; }
        public GroupTour GroupTour { get; set; }
        public string Mode { get; set; }
        public IEnumerable<Person> Responsibles { get; set; }
        public AgeCategory SelectedAgeCategory { get; set; }
        public Destination SelectedDestination { get; set; }
        public Person SelectedResponsible { get; set; }
        public Theme SelectedTheme { get; set; }
        public IEnumerable<Theme> Themas { get; set; }

        public GroupTourDetailViewModel(GroupTour groupTour, DashboardViewModel dVM)
        {
            DVM = dVM;
            GroupTour = groupTour;
            SelectedTheme = GroupTour.Theme;
            SelectedAgeCategory = GroupTour.AgeCategory;
            SelectedResponsible = GroupTour.Responsible;
            SelectedDestination = GroupTour.Destination;
            Themas = unit.ThemeRepo.Retrieve();
            AgeCategories = unit.AgeCategoryRepo.Retrieve();
            Responsibles = unit.PersonRepo.Retrieve();
            Destinations = unit.DestinationRepo.Retrieve();
            Mode = "Wijzig";
        }

        public GroupTourDetailViewModel(DashboardViewModel dVM)
        {
            DVM = dVM;
            GroupTour = new GroupTour();
            Themas = unit.ThemeRepo.Retrieve();
            AgeCategories = unit.AgeCategoryRepo.Retrieve();
            Responsibles = unit.PersonRepo.Retrieve();
            Destinations = unit.DestinationRepo.Retrieve();
            Mode = "Voeg toe";
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddParticipants":
                    if (GroupTour.GroupTourID == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return true;
            }
        }

        public override void Execute(object parameter)
        {
            string errors = "";
            switch (parameter.ToString())
            {
                case "Cancel":
                    GroupTourViewModel gtvm = new GroupTourViewModel(DVM);
                    GroupTripView gtview = new GroupTripView();
                    gtview.DataContext = gtvm;
                    DVM.Content = gtview;
                    break;

                case "Update":
                    errors = ValidateInput();
                    if (string.IsNullOrEmpty(errors))
                    {
                        if (Mode == "Voeg toe")
                        {
                            GroupTour newGt = new GroupTour(GroupTour.Name, GroupTour.Startdate, GroupTour.Enddate, GroupTour.Budget, GroupTour.Price, GroupTour.MaxParticipants, SelectedTheme.ThemeID, SelectedAgeCategory.AgeCategoryID, SelectedResponsible.PersonID, SelectedDestination.DestinationID);
                            unit.GroupTourRepo.Create(newGt);
                            unit.Save();
                        }
                        if (Mode == "Wijzig")
                        {
                            unit.GroupTourRepo.Update(GroupTour);
                            unit.Save();
                        }
                        GroupTourViewModel gtvm2 = new GroupTourViewModel(DVM);
                        GroupTripView gtview2 = new GroupTripView();
                        gtview2.DataContext = gtvm2;
                        DVM.Content = gtview2;
                        break;
                    }
                    else
                    {
                        MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }

                case "AddParticipants":
                    AddParticipantsViewModel apvm = new AddParticipantsViewModel(GroupTour, DVM);
                    AddParticipantsView apv = new AddParticipantsView();
                    apv.DataContext = apvm;
                    DVM.Content = apv;
                    break;
            }
        }

        public string ValidateInput()
        {
            string result = "";
            bool startDateIsValid = false;
            bool endDateIsValid = false;

            if (string.IsNullOrEmpty(GroupTour.Name))
                result += "Naam van de reis is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(GroupTour.Startdate.ToString("dd/MM/yyyy")))
                result += "Startdatum is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!DateTime.TryParse(GroupTour.Startdate.ToString("dd/MM/yyy"), out DateTime dateStart))
                    result += "Startdatum heeft een ongeldig formaat: dd/MM/yyy." + Environment.NewLine;
                else if (dateStart <= DateTime.Now)
                    result += "Startdatum moet in de toekomst liggen." + Environment.NewLine;
            }
            // Marks StartDate as valid, will be used for further validations!
            if (!result.Contains("Startdatum"))
                startDateIsValid = true;
            if (string.IsNullOrEmpty(GroupTour.Enddate.ToString("dd/MM/yyyy")))
                result += "Einddatum is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!DateTime.TryParse(GroupTour.Enddate.ToString("dd/MM/yyy"), out DateTime dateStart))
                    result += "Einddatum heeft een ongeldig formaat: dd/MM/yyy." + Environment.NewLine;
                else if (dateStart <= DateTime.Now)
                    result += "Einddatum moet in de toekomst liggen." + Environment.NewLine;
            }
            // Marks EndDate as valid, will be used for further validations!
            if (!result.Contains("Einddatum"))
                endDateIsValid = true;
            // If both dates are valid, checks if EndDate is after StartDate
            if (startDateIsValid && endDateIsValid)
            {
                if (GroupTour.Enddate <= GroupTour.Startdate)
                    result += "Einddatum moet na de startdatum liggen." + Environment.NewLine;
            }
            // Validate Price on correct format, and if value > 0
            if (string.IsNullOrEmpty(GroupTour.Price.ToString()))
                result += "Prijs is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!decimal.TryParse(GroupTour.Price.ToString(), out decimal budget))
                    result += "Prijs is verplicht numeriek." + Environment.NewLine;
                else if (budget <= 0)
                    result += "Prijs mag niet kleiner of gelijk aan 0 zijn." + Environment.NewLine;
            }
            // Validate MaximumParticipants.
            if (string.IsNullOrEmpty(GroupTour.MaxParticipants.ToString()))
                result += "Aantal deelnemers is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (int.TryParse(GroupTour.MaxParticipants.ToString(), out int maxParticpants))
                    result += "Aantal deelnemers is verplicht numeriek." + Environment.NewLine;
                else if (maxParticpants <= 0)
                    result += "Aantal deelnemers mag niet kleiner of gelijk aan 0 zijn." + Environment.NewLine;
                // If all input is valid, check if the max amount of subscribed participants is exceeded
                else if (GroupTour.Participants.Count > maxParticpants)
                    result += $"Er mogen niet meer dan {maxParticpants} deelnemers ingeschreven zijn." + Environment.NewLine;
            }
            // Check if an object is selected in the comboboxes
            if (SelectedTheme == null)
                result += "Gelieve een thema te selecteren." + Environment.NewLine;
            if (SelectedAgeCategory == null)
                result += "Gelieve een leeftijdscategorie te selecteren." + Environment.NewLine;
            if (SelectedDestination == null)
                result += "Gelieve een reisbestemming te selecteren." + Environment.NewLine;
            if (SelectedResponsible == null)
                result += "Gelieve een hoofd monitor toe te wijzen." + Environment.NewLine;

            return result;
        }
    }
}