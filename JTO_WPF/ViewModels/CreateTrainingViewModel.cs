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

namespace JTO_WPF.ViewModels
{
    internal class CreateTrainingViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        private Snackbar _snackbar = new Snackbar();

        public DateTime Date { get; set; }
        public DashboardViewModel DVM { get; set; }
        public string Name { get; set; }
        public string OutputResult { get; set; }
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

        public override void Execute(object parameter)
        {
            string errors = "";
            switch (parameter.ToString())
            {
                case "CreateTraining":
                    errors = ValidateInput();
                    if (string.IsNullOrEmpty(errors))
                    {
                        unit.TrainingRepo.Create(Training);
                        unit.Save();
                    }
                    else
                    {
                        OutputResult = errors;
                        break;
                    }
                    TrainingViewModel tVM = new TrainingViewModel(DVM);
                    TrainingView tV = new TrainingView();
                    tV.DataContext = tVM;
                    DVM.Content = tV;
                    break;

                case "Cancel":
                    TrainingViewModel tVM2 = new TrainingViewModel(DVM);
                    TrainingView tV2 = new TrainingView();
                    tV2.DataContext = tVM2;
                    DVM.Content = tV2;
                    break;
            }
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