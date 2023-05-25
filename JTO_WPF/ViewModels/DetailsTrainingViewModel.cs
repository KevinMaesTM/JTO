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
    internal class DetailsTrainingViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public IEnumerable<Person> AvailableTrainees { get; set; }
        public IEnumerable<Trainee> ListTrainees { get; set; }
        public Training Training { get; set; }

        public DetailsTrainingViewModel(Training selectedTraining)
        {
            this.Training = selectedTraining;
            ListTrainees = unit.TraineeRepo.Retrieve(x => x.Training.TrainingID == Training.TrainingID);
            AvailableTrainees = unit.PersonRepo.Retrieve();
        }

        public DetailsTrainingViewModel()
        {
            Training = new Training();
            ListTrainees = new List<Trainee>();
            AvailableTrainees = unit.PersonRepo.Retrieve();
            Training.Name = null;
            Training.Date = null;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}