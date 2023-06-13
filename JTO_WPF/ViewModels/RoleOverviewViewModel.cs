using DAL.Data.UnitOfWork;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_MODELS;
using JTO_WPF.Views;
using System.Windows;

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

        public void AddRole()
        {
            RoleDetailsViewModel rdVM = new RoleDetailsViewModel(DVM);
            RoleDetailsView rdV = new RoleDetailsView();
            rdV.DataContext = rdVM;
            DVM.Content = rdV;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    return (SelectedRole != null);

                case "Delete":
                    return (SelectedRole != null);

                case "Add":
                default:
                    return true;
            }
        }

        public void DeleteRole()
        {
            if (!(SelectedRole.RoleID == 1 || SelectedRole.RoleID == 2 || SelectedRole.RoleID == 3 || SelectedRole.RoleID == 4))
            {
                SelectedRole.IsActive = false;
                try
                {
                    unit.RoleRepo.Update(SelectedRole);
                    unit.Save();
                    Roles = unit.RoleRepo.Retrieve(r => r.IsActive == null || r.IsActive == true);
                }
                catch
                {
                    MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
                MessageBox.Show("Deze rol kan niet verwijderd worden!", "Opgelet!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Add": AddRole(); break;
                case "ShowDetail": ShowRoleDetails(); break;
                case "Delete": DeleteRole(); break;
                default: break;
            }
        }

        public void ShowRoleDetails()
        {
            RoleDetailsViewModel rdVM = new RoleDetailsViewModel(DVM, SelectedRole);
            RoleDetailsView rdV = new RoleDetailsView();
            rdV.DataContext = rdVM;
            DVM.Content = rdV;
        }
    }
}