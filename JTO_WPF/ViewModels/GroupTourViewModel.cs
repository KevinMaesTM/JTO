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
            GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme);
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
                        GroupTours = unit.GroupTourRepo.Retrieve(x => x.Startdate > DateTime.Now, x => x.AgeCategory, x => x.Theme);
                    } else
                    {
                        GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme);
                    }
                    break;
            }
        }
    }
}