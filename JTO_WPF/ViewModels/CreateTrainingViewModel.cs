using DAL.Data.UnitOfWork;
using DAL.Data;
using MaterialDesignThemes.Wpf;
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
    internal class CreateTrainingViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        private Snackbar _snackbar = new Snackbar();

        public DateTime Date { get; set; }
        public DashboardViewModel DVM { get; set; }
        public string Name { get; set; }
        public Training Training { get; set; }

        public CreateTrainingViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Training = new Training();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public void CreateTraining(string errors)
        {
            errors = ValidateInput();
            if (string.IsNullOrEmpty(errors))
            {
                try
                {
                    unit.TrainingRepo.Create(Training);
                    unit.Save();

                    DVM.SnackbarContent = $"Training '{Training.Name} is aangemaakt.";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Er ging iets fout. Gelieve de pagina te herladen.", "Er is een fout opgetreden", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ShowTrainings();
        }

        public override void Execute(object parameter)
        {
            string errors = "";
            switch (parameter.ToString())
            {
                case "CreateTraining": CreateTraining(errors); break;
                case "Cancel": ShowTrainings(); break;
                default: break;
            }
        }

        public void ShowTrainings()
        {
            TrainingViewModel tVM = new TrainingViewModel(DVM);
            TrainingView tV = new TrainingView();
            tV.DataContext = tVM;
            DVM.Content = tV;
        }

        public string ValidateInput()
        {
            string error = "";
            if (Training.Name == null)
                error += "Training naam is verplicht!" + Environment.NewLine;
            if (DateTime.TryParse(Training.Date.ToString(), out DateTime dateTraining) == false)
                error += "Datum heeft een ongeldig formaat: dd/MM/yyy" + Environment.NewLine;
            return error;
        }
    }
}