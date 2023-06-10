using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_Models;
using JTO_MODELS;
using JTO_WPF.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_WPF.ViewModels
{
    internal class DetailsTrainingViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public IEnumerable<Role> AvailableRoles { get; set; }
        public IEnumerable<Person> AvailableTrainees { get; set; }
        public Training NewTraining { get; set; }
        public Person SelectedAvailableTrainee { get; set; }
        public Role SelectedRole { get; set; }
        public Trainee SelectedSubscribedTrainee { get; set; }
        public ObservableCollection<Trainee> SubscribedTrainees { get; set; }
        public ObservableCollection<Person> SubscribedTraineesCollection { get; set; } = new ObservableCollection<Person> { };
        public Training Training { get; set; }

        // Constructor is called when a Training object is passed from TrainingView
        public DetailsTrainingViewModel(Training selectedTraining)
        {
            this.Training = selectedTraining;
            // Get list of (subscribed) Trainee objects through TrainingID, based on ID of current
            // Training object
            SubscribedTrainees = selectedTraining.Trainees;
            // Generate list of person objects from subscribed trainees collection (are originally
            // Trainee objects)
            foreach (Trainee t in SubscribedTrainees)
            {
                Person p = unit.PersonRepo.Retrieve(p => p.PersonID == t.PersonID).FirstOrDefault();
                SubscribedTraineesCollection.Add(p);
            }
            // Retrieve list of all Person objects except subscribed trainees
            AvailableTrainees = unit.PersonRepo.Retrieve().Except(SubscribedTraineesCollection);
            AvailableRoles = unit.RoleRepo.Retrieve(ar => ar.AssignedObject == "Training").ToList();
        }

        // Constructor is called when no Training object is passed from TrainingView (= new training
        // is created)
        public DetailsTrainingViewModel()
        {
            Training = new Training();
            AvailableTrainees = unit.PersonRepo.Retrieve();
            SubscribedTrainees = new ObservableCollection<Trainee>();
            SubscribedTraineesCollection = new ObservableCollection<Person>();
            Training.Name = null;
            Training.Date = null;
            AvailableRoles = unit.RoleRepo.Retrieve(ar => ar.AssignedObject == "Training").ToList();
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                // Enables/Disable AddTraineeButton based on if Person object in AvailableTrainee
                // datagrid is selected
                case "AddTrainee":
                    if (SelectedAvailableTrainee == null && SelectedRole == null)
                        return false;
                    else
                        return true;

                case "RemoveTrainee":
                    if (SelectedSubscribedTrainee == null)
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
                Trainees = SubscribedTrainees
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

                case "AddTrainee":
                    Trainee trainee = new Trainee();

                    trainee.PersonID = SelectedAvailableTrainee.PersonID;
                    trainee.RoleID = SelectedRole.RoleID;
                    trainee.TrainingID = Training.TrainingID;
                    SubscribedTrainees.Add(trainee);

                    unit.TraineeRepo.Create(trainee);
                    unit.Save();

                    SubscribedTraineesCollection.Add(unit.PersonRepo.Retrieve(p => p.PersonID == trainee.PersonID).FirstOrDefault());
                    AvailableTrainees = AvailableTrainees.Except(SubscribedTraineesCollection);
                    break;

                case "RemoveTrainee":
                    Trainee deletedTrainee = SelectedSubscribedTrainee;
                    SubscribedTrainees.Remove(deletedTrainee);
                    unit.TraineeRepo.Delete(deletedTrainee);
                    unit.Save();

                    SubscribedTraineesCollection.Remove(unit.PersonRepo.Retrieve(p => p.PersonID == deletedTrainee.PersonID).FirstOrDefault());
                    AvailableTrainees = AvailableTrainees.Except(SubscribedTraineesCollection);
                    break;

                default:
                    break;
            }
        }
    }
}