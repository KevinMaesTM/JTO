using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_Models;
using JTO_MODELS;
using JTO_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_WPF.ViewModels
{
    internal class TrainingViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public Training SelectedTraining { get; set; }
        public IEnumerable<Training> Trainings { get; set; }

        public TrainingViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Trainings = unit.TrainingRepo.Retrieve(x => x.Trainees).Where(t => t.IsActive == true || t.IsActive == null);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                case "Delete":
                    return (SelectedTraining != null);

                default:
                    return true;
            }
        }

        public void DeleteTraining()
        {
            SelectedTraining.IsActive = false;
            unit.TrainingRepo.Update(SelectedTraining);
            unit.Save();
            Trainings = unit.TrainingRepo.Retrieve(x => x.Trainees).Where(t => t.IsActive == true || t.IsActive == null);
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail": ShowTrainingDetails(); break;
                case "Add": ShowCreateTraining(); break;
                case "Delete": DeleteTraining(); break;
                default: break;
            }
        }

        public void ShowCreateTraining()
        {
            CreateTrainingViewModel ctVM = new CreateTrainingViewModel(DVM);
            CreateTrainingView ctV = new CreateTrainingView();
            ctV.DataContext = ctVM;
            DVM.Content = ctV;
        }

        public void ShowTrainingDetails()
        {
            DetailsTrainingViewModel dtVM = new DetailsTrainingViewModel(this.SelectedTraining, DVM);
            DetailsTrainingView dtV = new DetailsTrainingView();
            dtV.DataContext = dtVM;
            DVM.Content = dtV;
        }
    }
}