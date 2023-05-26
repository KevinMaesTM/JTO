using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_Models;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public Person SelectedAvailableTrainee { get; set; }
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
            switch (parameter.ToString())
            {
                case "AddTrainee":
                    if (SelectedAvailableTrainee == null)
                        return false;
                    else
                        return true;

                default:
                    return true;
            }
        }

        public string Errors()
        {
            string error = "";
            Training training = new Training
            {
                Name = Training.Name,
                Date = Training.Date,
                TrainingID = Training.TrainingID
            };
            if (training.Name == null)
                error += "Training naam is verplicht!" + Environment.NewLine;
            if (DateTime.TryParse(training.Date, DateTime dateTraining) == false)
                error += "Datum heeft een ongeldig formaat: dd/MM/yyy" + Environment.NewLine;
            return error;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "SaveTraining":
                    if (string.IsNullOrEmpty(Errors())
                    {
                        return;
                    }
                    else
                        break;

                default:
                    break;
            }
        }
    }
}