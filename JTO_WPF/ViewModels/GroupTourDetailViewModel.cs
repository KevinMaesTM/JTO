using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_WPF.Views;

namespace JTO_WPF.ViewModels
{
    internal class GroupTourDetailViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public GroupTour GroupTour { get; set; }
        public IEnumerable<Theme> Themas { get; set; }
        public Theme SelectedTheme { get; set; }
        public IEnumerable<AgeCategory> AgeCategories { get; set; }
        public AgeCategory SelectedAgeCategory { get; set; }
        public IEnumerable<Person> Responsibles { get; set; }
        public Person SelectedResponsible { get; set; }
        public IEnumerable<Destination> Destinations { get; set; }
        public Destination SelectedDestination { get; set; }
        public string Mode { get; set; }

        public GroupTourDetailViewModel(GroupTour groupTour, DashboardViewModel dVM)
        {
            DVM = dVM;
            GroupTour = groupTour;
            SelectedTheme = GroupTour.Theme;
            SelectedAgeCategory = GroupTour.AgeCategory;
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
                    if(GroupTour.GroupTourID == 0)
                    {
                        return false;
                    } else
                    {
                        return true;
                    }
                default:
                    return true;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Cancel":
                    GroupTourViewModel gtvm = new GroupTourViewModel(DVM);
                    GroupTripView gtview = new GroupTripView();
                    gtview.DataContext = gtvm;
                    DVM.Content = gtview;
                    break;
                case "Update":
                    if(Mode == "Voeg toe")
                    {
                        GroupTour newGt = new GroupTour(GroupTour.Name, GroupTour.Startdate, GroupTour.Enddate, GroupTour.Budget, GroupTour.Price, GroupTour.MaxParticipants, SelectedTheme.ThemeID, SelectedAgeCategory.AgeCategoryID, SelectedResponsible.PersonID, SelectedDestination.DestinationID);
                        unit.GroupTourRepo.Create(newGt);
                        unit.Save();
                    }
                    if(Mode == "Wijzig")
                    {
                        unit.GroupTourRepo.Update(GroupTour);
                        unit.Save();
                    }
                    GroupTourViewModel gtvm2 = new GroupTourViewModel(DVM);
                    GroupTripView gtview2 = new GroupTripView();
                    gtview2.DataContext = gtvm2;
                    DVM.Content = gtview2;
                    break;
                case "AddParticipants":
                    AddParticipantsViewModel apvm = new AddParticipantsViewModel(GroupTour, DVM);
                    AddParticipantsView apv = new AddParticipantsView();
                    apv.DataContext = apvm;
                    DVM.Content = apv;
                    break;
            }
        }
    }
}
