using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_Models;
using JTO_MODELS;
using JTO_WPF.Converters;
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
        public Training NewTraining { get; set; }
        public Person SelectedAvailableTrainee { get; set; }
        public Trainee SelectedTrainee { get; set; }
        public IEnumerable<Trainee> SubscribedTrainees { get; set; }
        public Training Training { get; set; }

        // Constructor is called when a Training object is passed from TrainingView
        public DetailsTrainingViewModel(Training selectedTraining)
        {
            this.Training = selectedTraining;
            // Get list of (subscribed) Trainee objects through TrainingID, based on ID of current
            // Training object
            SubscribedTrainees = unit.TraineeRepo.Retrieve(x => x.Training.TrainingID == selectedTraining.TrainingID);
            // Retrieve list of all Person objects
            AvailableTrainees = unit.PersonRepo.Retrieve();
        }

        // Constructor is called when no Training object is passed from TrainingView (= new training
        // is created)
        public DetailsTrainingViewModel()
        {
            Training = new Training();
            AvailableTrainees = unit.PersonRepo.Retrieve();
            SubscribedTrainees = new List<Trainee>();
            Training.Name = null;
            Training.Date = null;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                // Enables/Disable AddTraineeButton based on if Person object in AvailableTrainee
                // datagrid is selected
                case "AddTrainee":
                    if (SelectedAvailableTrainee == null)
                        return false;
                    else
                        return true;

                default:
                    return true;
            }
        }

        // Validation for input fields: Checks if all criteria are fullfilled
        public string Errors()
        {
            string error = "";
            NewTraining = new Training
            {
                Name = Training.Name,
                Date = Training.Date,
                TrainingID = Training.TrainingID,
                Trainees = (System.Collections.ObjectModel.ObservableCollection<Trainee>)SubscribedTrainees
            };
            if (NewTraining.Name == null)
                error += "Training naam is verplicht!" + Environment.NewLine;
            if (DateTime.TryParse(NewTraining.Date.ToString(), out DateTime dateTraining) == false)
                error += "Datum heeft een ongeldig formaat: dd/MM/yyy" + Environment.NewLine;
            // Checks the amount of trainees marked as trainer. Throw an error if the list contains
            // more or less than 1 trainnee
            if (SubscribedTrainees.Where(x => x.RoleID == 2).Count() <= 0)
                error += "Er moet teminste 1 persoon als trainer aangeduid worden" + Environment.NewLine;
            if (SubscribedTrainees.Where(x => x.RoleID == 2).Count() > 1)
                error += "Er mag maximum 1 trainer per opleiding toegewezen worden" + Environment.NewLine;

            return error;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "SaveTraining":
                    if (string.IsNullOrEmpty(Errors()))
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