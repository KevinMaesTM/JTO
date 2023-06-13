﻿using DAL.Data;
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

namespace JTO_WPF.ViewModels
{
    internal class DetailsTrainingViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        private Snackbar _snackbar = new Snackbar();
        public IEnumerable<Role> AvailableRoles { get; set; }
        public IEnumerable<Person> AvailableTrainees { get; set; }
        public DashboardViewModel DVM { get; set; }
        public string ResultOutput { get; set; }
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
            AvailableTrainees = unit.PersonRepo.RetrieveTracked().Except(SubscribedTraineesCollection);
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
            if (Training.Name == null)
                error += "Training naam is verplicht!" + Environment.NewLine;
            if (DateTime.TryParse(Training.Date.ToString(), out DateTime dateTraining) == false)
                error += "Datum heeft een ongeldig formaat: dd/MM/yyy" + Environment.NewLine;
            return error;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "SaveTraining":
                    // Checks the amount of trainees marked as trainer. Throw an error if the list
                    // contains less than 1 trainer
                    if (SubscribedTrainees.Count() >= 1 && SubscribedTrainees.Where(x => x.RoleID == 2).Count() <= 0)
                    {
                        ResultOutput = "Er moet teminste 1 persoon als trainer aangeduid worden";
                        break;
                    }
                    unit.TrainingRepo.Update(Training);
                    unit.Save();

                    var tVM = new TrainingViewModel(DVM);
                    var tV = new TrainingView();
                    tV.DataContext = tVM;
                    DVM.Content = tV;
                    break;

                case "AddTrainee":
                    Trainee trainee = new Trainee();

                    trainee.PersonID = SelectedAvailableTrainee.PersonID;
                    trainee.RoleID = SelectedRole.RoleID;
                    if (Training.TrainingID != 0)
                        trainee.TrainingID = Training.TrainingID;
                    else
                    {
                        if (string.IsNullOrEmpty(Errors()))
                        {
                            unit.TrainingRepo.Create(Training);
                            unit.Save();
                        }
                        else
                        {
                            ResultOutput = Errors();
                            break;
                        }
                    }

                    if (SubscribedTrainees.Where(x => x.RoleID == 2).Count() >= 1 && trainee.RoleID == 2)
                    {
                        ResultOutput = "Er mag maximum 1 trainer per opleiding toegewezen worden";
                        _snackbar.MessageQueue.Enqueue(ResultOutput);
                        break;
                    }
                    SubscribedTrainees.Add(trainee);
                    unit.TraineeRepo.Create(trainee);
                    unit.Save();

                    SubscribedTraineesCollection.Add(unit.PersonRepo.Retrieve(p => p.PersonID == trainee.PersonID).FirstOrDefault());
                    AvailableTrainees = AvailableTrainees.Except(SubscribedTraineesCollection);
                    ResultOutput = "Cursist/Trainer is toegevoegd.";
                    break;

                case "RemoveTrainee":
                    Trainee deletedTrainee = SelectedSubscribedTrainee;
                    SubscribedTrainees.Remove(deletedTrainee);
                    unit.TraineeRepo.Delete(deletedTrainee);
                    unit.Save();

                    SubscribedTraineesCollection.Remove(unit.PersonRepo.Retrieve(p => p.PersonID == deletedTrainee.PersonID).FirstOrDefault());
                    AvailableTrainees = AvailableTrainees.Except(SubscribedTraineesCollection);
                    ResultOutput = $"Cursist is verwijderd.";

                    break;

                default:
                    break;
            }
        }
    }
}