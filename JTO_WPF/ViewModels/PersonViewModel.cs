using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTO_WPF.Views;
using System.Windows;

namespace JTO_WPF.ViewModels
{
    internal class PersonViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public DashboardViewModel DVM { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public Person SelectedPerson { get; set; }

        public PersonViewModel(DashboardViewModel dvm)
        {
            DVM = dvm;
            Persons = unit.PersonRepo.Retrieve();
        }

        public void AddPerson()
        {
            PersonDetailViewModel pdvm2 = new PersonDetailViewModel(DVM);
            PersonDetailView pdv2 = new PersonDetailView();
            pdv2.DataContext = pdvm2;
            DVM.Content = pdv2;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail":
                    return (SelectedPerson != null);

                case "Delete":
                    return (SelectedPerson != null);

                default:
                    return true;
            }
        }

        public void DeletePerson()
        {
            try
            {
                unit.PersonRepo.Delete(SelectedPerson);
                unit.Save();
                Persons = unit.PersonRepo.Retrieve();
            }
            catch (Exception ex)
            {
                unit.Reload(SelectedPerson);
                MessageBox.Show("Er ging iets fout. Mogelijk wordt de geselecteerde persoon nog gebruikt.");
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ShowDetail": ShowPersonDetails(); break;
                case "Add": AddPerson(); break;
                case "Delete": DeletePerson(); break;
                default: break;
            }
        }

        public void ShowPersonDetails()
        {
            PersonDetailViewModel pdvm = new PersonDetailViewModel(DVM, SelectedPerson);
            PersonDetailView pdv = new PersonDetailView();
            pdv.DataContext = pdvm;
            DVM.Content = pdv;
        }
    }
}