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
        public decimal? BudgetTour { get; set; }
        public IEnumerable<Destination> Destinations { get; set; }
        public DashboardViewModel DVM { get; set; }
        public DateTime? EndDateTour { get; set; }
        public GroupTour GroupTour { get; set; }
        public int? MaxParticipantsTour { get; set; }
        public string Mode { get; set; }
        public decimal? PriceTour { get; set; }
        public IEnumerable<Person> Responsibles { get; set; }
        public AgeCategory SelectedAgeCategory { get; set; }
        public Destination SelectedDestination { get; set; }
        public Person SelectedResponsible { get; set; }
        public Theme SelectedTheme { get; set; }
        public DateTime? StartDateTour { get; set; }
        public IEnumerable<Theme> Themas { get; set; }

        public GroupTourDetailViewModel(GroupTour groupTour, DashboardViewModel dVM)
        {
            DVM = dVM;
            GroupTour = groupTour;
            SelectedTheme = GroupTour.Theme;
            SelectedAgeCategory = GroupTour.AgeCategory;
            SelectedResponsible = unit.PersonRepo.Retrieve(sr => sr.PersonID == GroupTour.Responsible.PersonID).FirstOrDefault();
            SelectedDestination = GroupTour.Destination;
            Themas = unit.ThemeRepo.Retrieve();
            AgeCategories = unit.AgeCategoryRepo.Retrieve();
            Responsibles = unit.PersonRepo.Retrieve(r => r.GroupTourResponsible == true);
            Destinations = unit.DestinationRepo.Retrieve();
            Mode = "Wijzig";
            StartDateTour = GroupTour.Startdate;
            EndDateTour = GroupTour.Enddate;
            BudgetTour = GroupTour.Budget;
            PriceTour = GroupTour.Price;
            MaxParticipantsTour = GroupTour.MaxParticipants;
        }

        public GroupTourDetailViewModel(DashboardViewModel dVM)
        {
            DVM = dVM;
            GroupTour = new GroupTour();
            Themas = unit.ThemeRepo.Retrieve();
            AgeCategories = unit.AgeCategoryRepo.Retrieve();
            Responsibles = unit.PersonRepo.Retrieve(r => r.GroupTourResponsible == true);
            Destinations = unit.DestinationRepo.Retrieve();
            Mode = "Voeg toe";
            StartDateTour = null;
            EndDateTour = null;
            BudgetTour = null;
            PriceTour = null;
            MaxParticipantsTour = null;
        }

        public void AddGroupTour()
        {
            GroupTour = CastInputGroupTour();
            unit.GroupTourRepo.Create(GroupTour);
            unit.Save();

            ShowGroupTours();
        }

        public void AddParticipants()
        {
            AddParticipantsViewModel apvm = new AddParticipantsViewModel(GroupTour, DVM);
            AddParticipantsView apv = new AddParticipantsView();
            apv.DataContext = apvm;
            DVM.Content = apv;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddParticipants":
                    return (GroupTour.GroupTourID != 0);
                default:
                    return true;
            }
        }

        public override void Execute(object parameter)
        {
            string errors = "";
            switch (parameter.ToString())
            {
                case "Cancel": ShowGroupTours(); break;
                case "Update":
                    errors = ValidateInput();
                    if (string.IsNullOrEmpty(errors))
                    {
                        if (Mode == "Voeg toe")
                            AddGroupTour();
                        if (Mode == "Wijzig")
                            UpdateGroupTour();
                    }
                    else
                        MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                case "AddParticipants": AddParticipants(); break;
                default: break;
            }
        }
        public void ShowGroupTours()
        {
            GroupTourViewModel gtvm = new GroupTourViewModel(DVM);
            GroupTripView gtview = new GroupTripView();
            gtview.DataContext = gtvm;
            DVM.Content = gtview;
        }

        public void UpdateGroupTour()
        {
            GroupTour = CastInputGroupTour();

            unit.GroupTourRepo.Update(GroupTour);
            unit.Save();
            ShowGroupTours();
        }

        public GroupTour CastInputGroupTour()
        {
            GroupTour newGT = new GroupTour()
            {
                Name = GroupTour.Name,
                Startdate = (DateTime)StartDateTour,
                Enddate = (DateTime)EndDateTour,
                MaxParticipants = (int)MaxParticipantsTour,
                Price = (int)PriceTour,
                AgeCategoryID = SelectedAgeCategory.AgeCategoryID,
                ThemeID = SelectedTheme.ThemeID,
                ResponsibleID = SelectedResponsible.PersonID,
                DestinationID = SelectedDestination.DestinationID
            };
            if (GroupTour.GroupTourID != 0)
                newGT.GroupTourID = GroupTour.GroupTourID;

            return newGT;
        }

        public string ValidateInput()
        {
            string result = "";
            bool startDateIsValid = false;
            bool endDateIsValid = false;

            if (string.IsNullOrEmpty(GroupTour.Name))
                result += "Naam van de reis is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(StartDateTour.ToString()))
                result += "Startdatum is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!DateTime.TryParse(StartDateTour.ToString(), out DateTime dateStart))
                    result += "Startdatum heeft een ongeldig formaat: dd/MM/yyyy." + Environment.NewLine;
                else if (dateStart <= DateTime.Now)
                    result += "Startdatum moet in de toekomst liggen." + Environment.NewLine;
            }
            // Marks StartDate as valid, will be used for further validations!
            if (!result.Contains("Startdatum"))
                startDateIsValid = true;
            if (string.IsNullOrEmpty(EndDateTour.ToString()))
                result += "Einddatum is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!DateTime.TryParse(EndDateTour.ToString(), out DateTime dateStart))
                    result += "Einddatum heeft een ongeldig formaat: dd/MM/yyyy." + Environment.NewLine;
                else if (dateStart <= DateTime.Now)
                    result += "Einddatum moet in de toekomst liggen." + Environment.NewLine;
            }
            // Marks EndDate as valid, will be used for further validations!
            if (!result.Contains("Einddatum"))
                endDateIsValid = true;
            // If both dates are valid, checks if EndDate is after StartDate
            if (startDateIsValid && endDateIsValid)
            {
                if (EndDateTour <= StartDateTour)
                    result += "Einddatum moet na de startdatum liggen." + Environment.NewLine;
            }
            // Validate Price on correct format, and if value > 0
            if (string.IsNullOrEmpty(GroupTour.Price.ToString()))
                result += "Prijs is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!decimal.TryParse(PriceTour.ToString(), out decimal budget))
                    result += "Prijs is verplicht numeriek." + Environment.NewLine;
                else if (budget <= 0)
                    result += "Prijs mag niet kleiner of gelijk aan 0 zijn." + Environment.NewLine;
            }
            // Validate MaximumParticipants.
            if (string.IsNullOrEmpty(MaxParticipantsTour.ToString()))
                result += "Aantal deelnemers is een verplicht veld!" + Environment.NewLine;
            else
            {
                if (!int.TryParse(MaxParticipantsTour.ToString(), out int maxParticpants))
                    result += "Aantal deelnemers is verplicht numeriek." + Environment.NewLine;
                else if (maxParticpants <= 0)
                    result += "Aantal deelnemers mag niet kleiner of gelijk aan 0 zijn." + Environment.NewLine;
                // If all input is valid, check if the max amount of subscribed participants is exceeded
                else if (GroupTour.Participants != null && GroupTour.Participants.Count > maxParticpants)
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