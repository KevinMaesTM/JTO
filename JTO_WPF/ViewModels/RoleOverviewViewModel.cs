using DAL.Data.UnitOfWork;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_MODELS;

namespace JTO_WPF.ViewModels
{
    internal class RoleOverviewViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public Role SelectedRole { get; set; }

        public RoleOverviewViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Roles = unit.RoleRepo.Retrieve(r => r.IsActive == null || r.IsActive == true);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add":
                    return true;

                case "ShowDetail":
                    if (SelectedRole == null)
                        return false;
                    else
                        return true;

                case "Delete":
                    if (SelectedRole == null)
                        return false;
                    else
                        return true;

                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add":
                    break;
            }
        }
    }
}