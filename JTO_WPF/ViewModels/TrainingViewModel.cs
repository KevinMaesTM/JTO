using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_Models;
using JTO_MODELS;
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
            Trainings = unit.TrainingRepo.Retrieve(x => x.Trainees);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    if (SelectedTraining == null)
                        return false;
                    else
                        return true;

                case "Delete":
                    if (SelectedTraining == null)
                        return false;
                    else
                        return true;

                default:
                    return true;
            }
        }

        public override void Execute(object parameter)
        { }
    }
}