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
        public DashboardViewModel DVM { get; set; }
        private IEnumerable<GroupTour> _groupTours;
        public IEnumerable<GroupTour> GroupTours
        {
            get
            { return _groupTours; }
            set
            { _groupTours = value;
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

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    if (SelectedGroupTour == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "Delete":
                    if (SelectedGroupTour == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case "AddGroupTour":
                    if (SelectedGroupTour == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Filter":
                    if(ShowOnlyFutureTrips)
                    {
                        GroupTours = unit.GroupTourRepo.Retrieve(x => x.Startdate > DateTime.Now, x => x.AgeCategory, x => x.Theme, x => x.Participants);
                    } else
                    {
                        GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme, x => x.Participants);
                    }
                    break;
                case "ShowDetail":
                    GroupTourDetailViewModel gtdVm = new GroupTourDetailViewModel(SelectedGroupTour, DVM);
                    GroupTourDetailView gtdv = new GroupTourDetailView();
                    gtdv.DataContext = gtdVm;
                    DVM.Content = gtdv;
                    break;
                case "Delete":
                    unit.GroupTourRepo.Delete(SelectedGroupTour);
                    unit.Save();
                    GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme, x => x.Participants);
                    break;
                case "AddGroupTour":
                    GroupTourDetailViewModel gtdVm2 = new GroupTourDetailViewModel(DVM);
                    GroupTourDetailView gtdv2 = new GroupTourDetailView();
                    gtdv2.DataContext = gtdVm2;
                    DVM.Content = gtdv2;
                    break;

            }
        }
    }
}