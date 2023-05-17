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
        public GroupTour SelectedGroupTour { get; set; }
        public IEnumerable<GroupTour> GroupTours { get; set; }
        public GroupTourViewModel() {
            GroupTours = unit.GroupTourRepo.Retrieve(x => x.AgeCategory, x => x.Theme);
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    if(SelectedGroupTour == null)
                    {
                        return false;
                    } else
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
                
            }
        }
    }
}
