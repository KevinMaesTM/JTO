using DAL.Data.UnitOfWork;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_MODELS;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using JTO_WPF.Views;

namespace JTO_WPF.ViewModels
{
    internal class GroupTourViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        private IEnumerable<GroupTour> _groupTours;
        public DashboardViewModel DVM { get; set; }

        public IEnumerable<GroupTour> GroupTours
        {
            get
            { return _groupTours; }
            set
            {
                _groupTours = value;
                NotifyPropertyChanged();
            }
        }

        public GroupTour SelectedGroupTour { get; set; }
        public bool ShowOnlyFutureTrips { get; set; }

        public GroupTourViewModel(DashboardViewModel dVM)
        {
            this.DVM = dVM;
            GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme, x => x.Responsible, x => x.Destination, x => x.Participants);
        }

        public void AddGroupTour()
        {
            GroupTourDetailViewModel gtdVm2 = new GroupTourDetailViewModel(DVM);
            GroupTourDetailView gtdv2 = new GroupTourDetailView();
            gtdv2.DataContext = gtdVm2;
            DVM.Content = gtdv2;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    return (SelectedGroupTour != null);

                case "Delete":
                    return (SelectedGroupTour != null);

                case "AddGroupTour":
                    return (SelectedGroupTour == null);

                default:
                    return true;
            }
        }

        public void DeleteGroupTour()
        {
            unit.GroupTourRepo.Delete(SelectedGroupTour);
            unit.Save();
            GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme, x => x.Participants);
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Filter": FilterGroupTours(); break;
                case "ShowDetail": ShowGroupTourDetails(); break;
                case "Delete": DeleteGroupTour(); break;
                case "AddGroupTour": AddGroupTour(); break;
                default: break;
            }
        }

        public void FilterGroupTours()
        {
            if (ShowOnlyFutureTrips)
                GroupTours = unit.GroupTourRepo.Retrieve(x => x.Startdate > DateTime.Now, x => x.AgeCategory, x => x.Theme, x => x.Participants);
            else
                GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme, x => x.Participants);
        }

        public void ShowGroupTourDetails()
        {
            GroupTourDetailViewModel gtdVm = new GroupTourDetailViewModel(SelectedGroupTour, DVM);
            GroupTourDetailView gtdv = new GroupTourDetailView();
            gtdv.DataContext = gtdVm;
            DVM.Content = gtdv;
        }
    }
}