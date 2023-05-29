using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_WPF.Views;
using System.Reflection.Metadata;
using System.Collections.ObjectModel;

namespace JTO_WPF.ViewModels
{
    internal class AddParticipantsViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public GroupTour GroupTour { get; set; }
        public IEnumerable<Person> AllPersons { get; set; }
        public IEnumerable<Person> AvailablePersons { get; set; }
        public ObservableCollection<Person> Participants { get; set; }
        public Person SelectedPerson { get; set; }
        public Participant SelectedParticipant { get; set; }

        public AddParticipantsViewModel(GroupTour groupTour, DashboardViewModel dVM)
        {
            DVM = dVM;
            GroupTour = groupTour;
            AllPersons = unit.PersonRepo.Retrieve();
            Participants = new ObservableCollection<Person>();

            foreach (var participant in GroupTour.Participants)
            {
                var person = unit.PersonRepo.Retrieve(x => x.PersonID == participant.PersonID).FirstOrDefault();
                Participants.Add(person);
            }

            AvailablePersons = AllPersons.Except(Participants);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddParticipant":
                    if(SelectedPerson != null)
                    {
                        if(GroupTour.Participants.Count >= GroupTour.MaxParticipants)
                        {
                            return false;
                        } else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                case "RemoveParticipant":
                    if (SelectedParticipant != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default: return true;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Cancel":
                    GroupTourDetailViewModel gtdvm = new GroupTourDetailViewModel(GroupTour, DVM);
                    GroupTourDetailView gtdv = new GroupTourDetailView();
                    gtdv.DataContext = gtdvm;
                    DVM.Content = gtdv;
                    break;
                case "AddParticipant":
                    Participant p = new Participant(GroupTour.GroupTourID, SelectedPerson.PersonID, 3);
                    unit.ParticipantRepo.Create(p);
                    unit.Save();

                    GroupTour = unit.GroupTourRepo.Retrieve(x => x.GroupTourID == GroupTour.GroupTourID, x => x.Participants).FirstOrDefault();

                    Participants = new ObservableCollection<Person>();

                    foreach (var participant in GroupTour.Participants)
                    {
                        var person = unit.PersonRepo.Retrieve(x => x.PersonID == participant.PersonID).FirstOrDefault();
                        Participants.Add(person);
                    }

                    AvailablePersons = AllPersons.Except(Participants);
                    break;
                case "RemoveParticipant":
                    var toBeDeleted = unit.ParticipantRepo.Retrieve(x => x.GroupTourID == GroupTour.GroupTourID && x.PersonID == SelectedParticipant.PersonID).FirstOrDefault();
                    unit.ParticipantRepo.Delete(toBeDeleted);
                    unit.Save();

                    GroupTour = unit.GroupTourRepo.Retrieve(x => x.GroupTourID == GroupTour.GroupTourID, x => x.Participants).FirstOrDefault();

                    Participants = new ObservableCollection<Person>();

                    foreach (var participant in GroupTour.Participants)
                    {
                        var person = unit.PersonRepo.Retrieve(x => x.PersonID == participant.PersonID).FirstOrDefault();
                        Participants.Add(person);
                    }

                    AvailablePersons = AllPersons.Except(Participants);
                    break;
            }
        }
    }
}
