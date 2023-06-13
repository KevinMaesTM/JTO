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
            SelectedResponsible = GroupTour.Responsible;
            SelectedDestination = GroupTour.Destination;
            Themas = unit.ThemeRepo.Retrieve();
            AgeCategories = unit.AgeCategoryRepo.Retrieve();
            Responsibles = unit.PersonRepo.Retrieve();
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
            Responsibles = unit.PersonRepo.Retrieve();
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
            GroupTour newGt = new GroupTour(GroupTour.Name, GroupTour.Startdate, GroupTour.Enddate, GroupTour.Budget, GroupTour.Price, GroupTour.MaxParticipants, SelectedTheme.ThemeID, SelectedAgeCategory.AgeCategoryID, SelectedResponsible.PersonID, SelectedDestination.DestinationID);
            unit.GroupTourRepo.Create(newGt);
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
                    if (Mode == "Voeg toe")
                        AddGroupTour();
                    if (Mode == "Wijzig")
                        UpdateGroupTour();
                    GroupTourViewModel gtvm2 = new GroupTourViewModel(DVM);
                    GroupTripView gtview2 = new GroupTripView();
                    gtview2.DataContext = gtvm2;
                    DVM.Content = gtview2;
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
            unit.GroupTourRepo.Update(GroupTour);
            unit.Save();
            ShowGroupTours();
        }
    }
}