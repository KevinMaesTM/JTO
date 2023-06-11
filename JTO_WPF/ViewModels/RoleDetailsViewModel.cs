using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_MODELS;
using JTO_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        }
                        else
                        {
                            unit.RoleRepo.Update(Role);
                            unit.Save();
                        }

                        var roVM = new RoleOverviewViewModel(DVM);
                        var roV = new RoleOverviewView();
                        roV.DataContext = roVM;
                        DVM.Content = roV;
                        break;
                    }
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