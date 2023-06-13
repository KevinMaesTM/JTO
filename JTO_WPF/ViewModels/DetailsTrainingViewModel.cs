using DAL.Data;
using DAL.Data.UnitOfWork;
using JTO_Models;
using JTO_MODELS;
using JTO_WPF.Converters;
using JTO_WPF.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTO_WPF.ViewModels
{
    internal class DetailsTrainingViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public IEnumerable<Role> AvailableRoles { get; set; }
        public IEnumerable<Person> AvailableTrainees { get; set; }
        public DashboardViewModel DVM { get; set; }
        public Person SelectedAvailableTrainee { get; set; }
        public Role SelectedRole { get; set; }
        public Trainee SelectedSubscribedTrainee { get; set; }
        public ObservableCollection<Trainee> SubscribedTrainees { get; set; }
        public ObservableCollection<Person> SubscribedTraineesCollection { get; set; } = new ObservableCollection<Person> { };
        public Training Training { get; set; }

        // Constructor is called when a Training object is passed from TrainingView
        public DetailsTrainingViewModel(Training selectedTraining, DashboardViewModel dvm)
        {
            DVM = dvm;
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
        public DetailsTrainingViewModel(DashboardViewModel dvm)
        {
            Training = new Training();
            DVM = dvm;
            AvailableTrainees = unit.PersonRepo.Retrieve();
            SubscribedTrainees = new ObservableCollection<Trainee>();
            SubscribedTraineesCollection = new ObservableCollection<Person>();
            Training.Name = null;
            Training.Date = null;
            AvailableRoles = unit.RoleRepo.Retrieve(ar => ar.AssignedObject == "Training").ToList();
        }

        public void AddTrainee()
        {
            Trainee trainee = new Trainee();

            trainee.PersonID = SelectedAvailableTrainee.PersonID;
            trainee.RoleID = SelectedRole.RoleID;
            trainee.TrainingID = Training.TrainingID;
            if (SubscribedTrainees.Where(x => x.RoleID == 2).Count() >= 1 && trainee.RoleID == 2)
            {
                MessageBox.Show("Er mag maximum 1 trainer per opleiding toegewezen worden", "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SubscribedTrainees.Add(trainee);
            unit.TraineeRepo.Create(trainee);
            unit.Save();

            SubscribedTraineesCollection.Add(unit.PersonRepo.Retrieve(p => p.PersonID == trainee.PersonID).FirstOrDefault());
            AvailableTrainees = AvailableTrainees.Except(SubscribedTraineesCollection);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                // Enables/Disable AddTraineeButton based on if Person object in AvailableTrainee
                // datagrid is selected
                case "AddTrainee":
                    if (SelectedAvailableTrainee == null || SelectedRole == null)
                        return false;
                    else
                        return true;

                case "RemoveTrainee":
                    return (SelectedSubscribedTrainee != null);

                default:
                    return true;
            }
        }

        // Validation for input fields: Checks if all criteria are fullfilled
        public string Errors()
        {
            string error = "";
            if (string.IsNullOrEmpty(Training.Name))
                error += "Training naam is verplicht!" + Environment.NewLine;
            if (DateTime.TryParse(Training.Date.ToString(), out DateTime dateTraining) == false)
                error += "Datum heeft een ongeldig formaat: dd/MM/yyy" + Environment.NewLine;
            return error;
        }

        public override void Execute(object parameter)
        {
            string errors = "";

            switch (parameter.ToString())
            {
                case "SaveTraining":
                    errors = Errors();
                    // Checks the amount of trainees marked as trainer. Throw an error if the list
                    // contains less than 1 trainer
                    if (SubscribedTrainees.Count() >= 1 && SubscribedTrainees.Where(x => x.RoleID == 2).Count() <= 0)
                    {
                        MessageBox.Show("Er moet teminste 1 persoon als trainer aangeduid worden", "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                    if (string.IsNullOrEmpty(errors))
                        UpdateTraining();
                    else
                        MessageBox.Show(errors, "Errors!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case "AddTrainee": AddTrainee(); break;
                case "RemoveTrainee": RemoveTrainee(); break;
                case "Cancel": ShowTrainings(); break;
                default:
                    break;
            }
        }

        public void RemoveTrainee()
        {
            Trainee deletedTrainee = SelectedSubscribedTrainee;
            SubscribedTrainees.Remove(deletedTrainee);
            unit.TraineeRepo.Delete(deletedTrainee);
            unit.Save();

            SubscribedTraineesCollection.Remove(unit.PersonRepo.Retrieve(p => p.PersonID == deletedTrainee.PersonID).FirstOrDefault());
            AvailableTrainees = AvailableTrainees.Except(SubscribedTraineesCollection);
        }

        public void ShowTrainings()
        {
            var tVM = new TrainingViewModel(DVM);
            var tV = new TrainingView();
            tV.DataContext = tVM;
            DVM.Content = tV;
        }

        public void UpdateTraining()
        {
            unit.TrainingRepo.Update(Training);
            unit.Save();
            DVM.SnackbarContent = $"Training '{Training.Name} ({Training.Date})' aangepast.";

            ShowTrainings();
        }
    }
}