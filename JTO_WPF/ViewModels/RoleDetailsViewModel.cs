using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_MODELS;
using JTO_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTO_WPF.ViewModels
{
    internal class RoleDetailsViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());

        public string AssignedObject { get; set; }
        public List<string> AvailableObjects { get; set; } = new List<string>();
        public DashboardViewModel DVM { get; set; }
        public Role Role { get; set; }
        public string SelectedAssignedObject { get; set; }

        public RoleDetailsViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Role = new Role();
            AvailableObjects.Add("Groepsreizen");
            AvailableObjects.Add("Training");
        }

        public RoleDetailsViewModel(DashboardViewModel dvm, Role role)
        {
            DVM = dvm;
            Role = role;
            AvailableObjects.Add("Groepsreizen");
            AvailableObjects.Add("Training");
            if (Role.AssignedObject == "GroupTour")
                SelectedAssignedObject = "Groepsreizen";
            else
                SelectedAssignedObject = "Training";
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            string errors = "";
            switch (parameter.ToString())
            {
                case "Save":
                    errors = ValidateInput();
                    if (string.IsNullOrEmpty(errors))
                    {
                        if (SelectedAssignedObject == "Groepsreizen")
                            Role.AssignedObject = "GroupTour";
                        else
                            Role.AssignedObject = "Training";

                        if (Role.RoleID == 0)
                        {
                            unit.RoleRepo.Create(Role);
                            unit.Save();

                            DVM.SnackbarContent = $"Niewe rol '{Role.Name}' aangemaakt.";
                        }
                        else
                        {
                            unit.RoleRepo.Update(Role);
                            unit.Save();

                            DVM.SnackbarContent = $"Rol '{Role.Name}' aangepast.";
                        }

                        var roVM = new RoleOverviewViewModel(DVM);
                        var roV = new RoleOverviewView();
                        roV.DataContext = roVM;
                        DVM.Content = roV;
                        break;
                    }
                    else
                    {
                        MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }

                case "Cancel":
                    RoleOverviewViewModel roVM2 = new RoleOverviewViewModel(DVM);
                    RoleOverviewView roV2 = new RoleOverviewView();
                    roV2.DataContext = roVM2;
                    DVM.Content = roV2;
                    break;
            }
        }

        public string ValidateInput()
        {
            string result = "";
            if (string.IsNullOrEmpty(Role.Name))
                result += "Naam van de rol is een verplicht veld!" + Environment.NewLine;
            if (string.IsNullOrEmpty(SelectedAssignedObject))
                result += "Gelieve de rol toe te wijzen aan groepsreizen of trainingen." + Environment.NewLine;

            return result;
        }
    }
}